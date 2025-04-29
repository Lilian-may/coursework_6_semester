using System;
using System.Windows.Forms;
using AxWMPLib;

namespace IAT_Test
{
    public partial class VideoForm : Form
    {
        private string videoPath;
        public DateTime startTime;
        private bool videoStarted = false;

        public event EventHandler<VideoWatchedEventArgs> VideoWatched;

        public VideoForm(string videoPath)
        {
            InitializeComponent();
            this.videoPath = videoPath;
            this.KeyPreview = true;
            this.ActiveControl = null;
            this.Focus();
            this.WindowState = FormWindowState.Maximized;
        }

        private void VideoForm_Load(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = videoPath;
            axWindowsMediaPlayer1.settings.setMode("loop", true);
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void VideoForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Space)
                {
                    if (!videoStarted)
                    {
                        videoStarted = true;
                        startTime = DateTime.Now;
                        axWindowsMediaPlayer1.Ctlcontrols.play();
                    }
                    else
                    {
                        axWindowsMediaPlayer1.Ctlcontrols.stop();
                        TimeSpan duration = DateTime.Now - startTime;
                        VideoWatched?.Invoke(this, new VideoWatchedEventArgs(duration));
                        //this.Hide();
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при завершении видео: {ex.Message}");
            }
        }

        private void VideoForm_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                e.IsInputKey = true;
            }

        }
    }

    public class VideoWatchedEventArgs : EventArgs
    {
        public TimeSpan ViewTime { get; }
        public VideoWatchedEventArgs(TimeSpan viewTime)
        {
            ViewTime = viewTime;
        }
    }
}