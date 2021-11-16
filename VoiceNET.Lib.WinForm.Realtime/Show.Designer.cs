
namespace Libum
{
    partial class frmShow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmShow));
            this.picShow = new System.Windows.Forms.PictureBox();
            this.picRotate = new System.Windows.Forms.PictureBox();
            this.picZoomIn = new System.Windows.Forms.PictureBox();
            this.picZoomOut = new System.Windows.Forms.PictureBox();
            this.picPre = new System.Windows.Forms.PictureBox();
            this.picNext = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRotate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZoomIn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZoomOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPre)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNext)).BeginInit();
            this.SuspendLayout();
            // 
            // picShow
            // 
            this.picShow.BackColor = System.Drawing.Color.Transparent;
            this.picShow.Location = new System.Drawing.Point(271, 103);
            this.picShow.Name = "picShow";
            this.picShow.Size = new System.Drawing.Size(642, 411);
            this.picShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picShow.TabIndex = 0;
            this.picShow.TabStop = false;
            // 
            // picRotate
            // 
            this.picRotate.BackColor = System.Drawing.Color.Transparent;
            this.picRotate.Image = ((System.Drawing.Image)(resources.GetObject("picRotate.Image")));
            this.picRotate.Location = new System.Drawing.Point(534, 646);
            this.picRotate.Name = "picRotate";
            this.picRotate.Size = new System.Drawing.Size(45, 40);
            this.picRotate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picRotate.TabIndex = 7;
            this.picRotate.TabStop = false;
            this.picRotate.Click += new System.EventHandler(this.picRotate_Click);
            // 
            // picZoomIn
            // 
            this.picZoomIn.BackColor = System.Drawing.Color.Transparent;
            this.picZoomIn.Image = ((System.Drawing.Image)(resources.GetObject("picZoomIn.Image")));
            this.picZoomIn.Location = new System.Drawing.Point(399, 646);
            this.picZoomIn.Name = "picZoomIn";
            this.picZoomIn.Size = new System.Drawing.Size(45, 40);
            this.picZoomIn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picZoomIn.TabIndex = 8;
            this.picZoomIn.TabStop = false;
            this.picZoomIn.Click += new System.EventHandler(this.picZoomIn_Click);
            // 
            // picZoomOut
            // 
            this.picZoomOut.BackColor = System.Drawing.Color.Transparent;
            this.picZoomOut.Image = ((System.Drawing.Image)(resources.GetObject("picZoomOut.Image")));
            this.picZoomOut.Location = new System.Drawing.Point(707, 646);
            this.picZoomOut.Name = "picZoomOut";
            this.picZoomOut.Size = new System.Drawing.Size(49, 40);
            this.picZoomOut.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picZoomOut.TabIndex = 9;
            this.picZoomOut.TabStop = false;
            this.picZoomOut.Click += new System.EventHandler(this.picZoomOut_Click);
            // 
            // picPre
            // 
            this.picPre.BackColor = System.Drawing.Color.Transparent;
            this.picPre.Image = ((System.Drawing.Image)(resources.GetObject("picPre.Image")));
            this.picPre.Location = new System.Drawing.Point(3, 261);
            this.picPre.Name = "picPre";
            this.picPre.Size = new System.Drawing.Size(37, 55);
            this.picPre.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPre.TabIndex = 10;
            this.picPre.TabStop = false;
            this.picPre.Click += new System.EventHandler(this.picPre_Click);
            // 
            // picNext
            // 
            this.picNext.BackColor = System.Drawing.Color.Transparent;
            this.picNext.Image = ((System.Drawing.Image)(resources.GetObject("picNext.Image")));
            this.picNext.Location = new System.Drawing.Point(115, 261);
            this.picNext.Name = "picNext";
            this.picNext.Size = new System.Drawing.Size(37, 55);
            this.picNext.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNext.TabIndex = 11;
            this.picNext.TabStop = false;
            this.picNext.Click += new System.EventHandler(this.picNext_Click);
            // 
            // frmShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1139, 693);
            this.Controls.Add(this.picNext);
            this.Controls.Add(this.picPre);
            this.Controls.Add(this.picZoomOut);
            this.Controls.Add(this.picZoomIn);
            this.Controls.Add(this.picRotate);
            this.Controls.Add(this.picShow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmShow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Show Album";
            this.Load += new System.EventHandler(this.frmShow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRotate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZoomIn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picZoomOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPre)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picNext)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picShow;
        private System.Windows.Forms.PictureBox picRotate;
        private System.Windows.Forms.PictureBox picZoomIn;
        private System.Windows.Forms.PictureBox picZoomOut;
        private System.Windows.Forms.PictureBox picPre;
        private System.Windows.Forms.PictureBox picNext;
    }
}