using System;
using System.Windows.Forms;
using VoiceNET.Lib.ClientAPI;

namespace Winform.Realtime.WebAPI
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();

            //You need to add a command to check if the URL exists or not

            VBuilder.setApiUrl = "https://localhost:44355/VoiceNETResultLabel";

            VBuilder.getDevice();

            VBuilder.WebAPIListener();

            tmGetResult.Start();

        }

        private void tmGetResult_Tick(object sender, EventArgs e)
        {

            lbResult.Text = VBuilder.WebAPIGetResult;

        }

        private void frmHome_Load(object sender, EventArgs e)
        {

        }
    }
}
