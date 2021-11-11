using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VoiceNET.Lib.MicBuilder
{
    public partial class frmTrain : Form
    {
        public int cw = 0;

        public frmTrain() => InitializeComponent();

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (cw == 0)

            {

                lbWait.Text = "Training data |";

                cw++;

            }

            else if (cw == 1)

            {

                lbWait.Text = "Training data /";

                cw++;

            }

           else if (cw == 2)

            {

                lbWait.Text = "Training data -";

                cw++;

            }

            else if (cw == 3)

            {

                lbWait.Text = "Training data \\";

                cw = 0;

            }

            lbStatus.Text = "Status: " + VBuilder.getTrainStatus();

            if (VBuilder.getTrainStatus().Contains("Completed!"))

            {

                if (Application.OpenForms.OfType<frmMicBuilder>().Count() == 1)

                {
                    Application.OpenForms.OfType<frmMicBuilder>().First().Enabled = true;

                    frmEvaluate frmEvaluate = new frmEvaluate();

                    frmEvaluate.Show();

                    this.Hide();

                    timer1.Stop();

                }

            }

        }

        private void frmTrain_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing) MessageBox.Show("Training is in progress. Please wait until it's done!", "Message Box");

            e.Cancel = true;

        }
    }
}
