using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IAT_Test
{
    public partial class InstructionForm : Form
    {
        public InstructionForm()
        {
            InitializeComponent();
            LoadInstructionText();
        }

        private void LoadInstructionText()
        {
            string consentPath = Path.Combine(Application.StartupPath, "./files/instruction.txt");
            if (File.Exists(consentPath))
            {
                richTextBoxInstruction.Font = new Font(richTextBoxInstruction.Font.FontFamily, 15.0f);
                richTextBoxInstruction.Text += "\n" + File.ReadAllText(consentPath);
            }
            else
            {
                richTextBoxInstruction.Text = "Не удалось загрузить текст инструкции.";
            }
        }

        private void richTextBoxInstruction_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void richTextBoxInstruction_SelectionChanged(object sender, EventArgs e)
        {
            this.richTextBoxInstruction.SelectionLength = 0;
        }

    }
}
