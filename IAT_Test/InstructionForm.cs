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
            string consentPath = Path.Combine(Application.StartupPath, "./exmp/instruction.txt");
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

        private void richTextBoxInstruction_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
