using System.IO;
using System;
using System.Windows.Forms;
using System.Drawing;

namespace IAT_Test
{
    public partial class ConsentForm : Form
    {
        public ConsentForm()
        {
            InitializeComponent();
            LoadConsentText();
        }

        private void LoadConsentText()
        {
            string consentPath = Path.Combine(Application.StartupPath, "./files/consent.txt");
            if (File.Exists(consentPath))
            {
                richTextBoxConsent.Font = new Font(richTextBoxConsent.Font.FontFamily, 15.0f);
                richTextBoxConsent.Text += "\n" + File.ReadAllText(consentPath);
            }
            else
            {
                richTextBoxConsent.Text = "Не удалось загрузить текст согласия.";
            }
        }

        private void richTextBoxConsent_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBoxConsent_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void richTextBoxConsent_SelectionChanged(object sender, EventArgs e)
        {
            this.richTextBoxConsent.SelectionLength = 0;
        }
    }
}