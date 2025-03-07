namespace JidamVision.Property
{
    partial class MatchInspProp
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
            this.components = new System.ComponentModel.Container();
            this.grpMatch = new System.Windows.Forms.GroupBox();
            this.lbX = new System.Windows.Forms.Label();
            this.txtExtendY = new System.Windows.Forms.TextBox();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.txtExtendX = new System.Windows.Forms.TextBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.lbExtent = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lbMatchCount = new System.Windows.Forms.Label();
            this.txtMatchCount = new System.Windows.Forms.TextBox();
            this.btnTeach = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grpMatch.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMatch
            // 
            this.grpMatch.Controls.Add(this.btnSearch);
            this.grpMatch.Controls.Add(this.btnTeach);
            this.grpMatch.Controls.Add(this.txtMatchCount);
            this.grpMatch.Controls.Add(this.lbMatchCount);
            this.grpMatch.Controls.Add(this.lbX);
            this.grpMatch.Controls.Add(this.txtExtendY);
            this.grpMatch.Controls.Add(this.txtScore);
            this.grpMatch.Controls.Add(this.txtExtendX);
            this.grpMatch.Controls.Add(this.lblScore);
            this.grpMatch.Controls.Add(this.lbExtent);
            this.grpMatch.Location = new System.Drawing.Point(15, 17);
            this.grpMatch.Name = "grpMatch";
            this.grpMatch.Size = new System.Drawing.Size(456, 376);
            this.grpMatch.TabIndex = 0;
            this.grpMatch.TabStop = false;
            this.grpMatch.Text = "패턴매칭";
            // 
            // lbX
            // 
            this.lbX.AutoSize = true;
            this.lbX.Location = new System.Drawing.Point(252, 58);
            this.lbX.Name = "lbX";
            this.lbX.Size = new System.Drawing.Size(19, 18);
            this.lbX.TabIndex = 5;
            this.lbX.Text = "X";
            // 
            // txtExtendY
            // 
            this.txtExtendY.Location = new System.Drawing.Point(298, 49);
            this.txtExtendY.Name = "txtExtendY";
            this.txtExtendY.Size = new System.Drawing.Size(100, 28);
            this.txtExtendY.TabIndex = 4;
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(132, 108);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(100, 28);
            this.txtScore.TabIndex = 3;
            this.txtScore.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtExtendX
            // 
            this.txtExtendX.Location = new System.Drawing.Point(132, 49);
            this.txtExtendX.Name = "txtExtendX";
            this.txtExtendX.Size = new System.Drawing.Size(100, 28);
            this.txtExtendX.TabIndex = 2;
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(12, 108);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(98, 18);
            this.lblScore.TabIndex = 1;
            this.lblScore.Text = "매칭스코어";
            // 
            // lbExtent
            // 
            this.lbExtent.AutoSize = true;
            this.lbExtent.Location = new System.Drawing.Point(21, 49);
            this.lbExtent.Name = "lbExtent";
            this.lbExtent.Size = new System.Drawing.Size(80, 18);
            this.lbExtent.TabIndex = 0;
            this.lbExtent.Text = "확장영역";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // lbMatchCount
            // 
            this.lbMatchCount.AutoSize = true;
            this.lbMatchCount.Location = new System.Drawing.Point(21, 168);
            this.lbMatchCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMatchCount.Name = "lbMatchCount";
            this.lbMatchCount.Size = new System.Drawing.Size(86, 18);
            this.lbMatchCount.TabIndex = 6;
            this.lbMatchCount.Text = "매칭 갯수";
            // 
            // txtMatchCount
            // 
            this.txtMatchCount.Location = new System.Drawing.Point(132, 168);
            this.txtMatchCount.Margin = new System.Windows.Forms.Padding(4);
            this.txtMatchCount.Name = "txtMatchCount";
            this.txtMatchCount.Size = new System.Drawing.Size(100, 28);
            this.txtMatchCount.TabIndex = 7;
            // 
            // btnTeach
            // 
            this.btnTeach.Location = new System.Drawing.Point(37, 225);
            this.btnTeach.Margin = new System.Windows.Forms.Padding(4);
            this.btnTeach.Name = "btnTeach";
            this.btnTeach.Size = new System.Drawing.Size(94, 38);
            this.btnTeach.TabIndex = 8;
            this.btnTeach.Text = "티칭";
            this.btnTeach.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(184, 222);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(177, 44);
            this.btnSearch.TabIndex = 9;
            this.btnSearch.Text = "찾기";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // MatchInspProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpMatch);
            this.Name = "MatchInspProp";
            this.Size = new System.Drawing.Size(496, 420);
            this.grpMatch.ResumeLayout(false);
            this.grpMatch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMatch;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.TextBox txtExtendX;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label lbExtent;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label lbX;
        private System.Windows.Forms.TextBox txtExtendY;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnTeach;
        private System.Windows.Forms.TextBox txtMatchCount;
        private System.Windows.Forms.Label lbMatchCount;
    }
}
