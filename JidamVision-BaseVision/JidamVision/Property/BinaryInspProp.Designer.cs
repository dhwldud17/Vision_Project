namespace JidamVision.Property
{
    partial class BinaryInspProp
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpBinary = new System.Windows.Forms.GroupBox();
            this.chkHighlight = new System.Windows.Forms.CheckBox();
            this.trackBarUpper = new System.Windows.Forms.TrackBar();
            this.trackBarLower = new System.Windows.Forms.TrackBar();
            this.grpBinary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarUpper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLower)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBinary
            // 
            this.grpBinary.Controls.Add(this.chkHighlight);
            this.grpBinary.Controls.Add(this.trackBarUpper);
            this.grpBinary.Controls.Add(this.trackBarLower);
            this.grpBinary.Location = new System.Drawing.Point(19, 43);
            this.grpBinary.Name = "grpBinary";
            this.grpBinary.Size = new System.Drawing.Size(476, 300);
            this.grpBinary.TabIndex = 0;
            this.grpBinary.TabStop = false;
            this.grpBinary.Text = "이진화";
            this.grpBinary.Enter += new System.EventHandler(this.grpBinary_Enter);
            // 
            // chkHighlight
            // 
            this.chkHighlight.AutoSize = true;
            this.chkHighlight.Location = new System.Drawing.Point(50, 219);
            this.chkHighlight.Name = "chkHighlight";
            this.chkHighlight.Size = new System.Drawing.Size(99, 22);
            this.chkHighlight.TabIndex = 2;
            this.chkHighlight.Text = "Highlight";
            this.chkHighlight.UseVisualStyleBackColor = true;
            // 
            // trackBarUpper
            // 
            this.trackBarUpper.Location = new System.Drawing.Point(50, 131);
            this.trackBarUpper.Maximum = 255;
            this.trackBarUpper.Name = "trackBarUpper";
            this.trackBarUpper.Size = new System.Drawing.Size(377, 69);
            this.trackBarUpper.TabIndex = 1;
            this.trackBarUpper.Value = 255;
            // 
            // trackBarLower
            // 
            this.trackBarLower.Location = new System.Drawing.Point(50, 66);
            this.trackBarLower.Maximum = 255;
            this.trackBarLower.Name = "trackBarLower";
            this.trackBarLower.Size = new System.Drawing.Size(377, 69);
            this.trackBarLower.TabIndex = 0;
            this.trackBarLower.Scroll += new System.EventHandler(this.trackBarLower_Scroll);
            // 
            // BinaryInspProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpBinary);
            this.Name = "BinaryInspProp";
            this.Size = new System.Drawing.Size(589, 421);
            this.Load += new System.EventHandler(this.BinaryInspProp_Load);
            this.grpBinary.ResumeLayout(false);
            this.grpBinary.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarUpper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLower)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBinary;
        private System.Windows.Forms.TrackBar trackBarLower;
        private System.Windows.Forms.TrackBar trackBarUpper;
        private System.Windows.Forms.CheckBox chkHighlight;
    }
}
