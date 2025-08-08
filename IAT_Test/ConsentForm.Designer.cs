using System.Windows.Forms;

namespace IAT_Test
{
    partial class ConsentForm
    {
        private System.ComponentModel.IContainer components = null;
        private RichTextBox richTextBoxConsent;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            richTextBoxConsent = new RichTextBox();
            SuspendLayout();
            // 
            // richTextBoxConsent
            // 
            richTextBoxConsent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBoxConsent.BorderStyle = BorderStyle.None;
            richTextBoxConsent.Location = new Point(12, 12);
            richTextBoxConsent.Name = "richTextBoxConsent";
            richTextBoxConsent.ReadOnly = true;
            richTextBoxConsent.Size = new Size(776, 426);
            richTextBoxConsent.TabIndex = 0;
            richTextBoxConsent.TabStop = false;
            richTextBoxConsent.Text = "Информированное согласие";
            richTextBoxConsent.SelectionChanged += richTextBoxConsent_SelectionChanged;
            richTextBoxConsent.KeyPress += richTextBoxConsent_KeyPress;
            // 
            // ConsentForm
            // 
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBoxConsent);
            Name = "ConsentForm";
            Text = "Информированное согласие";
            ResumeLayout(false);

        }
    }
}