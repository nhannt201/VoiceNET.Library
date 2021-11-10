namespace VoiceNET.Lib.MicBuilder
{
    partial class frmMonitor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMonitor));
            this.label4 = new System.Windows.Forms.Label();
            this.btnCount = new System.Windows.Forms.Button();
            this.btnMake = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLabelPre = new System.Windows.Forms.TextBox();
            this.lbCount = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtPathDataset = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lstAdded = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(41, 335);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 36;
            this.label4.Text = "Times Added:";
            // 
            // btnCount
            // 
            this.btnCount.Location = new System.Drawing.Point(394, 320);
            this.btnCount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCount.Name = "btnCount";
            this.btnCount.Size = new System.Drawing.Size(135, 47);
            this.btnCount.TabIndex = 35;
            this.btnCount.Text = "Reset Count";
            this.btnCount.UseVisualStyleBackColor = true;
            this.btnCount.Click += new System.EventHandler(this.btnCount_Click);
            // 
            // btnMake
            // 
            this.btnMake.Location = new System.Drawing.Point(551, 320);
            this.btnMake.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnMake.Name = "btnMake";
            this.btnMake.Size = new System.Drawing.Size(170, 47);
            this.btnMake.TabIndex = 34;
            this.btnMake.Text = "Add Image Label";
            this.btnMake.UseVisualStyleBackColor = true;
            this.btnMake.Click += new System.EventHandler(this.btnMake_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 20);
            this.label3.TabIndex = 33;
            this.label3.Text = "Enter Label Name";
            // 
            // txtLabelPre
            // 
            this.txtLabelPre.Location = new System.Drawing.Point(232, 91);
            this.txtLabelPre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLabelPre.MaxLength = 255;
            this.txtLabelPre.Name = "txtLabelPre";
            this.txtLabelPre.Size = new System.Drawing.Size(422, 26);
            this.txtLabelPre.TabIndex = 32;
            // 
            // lbCount
            // 
            this.lbCount.AutoSize = true;
            this.lbCount.Location = new System.Drawing.Point(155, 333);
            this.lbCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCount.Name = "lbCount";
            this.lbCount.Size = new System.Drawing.Size(18, 20);
            this.lbCount.TabIndex = 31;
            this.lbCount.Text = "0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtPathDataset);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtLabelPre);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(34, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(687, 264);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dataset";
            // 
            // txtPathDataset
            // 
            this.txtPathDataset.Location = new System.Drawing.Point(232, 38);
            this.txtPathDataset.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPathDataset.Name = "txtPathDataset";
            this.txtPathDataset.ReadOnly = true;
            this.txtPathDataset.Size = new System.Drawing.Size(422, 26);
            this.txtPathDataset.TabIndex = 34;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 41);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 35;
            this.label1.Text = "Path Dataset";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(232, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(404, 80);
            this.label2.TabIndex = 36;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lstAdded);
            this.groupBox2.Location = new System.Drawing.Point(34, 375);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(687, 264);
            this.groupBox2.TabIndex = 38;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Image Label Added";
            // 
            // lstAdded
            // 
            this.lstAdded.FormattingEnabled = true;
            this.lstAdded.HorizontalScrollbar = true;
            this.lstAdded.ItemHeight = 20;
            this.lstAdded.Location = new System.Drawing.Point(19, 35);
            this.lstAdded.Name = "lstAdded";
            this.lstAdded.Size = new System.Drawing.Size(648, 204);
            this.lstAdded.TabIndex = 0;
            // 
            // frmMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 663);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCount);
            this.Controls.Add(this.btnMake);
            this.Controls.Add(this.lbCount);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMonitor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VoiceNET Library - Monitor";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmMonitor_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCount;
        private System.Windows.Forms.Button btnMake;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLabelPre;
        private System.Windows.Forms.Label lbCount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPathDataset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstAdded;
    }
}