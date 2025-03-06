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
            this.imageViewer = new JidamVision.ImageViewCCtrl();
            this.btnLive = new System.Windows.Forms.Button();
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
            // imageViewer
            // 
            this.imageViewer.AutoSize = true;
            this.imageViewer.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.imageViewer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.imageViewer.Location = new System.Drawing.Point(17, 18);
            this.imageViewer.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.imageViewer.Name = "imageViewer";
            this.imageViewer.Size = new System.Drawing.Size(473, 406);
            this.imageViewer.TabIndex = 2;
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
            // CameraForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 444);
            this.Controls.Add(this.btnLive);
            this.Controls.Add(this.imageViewer);
            this.Controls.Add(this.btnGrab);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "CameraForm";
            this.Text = "CameraForm";
            this.Resize += new System.EventHandler(this.CameraForm_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGrab;
        private ImageViewCCtrl imageViewer;
        private System.Windows.Forms.Button btnLive;
    }
}