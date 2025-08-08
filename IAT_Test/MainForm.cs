namespace IAT_Test
{
    public partial class MainForm : Form
    {
        private List<string>? allVideos;
        private List<string> randomizedVideos = null!;
        private ParticipantData participant = null!;
        private int currentVideoIndex = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            InitializeAppSettings();

            using (var auth = new AuthorizationForm())
            {
                if (auth.ShowDialog() == DialogResult.OK)
                {
                    var db = new DatabaseForm();
                    if (db.ShowDialog() == DialogResult.OK)
                    {
                        this.Close();
                    }
                }
                else if (auth.ShowDialog() == DialogResult.Yes)
                {
                    this.Show();
                }
            }

        }

        private void InitializeAppSettings()
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default["VideoFolderPath"].ToString()))
            {
                // Путь к папке с видео по умолчанию
                Properties.Settings.Default["VideoFolderPath"] = ".\\videos";
            }
            Properties.Settings.Default.Save();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SettingsForm settingsForm = new SettingsForm();
                if (settingsForm.ShowDialog() == DialogResult.OK)
                {
                    // Сохранение настроек после изменения
                    Properties.Settings.Default["VideoFolderPath"] = settingsForm.VideoFolderPath;
                    Properties.Settings.Default.Save();

                    MessageBox.Show("Настройки успешно применены.",
                        "Успех",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка!",
                    ex.Message,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default["VideoFolderPath"].ToString()))
            {
                MessageBox.Show("Сначала настройте путь к видео в Настройках!",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            allVideos =
                LoadVideos(Properties.Settings.Default["VideoFolderPath"]
                .ToString()!);

            if (allVideos == null || allVideos.Count() == 0)
            {
                MessageBox.Show("Недостаточно видео в папке.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                MessageBox.Show($"Загружено видео: {(allVideos == null ? null : allVideos.Count())}", "Отладка");
                return;
            }

            randomizedVideos =
                ShuffleList(allVideos)
                .Take(allVideos.Count())
                .ToList();

            if (randomizedVideos == null || randomizedVideos.Count == 0)
            {
                MessageBox.Show("Папка с видео пустая.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (!Directory.Exists("./exmp") || Directory.GetFiles("./exmp", "*.txt").Length == 0)
            {
                MessageBox.Show("Папка instruction пуста или отсутствует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // Этап 1: Информированное согласие
            var consentForm = new ConsentForm();
            if (consentForm.ShowDialog() != DialogResult.OK)
                return;

            // Этап 2: Анкета участника
            var infoForm = new ParticipantInfoForm();
            if (infoForm.ShowDialog() != DialogResult.OK)
            {
                DatabaseHelper.ResetParticipantState();
                return;
            }

            participant = infoForm.ParticipantData;

            // Этап 3: Категории и слова
            var instructionForm = new InstructionForm();
            instructionForm.ShowDialog();

            // Этап 4: Старт видео + оценка
            PlayNextVideo();
        }

        private void PlayNextVideo()
        {
            if (currentVideoIndex >= randomizedVideos?.Count)
            {
                MessageBox.Show("Исследование завершено. Спасибо!", "Благодарность", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
                return;
            }

            string? videoPath = randomizedVideos?[currentVideoIndex];
            string? videoName = Path.GetFileNameWithoutExtension(videoPath);

            var videoForm = new VideoForm(videoPath ?? string.Empty);
            videoForm.VideoWatched += (s, e) =>
            {
                var viewTime = e.ViewTime;

                using (var testForm = new TestForm())
                {
                    if (testForm.ShowDialog() == DialogResult.OK)
                    {
                        var scaleData = testForm.TestResult;
                        try
                        {
                            DatabaseHelper.SaveResults(
                                participant?.Age,
                                participant?.Gender ?? string.Empty,
                                participant?.Occupation ?? string.Empty,
                                videoName ?? string.Empty,
                                participant?.Faculty ?? string.Empty,
                                participant?.StudyForm ?? string.Empty,
                                participant?.Course,
                                viewTime,
                                scaleData?.ToArray() ?? Array.Empty<string>());
                        }
                        catch (IOException)
                        {
                            MessageBox.Show("Ошибка записи результатов теста.",
                                "Предупреждение",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                        }

                        currentVideoIndex++;
                        PlayNextVideo();
                    }
                }
            };

            videoForm.ShowDialog();
        }

        private List<string>? LoadVideos(string folder)
        {
            if (!Directory.Exists(folder))
                return null;

            var extensions = new[] { ".mp4", ".avi", ".mov", ".wmv" };

            return Directory.EnumerateFiles(
                    folder,
                    "*.*",
                    SearchOption.TopDirectoryOnly)
                .Where(f => extensions.Contains(Path.GetExtension(f).ToLower()))
                .OrderBy(f => f)
                .ToList();
        }

        private List<string> ShuffleList(List<string> list)
        {
            Random rng = new Random();
            return list.OrderBy(_ => rng.Next()).ToList();
        }

    }


}
