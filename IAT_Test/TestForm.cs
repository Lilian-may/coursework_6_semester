/*using AxWMPLib;
using OfficeOpenXml;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace IAT_Test
{
    public partial class TestForm : Form
    {
        private readonly string videoFolderPath = "video";
        private readonly string instructionFolderPath = "instruction";
        private readonly string resultsFilePath = "Results.xlsx";
        private readonly ParticipantData userProfile;
        private string[] scale = new string[7] { "1", "2", "3", "4", "5", "6", "7" };
        private bool isTestPending = false; // Блокирует запуск нового видео, пока не завершен тест
        private bool isTestContinue = false;
        private int cntSpace = 0;

        public ParticipantData ParticipantData { get; private set; }

        public TestForm(ParticipantData profile)
        {
            InitializeComponent();
            userProfile = profile;
            ParticipantData = profile;
            cmbInitialize();
            this.KeyPreview = true;
            this.KeyDown += VideoTestForm_KeyDown;
            this.WindowState = FormWindowState.Maximized; // Разворачивает на весь экран
            //this.FormBorderStyle = FormBorderStyle.None;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox6.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox7.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox8.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox9.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox10.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void cmbInitialize()
        {
            comboBox1.Items.AddRange(scale);
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.AddRange(scale);
            comboBox2.SelectedIndex = 0;

            comboBox6.Items.AddRange(scale);
            comboBox6.SelectedIndex = 0;

            comboBox7.Items.AddRange(scale);
            comboBox7.SelectedIndex = 0;

            comboBox8.Items.AddRange(scale);
            comboBox8.SelectedIndex = 0;

            comboBox9.Items.AddRange(scale);
            comboBox9.SelectedIndex = 0;

            comboBox10.Items.AddRange(scale);
            comboBox10.SelectedIndex = 0;
        }

        private string[] Answers()
        {
            string[] scales = new string[9];
            scales[0] = (comboBox1.SelectedIndex + 1).ToString();
            scales[1] = (comboBox2.SelectedIndex + 1).ToString();
            scales[2] = trackBar1.Value.ToString();
            scales[3] = trackBar2.Value.ToString();
            scales[4] = (comboBox6.SelectedIndex + 1).ToString();
            scales[5] = (comboBox7.SelectedIndex + 1).ToString();
            scales[6] = (comboBox8.SelectedIndex + 1).ToString();
            scales[7] = (comboBox9.SelectedIndex + 1).ToString();
            scales[8] = (comboBox10.SelectedIndex + 1).ToString();
            cmbInitialize();
            return scales;
        }

        public static void SaveResults(bool isTestContinue, string filePath, string gender, int age, string work, string faculty, string studyForm, int course, string video, TimeSpan time, string[] scales)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            int row = 1;
            try
            {
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    //var worksheet = package.Workbook.Worksheets[0];
                    var workbook = package.Workbook;
                    var worksheet = workbook.Worksheets.FirstOrDefault() ?? workbook.Worksheets.Add("Results");

                    if (!isTestContinue)
                    {
                        // Найти последнюю строку для добавления новых данных
                        row = worksheet.Dimension.End.Row + 1;
                    }

                    worksheet.Cells[1, 1].Value = "Номер испытуемого";
                    worksheet.Cells[1, 2].Value = "Пол";
                    worksheet.Cells[1, 3].Value = "Возраст";
                    worksheet.Cells[1, 4].Value = "Род занятий";
                    worksheet.Cells[1, 5].Value = "Факультет";
                    worksheet.Cells[1, 6].Value = "Форма обучения";
                    worksheet.Cells[1, 7].Value = "Курс";
                    worksheet.Cells[1, 8].Value = "Название видео";
                    worksheet.Cells[1, 9].Value = "Время остановки";
                    worksheet.Cells[1, 10].Value = "Комфорт";
                    worksheet.Cells[1, 11].Value = "Сила переживания";
                    worksheet.Cells[1, 12].Value = "Равнодушие";
                    worksheet.Cells[1, 13].Value = "Антипатия";
                    worksheet.Cells[1, 14].Value = "Тревога";
                    worksheet.Cells[1, 15].Value = "Раздражение";
                    worksheet.Cells[1, 16].Value = "Печаль";
                    worksheet.Cells[1, 17].Value = "Удовольствие";
                    worksheet.Cells[1, 18].Value = "Отторжение";

                    worksheet.Cells[row, 1].Value = row - 1;
                    worksheet.Cells[row, 2].Value = gender;
                    worksheet.Cells[row, 3].Value = age;
                    worksheet.Cells[row, 4].Value = work;
                    worksheet.Cells[row, 5].Value = faculty;
                    worksheet.Cells[row, 6].Value = studyForm;
                    worksheet.Cells[row, 7].Value = course;
                    worksheet.Cells[row, 8].Value += video;
                    worksheet.Cells[row, 9].Value += time.ToString();
                    worksheet.Cells[row, 10].Value += scales[0];
                    worksheet.Cells[row, 11].Value += scales[1];
                    worksheet.Cells[row, 12].Value += scales[2];
                    worksheet.Cells[row, 13].Value += scales[3];
                    worksheet.Cells[row, 14].Value += scales[4];
                    worksheet.Cells[row, 15].Value += scales[5];
                    worksheet.Cells[row, 16].Value += scales[6];
                    worksheet.Cells[row, 17].Value += scales[7];
                    worksheet.Cells[row, 18].Value += scales[8];

                    package.Save();
                    isTestContinue = true;
                }
            }
            catch (IOException)
            {
                string backupPath = "Results.xlsx".Replace(".xlsx", "_backup.xlsx");
                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    //var worksheet = package.Workbook.Worksheets[0];
                    var workbook = package.Workbook;
                    var worksheet = workbook.Worksheets.FirstOrDefault() ?? workbook.Worksheets.Add("Results");

                    if (!isTestContinue)
                    {
                        // Найти последнюю строку для добавления новых данных
                        row = worksheet.Dimension.End.Row + 1;
                    }

                    worksheet.Cells[1, 1].Value = "Номер испытуемого";
                    worksheet.Cells[1, 2].Value = "Пол";
                    worksheet.Cells[1, 3].Value = "Возраст";
                    worksheet.Cells[1, 4].Value = "Род занятий";
                    worksheet.Cells[1, 5].Value = "Факультет";
                    worksheet.Cells[1, 6].Value = "Форма обучения";
                    worksheet.Cells[1, 7].Value = "Курс";
                    worksheet.Cells[1, 8].Value = "Название видео";
                    worksheet.Cells[1, 9].Value = "Время остановки";
                    worksheet.Cells[1, 10].Value = "Комфорт";
                    worksheet.Cells[1, 11].Value = "Сила переживания";
                    worksheet.Cells[1, 12].Value = "Равнодушие";
                    worksheet.Cells[1, 13].Value = "Антипатия";
                    worksheet.Cells[1, 14].Value = "Тревога";
                    worksheet.Cells[1, 15].Value = "Раздражение";
                    worksheet.Cells[1, 16].Value = "Печаль";
                    worksheet.Cells[1, 17].Value = "Удовольствие";
                    worksheet.Cells[1, 18].Value = "Отторжение";

                    worksheet.Cells[row, 1].Value = row - 1;
                    worksheet.Cells[row, 2].Value = gender;
                    worksheet.Cells[row, 3].Value = age;
                    worksheet.Cells[row, 4].Value = work;
                    worksheet.Cells[row, 5].Value = faculty;
                    worksheet.Cells[row, 6].Value = studyForm;
                    worksheet.Cells[row, 7].Value = course;
                    worksheet.Cells[row, 8].Value = video;
                    worksheet.Cells[row, 9].Value = time.ToString();
                    worksheet.Cells[row, 10].Value = scales[0];
                    worksheet.Cells[row, 11].Value = scales[1];
                    worksheet.Cells[row, 12].Value = scales[2];
                    worksheet.Cells[row, 13].Value = scales[3];
                    worksheet.Cells[row, 14].Value = scales[4];
                    worksheet.Cells[row, 15].Value = scales[5];
                    worksheet.Cells[row, 16].Value = scales[6];
                    worksheet.Cells[row, 17].Value = scales[7];
                    worksheet.Cells[row, 18].Value = scales[8];

                    package.Save();
                    isTestContinue = true;
                }
                MessageBox.Show("Файл результатов был занят. Результаты сохранены в резервный файл.");
            }
        }

        private void PlayNextVideo()
        {
            this.DialogResult = DialogResult.None;
            this.Hide();
        }

        private void VideoTestForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                e.Handled = true;

                ParticipantData.StopTime = GlobalVariables.StopTime;
                SaveResults(
                    isTestContinue,
                    resultsFilePath,
                    ParticipantData.Gender,
                    ParticipantData.Age,
                    ParticipantData.Occupation,
                    ParticipantData.Faculty,
                    ParticipantData.StudyForm,
                    ParticipantData.Course,
                    ParticipantData.VideoName,
                    ParticipantData.StopTime,
                    Answers());
                PlayNextVideo();
            }
        }

        private void TestForm_Load(object sender, EventArgs e)
        {

        }
    }*//*

    public partial class ParticipantData
    {
        public string VideoName { get; set; }
        public DateTime VideoStartTime { get; set; }
        public TimeSpan StopTime { get; set; }
        //public string[] Ratings { get; set; }
    }
}*/

