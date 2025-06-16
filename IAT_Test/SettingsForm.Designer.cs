using System.Windows.Forms;

namespace IAT_Test
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnSelectVideoFolder;
        private Button btnApply;
        private TextBox txtVideoPath;
        private Label lblVideo;

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
            btnSelectVideoFolder = new Button();
            btnApply = new Button();
            txtVideoPath = new TextBox();
            lblVideo = new Label();
            SuspendLayout();
            // 
            // btnSelectVideoFolder
            // 
            btnSelectVideoFolder.Location = new Point(280, 45);
            btnSelectVideoFolder.Name = "btnSelectVideoFolder";
            btnSelectVideoFolder.Size = new Size(135, 39);
            btnSelectVideoFolder.TabIndex = 6;
            btnSelectVideoFolder.Text = "Выбрать папку видео";
            btnSelectVideoFolder.UseVisualStyleBackColor = true;
            btnSelectVideoFolder.Click += btnSelectVideoFolder_Click;
            // 
            // btnApply
            // 
            btnApply.Location = new Point(182, 358);
            btnApply.Name = "btnApply";
            btnApply.Size = new Size(159, 45);
            btnApply.TabIndex = 4;
            btnApply.Text = "Применить";
            btnApply.UseVisualStyleBackColor = true;
            btnApply.Click += btnApply_Click;
            // 
            // txtVideoPath
            // 
            txtVideoPath.Location = new Point(20, 45);
            txtVideoPath.Name = "txtVideoPath";
            txtVideoPath.ReadOnly = true;
            txtVideoPath.Size = new Size(250, 39);
            txtVideoPath.TabIndex = 3;
            // 
            // lblVideo
            // 
            lblVideo.AutoSize = true;
            lblVideo.Location = new Point(20, 122);
            lblVideo.Name = "lblVideo";
            lblVideo.Size = new Size(196, 32);
            lblVideo.TabIndex = 1;
            lblVideo.Text = "Файл с данными";
            // 
            // SettingsForm
            // 
            ClientSize = new Size(579, 453);
            Controls.Add(lblVideo);
            Controls.Add(txtVideoPath);
            Controls.Add(btnApply);
            Controls.Add(btnSelectVideoFolder);
            Name = "SettingsForm";
            Text = "Настройки";
            ResumeLayout(false);
            PerformLayout();

        }
    }
}