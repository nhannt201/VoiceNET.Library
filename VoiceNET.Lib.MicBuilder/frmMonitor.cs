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
    public partial class frmMonitor : Form
    {
        public frmMonitor()
        {
            InitializeComponent();
            txtPathDataset.Text = VBuilder.getPathDataset();
           
        }
        int cAdd = 0;
        private void btnMake_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(VBuilder.getPathDataset()))
            {
                MessageBox.Show("You cannot use this feature without first setting up a dataset. Please select the dataset folder in the settings section.", "MessageBox");
            }
            else
            {
                if ((!String.IsNullOrEmpty(txtLabelPre.Text)) && (txtLabelPre.Text.Length) < 255)
                {
                    if (!lstAdded.Items.Contains(txtLabelPre.Text))
                    {
                        lstAdded.Items.Add(txtLabelPre.Text);
                    }
                    cAdd++;
                    lbCount.Text = cAdd.ToString();
                    VBuilder.addImageLabel(txtLabelPre.Text);
                }
                else
                {
                    MessageBox.Show("Please enter a label name (max length of 255 characters)!", "MeseageBox");
                }
            }
        }


        private void btnCount_Click(object sender, EventArgs e)
        {
            cAdd = 0;
            lbCount.Text = "0";
        }

        private void frmMonitor_Load(object sender, EventArgs e)
        {
           
        }
    }
}