using System;
using System.Windows.Forms;

namespace IAT_Test
{
    public partial class TestForm : Form
    {
        public event EventHandler<TestResult> TestCompleted;
        private bool spacePressed = false;
        public TestResult TestResult { get; private set; }
        private string[] scale = new string[7] { "1", "2", "3", "4", "5", "6", "7" };

        public TestForm()
        {
            InitializeComponent();
            cmbInitialize();
            this.KeyPreview = true;
            this.KeyDown += TestForm_KeyDown;
            this.WindowState = FormWindowState.Maximized;
            this.ActiveControl = null;
        }

        private void cmbInitialize()
        {
            comboBox1.Items.AddRange(scale);
            comboBox1.SelectedIndex = 0;

            comboBox2.Items.AddRange(scale);
            comboBox2.SelectedIndex = 0;

            comboBox6.Items.AddRange(scale);
            comboBox6.SelectedIndex = 0;

            comboBox7.Items.AddRange(scale);
            comboBox7.SelectedIndex = 0;

            comboBox8.Items.AddRange(scale);
            comboBox8.SelectedIndex = 0;

            comboBox9.Items.AddRange(scale);
            comboBox9.SelectedIndex = 0;

            comboBox10.Items.AddRange(scale);
            comboBox10.SelectedIndex = 0;
        }

