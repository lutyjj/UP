using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Video.DirectShow;
using Accord.Video.FFMPEG;
using AForge.Imaging.Filters;
using NAudio.Wave;

namespace lab2
{
    public partial class MainForm : Form
    {
        private FilterInfoCollection webcams;
        private VideoCaptureDevice webcam;
        private WaveFileWriter waveWriter;
        private VideoFileWriter writer;
        private bool isRecording = false;
        private bool isPaused = false;
        private bool isAudioAttached = false;
        private DateTime? firstFrameTime;
        private TimeSpan recordedSpan;
        private WaveIn mic;
        SaturationCorrection filter = new SaturationCorrection(0.1f);

        private string audioPath;
        private string videoPath = @"E:\vid.avi";
        private string outputPath;

        public MainForm()
        {
            InitializeComponent();
            InitUI();
            Init();

            cbxWebcams.SelectedIndexChanged += OnCbxWebcamChanged;
            btnSaveSnapshot.Click += OnButtonSaveSnapshotClick;
            btnStartRecording.Click += OnButtonStartRecordingClick;
            btnPause.Click += OnButtonPauseClick;
            btnAttachAudio.Click += OnButtonAttachAudio;
            FormClosing += OnFormClosing;
            mic.DataAvailable += OnMicDataAvailable;
        }

        /* Initialize default UI setup */
        private void InitUI()
        {
            pbFeed.SizeMode = PictureBoxSizeMode.Zoom;
            rbNormalMode.Checked = true;
            btnPause.Enabled = false;
        }

        private void Init()
        {
            mic = new WaveIn();
            webcams = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            /* Cycle through available video input devices */
            foreach (var webcam in webcams)
                cbxWebcams.Items.Add(webcam.Name);

            /* If there's at least one camera available, start it up */
            if (cbxWebcams.Items.Count > 0)
            {
                cbxWebcams.SelectedIndex = 0;
                StartWebcam();
            }
        }

        private void StartWebcam()
        {
            /* Get selected webcam access path */
            webcam = new VideoCaptureDevice(webcams[cbxWebcams.SelectedIndex].MonikerString);
            webcam.Start();
            webcam.NewFrame += Webcam_NewFrame;
        }

        private void StopWebcam()
        {
            webcam?.SignalToStop();
            webcam?.Stop();
        }

