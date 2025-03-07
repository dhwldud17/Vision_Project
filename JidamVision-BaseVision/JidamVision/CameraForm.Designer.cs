namespace JidamVision
{
    partial class CameraForm
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
            this.btnGrab = new System.Windows.Forms.Button();
            this.btnLive = new System.Windows.Forms.Button();
            this.grbChannel = new System.Windows.Forms.GroupBox();
            this.rbtRed = new System.Windows.Forms.RadioButton();
            this.rbtBlue = new System.Windows.Forms.RadioButton();
            this.rbtGreen = new System.Windows.Forms.RadioButton();
            this.rbtGray = new System.Windows.Forms.RadioButton();
            this.imageViewer = new JidamVision.ImageViewCCtrl();
            this.grbChannel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGrab
            // 
            this.btnGrab.Location = new System.Drawing.Point(500, 18);
            this.btnGrab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGrab.Name = "btnGrab";
            this.btnGrab.Size = new System.Drawing.Size(107, 34);
            this.btnGrab.TabIndex = 1;
            this.btnGrab.Text = "Grab";
            this.btnGrab.UseVisualStyleBackColor = true;
            this.btnGrab.Click += new System.EventHandler(this.btnGrab_Click);
            // 
            // btnLive
            // 
            this.btnLive.Location = new System.Drawing.Point(500, 71);
            this.btnLive.Margin = new System.Windows.Forms.Padding(4);
            this.btnLive.Name = "btnLive";
            this.btnLive.Size = new System.Drawing.Size(107, 34);
            this.btnLive.TabIndex = 3;
            this.btnLive.Text = "Live";
            this.btnLive.UseVisualStyleBackColor = true;
            this.btnLive.Click += new System.EventHandler(this.btnLive_Click);
            // 
            // grbChannel
            // 
            this.grbChannel.Controls.Add(this.rbtGray);
            this.grbChannel.Controls.Add(this.rbtGreen);
            this.grbChannel.Controls.Add(this.rbtBlue);
            this.grbChannel.Controls.Add(this.rbtRed);
            this.grbChannel.Location = new System.Drawing.Point(499, 152);
            this.grbChannel.Name = "grbChannel";
            this.grbChannel.Size = new System.Drawing.Size(158, 183);
            this.grbChannel.TabIndex = 4;
            this.grbChannel.TabStop = false;
            this.grbChannel.Text = "Channel";
            // 
            // rbtRed
            // 
            this.rbtRed.AutoSize = true;
            this.rbtRed.Location = new System.Drawing.Point(7, 28);
            this.rbtRed.Name = "rbtRed";
            this.rbtRed.Size = new System.Drawing.Size(64, 22);
            this.rbtRed.TabIndex = 0;
            this.rbtRed.TabStop = true;
            this.rbtRed.Text = "Red";
            this.rbtRed.UseVisualStyleBackColor = true;
            // 
            // rbtBlue
            // 
            this.rbtBlue.AutoSize = true;
            this.rbtBlue.Location = new System.Drawing.Point(6, 66);
            this.rbtBlue.Name = "rbtBlue";
            this.rbtBlue.Size = new System.Drawing.Size(67, 22);
            this.rbtBlue.TabIndex = 1;
            this.rbtBlue.TabStop = true;
            this.rbtBlue.Text = "Blue";
            this.rbtBlue.UseVisualStyleBackColor = true;
            // 
            // rbtGreen
            // 
            this.rbtGreen.AutoSize = true;
            this.rbtGreen.Location = new System.Drawing.Point(7, 107);
            this.rbtGreen.Name = "rbtGreen";
            this.rbtGreen.Size = new System.Drawing.Size(81, 22);
            this.rbtGreen.TabIndex = 2;
            this.rbtGreen.TabStop = true;
            this.rbtGreen.Text = "Green";
            this.rbtGreen.UseVisualStyleBackColor = true;
            // 
            // rbtGray
            // 
            this.rbtGray.AutoSize = true;
            this.rbtGray.Location = new System.Drawing.Point(7, 146);
            this.rbtGray.Name = "rbtGray";
            this.rbtGray.Size = new System.Drawing.Size(71, 22);
            this.rbtGray.TabIndex = 3;
            this.rbtGray.TabStop = true;
            this.rbtGray.Text = "Gray";
            this.rbtGray.UseVisualStyleBackColor = true;
            // 
            // imageViewer
            // 
            this.imageViewer.AutoSize = true;
            this.imageViewer.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.imageViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imageViewer.Location = new System.Drawing.Point(17, 18);
            this.imageViewer.Margin = new System.Windows.Forms.Padding(6);
            this.imageViewer.Name = "imageViewer";
            this.imageViewer.Size = new System.Drawing.Size(473, 406);
            this.imageViewer.TabIndex = 2;
            // 
            // CameraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 444);
            this.Controls.Add(this.grbChannel);
            this.Controls.Add(this.btnLive);
            this.Controls.Add(this.imageViewer);
            this.Controls.Add(this.btnGrab);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CameraForm";
            this.Text = "CameraForm";
            this.Load += new System.EventHandler(this.CameraForm_Load);
            this.Resize += new System.EventHandler(this.CameraForm_Resize);
            this.grbChannel.ResumeLayout(false);
            this.grbChannel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGrab;
        private ImageViewCCtrl imageViewer;
        private System.Windows.Forms.Button btnLive;
        private System.Windows.Forms.GroupBox grbChannel;
        private System.Windows.Forms.RadioButton rbtGray;
        private System.Windows.Forms.RadioButton rbtGreen;
        private System.Windows.Forms.RadioButton rbtBlue;
        private System.Windows.Forms.RadioButton rbtRed;
    }
}