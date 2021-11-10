namespace VoiceNET.Lib
{
    partial class frmEvaluate
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEvaluate));
            this.cbDevice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbSpectrogram = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.pbAmplitude = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusPercent = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmDisposeRam = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnLoad = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbResult = new System.Windows.Forms.Label();
            this.picTake = new System.Windows.Forms.PictureBox();
            this.tmLisener = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.micValue = new System.Windows.Forms.HScrollBar();
            this.lbValueMic = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tmWaitLoad = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbSpectrogram)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pnLoad.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTake)).BeginInit();
            this.SuspendLayout();
            // 
            // cbDevice
            // 
            this.cbDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDevice.FormattingEnabled = true;
            this.cbDevice.Location = new System.Drawing.Point(18, 38);
            this.cbDevice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDevice.Name = "cbDevice";
            this.cbDevice.Size = new System.Drawing.Size(180, 28);
            this.cbDevice.TabIndex = 0;
            this.cbDevice.SelectedIndexChanged += new System.EventHandler(this.cbDevice_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Device";
            // 
            // pbSpectrogram
            // 
            this.pbSpectrogram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSpectrogram.BackColor = System.Drawing.Color.Black;
            this.pbSpectrogram.Location = new System.Drawing.Point(0, 0);
            this.pbSpectrogram.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbSpectrogram.Name = "pbSpectrogram";
            this.pbSpectrogram.Size = new System.Drawing.Size(626, 392);
            this.pbSpectrogram.TabIndex = 2;
            this.pbSpectrogram.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbAmplitude,
            this.toolStripStatusPercent});
            this.statusStrip1.Location = new System.Drawing.Point(0, 874);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1548, 32);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // pbAmplitude
            // 
            this.pbAmplitude.Name = "pbAmplitude";
            this.pbAmplitude.Size = new System.Drawing.Size(300, 24);
            this.pbAmplitude.Step = 1;
            this.pbAmplitude.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pbAmplitude.Value = 25;
            // 
            // toolStripStatusPercent
            // 
            this.toolStripStatusPercent.Name = "toolStripStatusPercent";
            this.toolStripStatusPercent.Size = new System.Drawing.Size(1221, 25);
            this.toolStripStatusPercent.Spring = true;
            this.toolStripStatusPercent.Text = "Percent";
            this.toolStripStatusPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tmDisposeRam
            // 
            this.tmDisposeRam.Interval = 1;
            this.tmDisposeRam.Tick += new System.EventHandler(this.tmDisposeRam_Tick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.pnLoad);
            this.panel1.Controls.Add(this.lbResult);
            this.panel1.Controls.Add(this.picTake);
            this.panel1.Controls.Add(this.pbSpectrogram);
            this.panel1.Location = new System.Drawing.Point(18, 80);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1512, 788);
            this.panel1.TabIndex = 10;
            // 
            // pnLoad
            // 
            this.pnLoad.BackColor = System.Drawing.Color.White;
            this.pnLoad.Controls.Add(this.label5);
            this.pnLoad.Controls.Add(this.label4);
            this.pnLoad.Location = new System.Drawing.Point(551, 204);
            this.pnLoad.Name = "pnLoad";
            this.pnLoad.Size = new System.Drawing.Size(558, 266);
            this.pnLoad.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(114, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(331, 37);
            this.label5.TabIndex = 1;
            this.label5.Text = "Evaluate Data Model";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(157, 156);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(242, 32);
            this.label4.TabIndex = 0;
            this.label4.Text = "Loading Model...";
            // 
            // lbResult
            // 
            this.lbResult.AutoSize = true;
            this.lbResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbResult.Location = new System.Drawing.Point(60, 425);
            this.lbResult.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbResult.Name = "lbResult";
            this.lbResult.Size = new System.Drawing.Size(384, 55);
            this.lbResult.TabIndex = 4;
            this.lbResult.Text = "Label Prediction";
            // 
            // picTake
            // 
            this.picTake.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picTake.BackColor = System.Drawing.Color.Black;
            this.picTake.Location = new System.Drawing.Point(0, 391);
            this.picTake.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picTake.Name = "picTake";
            this.picTake.Size = new System.Drawing.Size(626, 392);
            this.picTake.TabIndex = 5;
            this.picTake.TabStop = false;
            // 
            // tmLisener
            // 
            this.tmLisener.Tick += new System.EventHandler(this.tmLisener_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1378, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Microphone Volume";
            // 
            // micValue
            // 
            this.micValue.Location = new System.Drawing.Point(1232, 45);
            this.micValue.Name = "micValue";
            this.micValue.Size = new System.Drawing.Size(298, 17);
            this.micValue.TabIndex = 12;
            this.micValue.Scroll += new System.Windows.Forms.ScrollEventHandler(this.micValue_Scroll);
            // 
            // lbValueMic
            // 
            this.lbValueMic.AutoSize = true;
            this.lbValueMic.Location = new System.Drawing.Point(1227, 14);
            this.lbValueMic.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbValueMic.Name = "lbValueMic";
            this.lbValueMic.Size = new System.Drawing.Size(27, 20);
            this.lbValueMic.TabIndex = 13;
            this.lbValueMic.Text = "70";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(357, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(795, 32);
            this.label3.TabIndex = 14;
            this.label3.Text = "Repeat the label samples you talked about for evaluation.";
            // 
            // tmWaitLoad
            // 
            this.tmWaitLoad.Enabled = true;
            this.tmWaitLoad.Interval = 1000;
            this.tmWaitLoad.Tick += new System.EventHandler(this.tmWaitLoad_Tick);
            // 
            // frmEvaluate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1548, 906);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbValueMic);
            this.Controls.Add(this.micValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDevice);
            this.Enabled = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEvaluate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VoiceNET Library - Evaluate Data Model";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEvaluate_FormClosing);
            this.Load += new System.EventHandler(this.Evaluate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSpectrogram)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnLoad.ResumeLayout(false);
            this.pnLoad.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTake)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDevice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbSpectrogram;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar pbAmplitude;
        private System.Windows.Forms.Timer tmDisposeRam;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer tmLisener;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusPercent;
        private System.Windows.Forms.PictureBox picTake;
        private System.Windows.Forms.Label lbResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.HScrollBar micValue;
        private System.Windows.Forms.Label lbValueMic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel pnLoad;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Timer tmWaitLoad;
    }
}

