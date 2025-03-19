namespace JidamVision
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageLoadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImageSaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModelNewMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModelOpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModelSaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModelSaveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.setupToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1271, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ModelNewMenuItem,
            this.ModelOpenMenuItem,
            this.ModelSaveMenuItem,
            this.ModelSaveAsMenuItem,
            this.toolStripSeparator1,
            this.ImageLoadToolStripMenuItem,
            this.ImageSaveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(55, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // ImageLoadToolStripMenuItem
            // 
            this.ImageLoadToolStripMenuItem.Name = "ImageLoadToolStripMenuItem";
            this.ImageLoadToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.ImageLoadToolStripMenuItem.Text = "Image Load";
            this.ImageLoadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // ImageSaveToolStripMenuItem
            // 
            this.ImageSaveToolStripMenuItem.Name = "ImageSaveToolStripMenuItem";
            this.ImageSaveToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.ImageSaveToolStripMenuItem.Text = "Image Save";
            this.ImageSaveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(75, 29);
            this.setupToolStripMenuItem.Text = "Setup";
            this.setupToolStripMenuItem.Click += new System.EventHandler(this.setupToolStripMenuItem_Click);
            // 
            // ModelNewMenuItem
            // 
            this.ModelNewMenuItem.Name = "ModelNewMenuItem";
            this.ModelNewMenuItem.Size = new System.Drawing.Size(270, 34);
            this.ModelNewMenuItem.Text = "Model New";
            this.ModelNewMenuItem.Click += new System.EventHandler(this.modelNewToolStripMenuItem_Click);
            // 
            // ModelOpenMenuItem
            // 
            this.ModelOpenMenuItem.Name = "ModelOpenMenuItem";
            this.ModelOpenMenuItem.Size = new System.Drawing.Size(270, 34);
            this.ModelOpenMenuItem.Text = "Model Open";
            this.ModelOpenMenuItem.Click += new System.EventHandler(this.ModelOpenMenuItem_Click);
            // 
            // ModelSaveMenuItem
            // 
            this.ModelSaveMenuItem.Name = "ModelSaveMenuItem";
            this.ModelSaveMenuItem.Size = new System.Drawing.Size(270, 34);
            this.ModelSaveMenuItem.Text = "Model Save";
            this.ModelSaveMenuItem.Click += new System.EventHandler(this.ModelSaveMenuItem_Click);
            // 
            // ModelSaveAsMenuItem
            // 
            this.ModelSaveAsMenuItem.Name = "ModelSaveAsMenuItem";
            this.ModelSaveAsMenuItem.Size = new System.Drawing.Size(270, 34);
            this.ModelSaveAsMenuItem.Text = "Model Save As";
            this.ModelSaveAsMenuItem.Click += new System.EventHandler(this.ModelSaveAsMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(267, 6);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1271, 732);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImageLoadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ImageSaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ModelNewMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ModelOpenMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ModelSaveMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ModelSaveAsMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}