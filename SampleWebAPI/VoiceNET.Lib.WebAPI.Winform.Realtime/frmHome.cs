using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VoiceNET.Lib;

namespace Winform.Realtime.WebAPI
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();

            //You can remove these bundled NuGet packages when using Web API to free up space for your application

            //Can Remove: TensorFlow.NET, NumSharp, Microsoft.ML, SciSharp.TensorFlow.Redist

            //You need to add a command to check if the URL exists or not

            VBuilder.setApiUrl = "https://localhost:44339/VoiceNETResultLabel";

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
