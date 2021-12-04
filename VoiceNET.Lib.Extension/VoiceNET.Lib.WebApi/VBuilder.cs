using Spectrogram;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace VoiceNET.Lib.WebAPI
{

    public class VBuilder
    {

        private static string temp_imgload_analytic = Path.Combine(Path.GetTempPath() + @"\" + Guid.NewGuid().ToString() + ".png");

        static string temp_image_analytic = Path.Combine(Path.GetTempPath() + @"\" + Guid.NewGuid().ToString() + ".png");

        protected static string return_label = "";


        public static bool loadModel()
        {
            Bitmap bmp = new Bitmap(100,100);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);
            bmp.Save(temp_imgload_analytic);
            if(Result(temp_imgload_analytic).Length >0)
                return true;
            else
                return false;
        }

       
        private static (double[] audio, int sampleRate)  ReadWAV(string filePath, double multiplier = 32_000)
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
   
        public static void ModelPath(string model)
        {
            ConsumeModel.MLNetModelPath = model;
        }
        public static void setWebRecord(string path_wav)
        {

            (double[] audio, int sampleRate) = ReadWAV(path_wav);

            //Sound to Spectrogram
            var sg = new SpectrogramGenerator(sampleRate, fftSize: 4096, stepSize: 500, maxFreq: 3000);

            sg.Add(audio);

            //Spectrogram to Image
            sg.SaveImage(temp_image_analytic);

        }

        public static string Result()
        {
            ModelInput SpeechDataset = new ModelInput()
            {
                ImageSource = temp_image_analytic,
            };

            return_label = ConsumeModel.Predict(SpeechDataset).Prediction;

            return return_label;
        }

        public static string Result(string image_path_ana)
        {
            //ML.NET - Image to Label
            ModelInput SpeechDataset = new ModelInput()
            {
                ImageSource = image_path_ana,
            };

            return_label = ConsumeModel.Predict(SpeechDataset).Prediction;

            return return_label;
        }

        }
}