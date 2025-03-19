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
            this.ckb_Width = new System.Windows.Forms.CheckBox();
            this.ckb_Height = new System.Windows.Forms.CheckBox();
            this.ckb_Area = new System.Windows.Forms.CheckBox();
            this.txtWidth_max = new System.Windows.Forms.TextBox();
            this.txtHeight_max = new System.Windows.Forms.TextBox();
            this.txtWidth_min = new System.Windows.Forms.TextBox();
            this.txtHeight_min = new System.Windows.Forms.TextBox();
            this.lbMax = new System.Windows.Forms.Label();
            this.lbMin = new System.Windows.Forms.Label();
            this.lbWidth = new System.Windows.Forms.Label();
            this.lbHeight = new System.Windows.Forms.Label();
            this.txtArea_max = new System.Windows.Forms.TextBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.txtArea_min = new System.Windows.Forms.TextBox();
            this.lbArea = new System.Windows.Forms.Label();
            this.grpSetFilter = new System.Windows.Forms.GroupBox();
            this.btnSetFilter = new System.Windows.Forms.Button();
            this.cbSetFilter = new System.Windows.Forms.ComboBox();
            this.grpBinary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarUpper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLower)).BeginInit();
            this.grpFilter.SuspendLayout();
            this.grpSetFilter.SuspendLayout();
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
            this.grpFilter.Controls.Add(this.ckb_Width);
            this.grpFilter.Controls.Add(this.ckb_Height);
            this.grpFilter.Controls.Add(this.ckb_Area);
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
            this.grpFilter.Location = new System.Drawing.Point(5, 390);
            this.grpFilter.Margin = new System.Windows.Forms.Padding(4);
            this.grpFilter.Name = "grpFilter";
            this.grpFilter.Padding = new System.Windows.Forms.Padding(4);
            this.grpFilter.Size = new System.Drawing.Size(356, 270);
            this.grpFilter.TabIndex = 1;
            this.grpFilter.TabStop = false;
            this.grpFilter.Text = "필터";
            // 
            // ckb_Width
            // 
            this.ckb_Width.AutoSize = true;
            this.ckb_Width.Location = new System.Drawing.Point(18, 130);
            this.ckb_Width.Name = "ckb_Width";
            this.ckb_Width.Size = new System.Drawing.Size(22, 21);
            this.ckb_Width.TabIndex = 14;
            this.ckb_Width.UseVisualStyleBackColor = true;
            this.ckb_Width.CheckedChanged += new System.EventHandler(this.ckb_Width_CheckedChanged);
            // 
            // ckb_Height
            // 
            this.ckb_Height.AutoSize = true;
            this.ckb_Height.Location = new System.Drawing.Point(18, 84);
            this.ckb_Height.Name = "ckb_Height";
            this.ckb_Height.Size = new System.Drawing.Size(22, 21);
            this.ckb_Height.TabIndex = 13;
            this.ckb_Height.UseVisualStyleBackColor = true;
            this.ckb_Height.CheckedChanged += new System.EventHandler(this.ckb_Height_CheckedChanged);
            // 
            // ckb_Area
            // 
            this.ckb_Area.AutoSize = true;
            this.ckb_Area.Location = new System.Drawing.Point(18, 43);
            this.ckb_Area.Name = "ckb_Area";
            this.ckb_Area.Size = new System.Drawing.Size(22, 21);
            this.ckb_Area.TabIndex = 12;
            this.ckb_Area.UseVisualStyleBackColor = true;
            this.ckb_Area.CheckedChanged += new System.EventHandler(this.ckb_Area_CheckedChanged);
            // 
            // txtWidth_max
            // 
            this.txtWidth_max.Location = new System.Drawing.Point(243, 130);
            this.txtWidth_max.Margin = new System.Windows.Forms.Padding(4);
            this.txtWidth_max.Name = "txtWidth_max";
            this.txtWidth_max.Size = new System.Drawing.Size(63, 28);
            this.txtWidth_max.TabIndex = 11;
            // 
            // txtHeight_max
            // 
            this.txtHeight_max.Location = new System.Drawing.Point(243, 84);
            this.txtHeight_max.Margin = new System.Windows.Forms.Padding(4);
            this.txtHeight_max.Name = "txtHeight_max";
            this.txtHeight_max.Size = new System.Drawing.Size(63, 28);
            this.txtHeight_max.TabIndex = 10;
            // 
            // txtWidth_min
            // 
            this.txtWidth_min.Location = new System.Drawing.Point(147, 127);
            this.txtWidth_min.Margin = new System.Windows.Forms.Padding(4);
            this.txtWidth_min.Name = "txtWidth_min";
            this.txtWidth_min.Size = new System.Drawing.Size(63, 28);
            this.txtWidth_min.TabIndex = 9;
            // 
            // txtHeight_min
            // 
            this.txtHeight_min.Location = new System.Drawing.Point(147, 84);
            this.txtHeight_min.Margin = new System.Windows.Forms.Padding(4);
            this.txtHeight_min.Name = "txtHeight_min";
            this.txtHeight_min.Size = new System.Drawing.Size(63, 28);
            this.txtHeight_min.TabIndex = 8;
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
            // lbMin
            // 
            this.lbMin.AutoSize = true;
            this.lbMin.Location = new System.Drawing.Point(159, 24);
            this.lbMin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMin.Name = "lbMin";
            this.lbMin.Size = new System.Drawing.Size(36, 18);
            this.lbMin.TabIndex = 6;
            this.lbMin.Text = "min";
            // 
            // lbWidth
            // 
            this.lbWidth.AutoSize = true;
            this.lbWidth.Location = new System.Drawing.Point(64, 133);
            this.lbWidth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbWidth.Name = "lbWidth";
            this.lbWidth.Size = new System.Drawing.Size(51, 18);
            this.lbWidth.TabIndex = 5;
            this.lbWidth.Text = "Width";
            // 
            // lbHeight
            // 
            this.lbHeight.AutoSize = true;
            this.lbHeight.Location = new System.Drawing.Point(64, 87);
            this.lbHeight.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbHeight.Name = "lbHeight";
            this.lbHeight.Size = new System.Drawing.Size(57, 18);
            this.lbHeight.TabIndex = 4;
            this.lbHeight.Text = "Height";
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
            this.txtArea_min.Location = new System.Drawing.Point(147, 46);
            this.txtArea_min.Margin = new System.Windows.Forms.Padding(4);
            this.txtArea_min.Name = "txtArea_min";
            this.txtArea_min.Size = new System.Drawing.Size(63, 28);
            this.txtArea_min.TabIndex = 1;
            this.txtArea_min.TextChanged += new System.EventHandler(this.txtArea_TextChanged);
            // 
            // lbArea
            // 
            this.lbArea.AutoSize = true;
            this.lbArea.Location = new System.Drawing.Point(64, 46);
            this.lbArea.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbArea.Name = "lbArea";
            this.lbArea.Size = new System.Drawing.Size(46, 18);
            this.lbArea.TabIndex = 0;
            this.lbArea.Text = "Area";
            this.lbArea.Click += new System.EventHandler(this.lbArea_Click);
            // 
            // grpSetFilter
            // 
            this.grpSetFilter.Controls.Add(this.btnSetFilter);
            this.grpSetFilter.Controls.Add(this.cbSetFilter);
            this.grpSetFilter.Location = new System.Drawing.Point(5, 270);
            this.grpSetFilter.Name = "grpSetFilter";
            this.grpSetFilter.Size = new System.Drawing.Size(356, 113);
            this.grpSetFilter.TabIndex = 2;
            this.grpSetFilter.TabStop = false;
            this.grpSetFilter.Text = "Mophology 필터";
            // 
            // btnSetFilter
            // 
            this.btnSetFilter.Location = new System.Drawing.Point(270, 72);
            this.btnSetFilter.Name = "btnSetFilter";
            this.btnSetFilter.Size = new System.Drawing.Size(75, 35);
            this.btnSetFilter.TabIndex = 1;
            this.btnSetFilter.Text = "적용";
            this.btnSetFilter.UseVisualStyleBackColor = true;
            this.btnSetFilter.Click += new System.EventHandler(this.btnSetFilter_Click);
            // 
            // cbSetFilter
            // 
            this.cbSetFilter.FormattingEnabled = true;
            this.cbSetFilter.Location = new System.Drawing.Point(58, 27);
            this.cbSetFilter.Name = "cbSetFilter";
            this.cbSetFilter.Size = new System.Drawing.Size(248, 26);
            this.cbSetFilter.TabIndex = 0;
            this.cbSetFilter.SelectedIndexChanged += new System.EventHandler(this.cbSetFilter_SelectedIndexChanged);
            // 
            // BinaryInspProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpSetFilter);
            this.Controls.Add(this.grpFilter);
            this.Controls.Add(this.grpBinary);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BinaryInspProp";
            this.Size = new System.Drawing.Size(387, 739);
            this.grpBinary.ResumeLayout(false);
            this.grpBinary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarUpper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLower)).EndInit();
            this.grpFilter.ResumeLayout(false);
            this.grpFilter.PerformLayout();
            this.grpSetFilter.ResumeLayout(false);
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
        private System.Windows.Forms.CheckBox ckb_Width;
        private System.Windows.Forms.CheckBox ckb_Height;
        private System.Windows.Forms.CheckBox ckb_Area;
        private System.Windows.Forms.GroupBox grpSetFilter;
        private System.Windows.Forms.Button btnSetFilter;
        private System.Windows.Forms.ComboBox cbSetFilter;
    }
}
