using System;
using System.Windows.Forms;
using NAudio.Mixer;
using Spectrogram;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Timers;

namespace VoiceNET.Lib
{
       public class VSpeech 
        {
        static UnsignedMixerControl volumeControl;

        static SpectrogramGenerator spec;

        static Listener listener;

        static int minVolume=10;

        static int micTime=250;

        static string pathDataset;

        static bool isTalking = false;

        static int secondTalking = 0;

        static int defaultWidth = 400; //Default VBuildertrogram image width

        static bool needDispose = false;

        protected static string temp_image_analytic = Path.Combine(Path.GetTempPath() + @"\VoiceNET.Library\" + Guid.NewGuid().ToString() + ".png");

        protected static string temp_path_analytic = Path.Combine(Path.GetTempPath() + @"\VoiceNET.Library");

         static ComboBox WPFcbDevice = new ComboBox();

         static int WPFpbSpec = defaultWidth;

        public static void getDevice(ComboBox cbDevice)
        {
            if (NAudio.Wave.WaveIn.DeviceCount == 0) MessageBox.Show("No audio input devices found.\n\nThis program will now exit.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                //Add device to Combobox
                cbDevice.Items.Clear();
                for (int i = 0; i < NAudio.Wave.WaveIn.DeviceCount; i++)
                    cbDevice.Items.Add(NAudio.Wave.WaveIn.GetCapabilities(i).ProductName);
                cbDevice.SelectedIndex = 0; //Default
            }
        }

        public static void getDevice() => WPFgetDevice(); //Default device
        public static void WPFgetDevice() //WPF
        {
                //Add device to Combobox
                WPFcbDevice.Items.Clear();
                for (int i = 0; i < NAudio.Wave.WaveIn.DeviceCount; i++)
                    WPFcbDevice.Items.Add(NAudio.Wave.WaveIn.GetCapabilities(i).ProductName);
                WPFcbDevice.SelectedIndex = 0; //Default device
            
        }
        public static bool checkDevice() => (NAudio.Wave.WaveIn.DeviceCount == 0) ? false : true;

        public static void setVolume(int volume)
        {
            int waveInDeviceNumber = 0;
            var mixerLine = new MixerLine((IntPtr)waveInDeviceNumber,
                                           0, MixerFlags.WaveIn);

            foreach (var control in mixerLine.Controls)
            {
                if (control.ControlType == MixerControlType.Volume)
                {
                    volumeControl = control as UnsignedMixerControl;
                    break;
                }
            }

            volumeControl.Percent = volume; // you are setting volume here, as a percentage.
        }

        public static int getVolume()
        {
            int waveInDeviceNumber = 0;
            var mixerLine = new MixerLine((IntPtr)waveInDeviceNumber,
                                           0, MixerFlags.WaveIn);

            foreach (var control in mixerLine.Controls)
            {
                if (control.ControlType == MixerControlType.Volume)
                    volumeControl = control as UnsignedMixerControl;
                    break;
            }

            return Convert.ToInt32(volumeControl.Percent);
        }

       

        public static void StartListening(ComboBox cbDevice) //Choose microphone to listening
        {
            int sampleRate = 6000;
            int fftSize = 512;// 1 << (9 + cbFftSize.SelectedIndex);
            int stepSize = fftSize / 20;

            listener?.Dispose();
            listener = new Listener(cbDevice.SelectedIndex, sampleRate);
            spec = new SpectrogramGenerator(sampleRate, fftSize, stepSize);
        }

        static void WPFStartListening() //WPF
        {
            int sampleRate = 6000;
            int fftSize = 512;
            int stepSize = fftSize / 20;

            listener?.Dispose();
            listener = new Listener(WPFcbDevice.SelectedIndex, sampleRate);
            spec = new SpectrogramGenerator(sampleRate, fftSize, stepSize);
           
        }

        static int valueInput = 0;

        public static int getAmplitude => valueInput;
 
        public static Bitmap ListenTimer(int picWidth)
        {
            double[] newAudio = listener.GetNewAudio();
            spec.Add(newAudio, process: false);

            double multiplier = 0.25;// tbBrightness.Value / 20.0; = 5/20

                Stopwatch sw = Stopwatch.StartNew();
                spec.Process();
                spec.SetFixedWidth(picWidth);
                Bitmap bmpSpec = new Bitmap(spec.Width, spec.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
                using (var bmpSpecIndexed = spec.GetBitmap(multiplier, false, roll: false))
                using (var gfx = Graphics.FromImage(bmpSpec))
                using (var pen = new Pen(Color.White))
                    gfx.DrawImage(bmpSpecIndexed, 0, 0);
                sw.Stop();
                valueInput = (int)(listener.AmplitudeFrac * 100); //100 la maxium cua progress value
                return bmpSpec;

        }

        static void WPFListenTimer() //WPF
        {
            double[] newAudio = listener.GetNewAudio();
                spec.Add(newAudio, process: false);

                double multiplier = 0.25;// tbBrightness.Value / 20.0; = 5/20

            Stopwatch sw = Stopwatch.StartNew();
            spec.Process();
            spec.SetFixedWidth(WPFpbSpec);
            Bitmap bmpSpec = new Bitmap(spec.Width, spec.Height, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            using (var bmpSpecIndexed = spec.GetBitmap(multiplier, false, roll: false))
            using (var gfx = Graphics.FromImage(bmpSpec))
            using (var pen = new Pen(Color.White))
                gfx.DrawImage(bmpSpecIndexed, 0, 0);
            sw.Stop();

            valueInput = (int)(listener.AmplitudeFrac * 100); //100 la maxium cua progress value

        }

        public static void ListenDispose()
        {
            listener.DisposeOnly();
        }

        public static void saveImage(string fileName, double intensity = 1, bool dB = false, double dBScale = 1, bool roll = false)
        {
            spec.SaveImage(fileName, intensity, dB, dBScale, roll);
        }

        public static Bitmap getImage(double intensity = 1, bool dB = false, double dBScale = 1, bool roll = false)
        {
            return spec.GetBitmap( intensity,  dB,  dBScale,  roll);
        }

        public static Bitmap getImageTaken(PictureBox picWantTake)
        {
            picWantTake.Width = defaultWidth;
            return spec.GetBitmap(0.25);
        }


        //Setting MicBuilder
        public static void setMinVolume(int volume) => minVolume = volume;


        public static int getMinVolume() =>  minVolume;

        public static void setMicTime(int time_ms) => micTime = time_ms;

        public static int getMicTime() => micTime;

        public static void setPathDataset(string pathDt) => pathDataset = pathDt;

        public static string getPathDataset() => pathDataset;

        //Xu ly thiet lap giam tieng on
        public static void reduceNoiseAndCapture(PictureBox pic, bool devtrainer = false)
        {
            //Rõ ràng volume mic lớn thì khả năng nhận dạng càng cao tuy nhiên môi trường phải không ồn   

            //Khi âm thanh đầu vào cao hơn n%

            if (getAmplitude >= getMinVolume()) 
            {
                isTalking = true;

                secondTalking += 100;

                //Nói kéo dài hơn 680ms thì pbSpectrogram sẽ mở rông, tăng width image

                if (secondTalking > 680 && pic.Width <= 900) pic.Width += 60;

            }

            //Định nghĩa dưới n% là tạp âm nên không bắt ảnh VBuildertrogram, có thể thay đổi cho phù hợp nhu cầu

            //Điều kiện nhận dạng mặc định: Độ lớn sound input>n và duy trì hơn 250ms

            else if (getAmplitude <= getMinVolume())
            {

                if (isTalking == true)
                {
                    //Tránh tạp âm thanh đầu vào quá ngắn, mặc định 250 mili giây. Âm thanh phải kéo dài hơn 250ms
                    if (secondTalking > getMicTime())
                    {
                        ListenDispose();

                        //Chế độ phát triển để tạo data training

                        if (devtrainer)
                            saveImageLabelCache();
                        else
                            saveImage(temp_image_analytic);// Application.StartupPath + @"\img.png");
                        
                        needDispose = true;

                        secondTalking = 0;
                    }


                }
                isTalking = false;
            }
        }

        //Timer for WPF
        static System.Timers.Timer WPFTimer_Listener;
        static System.Timers.Timer WPFTimer_DisposeRam;


        static string return_label =  "";

        public static string WPFGetResult => return_label; //Get text

        public static void WPFListener()
        {
            WPFStartListening();

            WPFTimer_Listener = new System.Timers.Timer(100);
            WPFTimer_Listener.Elapsed += WPF_Listener;
            WPFTimer_Listener.AutoReset = true;
            WPFTimer_Listener.Enabled = true;

            WPFDisposeRam();
        }

        static void WPFDisposeRam()
        {
            WPFTimer_DisposeRam = new System.Timers.Timer(1);
            WPFTimer_DisposeRam.Elapsed += WPF_DisposeRam;
            WPFTimer_DisposeRam.AutoReset = true;
            WPFTimer_DisposeRam.Enabled = true;
        }

        static void WPF_Listener(Object source, ElapsedEventArgs e)
        {
            if (VBuilder.requestDisposeListening)

            {
                WPFpbSpec = defaultWidth;

                return_label = VBuilder.WPFResult();

                WPFStartListening(); //Renew Lisener

                VBuilder.requestDisposeListening = false;

            }

            else

            {

                VBuilder.WPFreduceNoiseAndCapture();

            }

        }

        static void WPF_DisposeRam(Object source, ElapsedEventArgs e)
        {
            WPFListenTimer();
        }

        //End Timer for WPF

        static void WPFreduceNoiseAndCapture() //WPF
        {

            if (getAmplitude >= getMinVolume())
            {
                isTalking = true;

                secondTalking += 100;


                if (secondTalking > 680 && WPFpbSpec <= 900) WPFpbSpec += 60;

            }

            else if (getAmplitude <= getMinVolume())
            {

                if (isTalking == true)
                {
                    if (secondTalking > getMicTime())
                    {
                        ListenDispose();

                        saveImage(temp_image_analytic);

                        needDispose = true;

                        secondTalking = 0;
                    }


                }
                isTalking = false;
            }
        }

        public static bool requestDisposeListening
        {
            get { return needDispose; }  
            set { needDispose = value; } 
        }

        private static void saveImageLabelCache()
        {

            string filename = "vb_cache";

            string ImageFileS = temp_path_analytic + @"\" + filename;

            string exsFile = ".png";

            saveImage(ImageFileS + "_1" + exsFile, 0.1);
            saveImage(ImageFileS + "_2" + exsFile, 0.2);
            saveImage(ImageFileS + "_here" + exsFile, 0.25);
            saveImage(ImageFileS + "_3" + exsFile, 0.3);
            saveImage(ImageFileS + "_4" + exsFile, 0.4);
            saveImage(ImageFileS + "_5" + exsFile, 0.5);
            saveImage(ImageFileS + "_6" + exsFile, 0.6);
            saveImage(ImageFileS + "_7" + exsFile, 0.7);
            saveImage(ImageFileS + "_8" + exsFile, 0.8);
            saveImage(ImageFileS + "_9" + exsFile, 0.9);
            saveImage(ImageFileS + "_10" + exsFile, 1);

            //  }


        }

        public static void addImageLabel(string filename) //For train data
        {
            //Yêu cầu trong folder phải có subfolder name theo label được nhập sau đó click nút MakeData để save data vừa nói lại vào đây

            string ImageFileS;

            //Kiểm tra subfolder có tên theo label có chưa, chưa có thì tạo

            //First filename is sub-folder

            string subfolder_path = getPathDataset()  + @"\" + filename; 

            if (!Directory.Exists(subfolder_path)) Directory.CreateDirectory(subfolder_path);

                //Đường dẫn để lưu image tạo mặc định

                ImageFileS = getPathDataset() + @"\"  + filename + @"\" + filename + "_" + DateTime.Now.ToString("HH-mm-ss").ToString() + "_" + DateTime.Now.DayOfWeek.ToString();
            
            //Sao chép 10 ảnh đã tạo vào thư mục dataset chỉ định

            string exsFile = ".png";

            string cachename = "vb_cache";

            string TempImagePath = temp_path_analytic + @"\" + cachename;

            File.Copy(TempImagePath + @"_1.png", ImageFileS + "_1" + exsFile);
            File.Copy(TempImagePath + @"_2.png", ImageFileS + "_2" + exsFile);
            File.Copy(TempImagePath + @"_here.png", ImageFileS + "_here" + exsFile);
            File.Copy(TempImagePath + @"_3.png", ImageFileS + "_3" + exsFile);
            File.Copy(TempImagePath + @"_4.png", ImageFileS + "_4" + exsFile);
            File.Copy(TempImagePath + @"_5.png", ImageFileS + "_5" + exsFile);
            File.Copy(TempImagePath + @"_6.png", ImageFileS + "_6" + exsFile);
            File.Copy(TempImagePath + @"_7.png", ImageFileS + "_7" + exsFile);
            File.Copy(TempImagePath + @"_8.png", ImageFileS + "_8" + exsFile);
            File.Copy(TempImagePath + @"_9.png", ImageFileS + "_9" + exsFile);
            File.Copy(TempImagePath + @"_10.png", ImageFileS + "_10" + exsFile);



        }

    }
}
