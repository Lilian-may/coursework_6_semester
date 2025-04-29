using System.Windows.Forms;

namespace IAT_Test
{
    partial class SettingsForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnSelectVideoFolder;
        private Button btnSelectExcelFile;
        private Button btnApply;
        private TextBox txtVideoPath;
        private TextBox txtExcelPath;
        private Label lblVideo;
        private Label lblExcel;

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
            this.btnSelectVideoFolder = new System.Windows.Forms.Button();
            this.btnSelectExcelFile = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.txtVideoPath = new System.Windows.Forms.TextBox();
            this.txtExcelPath = new System.Windows.Forms.TextBox();
            this.lblExcel = new System.Windows.Forms.Label();
            this.lblVideo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnSelectVideoFolder
            // 
            this.btnSelectVideoFolder.Location = new System.Drawing.Point(280, 30);
            this.btnSelectVideoFolder.Name = "btnSelectVideoFolder";
            this.btnSelectVideoFolder.Size = new System.Drawing.Size(75, 23);
            this.btnSelectVideoFolder.TabIndex = 6;
            this.btnSelectVideoFolder.Text = "Выбрать папку видео";
            this.btnSelectVideoFolder.UseVisualStyleBackColor = true;
            this.btnSelectVideoFolder.Click += new System.EventHandler(this.btnSelectVideoFolder_Click);
            // 
            // btnSelectExcelFile
            // 
            this.btnSelectExcelFile.Location = new System.Drawing.Point(280, 80);
            this.btnSelectExcelFile.Name = "btnSelectExcelFile";
            this.btnSelectExcelFile.Size = new System.Drawing.Size(75, 23);
            this.btnSelectExcelFile.TabIndex = 5;
            this.btnSelectExcelFile.Text = "Выбрать файл Excel";
            this.btnSelectExcelFile.UseVisualStyleBackColor = true;
            this.btnSelectExcelFile.Click += new System.EventHandler(this.btnSelectExcelFile_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(135, 128);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(95, 23);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "Применить";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtVideoPath
            // 
            this.txtVideoPath.Location = new System.Drawing.Point(20, 30);
            this.txtVideoPath.Name = "txtVideoPath";
            this.txtVideoPath.ReadOnly = true;
            this.txtVideoPath.Size = new System.Drawing.Size(250, 22);
            this.txtVideoPath.TabIndex = 3;
            // 
            // txtExcelPath
            // 
            this.txtExcelPath.Location = new System.Drawing.Point(20, 80);
            this.txtExcelPath.Name = "txtExcelPath";
            this.txtExcelPath.ReadOnly = true;
            this.txtExcelPath.Size = new System.Drawing.Size(250, 22);
            this.txtExcelPath.TabIndex = 2;
            // 
            // lblExcel
            // 
            this.lblExcel.AutoSize = true;
            this.lblExcel.Location = new System.Drawing.Point(20, 10);
            this.lblExcel.Name = "lblExcel";
            this.lblExcel.Size = new System.Drawing.Size(101, 16);
            this.lblExcel.TabIndex = 0;
            this.lblExcel.Text = "Папка с видео";
            // 
            // lblVideo
            // 
            this.lblVideo.AutoSize = true;
            this.lblVideo.Location = new System.Drawing.Point(20, 60);
            this.lblVideo.Name = "lblVideo";
            this.lblVideo.Size = new System.Drawing.Size(113, 16);
            this.lblVideo.TabIndex = 1;
            this.lblVideo.Text = "Файл с данными";
            // 
            // SettingsForm
            // 
            this.ClientSize = new System.Drawing.Size(380, 180);
            this.Controls.Add(this.lblExcel);
            this.Controls.Add(this.lblVideo);
            this.Controls.Add(this.txtExcelPath);
            this.Controls.Add(this.txtVideoPath);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnSelectExcelFile);
            this.Controls.Add(this.btnSelectVideoFolder);
            this.Name = "SettingsForm";
            this.Text = "Настройки";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}