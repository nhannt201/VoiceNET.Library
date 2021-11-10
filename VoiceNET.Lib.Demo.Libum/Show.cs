using Libum;
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

namespace Libum
{
    public partial class frmShow : Form
    {
        int num_al;// = FollowForm.album_num;
        int num_max = 0;
        int num_now = 0;
        string[] album;
        string[] album1 = Directory.GetFiles(Application.StartupPath + @"\album1\", "*.*", SearchOption.TopDirectoryOnly);
        string[] album2 = Directory.GetFiles(Application.StartupPath + @"\album2\", "*.*", SearchOption.TopDirectoryOnly);
        string[] album3 = Directory.GetFiles(Application.StartupPath + @"\album3\", "*.*", SearchOption.TopDirectoryOnly);
        string[] album4 = Directory.GetFiles(Application.StartupPath + @"\album4\", "*.*", SearchOption.TopDirectoryOnly);

        //Dèault Zoom
        int picDW = 642;
        int picDH = 455;

        //Full Zoom
        int picFW = frmShow.ActiveForm.Width - 50;
        int picFH = frmShow.ActiveForm.Height - 50;
        public frmShow(int num_als)
        {
            num_al = num_als;
            InitializeComponent();
            initAl();
        }

        private void initAl()
        {
            switch (num_al)
            {
                case 1:
                    num_max = album1.Length;
                    album = album1;
                    break;
                case 2:
                    num_max = album2.Length;
                    album = album2;
                    break;
                case 3:
                    num_max = album3.Length;
                    album = album3;
                    break;
                case 4:
                    num_max = album4.Length;
                    album = album4;
                    break;
            }
        }
        Bitmap bitmap1;
        private void frmShow_Load(object sender, EventArgs e)
        {
            //https://docs.microsoft.com/en-us/dotnet/api/system.drawing.image.rotateflip?view=net-5.0
            //Xoay hoac lat hinh anh
            picShow.Width = picDW;
            picShow.Height = picDH;
            Libum.Properties.Settings.Default.frmNow = "show";
            Libum.Properties.Settings.Default.Save();
            if (num_max >0)
            {
               // picShow.Image = Image.FromFile(album[0].ToString());
                bitmap1 = (Bitmap)Bitmap.FromFile((album[0].ToString()));
                //picShow.SizeMode = PictureBoxSizeMode.AutoSize;
                picShow.Image = bitmap1;
                CenterPictureBox();
            }
            picRotate.Location = new Point((this.Width / 2) - (picRotate.Width / 2)-100, this.Height - picRotate.Height);
            picZoomIn.Location = new Point((this.Width / 2) - (picZoomIn.Width / 2), this.Height - picZoomIn.Height);
            picZoomOut.Location = new Point((this.Width / 2) - (picZoomOut.Width / 2) + 100, this.Height - picZoomOut.Height);

            picNext.Location = new Point((this.Width) - (picNext.Width), picNext.Location.Y);



        }

        private void CenterPictureBox()
        {
            picShow.Location = new Point((this.Width / 2) - ((picShow.Width) / 2), (this.Height / 2) - ((picShow.Height / 2) +60));

        }

        private void Zoom() {
            picShow.Width = picFW;
            picShow.Height = picFH;
            CenterPictureBox();
        }

        private void ThuNho()
        {
            picShow.Width = picDW;
            picShow.Height = picDH;
            CenterPictureBox();
        }

        private void XoayAnh()
        {
            bitmap1.RotateFlip(RotateFlipType.Rotate90FlipXY);
            picShow.Image = bitmap1;
        }
        private void Pre()
        {
            num_now -= 1;
            if (num_now >= 0)
            {
                bitmap1 = (Bitmap)Bitmap.FromFile((album[num_now].ToString()));
                picShow.Image = bitmap1;
                picNext.Visible = true;
                picPre.Visible = true;

            }
            else
            {
                num_now = 0;
                picNext.Visible = true;
                picPre.Visible = false;
            }
        }

        private void Next()
        {
            num_now += 1;
            if (num_now < num_max)
            {
                bitmap1 = (Bitmap)Bitmap.FromFile((album[num_now].ToString()));
                picShow.Image = bitmap1;
                picNext.Visible = true;
                picPre.Visible = true;

            } else
            {
                num_now = num_max;
                picNext.Visible = false;
                picPre.Visible = true;
            }
        }

        public void setAction(string command)
        {

            switch (command)
            {
                case "tientoi":
                    Next();
                    break;
                case "luilai":
                    Pre();
                    break;
                case "xoayanh":
                    XoayAnh();
                    break;
                case "phongto":
                    Zoom();
                    break;
                case "thunho":
                    ThuNho();
                    break;
                case "vetrangchu":
                    Properties.Settings.Default.frmNow = "home";
                    Properties.Settings.Default.Save();
                    HomeAlbum home = new HomeAlbum();
                    home.MdiParent = MDIHome.ActiveForm;
                    home.Width = MDIHome.ActiveForm.Width - 60;
                    home.Height = MDIHome.ActiveForm.Height - 80;
                    home.Show();

                    this.Hide();
                    break;
            }
        }

     

        private void picZoomIn_Click(object sender, EventArgs e)
        {
            Zoom();
        }

        private void picRotate_Click(object sender, EventArgs e)
        {
            XoayAnh();
        }

        private void picZoomOut_Click(object sender, EventArgs e)
        {
            ThuNho();
        }

        private void picPre_Click(object sender, EventArgs e)
        {
            Pre();
        }

        private void picNext_Click(object sender, EventArgs e)
        {
            Next();
        }
    }
}
