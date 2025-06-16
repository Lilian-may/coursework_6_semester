namespace IAT_Test
{
    public partial class SettingsForm : Form
    {
        public string VideoFolderPath { get; private set; }

        public SettingsForm()
        {
            InitializeComponent();

            // Устанавливаем умолчательные значения
            string defaultVideoFolder = Path.Combine(Application.StartupPath, "video");

            // Проверяем и создаем директорию video, если она не существует
            if (!Directory.Exists(defaultVideoFolder))
            {
                Directory.CreateDirectory(defaultVideoFolder);
            }

            VideoFolderPath = defaultVideoFolder;

            txtVideoPath.Text = VideoFolderPath;
        }

        private void btnSelectVideoFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderDialog = new FolderBrowserDialog();
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                VideoFolderPath = folderDialog.SelectedPath;
                txtVideoPath.Text = VideoFolderPath;
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(VideoFolderPath) || !Directory.Exists(VideoFolderPath))
            {
                MessageBox.Show("Папка с видео не найдена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Properties.Settings.Default["VideoFolderPath"] = VideoFolderPath;
            Properties.Settings.Default.Save();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}