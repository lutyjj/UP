using System;
using System.Windows.Forms;
using NAudio.Wave;

namespace lab1
{
    public partial class MainForm : Form
    {
        private readonly WaveIn waveIn;
        private WaveOutEvent waveOut;
        private AudioFileReader waveReader;
        private WaveFileWriter waveWriter;

        public MainForm()
        {
            InitializeComponent();
            ListDevices();
            startRecordingBtn.Click += OnButtonStartRecordingClick;
            stopRecordingBtn.Click += OnButtonStopRecordingClick;
            startPlayingBtn.Click += OnButtonStartPlaybackClick;
            stopPlayingBtn.Click += OnButtonStopPlaybackClick;
            startMixBtn.Click += OnButtonStartMixClick;
            stopMixBtn.Click += OnButtonStopMixClick;

            stopPlayingBtn.Enabled = false;
            stopRecordingBtn.Enabled = false;

            waveIn = new WaveIn();

            inputCbx.SelectedIndexChanged += (s, e) => waveIn.DeviceNumber = inputCbx.SelectedIndex;

            waveIn.DataAvailable += (s, a) =>
            {
                waveWriter.Write(a.Buffer, 0, a.BytesRecorded);
                waveWriter.Flush();
            };

            waveIn.RecordingStopped += (s, a) => { waveWriter.Dispose(); };
            FormClosing += OnButtonStopPlaybackClick;
        }

        private void OnButtonStartPlaybackClick(object sender, EventArgs e)
        {
            if (waveOut == null)
            {
                waveOut = new WaveOutEvent();
                waveOut.PlaybackStopped += OnPlaybackStopped;
            }

            if (waveReader == null)
            {
                waveReader = new AudioFileReader(@"E:\music.wav");
                waveOut.Init(waveReader);
            }

            waveOut.Play();

            stopPlayingBtn.Enabled = true;
            startPlayingBtn.Enabled = false;
        }

        private void OnButtonStopPlaybackClick(object sender, EventArgs e)
        {
            waveOut?.Stop();
            stopPlayingBtn.Enabled = false;
            startPlayingBtn.Enabled = true;
        }

        private void OnPlaybackStopped(object sender, EventArgs e)
        {
            stopPlayingBtn.Enabled = false;
            startPlayingBtn.Enabled = true;
            waveOut?.Dispose();
            waveOut = null;
            waveReader?.Dispose();
            waveReader = null;
        }

        private void OnButtonStartRecordingClick(object sender, EventArgs e)
        {
            waveWriter = new WaveFileWriter(@"E:\mic.wav", waveIn.WaveFormat);
            waveIn.StartRecording();
            startRecordingBtn.Enabled = false;
            stopRecordingBtn.Enabled = true;
        }

        private void OnButtonStopRecordingClick(object sender, EventArgs e)
        {
            waveIn.StopRecording();
            waveWriter.Dispose();
            waveIn.Dispose();
            startRecordingBtn.Enabled = true;
            stopRecordingBtn.Enabled = false;
        }

        private void OnButtonStartMixClick(object sender, EventArgs e)
        {
            var mixer = new WaveMixerStream32 { AutoStop = true};
            var wav1 = new WaveFileReader(@"E:\mic.wav");

            using (var reader = new AudioFileReader(@"E:\music.wav"))
            {
                var outFormat = new WaveFormat(8000, reader.WaveFormat.Channels);
                using (var resampler = new MediaFoundationResampler(reader, outFormat))
                {
                    WaveFileWriter.CreateWaveFile(@"E:\music_resampled.wav", resampler);
                }
            }
            var wav2 = new WaveFileReader(@"E:\music_resampled.wav");

            mixer.AddInputStream(new WaveChannel32(wav1));
            mixer.AddInputStream(new WaveChannel32(wav2));
            WaveFileWriter.CreateWaveFile(@"E:\mixed.wav", new Wave32To16Stream(mixer));

            waveOut = new WaveOutEvent();
            waveReader = new AudioFileReader(@"E:\mixed.wav");
            waveOut.Init(waveReader);
            waveOut.Play();
        }

        private void OnButtonStopMixClick(object sender, EventArgs e)
        {
            waveOut?.Stop();
            waveOut.Dispose();
        }

        private void ListDevices()
        {
            for (var n = 0; n < WaveIn.DeviceCount; n++)
            {
                var caps = WaveIn.GetCapabilities(n);
                inputCbx.Items.Add($"{n}: {caps.ProductName}");
            }

            inputCbx.SelectedIndex = 0;
        }
    }
}