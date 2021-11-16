using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Libum
{
    public partial class MDIHome : Form
    {
        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        private const int GWL_EXSTYLE = -20;

        private const int WS_EX_CLIENTEDGE = 0x200;

        public MDIHome()
        {
            InitializeComponent();

            foreach (Control ctrl in this.Controls)
            {

                if (ctrl is MdiClient)

                {

                    //Change backround color MdiContainer

                    ctrl.BackColor = Color.White; 

                    //Change BorderStyle MDI

                    ctrl.Dock = DockStyle.None;

                    int window = GetWindowLong(ctrl.Handle, GWL_EXSTYLE);

                    window &= ~WS_EX_CLIENTEDGE;

                    SetWindowLong(ctrl.Handle, GWL_EXSTYLE, window);

                    ctrl.Dock = DockStyle.Fill;

                }
            }    
        }

        private void Home_Load(object sender, EventArgs e)
        {

            Init initt = new Init();

            initt.MdiParent = this;

            initt.Show();

        }

    }
}
