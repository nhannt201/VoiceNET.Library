using System;
using System.Windows.Forms;
using VoiceNET.Lib.ClientAPI;

namespace Winform.Recording.ClientAPI
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();

            //You need to add a command to check if the URL exists or not

            VBuilder.setApiUrl = "https://localhost:44355/VoiceNETResultLabel";

            tmGetResult.Start();

        }

        private void tmGetResult_Tick(object sender, EventArgs e)
        {

            lbResult.Text = VBuilder.WebAPIGetResult;

        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            VBuilder.StartRecord();
            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            VBuilder.StopRecord();
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

    }
}
