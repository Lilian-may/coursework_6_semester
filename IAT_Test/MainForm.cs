using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace IAT_Test
{
    public partial class MainForm : Form
    {
        //private SettingsForm settingsForm;
        private List<string> allVideos;
        private List<string> randomizedVideos;
        private ParticipantData participant;
        private string excelFilePath;
        private int currentVideoIndex = 0;
        //private int videoCount;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            InitializeAppSettings();
        }

        private void InitializeAppSettings()
        {
            if (string.IsNullOrEmpty(Properties.Settings.Default["VideoFolderPath"].ToString()))
            {
                // Путь к папке с видео по умолчанию
                Properties.Settings.Default["VideoFolderPath"] = ".\\videos";
            }
            if (string.IsNullOrEmpty(Properties.Settings.Default["ExcelFilePath"].ToString()))
            {
                // Путь к Excel файлу по умолчанию
                Properties.Settings.Default["ExcelFilePath"] = ".\\files\\Results.xlsx";
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
                    Properties.Settings.Default["ExcelFilePath"] = settingsForm.ExcelFilePath;
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
            if (string.IsNullOrEmpty(Properties.Settings.Default["VideoFolderPath"].ToString()) ||
                string.IsNullOrEmpty(Properties.Settings.Default["ExcelFilePath"].ToString()))
            {
                MessageBox.Show("Сначала настройте путь к видео и файлу Excel в Настройках!",
                    "Ошибка", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Warning);
                return;
            }

            allVideos =
                LoadVideos(Properties.Settings.Default["VideoFolderPath"]
                .ToString());

            if (allVideos == null || allVideos.Count() == 0)
            {
                MessageBox.Show("Недостаточно видео в папке.", 
                    "Ошибка", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                MessageBox.Show($"Загружено видео: {allVideos.Count()}", "Отладка");
                //MessageBox.Show("Папка с видео пустая.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            randomizedVideos =
                ShuffleList(allVideos)
                .Take(allVideos.Count())
                .ToList();

            excelFilePath = Properties.Settings.Default["ExcelFilePath"].ToString();


            if (randomizedVideos == null || randomizedVideos.Count == 0)
            {
                MessageBox.Show("Папка с видео пустая.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (!Directory.Exists("instruction") || Directory.GetFiles("instruction", "*.txt").Length == 0)
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
                ExcelHelper.ResetParticipantState();
                return;
            }

            participant = infoForm.ParticipantData;

            // Этап 3: Категории и слова
            var instructionForm = new InstructionForm();
            instructionForm.ShowDialog();

            // Этап 4: Старт видео + оценка
            PlayNextVideo();
        }

        //private void PlayNextVideo()
        //{
        //    if (currentVideoIndex >= randomizedVideos.Count)
        //    {
        //        MessageBox.Show("Исследование завершено. Спасибо!", "Благодарность", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        Application.Exit();
        //        return;
        //    }

        //    string videoPath = randomizedVideos[currentVideoIndex];
        //    string videoName = Path.GetFileNameWithoutExtension(videoPath);

        //    var videoForm = new VideoForm(videoPath);
        //    videoForm.VideoWatched += (s, e) =>
        //    {

        //        var testForm = new TestForm();
        //        if (testForm.ShowDialog() == DialogResult.OK)
        //        {
        //            var scaleData = testForm.TestResult;
        //            try
        //            {
        //                ExcelHelper.SaveResults(
        //                    excelFilePath, 
        //                    participant.Gender, 
        //                    participant.Age, 
        //                    participant.Occupation, 
        //                    participant.Faculty, 
        //                    participant.StudyForm, 
        //                    participant.Course, 
        //                    videoName, 
        //                    e.ViewTime, 
        //                    scaleData.ToArray());
        //            }
        //            catch (IOException)
        //            {
        //                string backupPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Results_backup_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
        //                ExcelHelper.SaveResults(
        //                    backupPath,
        //                    participant.Gender, 
        //                    participant.Age, 
        //                    participant.Occupation, 
        //                    participant.Faculty, 
        //                    participant.StudyForm, 
        //                    participant.Course, 
        //                    videoName, 
        //                    e.ViewTime, 
        //                    scaleData.ToArray());

        //                MessageBox.Show("Файл Excel был открыт.Данные сохранены в резервный файл.",
        //                    "Предупреждение",
        //                    MessageBoxButtons.OK, 
        //                    MessageBoxIcon.Warning);
        //            }

        //            currentVideoIndex++;
        //            PlayNextVideo();
        //        }
        //    };

        //    //videoForm.ShowDialog(); // запуск видео
        //    if (videoForm.ShowDialog() == DialogResult.OK)
        //    {
        //        //return;
        //        videoForm.Close();
        //        videoForm.Hide();
        //        return;
        //    }
        //}

        private void PlayNextVideo()
        {
            if (currentVideoIndex >= randomizedVideos.Count)
            {
                MessageBox.Show("Исследование завершено. Спасибо!", "Благодарность", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
                return;
            }

            string videoPath = randomizedVideos[currentVideoIndex];
            string videoName = Path.GetFileNameWithoutExtension(videoPath);

            var videoForm = new VideoForm(videoPath);
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
                            ExcelHelper.SaveResults(
                                excelFilePath,
                                participant.Gender,
                                participant.Age,
                                participant.Occupation,
                                participant.Faculty,
                                participant.StudyForm,
                                participant.Course,
                                videoName,
                                viewTime,
                                scaleData.ToArray());
                        }
                        catch (IOException)
                        {
                            string backupPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Results_backup_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
                            ExcelHelper.SaveResults(
                                backupPath,
                                participant.Gender,
                                participant.Age,
                                participant.Occupation,
                                participant.Faculty,
                                participant.StudyForm,
                                participant.Course,
                                videoName,
                                viewTime,
                                scaleData.ToArray());

                            MessageBox.Show("Файл Excel был открыт. Данные сохранены в резервный файл.",
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



        private List<string> LoadVideos(string folder)
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
