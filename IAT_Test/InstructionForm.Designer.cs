namespace IAT_Test
{
    partial class InstructionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBoxInstruction = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBoxInstruction
            // 
            this.richTextBoxInstruction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxInstruction.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxInstruction.Cursor = System.Windows.Forms.Cursors.Default;
            this.richTextBoxInstruction.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxInstruction.Name = "richTextBoxInstruction";
            this.richTextBoxInstruction.ReadOnly = true;
            this.richTextBoxInstruction.Size = new System.Drawing.Size(776, 426);
            this.richTextBoxInstruction.TabIndex = 1;
            this.richTextBoxInstruction.TabStop = false;
            this.richTextBoxInstruction.Text = "Инструкция по прохождению теста";
            this.richTextBoxInstruction.SelectionChanged += new System.EventHandler(this.richTextBoxInstruction_SelectionChanged);
            this.richTextBoxInstruction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBoxInstruction_KeyPress);
            // 
            // InstructionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBoxInstruction);
            this.Name = "InstructionForm";
            this.Text = "Инструкция";
            this.Load += new System.EventHandler(this.InstructionForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxInstruction;
    }
}