namespace JidamVision.Setting
{
    partial class NetworkSetting
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
            this.cbNetworkType = new System.Windows.Forms.ComboBox();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.lbCommnicationType = new System.Windows.Forms.Label();
            this.lbIPAddress = new System.Windows.Forms.Label();
            this.btnApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbNetworkType
            // 
            this.cbNetworkType.FormattingEnabled = true;
            this.cbNetworkType.Location = new System.Drawing.Point(300, 120);
            this.cbNetworkType.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbNetworkType.Name = "cbNetworkType";
            this.cbNetworkType.Size = new System.Drawing.Size(295, 26);
            this.cbNetworkType.TabIndex = 0;
            this.cbNetworkType.SelectedIndexChanged += new System.EventHandler(this.cbNetworkType_SelectedIndexChanged);
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(300, 232);
            this.txtIPAddress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(258, 28);
            this.txtIPAddress.TabIndex = 1;
            this.txtIPAddress.TextChanged += new System.EventHandler(this.txtIPAddress_TextChanged);
            // 
            // lbCommnicationType
            // 
            this.lbCommnicationType.AutoSize = true;
            this.lbCommnicationType.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbCommnicationType.Location = new System.Drawing.Point(36, 123);
            this.lbCommnicationType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbCommnicationType.Name = "lbCommnicationType";
            this.lbCommnicationType.Size = new System.Drawing.Size(179, 18);
            this.lbCommnicationType.TabIndex = 2;
            this.lbCommnicationType.Text = "Communication Type";
            // 
            // lbIPAddress
            // 
            this.lbIPAddress.AutoSize = true;
            this.lbIPAddress.Font = new System.Drawing.Font("Gulim", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbIPAddress.Location = new System.Drawing.Point(39, 230);
            this.lbIPAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbIPAddress.Name = "lbIPAddress";
            this.lbIPAddress.Size = new System.Drawing.Size(96, 18);
            this.lbIPAddress.TabIndex = 3;
            this.lbIPAddress.Text = "IP Address";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(467, 321);
            this.btnApply.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(130, 66);
            this.btnApply.TabIndex = 4;
            this.btnApply.Text = "적용";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // NetworkSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lbIPAddress);
            this.Controls.Add(this.lbCommnicationType);
            this.Controls.Add(this.txtIPAddress);
            this.Controls.Add(this.cbNetworkType);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "NetworkSetting";
            this.Size = new System.Drawing.Size(640, 447);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbNetworkType;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label lbCommnicationType;
        private System.Windows.Forms.Label lbIPAddress;
        private System.Windows.Forms.Button btnApply;
    }
}
