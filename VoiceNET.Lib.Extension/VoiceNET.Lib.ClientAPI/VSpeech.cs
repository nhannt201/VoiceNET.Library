using System;
using System.Windows.Forms;
using NAudio.Mixer;
using Spectrogram;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Timers;
using System.Net.Http;
using System.Globalization;

namespace VoiceNET.Lib.ClientAPI
{
       public class VSpeech 
        {
        static UnsignedMixerControl volumeControl;

        static SpectrogramGenerator spec;

        static Listener listener;

        static int minVolume=10;

        static int micTime=250;

        static bool isTalking = false;

        static int secondTalking = 0;

        static int defaultWidth = 400;

        static bool needDispose = false;

        protected static string temp_image_analytic = Path.Combine(Path.GetTempPath() + @"\VoiceNET.Library\" + Guid.NewGuid().ToString() + ".png");

        protected static string temp_path_analytic = Path.Combine(Path.GetTempPath() + @"\VoiceNET.Library");

        protected static string api_path_url = "";

        protected static string return_label = "";


        static ComboBox WPFcbDevice = new ComboBox();

         static int WPFpbSpec = defaultWidth;
        protected static void getDevice() //WPF
        {
            if (!Directory.Exists(temp_path_analytic)) Directory.CreateDirectory(temp_path_analytic);
            //Add device to Combobox
            WPFcbDevice.Items.Clear();
                for (int i = 0; i < NAudio.Wave.WaveIn.DeviceCount; i++)
                    WPFcbDevice.Items.Add(NAudio.Wave.WaveIn.GetCapabilities(i).ProductName);
                WPFcbDevice.SelectedIndex = 0; //Default device
            
        }
        protected static bool checkDevice() => (NAudio.Wave.WaveIn.DeviceCount == 0) ? false : true;

        protected static void setVolume(int volume)
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

        protected static int getVolume()
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

       
        static void APIStartListening() //WPF
        {
            int sampleRate = 6000;
            int fftSize = 512;
            int stepSize = fftSize / 20;

            listener?.Dispose();

            listener = new Listener(WPFcbDevice.SelectedIndex, sampleRate);

            spec = new SpectrogramGenerator(sampleRate, fftSize, stepSize);
           
        }

        static int valueInput = 0;

        protected static int getAmplitude => valueInput;

        static void APIListenTimer() //WPF
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

        protected static void ListenDispose()
        {
            listener.DisposeOnly();
        }

        protected static void saveImage(string fileName, double intensity = 1, bool dB = false, double dBScale = 1, bool roll = false)
        {
            spec.SaveImage(fileName, intensity, dB, dBScale, roll);
        }

        //Setting MicBuilder
        protected static void setMinVolume(int volume) => minVolume = volume;

        protected static int getMinVolume() =>  minVolume;

        protected static void setMicTime(int time_ms) => micTime = time_ms;

        protected static int getMicTime() => micTime;
     

        //Timer for WPF
        static System.Timers.Timer APITimer_Listener;
        static System.Timers.Timer APITimer_DisposeRam;

        protected static string APIGetResult => return_label; //Get text

        //Action stop Timer
        protected static void APIStopListener()
        {
            APITimer_Listener.Stop();
            APITimer_DisposeRam.Stop();
        }

        static void APIDisposeRam()
        {
            APITimer_DisposeRam = new System.Timers.Timer(1);
            APITimer_DisposeRam.Elapsed += API_DisposeRam;
            APITimer_DisposeRam.AutoReset = true;
            APITimer_DisposeRam.Enabled = true;
        }

        static void API_DisposeRam(Object source, ElapsedEventArgs e)
        {
            APIListenTimer();
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

        //End Timer for Winform QuickStart

        //Timer for API

        protected static void WebAPIListener()
        {
            getDevice(); //Default Device

            APIStartListening();

            APITimer_Listener = new System.Timers.Timer(100);
            APITimer_Listener.Elapsed += WebAPI_ListenerAsync;
            APITimer_Listener.AutoReset = true;
            APITimer_Listener.Enabled = true;

            APIDisposeRam();
        }
        static void WebAPI_ListenerAsync(Object source, ElapsedEventArgs e)
        {
            if (requestDisposeListening)

            {
                WPFpbSpec = defaultWidth;

                var image = File.ReadAllBytes(temp_image_analytic);

                postAPI(api_path_url, image);

                APIStartListening(); //Renew Lisener

                requestDisposeListening = false;

            }

            else

            {

                WPFreduceNoiseAndCapture();

            }

        }

        //End API
        protected static bool requestDisposeListening
        {
            get { return needDispose; }  
            set { needDispose = value; } 
        }
        protected static async void postAPI(string actionUrl, byte[] image)
        {
            using (var client = new HttpClient())
            {
                using (var content =
                    new MultipartFormDataContent("Upload----" + DateTime.Now.ToString(CultureInfo.InvariantCulture)))
                {
                    content.Add(new StreamContent(new MemoryStream(image)), "name", RandomName.getRandomName() + "temp.png");

                    using (
                       var message =
                           await client.PostAsync(actionUrl, content))
                    {
                        var input = await message.Content.ReadAsStringAsync();

                        return_label = input.ToString();
                    }
                }
            }
        }


    }
}
