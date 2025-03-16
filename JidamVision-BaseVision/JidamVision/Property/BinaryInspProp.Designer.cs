namespace JidamVision.Property
{
    partial class BinaryInspProp
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
                if (trackBarLower != null)
                    trackBarLower.ValueChanged -= OnValueChanged;

                if (trackBarUpper != null)
                    trackBarUpper.ValueChanged -= OnValueChanged;

                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpBinary = new System.Windows.Forms.GroupBox();
            this.chkShowBinary = new System.Windows.Forms.CheckBox();
            this.chkInvert = new System.Windows.Forms.CheckBox();
            this.chkHighlight = new System.Windows.Forms.CheckBox();
            this.trackBarUpper = new System.Windows.Forms.TrackBar();
            this.trackBarLower = new System.Windows.Forms.TrackBar();
            this.grpFilter = new System.Windows.Forms.GroupBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.txtArea_min = new System.Windows.Forms.TextBox();
            this.lbArea = new System.Windows.Forms.Label();
            this.txtArea_max = new System.Windows.Forms.TextBox();
            this.lbHeight = new System.Windows.Forms.Label();
            this.lbWidth = new System.Windows.Forms.Label();
            this.lbMin = new System.Windows.Forms.Label();
            this.lbMax = new System.Windows.Forms.Label();
            this.txtHeight_min = new System.Windows.Forms.TextBox();
            this.txtWidth_min = new System.Windows.Forms.TextBox();
            this.txtHeight_max = new System.Windows.Forms.TextBox();
            this.txtWidth_max = new System.Windows.Forms.TextBox();
            this.grpBinary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarUpper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLower)).BeginInit();
            this.grpFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBinary
            // 
            this.grpBinary.Controls.Add(this.chkShowBinary);
            this.grpBinary.Controls.Add(this.chkInvert);
            this.grpBinary.Controls.Add(this.chkHighlight);
            this.grpBinary.Controls.Add(this.trackBarUpper);
            this.grpBinary.Controls.Add(this.trackBarLower);
            this.grpBinary.Location = new System.Drawing.Point(4, 4);
            this.grpBinary.Margin = new System.Windows.Forms.Padding(4);
            this.grpBinary.Name = "grpBinary";
            this.grpBinary.Padding = new System.Windows.Forms.Padding(4);
            this.grpBinary.Size = new System.Drawing.Size(357, 258);
            this.grpBinary.TabIndex = 0;
            this.grpBinary.TabStop = false;
            this.grpBinary.Text = "이진화";
            // 
            // chkShowBinary
            // 
            this.chkShowBinary.AutoSize = true;
            this.chkShowBinary.Location = new System.Drawing.Point(179, 188);
            this.chkShowBinary.Margin = new System.Windows.Forms.Padding(4);
            this.chkShowBinary.Name = "chkShowBinary";
            this.chkShowBinary.Size = new System.Drawing.Size(88, 22);
            this.chkShowBinary.TabIndex = 5;
            this.chkShowBinary.Text = "이진화";
            this.chkShowBinary.UseVisualStyleBackColor = true;
            this.chkShowBinary.CheckedChanged += new System.EventHandler(this.chkBinaryOnly_CheckedChanged);
            // 
            // chkInvert
            // 
            this.chkInvert.AutoSize = true;
            this.chkInvert.Location = new System.Drawing.Point(33, 222);
            this.chkInvert.Margin = new System.Windows.Forms.Padding(4);
            this.chkInvert.Name = "chkInvert";
            this.chkInvert.Size = new System.Drawing.Size(70, 22);
            this.chkInvert.TabIndex = 4;
            this.chkInvert.Text = "반전";
            this.chkInvert.UseVisualStyleBackColor = true;
            this.chkInvert.CheckedChanged += new System.EventHandler(this.chkInvert_CheckedChanged);
            // 
            // chkHighlight
            // 
            this.chkHighlight.AutoSize = true;
            this.chkHighlight.Checked = true;
            this.chkHighlight.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHighlight.Location = new System.Drawing.Point(33, 188);
            this.chkHighlight.Margin = new System.Windows.Forms.Padding(4);
            this.chkHighlight.Name = "chkHighlight";
            this.chkHighlight.Size = new System.Drawing.Size(99, 22);
            this.chkHighlight.TabIndex = 3;
            this.chkHighlight.Text = "Highlight";
            this.chkHighlight.UseVisualStyleBackColor = true;
            this.chkHighlight.CheckedChanged += new System.EventHandler(this.chkHighlight_CheckedChanged);
            // 
            // trackBarUpper
            // 
            this.trackBarUpper.Location = new System.Drawing.Point(33, 111);
            this.trackBarUpper.Margin = new System.Windows.Forms.Padding(4);
            this.trackBarUpper.Maximum = 255;
            this.trackBarUpper.Name = "trackBarUpper";
            this.trackBarUpper.Size = new System.Drawing.Size(313, 69);
            this.trackBarUpper.TabIndex = 1;
            this.trackBarUpper.Value = 255;
            // 
            // trackBarLower
            // 
            this.trackBarLower.Location = new System.Drawing.Point(33, 34);
            this.trackBarLower.Margin = new System.Windows.Forms.Padding(4);
            this.trackBarLower.Maximum = 255;
            this.trackBarLower.Name = "trackBarLower";
            this.trackBarLower.Size = new System.Drawing.Size(313, 69);
            this.trackBarLower.TabIndex = 0;
            // 
            // grpFilter
            // 
            this.grpFilter.Controls.Add(this.txtWidth_max);
            this.grpFilter.Controls.Add(this.txtHeight_max);
            this.grpFilter.Controls.Add(this.txtWidth_min);
            this.grpFilter.Controls.Add(this.txtHeight_min);
            this.grpFilter.Controls.Add(this.lbMax);
            this.grpFilter.Controls.Add(this.lbMin);
            this.grpFilter.Controls.Add(this.lbWidth);
            this.grpFilter.Controls.Add(this.lbHeight);
            this.grpFilter.Controls.Add(this.txtArea_max);
            this.grpFilter.Controls.Add(this.btnFilter);
            this.grpFilter.Controls.Add(this.txtArea_min);
            this.grpFilter.Controls.Add(this.lbArea);
            this.grpFilter.Location = new System.Drawing.Point(6, 288);
            this.grpFilter.Margin = new System.Windows.Forms.Padding(4);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Padding = new System.Windows.Forms.Padding(4);
            this.grpFilter.Size = new System.Drawing.Size(356, 270);
            this.grpFilter.TabIndex = 1;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "필터";
            // 
            // btnFilter
            // 
            this.btnFilter.Location = new System.Drawing.Point(113, 192);
            this.btnFilter.Margin = new System.Windows.Forms.Padding(4);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(139, 36);
            this.btnFilter.TabIndex = 2;
            this.btnFilter.Text = "필터적용";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // txtArea_min
            // 
            this.txtArea_min.Location = new System.Drawing.Point(113, 46);
            this.txtArea_min.Margin = new System.Windows.Forms.Padding(4);
            this.txtArea_min.Name = "txtArea_min";
            this.txtArea_min.Size = new System.Drawing.Size(63, 28);
            this.txtArea_min.TabIndex = 1;
            this.txtArea_min.TextChanged += new System.EventHandler(this.txtArea_TextChanged);
            // 
            // lbArea
            // 
            this.lbArea.AutoSize = true;
            this.lbArea.Location = new System.Drawing.Point(14, 46);
            this.lbArea.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbArea.Name = "lbArea";
            this.lbArea.Size = new System.Drawing.Size(46, 18);
            this.lbArea.TabIndex = 0;
            this.lbArea.Text = "Area";
            this.lbArea.Click += new System.EventHandler(this.lbArea_Click);
            // 
            // txtArea_max
            // 
            this.txtArea_max.Location = new System.Drawing.Point(243, 46);
            this.txtArea_max.Margin = new System.Windows.Forms.Padding(4);
            this.txtArea_max.Name = "txtArea_max";
            this.txtArea_max.Size = new System.Drawing.Size(63, 28);
            this.txtArea_max.TabIndex = 3;
            this.txtArea_max.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // lbHeight
            // 
            this.lbHeight.AutoSize = true;
            this.lbHeight.Location = new System.Drawing.Point(9, 84);
            this.lbHeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHeight.Name = "lbHeight";
            this.lbHeight.Size = new System.Drawing.Size(57, 18);
            this.lbHeight.TabIndex = 4;
            this.lbHeight.Text = "Height";
            // 
            // lbWidth
            // 
            this.lbWidth.AutoSize = true;
            this.lbWidth.Location = new System.Drawing.Point(9, 130);
            this.lbWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbWidth.Name = "lbWidth";
            this.lbWidth.Size = new System.Drawing.Size(51, 18);
            this.lbWidth.TabIndex = 5;
            this.lbWidth.Text = "Width";
            // 
            // lbMin
            // 
            this.lbMin.AutoSize = true;
            this.lbMin.Location = new System.Drawing.Point(125, 24);
            this.lbMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMin.Name = "lbMin";
            this.lbMin.Size = new System.Drawing.Size(36, 18);
            this.lbMin.TabIndex = 6;
            this.lbMin.Text = "min";
            // 
            // lbMax
            // 
            this.lbMax.AutoSize = true;
            this.lbMax.Location = new System.Drawing.Point(250, 25);
            this.lbMax.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMax.Name = "lbMax";
            this.lbMax.Size = new System.Drawing.Size(43, 18);
            this.lbMax.TabIndex = 7;
            this.lbMax.Text = "max";
            // 
            // txtHeight_min
            // 
            this.txtHeight_min.Location = new System.Drawing.Point(113, 84);
            this.txtHeight_min.Margin = new System.Windows.Forms.Padding(4);
            this.txtHeight_min.Name = "txtHeight_min";
            this.txtHeight_min.Size = new System.Drawing.Size(63, 28);
            this.txtHeight_min.TabIndex = 8;
            // 
            // txtWidth_min
            // 
            this.txtWidth_min.Location = new System.Drawing.Point(113, 127);
            this.txtWidth_min.Margin = new System.Windows.Forms.Padding(4);
            this.txtWidth_min.Name = "txtWidth_min";
            this.txtWidth_min.Size = new System.Drawing.Size(63, 28);
            this.txtWidth_min.TabIndex = 9;
            // 
            // txtHeight_max
            // 
            this.txtHeight_max.Location = new System.Drawing.Point(243, 84);
            this.txtHeight_max.Margin = new System.Windows.Forms.Padding(4);
            this.txtHeight_max.Name = "txtHeight_max";
            this.txtHeight_max.Size = new System.Drawing.Size(63, 28);
            this.txtHeight_max.TabIndex = 10;
            // 
            // txtWidth_max
            // 
            this.txtWidth_max.Location = new System.Drawing.Point(243, 130);
            this.txtWidth_max.Margin = new System.Windows.Forms.Padding(4);
            this.txtWidth_max.Name = "txtWidth_max";
            this.txtWidth_max.Size = new System.Drawing.Size(63, 28);
            this.txtWidth_max.TabIndex = 11;
            // 
            // BinaryInspProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.grpBinary);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BinaryInspProp";
            this.Size = new System.Drawing.Size(387, 572);
            this.grpBinary.ResumeLayout(false);
            this.grpBinary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarUpper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLower)).EndInit();
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBinary;
        private System.Windows.Forms.TrackBar trackBarUpper;
        private System.Windows.Forms.TrackBar trackBarLower;
        private System.Windows.Forms.CheckBox chkHighlight;
        private System.Windows.Forms.CheckBox chkInvert;
        private System.Windows.Forms.GroupBox grpFilter;
        private System.Windows.Forms.TextBox txtArea_min;
        private System.Windows.Forms.Label lbArea;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.CheckBox chkShowBinary;
        private System.Windows.Forms.TextBox txtArea_max;
        private System.Windows.Forms.TextBox txtWidth_max;
        private System.Windows.Forms.TextBox txtHeight_max;
        private System.Windows.Forms.TextBox txtWidth_min;
        private System.Windows.Forms.TextBox txtHeight_min;
        private System.Windows.Forms.Label lbMax;
        private System.Windows.Forms.Label lbMin;
        private System.Windows.Forms.Label lbWidth;
        private System.Windows.Forms.Label lbHeight;
    }
}
