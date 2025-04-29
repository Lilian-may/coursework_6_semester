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
            this.richTextBoxConsent = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBoxConsent
            // 
            this.richTextBoxConsent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxConsent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxConsent.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBoxConsent.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxConsent.Name = "richTextBoxConsent";
            this.richTextBoxConsent.ReadOnly = true;
            this.richTextBoxConsent.Size = new System.Drawing.Size(776, 426);
            this.richTextBoxConsent.TabIndex = 0;
            this.richTextBoxConsent.TabStop = false;
            this.richTextBoxConsent.Text = "Информированное согласие";
            this.richTextBoxConsent.SelectionChanged += new System.EventHandler(this.richTextBoxConsent_SelectionChanged);
            this.richTextBoxConsent.TextChanged += new System.EventHandler(this.richTextBoxConsent_TextChanged);
            this.richTextBoxConsent.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBoxConsent_KeyPress);
            // 
            // ConsentForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBoxConsent);
            this.Name = "ConsentForm";
            this.Text = "Информированное согласие";
            this.ResumeLayout(false);

        }
    }
}