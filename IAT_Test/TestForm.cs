using System;
using System.Windows.Forms;

namespace IAT_Test
{
    public partial class TestForm : Form
    {
        public event EventHandler<TestResult> TestCompleted = null!;
        private bool spacePressed = false;
        public TestResult? TestResult { get; private set; } = null!;
        private string[] scale = { "1", "2", "3", "4", "5", "6", "7" };

        public TestForm()
        {
            InitializeComponent();
            cmbInitialize();
            this.KeyPreview = true;
            this.KeyDown += TestForm_KeyDown!;
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
        public string Comfort { get; set; } = null!;
        public string EmotionIntensity { get; set; } = null!;
        public string Sympathy { get; set; } = null!;
        public string Empathy { get; set; } = null!;
        public string Anxiety { get; set; } = null!;
        public string Irritation { get; set; } = null!;
        public string Sadness { get; set; } = null!;
        public string Pleasure { get; set; } = null!;
        public string Rejection { get; set; } = null!;

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