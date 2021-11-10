namespace VoiceNET.Lib.MicBuilder
{
    partial class frmMicBuilder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMicBuilder));
            this.cbDevice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pbSpectrogram = new System.Windows.Forms.PictureBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.pbAmplitude = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusPercent = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmDisposeRam = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbCapture = new System.Windows.Forms.Label();
            this.picTake = new System.Windows.Forms.PictureBox();
            this.tmLisener = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.micValue = new System.Windows.Forms.HScrollBar();
            this.lbValueMic = new System.Windows.Forms.Label();
            this.lbPercent = new System.Windows.Forms.Label();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnMonitor = new System.Windows.Forms.Button();
            this.btnTrain = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbSpectrogram)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTake)).BeginInit();
            this.SuspendLayout();
            // 
            // cbDevice
            // 
            this.cbDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDevice.FormattingEnabled = true;
            this.cbDevice.Location = new System.Drawing.Point(495, 35);
            this.cbDevice.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbDevice.Name = "cbDevice";
            this.cbDevice.Size = new System.Drawing.Size(224, 28);
            this.cbDevice.TabIndex = 0;
            this.cbDevice.SelectedIndexChanged += new System.EventHandler(this.cbDevice_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(491, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Microphone Device";
            // 
            // pbSpectrogram
            // 
            this.pbSpectrogram.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pbSpectrogram.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pbSpectrogram.Location = new System.Drawing.Point(0, 0);
            this.pbSpectrogram.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pbSpectrogram.Name = "pbSpectrogram";
            this.pbSpectrogram.Size = new System.Drawing.Size(994, 392);
            this.pbSpectrogram.TabIndex = 2;
            this.pbSpectrogram.TabStop = false;
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pbAmplitude,
            this.toolStripStatusPercent});
            this.statusStrip.Location = new System.Drawing.Point(0, 874);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.statusStrip.Size = new System.Drawing.Size(1859, 32);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
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
            this.toolStripStatusPercent.Size = new System.Drawing.Size(1532, 25);
            this.toolStripStatusPercent.Spring = true;
            this.toolStripStatusPercent.Text = "Percent";
            this.toolStripStatusPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tmDisposeRam
            // 
            this.tmDisposeRam.Enabled = true;
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
            this.panel1.Controls.Add(this.lbCapture);
            this.panel1.Controls.Add(this.picTake);
            this.panel1.Controls.Add(this.pbSpectrogram);
            this.panel1.Location = new System.Drawing.Point(18, 80);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1828, 788);
            this.panel1.TabIndex = 10;
            // 
            // lbCapture
            // 
            this.lbCapture.AutoSize = true;
            this.lbCapture.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCapture.Location = new System.Drawing.Point(60, 425);
            this.lbCapture.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCapture.Name = "lbCapture";
            this.lbCapture.Size = new System.Drawing.Size(242, 55);
            this.lbCapture.TabIndex = 4;
            this.lbCapture.Text = "Capturing";
            // 
            // picTake
            // 
            this.picTake.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picTake.BackColor = System.Drawing.SystemColors.ControlDark;
            this.picTake.Location = new System.Drawing.Point(0, 391);
            this.picTake.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.picTake.Name = "picTake";
            this.picTake.Size = new System.Drawing.Size(1876, 392);
            this.picTake.TabIndex = 5;
            this.picTake.TabStop = false;
            // 
            // tmLisener
            // 
            this.tmLisener.Enabled = true;
            this.tmLisener.Tick += new System.EventHandler(this.tmLisener_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(749, 11);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "Microphone Volume";
            // 
            // micValue
            // 
            this.micValue.Location = new System.Drawing.Point(749, 35);
            this.micValue.Name = "micValue";
            this.micValue.Size = new System.Drawing.Size(298, 28);
            this.micValue.TabIndex = 12;
            this.micValue.Scroll += new System.Windows.Forms.ScrollEventHandler(this.micValue_Scroll);
            // 
            // lbValueMic
            // 
            this.lbValueMic.AutoSize = true;
            this.lbValueMic.Location = new System.Drawing.Point(992, 11);
            this.lbValueMic.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbValueMic.Name = "lbValueMic";
            this.lbValueMic.Size = new System.Drawing.Size(27, 20);
            this.lbValueMic.TabIndex = 13;
            this.lbValueMic.Text = "70";
            // 
            // lbPercent
            // 
            this.lbPercent.AutoSize = true;
            this.lbPercent.Location = new System.Drawing.Point(1024, 12);
            this.lbPercent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPercent.Name = "lbPercent";
            this.lbPercent.Size = new System.Drawing.Size(23, 20);
            this.lbPercent.TabIndex = 14;
            this.lbPercent.Text = "%";
            // 
            // btnSetting
            // 
            this.btnSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetting.Location = new System.Drawing.Point(18, 12);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(209, 51);
            this.btnSetting.TabIndex = 15;
            this.btnSetting.Text = "&Setting";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnMonitor
            // 
            this.btnMonitor.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMonitor.Location = new System.Drawing.Point(248, 12);
            this.btnMonitor.Name = "btnMonitor";
            this.btnMonitor.Size = new System.Drawing.Size(209, 51);
            this.btnMonitor.TabIndex = 16;
            this.btnMonitor.Text = "&Monitor";
            this.btnMonitor.UseVisualStyleBackColor = true;
            this.btnMonitor.Click += new System.EventHandler(this.btnMonitor_Click);
            // 
            // btnTrain
            // 
            this.btnTrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrain.Location = new System.Drawing.Point(1105, 12);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(209, 51);
            this.btnTrain.TabIndex = 17;
            this.btnTrain.Text = "&Train Data";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // frmMicBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1859, 906);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.btnMonitor);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.lbPercent);
            this.Controls.Add(this.lbValueMic);
            this.Controls.Add(this.micValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDevice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "frmMicBuilder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VoiceNET Library - MicBuilder";
            this.Load += new System.EventHandler(this.MicBuilder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbSpectrogram)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picTake)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDevice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbSpectrogram;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar pbAmplitude;
        private System.Windows.Forms.Timer tmDisposeRam;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer tmLisener;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusPercent;
        private System.Windows.Forms.PictureBox picTake;
        private System.Windows.Forms.Label lbCapture;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.HScrollBar micValue;
        private System.Windows.Forms.Label lbValueMic;
        private System.Windows.Forms.Label lbPercent;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnMonitor;
        private System.Windows.Forms.Button btnTrain;
    }
}

