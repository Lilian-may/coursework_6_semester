using System;
using System.Windows.Forms;
using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;

namespace IAT_Test
{
    public partial class VideoForm : Form
    {
        private readonly LibVLC _libVLC;
        private readonly MediaPlayer _mediaPlayer;
        private readonly string _videoPath;
        public DateTime StartTime;
        private bool _videoStarted;
        private readonly System.ComponentModel.IContainer? components = null; // Добавляем поле

        public event EventHandler<VideoWatchedEventArgs>? VideoWatched = null; // Делаем nullable

        public VideoForm(string videoPath)
        {
            InitializeComponent();
            Core.Initialize();

            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);
            videoView.MediaPlayer = _mediaPlayer;

            _videoPath = videoPath ?? throw new ArgumentNullException(nameof(videoPath));
            KeyPreview = true;
            WindowState = FormWindowState.Maximized;
        }

        private void VideoForm_Load(object sender, EventArgs e)
        {
            try
            {
                var media = new Media(_libVLC, new Uri(_videoPath));
                _mediaPlayer.Play(media);
                _mediaPlayer.SetPause(true); // Начинаем с паузы
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка загрузки видео: {ex.Message}");
                Close();
            }
        }

        private void VideoForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Space) return;

            try
            {
                if (!_videoStarted)
                {
                    StartTime = DateTime.Now;
                    _mediaPlayer.SetPause(false);
                    _videoStarted = true;
                }
                else
                {
                    _mediaPlayer.Stop();
                    var duration = DateTime.Now - StartTime;
                    VideoWatched?.Invoke(this, new VideoWatchedEventArgs(duration));
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка: {ex.Message}");
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _mediaPlayer?.Dispose();
                _libVLC?.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        public class VideoWatchedEventArgs(TimeSpan viewTime) : EventArgs
        {
            public TimeSpan ViewTime { get; } = viewTime;
        }
    }
}