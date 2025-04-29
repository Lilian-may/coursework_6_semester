using IAT_Test.Properties;
using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace IAT_Test
{
    public partial class SettingsForm : Form
    {
        public string VideoFolderPath { get; private set; }
        public string ExcelFilePath { get; private set; }
        //public int VideoCount { get; private set; }

        public SettingsForm()
        {
            InitializeComponent();

            // Устанавливаем умолчательные значения
            string defaultVideoFolder = Path.Combine(Application.StartupPath, "video");
            string defaultExcelFile = Path.Combine(Application.StartupPath, "Results.xlsx");

            // Проверяем и создаем директорию video, если она не существует
            if (!Directory.Exists(defaultVideoFolder))
            {
                Directory.CreateDirectory(defaultVideoFolder);
            }

            // Проверяем и создаем файл Excel, если он не существует
            if (!File.Exists(defaultExcelFile))
            {
                CreateDefaultExcelFile(defaultExcelFile);
            }

            VideoFolderPath = defaultVideoFolder;
            ExcelFilePath = defaultExcelFile;

            txtVideoPath.Text = VideoFolderPath;
            txtExcelPath.Text = ExcelFilePath;
        }

        private void CreateDefaultExcelFile(string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Results");
                worksheet.Cells[1, 1].Value = "Имя";
                worksheet.Cells[1, 2].Value = "Возраст";
                worksheet.Cells[1, 3].Value = "Пол";
                worksheet.Cells[1, 4].Value = "Род занятий";
                worksheet.Cells[1, 5].Value = "Видео";
                worksheet.Cells[1, 6].Value = "Время просмотра (сек)";
                package.Save();
            }
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

        private void btnSelectExcelFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                Title = "Выберите файл Excel"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExcelFilePath = openFileDialog.FileName;
                txtExcelPath.Text = ExcelFilePath;
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
            Properties.Settings.Default["ExcelFilePath"] = ExcelFilePath;
            Properties.Settings.Default.Save();

            //this.VideoCount = Directory.GetFiles(VideoFolderPath, "*.mp4").OrderBy(f => f).ToList().Count();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}