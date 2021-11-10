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
using VoiceNET.Lib;

namespace Libum
{
    public partial class LibumListener : Form
    {
         string returnLabel = "";
        public LibumListener()
        {
            InitializeComponent();
            
            VBuilder.getDevice(cbDevice);
            VBuilder.setVolume(80);
            lbValueMic.Text = VBuilder.getVolume().ToString();
            micValue.Value = VBuilder.getVolume();
            micValue.LargeChange = 1; //Cho phep nguoi dung chon den maxium

        }

        private void Form1_Load(object sender, EventArgs e) {

        }
        private void cbDevice_SelectedIndexChanged(object sender, EventArgs e) => StartListening();


        private void StartListening()
        {
            pbSpectrogram.Image?.Dispose();
            pbSpectrogram.Image = null;
            VBuilder.StartListening( cbDevice);
          
        }
        public void DisposeImage() {
            pbSpectrogram.Image?.Dispose();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Giai phong bo nho
            DisposeImage();
            pbSpectrogram.Image = VBuilder.ListenTimer(pbSpectrogram.Width);
            pbAmplitude.Value = VBuilder.getAmplitude;
            toolStripStatusPercent.Text = VBuilder.getAmplitude.ToString();
        }


        private void checkReturn()
        {
            if (Libum.Properties.Settings.Default.frmNow == "home")
            {
                var HomeAl = Application.OpenForms.OfType<HomeAlbum>().Single();
                HomeAl.setNum(returnLabel);
            }
            if ( Libum.Properties.Settings.Default.frmNow == "show")
            {
                var frmShow = Application.OpenForms.OfType<frmShow>().Single();
                frmShow.setAction(returnLabel);
            }
            // MessageBox.Show("endCheckReturn");
        }

 
        private void timer2_Tick(object sender, EventArgs e)
        {
         if(VBuilder.requestDisposeListening)
            {
                picTake.Image = VBuilder.getImageTaken(pbSpectrogram);

                returnLabel = VBuilder.Result();

                lbResult.Text = returnLabel;

                checkReturn(); //Tra lenh ve form nhan

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


    }
}
