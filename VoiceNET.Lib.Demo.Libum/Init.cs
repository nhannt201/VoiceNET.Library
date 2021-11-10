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
using VoiceNET.Lib;

namespace Libum
{
    public partial class Init : Form
    {
        public Init()
        {
            InitializeComponent();
        }

        private void Init_Load(object sender, EventArgs e)
        {
            VBuilder.ModelPath(Path.GetFullPath("MLModel.zip"));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (VBuilder.loadModel())
            {
                
                HomeAlbum home = new HomeAlbum();
                home.MdiParent = MDIHome.ActiveForm;
                home.Width = MDIHome.ActiveForm.Width - 60;
                home.Height = MDIHome.ActiveForm.Height - 80;
                home.Show();


                LibumListener formz = new LibumListener();
                formz.MdiParent = MDIHome.ActiveForm;
                formz.Show();
                formz.Hide();
            } else
            {
                MessageBox.Show("Load Model failed. Please try again!", "MessageBox");
                Close();
            }
            this.Hide();
            timer1.Stop();

        }
    }
}
