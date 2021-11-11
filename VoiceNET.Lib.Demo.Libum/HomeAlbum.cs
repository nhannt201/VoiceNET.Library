using Libum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Libum
{
    public partial class HomeAlbum : Form
    {

        public int num_selct = 0;

        public HomeAlbum()
        {
            InitializeComponent();
        }

        private void HomeAlbum_Load(object sender, EventArgs e)
        {

            Properties.Settings.Default.frmNow = "home";

            Properties.Settings.Default.Save();

            pc2.Image = Image.FromFile(Application.StartupPath + @"\album1\4.jpg");

            pc4.Image = Image.FromFile(Application.StartupPath + @"\album2\3.jpg");

            pc6.Image = Image.FromFile(Application.StartupPath + @"\album3\2.jfif");

            pc8.Image = Image.FromFile(Application.StartupPath + @"\album4\4.jpg");

            num_selct = 1;

            selectAlbum();

            CenterPictureBox();


        }

         public void setNum(string command)
        {

            switch (command)
            {
                case "sangphai":

                    num_selct = (num_selct >= 4) ? 4 : num_selct += 1;

                    break;

                case "sangtrai":

                    num_selct = (num_selct <=1) ? 1 : num_selct -= 1;

                    break;

                case "mo":

                    openAlbum();

                    break;

            }

            selectAlbum();
        }
        private void openAlbum()
        {
            frmShow newS = new frmShow(num_selct);

            newS.MdiParent = MDIHome.ActiveForm;

            newS.Width = MDIHome.ActiveForm.Width - 60;

            newS.Height = MDIHome.ActiveForm.Height - 50;

            if (num_selct > 0 && num_selct <= 4)
            {

                this.Hide();

                newS.Show();

            }
        }
        public void selectAlbum()
        {
            pc1.BackColor =  pc3.BackColor = pc5.BackColor = pc7.BackColor = Color.White;
            switch (num_selct) {

                case 1:

                    pc1.BackColor = Color.Black;

                    break;

                case 2:

                    pc3.BackColor = Color.Black;

                    break;

                case 3:

                    pc5.BackColor = Color.Black;

                    break;

                case 4:

                    pc7.BackColor = Color.Black;

                    break;

            }
        }
        private void CenterPictureBox() => panel1.Location = new Point((this.Width / 2) - ((panel1.Width) / 2), (this.Height / 2) - ((panel1.Height / 2) + 60));

        private void pc2_Click(object sender, EventArgs e) => openAlbum();

        private void pc4_Click(object sender, EventArgs e) => openAlbum();

        private void pc6_Click(object sender, EventArgs e) => openAlbum();

        private void pc8_Click(object sender, EventArgs e) => openAlbum();

    }
}
