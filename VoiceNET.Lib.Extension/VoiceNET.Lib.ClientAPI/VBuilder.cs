namespace VoiceNET.Lib.ClientAPI
{

    public class VBuilder : VSpeech
    {
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

        }
}