        private void TestForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && !spacePressed)
            {
                spacePressed = true;
                e.Handled = true;

                TestResult = new TestResult
                {
                    Comfort = (comboBox1.SelectedIndex + 1).ToString(),
                    EmotionIntensity = (comboBox2.SelectedIndex + 1).ToString(),
                    Sympathy = trackBar1.Value.ToString(),
                    Empathy = trackBar2.Value.ToString(),
                    Anxiety = (comboBox6.SelectedIndex + 1).ToString(),
                    Irritation = (comboBox7.SelectedIndex + 1).ToString(),
                    Sadness = (comboBox8.SelectedIndex + 1).ToString(),
                    Pleasure = (comboBox9.SelectedIndex + 1).ToString(),
                    Rejection = (comboBox10.SelectedIndex + 1).ToString(),
                };

                TestCompleted?.Invoke(this, TestResult);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }

    public class TestResult
    {
        public string Comfort { get; set; }
        public string EmotionIntensity { get; set; }
        public string Sympathy { get; set; }
        public string Empathy { get; set; }
        public string Anxiety { get; set; }
        public string Irritation { get; set; }
        public string Sadness { get; set; }
        public string Pleasure { get; set; }
        public string Rejection { get; set; }

        public string[] ToArray()
        {
            return new string[]
            {
                Comfort,
                EmotionIntensity,
                Sympathy,
                Empathy,
                Anxiety,
                Irritation,
                Sadness,
                Pleasure,
                Rejection
            };
        }
    }
}