using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoiceNET.Lib.WinForm.Realtime
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();

            //Auto choose default microphone device. You can set Volume with .setVolume

            VBuilder.ModelPath(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\SampleModel\MLModel.zip");

            if (VBuilder.loadModel())
            {
                tmGetResult.Start();
                VBuilder.WFListener();
            }
        }

        private void tmGetResult_Tick(object sender, EventArgs e)
        {
            lbResult.Text = VBuilder.WPFGetResult;
        }
    }
}
