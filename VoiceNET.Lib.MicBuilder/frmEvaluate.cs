using NAudio.Mixer;
using Spectrogram;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoiceNET.Lib
{
    public partial class frmEvaluate : Form
    {
        public frmEvaluate()
        {
            InitializeComponent();
            
            VBuilder.getDevice(cbDevice);

            VBuilder.setVolume(80);

            lbValueMic.Text = VBuilder.getVolume().ToString();

            micValue.Value = VBuilder.getVolume();

            micValue.LargeChange = 1; 

        }

        private void Evaluate_Load(object sender, EventArgs e) => VBuilder.ModelPath(VBuilder.getModelFilePath());
        private void cbDevice_SelectedIndexChanged(object sender, EventArgs e) => StartListening();

        private void StartListening()
        {
            DisposeImage();

            VBuilder.StartListening( cbDevice);
          
        }
        public void DisposeImage() {

            pbSpectrogram.Image?.Dispose();

            pbSpectrogram.Image = null;

        }

        private void tmDisposeRam_Tick(object sender, EventArgs e)
        {
            DisposeImage();

            pbSpectrogram.Image = VBuilder.ListenTimer(pbSpectrogram.Width);

            pbAmplitude.Value = VBuilder.getAmplitude;

            toolStripStatusPercent.Text = VBuilder.getAmplitude.ToString();
        }


     
 
        private void tmLisener_Tick(object sender, EventArgs e)
        {
         if(VBuilder.requestDisposeListening)
            {
                picTake.Image = VBuilder.getImageTaken(pbSpectrogram);

                lbResult.Text = VBuilder.Result();

                StartListening(); //Renew Lisener

                VBuilder.requestDisposeListening = false;

            } else
            {

                VBuilder.reduceNoiseAndCapture(pbSpectrogram);

            }

            
        }

        private void micValue_Scroll(object sender, ScrollEventArgs e)
        {

            VBuilder.setVolume ( micValue.Value);

            lbValueMic.Text = micValue.Value.ToString();
        }

        private void frmEvaluate_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {

                VBuilder.isTrainCompleted();

            }
        }

        private void tmWaitLoad_Tick(object sender, EventArgs e)
        {
            if(VBuilder.loadModel())
            {
                pnLoad.Visible = false;

                tmDisposeRam.Start();

                tmLisener.Start();

                this.Enabled = true;

                tmWaitLoad.Stop();
            }
        }
    }
}
