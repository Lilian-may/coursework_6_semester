using LibVLCSharp.WinForms;

namespace IAT_Test
{
    partial class VideoForm
    {
        private VideoView videoView;

        private void InitializeComponent()
        {
            this.videoView = new LibVLCSharp.WinForms.VideoView();
            this.SuspendLayout();
            this.Load += VideoForm_Load;
            this.KeyDown += VideoForm_KeyDown;
            // 
            // videoView
            // 
            this.videoView.BackColor = System.Drawing.Color.Black;
            this.videoView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoView.Location = new System.Drawing.Point(0, 0);
            this.videoView.Name = "videoView";
            this.videoView.Size = new System.Drawing.Size(800, 450);
            this.videoView.TabIndex = 0;
            // 
            // VideoForm
            // 
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.videoView);
            this.Name = "VideoForm";
            this.ResumeLayout(false);
        }
    }
}