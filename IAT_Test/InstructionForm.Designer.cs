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
            richTextBoxInstruction = new RichTextBox();
            SuspendLayout();
            // 
            // richTextBoxInstruction
            // 
            richTextBoxInstruction.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBoxInstruction.BorderStyle = BorderStyle.None;
            richTextBoxInstruction.Location = new Point(20, 24);
            richTextBoxInstruction.Margin = new Padding(5, 6, 5, 6);
            richTextBoxInstruction.Name = "richTextBoxInstruction";
            richTextBoxInstruction.ReadOnly = true;
            richTextBoxInstruction.Size = new Size(1261, 851);
            richTextBoxInstruction.TabIndex = 1;
            richTextBoxInstruction.TabStop = false;
            richTextBoxInstruction.Text = "Инструкция по прохождению теста";
            richTextBoxInstruction.SelectionChanged += richTextBoxInstruction_SelectionChanged;
            richTextBoxInstruction.TextChanged += richTextBoxInstruction_TextChanged;
            richTextBoxInstruction.KeyPress += richTextBoxInstruction_KeyPress;
            // 
            // InstructionForm
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1300, 899);
            Controls.Add(richTextBoxInstruction);
            Margin = new Padding(5, 6, 5, 6);
            Name = "InstructionForm";
            Text = "Инструкция";
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxInstruction;
    }
}