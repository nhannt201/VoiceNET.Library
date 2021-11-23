using Spectrogram;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace VoiceNET.Lib.ClientAPI
{

    public class VBuilder : VSpeech
    {

        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

        private static string temp_wav_analytic = Path.Combine(Path.GetTempPath() + @"\VoiceNET.Library\" + Guid.NewGuid().ToString() + ".wav");
        //Call from VSpeech
        public static new void getDevice() => VSpeech.getDevice();

        public static new bool checkDevice() => VSpeech.checkDevice();

        public static new void setVolume(int volume) => VSpeech.setVolume(volume);

        public static new int getVolume() =>   VSpeech.getVolume();

        public static new void setMinVolume(int volume) => VSpeech.setMinVolume(volume);

        public static new int getMinVolume() => VSpeech.getMinVolume();

        public static new void setMicTime(int time_ms) => VSpeech.setMicTime(time_ms);

        public static new int getMicTime() => VSpeech.getMicTime();

        public static string WebAPIGetResult => VSpeech.APIGetResult;

        public static new void WebAPIListener() => VSpeech.WebAPIListener(); //SameWPF

        public static void WebAPStopListener() => VSpeech.APIStopListener();

        public static string setApiUrl
        {
            get { return api_path_url; }
            set { api_path_url = value; }
        }

        private static (double[] audio, int sampleRate) ReadWAV(string filePath, double multiplier = 32_000)
        {
            var afr = new NAudio.Wave.AudioFileReader(filePath);
            int sampleRate = afr.WaveFormat.SampleRate;
            int sampleCount = (int)(afr.Length / afr.WaveFormat.BitsPerSample / 8);
            int channelCount = afr.WaveFormat.Channels;
            var audio = new List<double>(sampleCount);
            var buffer = new float[sampleRate * channelCount];
            int samplesRead = 0;
            while ((samplesRead = afr.Read(buffer, 0, buffer.Length)) > 0)
                audio.AddRange(buffer.Take(samplesRead).Select(x => x * multiplier));
            return (audio.ToArray(), sampleRate);
        }

        public static void StartRecord()
        {
            try
            {
                //Clear WAV temp file
                if (!Directory.Exists(temp_path_analytic)) Directory.CreateDirectory(temp_path_analytic);
                if (File.Exists(temp_wav_analytic)) File.Delete(temp_wav_analytic);
            }
            catch { }

                mciSendString("open new Type waveaudio Alias recsound", "", 0, 0);
                mciSendString("set recsound format tag pcm bitspersample 16 channels 1 samplespersec 44100 bytespersec 88200 alignment 2", "", 0, 0);
                mciSendString("record recsound", "", 0, 0);

        }
        public static void StopRecord()
        {
            mciSendString("stop recsound", "", 0, 0);
            mciSendString("save recsound " + temp_wav_analytic, "", 0, 0);
            mciSendString("close recsound", "", 0, 0);

            try{ if (File.Exists(temp_image_analytic)) File.Delete(temp_image_analytic); }
            catch { }

            (double[] audio, int sampleRate) = ReadWAV(temp_wav_analytic);
            var sg = new SpectrogramGenerator(sampleRate, fftSize: 4096, stepSize: 500, maxFreq: 3000);
            sg.Add(audio);
            sg.SaveImage(temp_image_analytic);

            var image = File.ReadAllBytes(temp_image_analytic);

            postAPI(api_path_url, image);
        }

    }
}
