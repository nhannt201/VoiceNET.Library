using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoiceNET.Lib.MicBuilder
{
    public partial class frmMicBuilder : Form
    {
        public frmMicBuilder()
        {
            InitializeComponent();
            VBuilder.getDevice(cbDevice);
            VBuilder.setVolume(80);
            lbValueMic.Text = VBuilder.getVolume().ToString();
            micValue.Value = VBuilder.getVolume();
            micValue.LargeChange = 1; //Cho phep nguoi dung chon den maxium


        }

        private void MicBuilder_Load(object sender, EventArgs e)
        {

        }
        private void cbDevice_SelectedIndexChanged(object sender, EventArgs e) => StartListening();


        private void StartListening()
        {
            pbSpectrogram.Image?.Dispose();
            pbSpectrogram.Image = null;
            VBuilder.StartListening(cbDevice);

        }


        public void DisposeImage()
        {
            pbSpectrogram.Image?.Dispose();
        }

        private void tmDisposeRam_Tick(object sender, EventArgs e)
        {
            if(!VBuilder.isStartTrain())
            {
                DisposeImage();
                pbSpectrogram.Image = VBuilder.ListenTimer(pbSpectrogram.Width);
                pbAmplitude.Value = VBuilder.getAmplitude;
                toolStripStatusPercent.Text = VBuilder.getAmplitude.ToString();
            }    
        }



        private void tmLisener_Tick(object sender, EventArgs e)
        {
            if (!VBuilder.isStartTrain())
            {
                if (VBuilder.requestDisposeListening)
                {
                    picTake.Image = VBuilder.getImageTaken(pbSpectrogram);

                    StartListening(); //Renew Lisener

                    VBuilder.requestDisposeListening = false;
                }
                else
                {
                    VBuilder.reduceNoiseAndCapture(pbSpectrogram, true);
                }
            }



        }

        private void micValue_Scroll(object sender, ScrollEventArgs e)
        {

            VBuilder.setVolume(micValue.Value);

            lbValueMic.Text = micValue.Value.ToString();
        }


        private void btnSetting_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms.OfType<frmConfig>().Count() == 1) 
                
                Application.OpenForms.OfType<frmConfig>().First().Show();   
            
            else
            
                new frmConfig().Show();
            
        }

        private void btnMonitor_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms.OfType<frmMonitor>().Count() == 1)

                Application.OpenForms.OfType<frmMonitor>().First().Show();

            else

                new frmMonitor().Show();

        }

        private void btnTrain_Click(object sender, EventArgs e)
        {
            if (VBuilder.isAlreadyTrainData())
            {
                VBuilder.startTrainData();
                new frmTrain().Show();
            }
            else
            {
                MessageBox.Show("Not ready to start data Train yet. Review:\n-Set up dataset folder\n- Make sure there are at least 2 sub - folder labels and each sub - folder label has at least 2 images.", "MessageBox");
            }
            
        }
    }
}