        private void Webcam_NewFrame(object sender, Accord.Video.NewFrameEventArgs e)
        {
            /* Mirror image on X axis to look normal */
            e.Frame.RotateFlip(RotateFlipType.RotateNoneFlipX);
            /* Release previous image */
            pbFeed.Image?.Dispose();

            /* Set up live feed from camera to PictureBox*/
            pbFeed.Image = (Bitmap)e.Frame.Clone();

            if (isRecording && !isPaused)
            {
                try
                {
                    using (Bitmap tmp = (Bitmap)pbFeed.Image.Clone())
                    {
                        /* Apply filter if checkbox checked */
                        if (chbBoostSaturation.Checked)
                        {
                            filter.ApplyInPlace(tmp);
                        }

                        if (firstFrameTime != null)
                        {
                            /* Write next frame with time based on already known recorded span */
                            writer.WriteVideoFrame(tmp, recordedSpan + (DateTime.Now - firstFrameTime.Value));
                        }
                        else
                        {
                            /* If first frame is empty, set first frame time */
                            writer.WriteVideoFrame(tmp);
                            firstFrameTime = DateTime.Now;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        
        private void OnMicDataAvailable(object sender, WaveInEventArgs e)
        {
            waveWriter.Write(e.Buffer, 0, e.BytesRecorded);
            waveWriter.Flush();
        }

        private void OnFormClosing(object sender, EventArgs e)
        {
            StopWebcam();
            waveWriter?.Dispose();
            mic?.Dispose();
        }

        private void OnButtonPauseClick(object sender, EventArgs e)
        {
            isPaused = !isPaused;
            if (isPaused)
            {
                /* If paused, stop recording data from mic */
                mic.DataAvailable -= OnMicDataAvailable;
                btnPause.Text = "Continue";
                recordedSpan += DateTime.Now - firstFrameTime.Value;
            }
            else
            {
                /* If гтpaused, start recording data from mic */
                mic.DataAvailable += OnMicDataAvailable;
                btnPause.Text = "Pause";
                firstFrameTime = DateTime.Now;
            }
        }

        private void OnCbxWebcamChanged(object sender, EventArgs e)
        {
            StopWebcam();
            StartWebcam();
        }

        private void OnButtonAttachAudio(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "Wave files (*.wav) |*.wav";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                isAudioAttached = true;
                audioPath = dialog.FileName;
            }
            dialog.Dispose();
        }

        private void OnButtonStartRecordingClick(object sender, EventArgs e)
        {
            if (!isRecording)
            {
                writer = new VideoFileWriter();
                /* Get all necessary info for writer from selected webcam */
                var videoCapabilities = webcam.VideoCapabilities[0];
                writer.FrameRate = videoCapabilities.AverageFrameRate;
                writer.Height = videoCapabilities.FrameSize.Height;
                writer.Width = videoCapabilities.FrameSize.Width;
                writer.VideoCodec = VideoCodec.Default;
                writer.BitRate = 100000;
                /* Create and open file where video will be stored */
                writer.Open(videoPath);

                /* If no audio attached, start recording mic into separate file */
                if (!isAudioAttached)
                {
                    audioPath = @"E:\mic.wav";
                    waveWriter = new WaveFileWriter(audioPath, mic.WaveFormat);
                    mic.StartRecording();
                }
                
                isRecording = true;
                FlipRecordUI();
            }
            else
            {
                StopRecording();
                FlipRecordUI();
            }
        }
        
        /* Enables/disables buttons that can affect video recording */
        private void FlipRecordUI()
        {
            btnStartRecording.Text = isRecording ? "Stop" : "Start";
            btnSaveSnapshot.Enabled = !isRecording;
            if (!isRecording)
            {
                btnPause.Text = "Pause";
                isPaused = false;
            }
            btnAttachAudio.Enabled = !isRecording;
            btnPause.Enabled = isRecording;
            chbBoostSaturation.Enabled = !isRecording;
            cbxWebcams.Enabled = !isRecording;
        }

        private void StopRecording()
        {
            /* Needed for writer to catch up with stream */
            Thread.Sleep(1000);
            writer.Close();
            if (!isAudioAttached)
            {
                mic.StopRecording();
            }

            /* Reset basic values for next recording */
            isRecording = false;
            firstFrameTime = null;
            recordedSpan = TimeSpan.Zero;

            ShowSaveFileDialog();
            MergeFiles();

            writer.Dispose();
            waveWriter?.Dispose();
        }
        
        private void ShowSaveFileDialog()
        {
            var dialog = new SaveFileDialog();
            dialog.Filter = "Avi files (*.avi)|*.avi|MPEG-4 files (*.mp4)|.mp4";

            if (dialog.ShowDialog() == DialogResult.OK)
                outputPath = dialog.FileName;
            dialog.Dispose();
        }

        /* Merges video and audio files via FFMPEG */
        private void MergeFiles()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = $"/c ffmpeg -i {videoPath} -i {audioPath} -shortest {outputPath}";
            using (Process exeProcess = Process.Start(startInfo))
            {
                exeProcess.WaitForExit();
            }
        }

        private async void OnButtonSaveSnapshotClick(object sender, EventArgs e)
        {
            Bitmap bitmap = (Bitmap)pbFeed.Image.Clone();
            btnSaveSnapshot.Enabled = false;
            /* Process image on different thread, avoiding UI freeze */
            if (rbGrayscale.Checked)
                bitmap = await Task.Run(() => Grayscale_Bitmap(bitmap));
            else if (rbThresolding.Checked)
                bitmap = await Task.Run(() => Thresold_Bitmap(bitmap));
            else if (rbConvolution.Checked)
                bitmap = await Task.Run(() => Convolution_Bitmap(bitmap));
            else if (rbRedChannel.Checked)
                bitmap = await Task.Run(() => Extract_Channel(bitmap, 'r'));
            else if (rbGreenChannel.Checked)
                bitmap = await Task.Run(() => Extract_Channel(bitmap, 'g'));
            else if (rbBlueChannel.Checked)
                bitmap = await Task.Run(() => Extract_Channel(bitmap, 'b'));

            bitmap.Save(@"D:\\result.png");
            bitmap.Dispose();
            btnSaveSnapshot.Enabled = true;
        }

        private Bitmap Thresold_Bitmap(Bitmap bitmap)
        {
            float avgBrightness = 0;

            /* Count total brightness level from each pixel */
            for (int x = 0; x < bitmap.Width; x++)
                for (int y = 0; y < bitmap.Height; y++)
                    avgBrightness += bitmap.GetPixel(x, y).GetBrightness();

            /* Count average brightness level */
            avgBrightness /= (bitmap.Width * bitmap.Height);

            /* If pixel brightness is greater than average, make pixel white
               If pixel brightness is lower than average, make pixel black */
            for (int x = 0; x < bitmap.Width; x++)
                for (int y = 0; y < bitmap.Height; y++)
                    if (bitmap.GetPixel(x, y).GetBrightness() > avgBrightness)
                        bitmap.SetPixel(x, y, Color.White);
                    else
                        bitmap.SetPixel(x, y, Color.Black);

            return bitmap;
        }

        private Bitmap Grayscale_Bitmap(Bitmap bitmap)
        {
            /* Calculate average RGB value of pixel
               Set it as each channel value to achieve grayscale */
            for (int x = 0; x < bitmap.Width; x++)
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color color = bitmap.GetPixel(x, y);
                    int avg = (color.R + color.G + color.B) / 3;
                    /* Drop alpha as we can't have it in src bitmap anyway */
                    bitmap.SetPixel(x, y, Color.FromArgb(avg, avg, avg));
                }

            return bitmap;
        }

        private Bitmap Extract_Channel(Bitmap bitmap, char channel)
        {
            for (int x = 0; x < bitmap.Width; x++)
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color color = bitmap.GetPixel(x, y);

                    /* Extract value of selected channel from pixel */
                    var color_value = 0;
                    if (channel == 'r')
                        color_value = color.R;
                    else if (channel == 'g')
                        color_value = color.G;
                    else if (channel == 'b')
                        color_value = color.B;

                    /* Drop alpha as we can't have it in src bitmap anyway */
                    bitmap.SetPixel(x, y, Color.FromArgb(color_value, color_value, color_value));
                }

            return bitmap;
        }

        private Bitmap Convolution_Bitmap(Bitmap bitmap)
        {
            bitmap = Grayscale_Bitmap(bitmap);

            /* Edge detection kernel */
            int[,] kernel = { { -1, -1, -1 }, { -1, 8, -1 }, { -1, -1, -1 } };

            /* Create temprorary bitmap to store new values as we can't operate directly on src */
            var output = new Bitmap(bitmap.Width, bitmap.Height);
            /* Calculate kernel starting offset */
            var offset = kernel.GetLength(0) / 2;

            /* Cycle through each pixel of bitmap */
            for (var x = offset; x < bitmap.Width - offset; x++)
                for (var y = offset; y < bitmap.Height - offset; y++)
                {
                    int r = 0, b = 0, g = 0;

                    /* Apply kernel mask and calculate respective RGB values */
                    for (var krow = 0; krow < kernel.GetLength(0); krow++)
                        for (var kcol = 0; kcol < kernel.GetLength(0); kcol++)
                        {
                            var pixel = bitmap.GetPixel(x + krow - offset, y + kcol - offset);

                            r += kernel[krow, kcol] * pixel.R;
                            g += kernel[krow, kcol] * pixel.G;
                            b += kernel[krow, kcol] * pixel.B;
                        }

                    /* if color > 255 => color = 255 
                       if color < 0 => color = 0 */
                    r = Math.Min(Math.Max(r, 0), 255);
                    g = Math.Min(Math.Max(g, 0), 255);
                    b = Math.Min(Math.Max(b, 0), 255);

                    output.SetPixel(x, y, Color.FromArgb(r, g, b));
                }

            bitmap.Dispose();
            return output;
        }
    }
}
