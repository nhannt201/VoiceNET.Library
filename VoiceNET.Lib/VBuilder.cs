using Spectrogram;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoiceNET.Lib
{

    public class VBuilder : VSpeech
    {
        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

        private static string temp_wav_analytic =  Path.Combine(Path.GetTempPath() + @"\VoiceNET.Library\" + Guid.NewGuid().ToString() + ".wav");

        private static string temp_imgload_analytic = Path.Combine(Path.GetTempPath() + @"\VoiceNET.Library\" + Guid.NewGuid().ToString() + ".png");

        private static bool isTrainData = false;

        //Call from VSpeech
        public static new void getDevice(ComboBox cbDevice) => VSpeech.getDevice(cbDevice);

        public static new void getDevice() => VSpeech.getDevice();

        public static new void WPFgetDevice() => VSpeech.WPFgetDevice();

        public static new bool checkDevice() => VSpeech.checkDevice();

        public static new void setVolume(int volume) => VSpeech.setVolume(volume);

        public static new int getVolume() =>   VSpeech.getVolume();

        public static new void StartListening(ComboBox cbDevice) => VSpeech.StartListening(cbDevice);

        public static new int getAmplitude => VSpeech.getAmplitude;

        public static new Bitmap ListenTimer(int picWidth) => VSpeech.ListenTimer(picWidth);

        public static new void ListenDispose() => VSpeech.ListenDispose();

        public static new void saveImage(string fileName, double intensity = 1, bool dB = false, double dBScale = 1, bool roll = false) => VSpeech.saveImage(fileName, intensity, dB, dBScale, roll);

        public static new Bitmap getImage(double intensity = 1, bool dB = false, double dBScale = 1, bool roll = false) => VSpeech.getImage(intensity, dB, dBScale, roll);

        public static new Bitmap getImageTaken(PictureBox picWantTake) => VSpeech.getImageTaken(picWantTake);

        public static new void setMinVolume(int volume) => VSpeech.setMinVolume(volume);

        public static new int getMinVolume() => VSpeech.getMinVolume();

        public static new void setMicTime(int time_ms) => VSpeech.setMicTime(time_ms);

        public static new int getMicTime() => VSpeech.getMicTime();

        public static new void setPathDataset(string pathDt) => VSpeech.setPathDataset(pathDt);

        public static new string getPathDataset() => VSpeech.getPathDataset();

        public static new void reduceNoiseAndCapture(PictureBox pic, bool devtrainer = false) => VSpeech.reduceNoiseAndCapture(pic, devtrainer);

        public static new string WPFGetResult => VSpeech.WPFGetResult;

        public static new string WFGetResult => VSpeech.WPFGetResult;

        public static string WebAPIGetResult => VSpeech.APIGetResult;

        public static new void WPFListener() => VSpeech.WPFListener();

        public static new void WFListener() => VSpeech.WFListener(); //SameWPF

        public static new void WebAPIListener() => VSpeech.WebAPIListener(); //SameWPF

        public static new void WPFStopListener() => VSpeech.WPFStopListener();

        public static new void WFStopListener() => VSpeech.WFStopListener();

        public static void WebAPStopListener() => VSpeech.WPFStopListener();



        public static string setApiUrl
        {
            get { return VSpeech.api_path_url; }
            set { VSpeech.api_path_url = value; }
        }
        public static new bool requestDisposeListening
        {
            
                get { return VSpeech.requestDisposeListening; }
                set { VSpeech.requestDisposeListening = value; }
            
        }

        public static new void addImageLabel(string filename) => VSpeech.addImageLabel(filename);


        //End call from VSpeech
        public static async void startTrainData()
        {
            if(isAlreadyTrainData())
            {
                    isTrainData = true;

                    makeTSV(getPathDataset());

                    ModelBuilder.TRAIN_DATA_FILEPATH = getPathDataset() + @"\train_list_data.tsv";

                    ModelBuilder.MODEL_FILEPATH = getPathDataset() + @"\MLModel.zip";

                    await Task.Run(() => ModelBuilder.CreateModel());

             }
            

        }
        public static string getModelFilePath() => ModelBuilder.MODEL_FILEPATH;
        public static bool isStartTrain() => isTrainData;

        public static bool loadModel()
        {
            if (!Directory.Exists(temp_path_analytic)) Directory.CreateDirectory(temp_path_analytic);
            Bitmap bmp = new Bitmap(100,100);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Black);
            bmp.Save(temp_imgload_analytic);
            if(Result(temp_imgload_analytic).Length >0)
                return true;
            else
                return false;
        }

        public static bool isTrainCompleted() => isTrainData = false;
        public static string getTrainStatus() => ModelBuilder.status_train;
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
            if (!Directory.Exists(temp_path_analytic)) Directory.CreateDirectory(temp_path_analytic);
            ConsumeModel.MLNetModelPath = model;
        }

        //Khi record doi vai giay de mic bat dau thu am
        public static void StartRecord()
        {
            try
            {
                //Clear WAV temp file
                if (File.Exists(temp_wav_analytic)) File.Delete(temp_wav_analytic);
            }
            catch { }
            if (NAudio.Wave.WaveIn.DeviceCount == 0) MessageBox.Show("No audio input devices found.\n\nThis program will now exit.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                mciSendString("open new Type waveaudio Alias recsound", "", 0, 0);
                mciSendString("set recsound format tag pcm bitspersample 16 channels 1 samplespersec 44100 bytespersec 88200 alignment 2", "", 0, 0);
                mciSendString("record recsound", "", 0, 0);
            }

            
        }
        public static void StopRecord()
        {
            mciSendString("stop recsound", "", 0, 0);
            mciSendString("save recsound " + temp_wav_analytic, "", 0, 0);
            mciSendString("close recsound", "", 0, 0);
        }

        //Web API Record
        public static void WebAPIStartRecord()
        {
            try { if (File.Exists(temp_wav_analytic)) File.Delete(temp_wav_analytic); }
            catch { }

            mciSendString("open new Type waveaudio Alias recsound", "", 0, 0);
            mciSendString("set recsound format tag pcm bitspersample 16 channels 1 samplespersec 44100 bytespersec 88200 alignment 2", "", 0, 0);
            mciSendString("record recsound", "", 0, 0);

        }
        public static void WebAPIStopRecord()
        {
            mciSendString("stop recsound", "", 0, 0);
            mciSendString("save recsound " + temp_wav_analytic, "", 0, 0);
            mciSendString("close recsound", "", 0, 0);

            try { if (File.Exists(temp_image_analytic)) File.Delete(temp_image_analytic); }
            catch { }

            (double[] audio, int sampleRate) = ReadWAV(temp_wav_analytic);
            var sg = new SpectrogramGenerator(sampleRate, fftSize: 4096, stepSize: 500, maxFreq: 3000);
            sg.Add(audio);
            sg.SaveImage(temp_image_analytic);

            var image = File.ReadAllBytes(temp_image_analytic);

            postAPI(api_path_url, image);
        }
        //End
        private static void ToImageTemp()
        {
            try
            {
                //Delete temp file
                if (File.Exists(temp_image_analytic)) File.Delete(temp_image_analytic);
            }
            catch { }
                   

            (double[] audio, int sampleRate) = ReadWAV(temp_wav_analytic);

            //Sound to Spectrogram
            var sg = new SpectrogramGenerator(sampleRate, fftSize: 4096, stepSize: 500, maxFreq: 3000);

            sg.Add(audio);

            //Spectrogram to Image
            sg.SaveImage(temp_image_analytic);

            //Image to Text
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


        public static string WPFResult()
        {

            ModelInput SpeechDataset = new ModelInput()
            {
                ImageSource = temp_image_analytic,
            };

            return_label = ConsumeModel.Predict(SpeechDataset).Prediction;

            return return_label;
        }

        public static string Result(bool isSoundData=false)
        {
            //Sound wav to Spectrogram - Temp
            if (isSoundData) ToImageTemp();

            ModelInput SpeechDataset = new ModelInput()
            {
                ImageSource = temp_image_analytic,
            };

            return_label = ConsumeModel.Predict(SpeechDataset).Prediction;

            //Kiem tra khi record bang sound thi moi xoa wav
            ReleaseTemp(isSoundData); 

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

        public static void ReleaseTemp(bool isSoundData = false)
        {
            try

            {
                if (File.Exists(temp_image_analytic)) File.Delete(temp_image_analytic);

                 if ((isSoundData) && (File.Exists(temp_wav_analytic))) File.Delete(temp_wav_analytic); 
                
            } catch {
            
            }
        }

        //Xu du trainning data

        public static bool isAlreadyTrainData()
        {
            if (!String.IsNullOrEmpty(getPathDataset()))
            {
                string[] folders = Directory.GetDirectories(getPathDataset(), "*", SearchOption.TopDirectoryOnly);
                if (folders.Length <= 1) return false;
                else
                {
                    string[] images;
                    int cImg = 0;
                    for (int i = 0; i < folders.Length; i++)
                    {

                        images = Directory.GetFiles(Path.GetFullPath(folders[i].ToString()), "*.png", SearchOption.TopDirectoryOnly);

                        if (images.Length > 2) cImg++; //Kiem tra moi thu muc it nhat 2 anh

                    }
                    return (cImg == folders.Length) ? true : false;
                }

            
            } else return false;
            

        }
        private  static void makeTSV(string folder_dataset)
        { //This folder dataset
            //Lay tat ca thu muc
            string[] folders = Directory.GetDirectories(folder_dataset, "*", SearchOption.TopDirectoryOnly);

            //before your loop - chuan bi ghi file csv
            var csv = new StringBuilder();

            //in your loop
            var first = "Label";
            var second = "ImageSource";
            //Ghi dan dau
            var newLine = string.Format("{0}	{1}", first, second);
            csv.AppendLine(newLine);
            //Lay tat ca file trong tung thu muc
            for (int i = 0; i < folders.Length; i++)
            {
                //Get foldername
                string FolderName = new DirectoryInfo(Path.GetDirectoryName(folders[i].ToString() + @"\")).Name;
                //   Console.WriteLine(FolderName);
                //Get list image from folder
                string[] images = Directory.GetFiles(Path.GetFullPath(folders[i].ToString()), "*.png", SearchOption.TopDirectoryOnly);
                for (int x = 0; x < images.Length; x++)
                {
                    //Ghi vao newline
                    var newDataLine = string.Format("{0}	{1}", FolderName, images[x].ToString());

                    csv.AppendLine(newDataLine);
                    //Print path image
                }
            }
            //after your loop - save tsv
            File.WriteAllText(folder_dataset + @"\train_list_data.tsv", csv.ToString());
        }



        }
}
