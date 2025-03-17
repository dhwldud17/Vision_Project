namespace JidamVision.Property
{
    partial class MatchInspProp
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grpMatch = new System.Windows.Forms.GroupBox();
            this.btnTeach = new System.Windows.Forms.Button();
            this.txtMatchCount = new System.Windows.Forms.TextBox();
            this.lbMatchCount = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lbScore = new System.Windows.Forms.Label();
            this.txtExtendY = new System.Windows.Forms.TextBox();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.txtExtendX = new System.Windows.Forms.TextBox();
            this.lbX = new System.Windows.Forms.Label();
            this.lbExtent = new System.Windows.Forms.Label();
            this.grpMatch.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMatch
            // 
            this.grpMatch.Controls.Add(this.btnTeach);
            this.grpMatch.Controls.Add(this.txtMatchCount);
            this.grpMatch.Controls.Add(this.lbMatchCount);
            this.grpMatch.Controls.Add(this.btnSearch);
            this.grpMatch.Controls.Add(this.lbScore);
            this.grpMatch.Controls.Add(this.txtExtendY);
            this.grpMatch.Controls.Add(this.txtScore);
            this.grpMatch.Controls.Add(this.txtExtendX);
            this.grpMatch.Controls.Add(this.lbX);
            this.grpMatch.Controls.Add(this.lbExtent);
            this.grpMatch.Location = new System.Drawing.Point(4, 4);
            this.grpMatch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpMatch.Name = "grpMatch";
            this.grpMatch.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpMatch.Size = new System.Drawing.Size(400, 378);
            this.grpMatch.TabIndex = 0;
            this.grpMatch.TabStop = false;
            this.grpMatch.Text = "패턴매칭";
            // 
            // btnTeach
            // 
            this.btnTeach.Location = new System.Drawing.Point(13, 148);
            this.btnTeach.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTeach.Name = "btnTeach";
            this.btnTeach.Size = new System.Drawing.Size(94, 38);
            this.btnTeach.TabIndex = 6;
            this.btnTeach.Text = "티칭";
            this.btnTeach.UseVisualStyleBackColor = true;
            this.btnTeach.Click += new System.EventHandler(this.btnTeach_Click);
            // 
            // txtMatchCount
            // 
            this.txtMatchCount.Location = new System.Drawing.Point(124, 105);
            this.txtMatchCount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMatchCount.Name = "txtMatchCount";
            this.txtMatchCount.Size = new System.Drawing.Size(70, 28);
            this.txtMatchCount.TabIndex = 5;
            // 
            // lbMatchCount
            // 
            this.lbMatchCount.AutoSize = true;
            this.lbMatchCount.Location = new System.Drawing.Point(13, 110);
            this.lbMatchCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbMatchCount.Name = "lbMatchCount";
            this.lbMatchCount.Size = new System.Drawing.Size(86, 18);
            this.lbMatchCount.TabIndex = 4;
            this.lbMatchCount.Text = "매칭 갯수";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(124, 146);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(177, 44);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "찾기";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lbScore
            // 
            this.lbScore.AutoSize = true;
            this.lbScore.Location = new System.Drawing.Point(10, 68);
            this.lbScore.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbScore.Name = "lbScore";
            this.lbScore.Size = new System.Drawing.Size(98, 18);
            this.lbScore.TabIndex = 2;
            this.lbScore.Text = "매칭스코어";
            // 
            // txtExtendY
            // 
            this.txtExtendY.Location = new System.Drawing.Point(230, 18);
            this.txtExtendY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtExtendY.Name = "txtExtendY";
            this.txtExtendY.Size = new System.Drawing.Size(70, 28);
            this.txtExtendY.TabIndex = 1;
            // 
            // txtScore
            // 
            this.txtScore.Location = new System.Drawing.Point(124, 63);
            this.txtScore.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtScore.Name = "txtScore";
            this.txtScore.Size = new System.Drawing.Size(70, 28);
            this.txtScore.TabIndex = 1;
            // 
            // txtExtendX
            // 
            this.txtExtendX.Location = new System.Drawing.Point(124, 18);
            this.txtExtendX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtExtendX.Name = "txtExtendX";
            this.txtExtendX.Size = new System.Drawing.Size(70, 28);
            this.txtExtendX.TabIndex = 1;
            this.txtExtendX.TextChanged += new System.EventHandler(this.txtExtendX_TextChanged);
            // 
            // lbX
            // 
            this.lbX.AutoSize = true;
            this.lbX.Location = new System.Drawing.Point(204, 27);
            this.lbX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbX.Name = "lbX";
            this.lbX.Size = new System.Drawing.Size(18, 18);
            this.lbX.TabIndex = 0;
            this.lbX.Text = "x";
            // 
            // lbExtent
            // 
            this.lbExtent.AutoSize = true;
            this.lbExtent.Location = new System.Drawing.Point(10, 32);
            this.lbExtent.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbExtent.Name = "lbExtent";
            this.lbExtent.Size = new System.Drawing.Size(80, 18);
            this.lbExtent.TabIndex = 0;
            this.lbExtent.Text = "확장영역";
            // 
            // MatchInspProp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpMatch);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MatchInspProp";
            this.Size = new System.Drawing.Size(427, 404);
            this.grpMatch.ResumeLayout(false);
            this.grpMatch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMatch;
        private System.Windows.Forms.TextBox txtExtendY;
        private System.Windows.Forms.TextBox txtExtendX;
        private System.Windows.Forms.Label lbX;
        private System.Windows.Forms.Label lbExtent;
        private System.Windows.Forms.Label lbScore;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtMatchCount;
        private System.Windows.Forms.Label lbMatchCount;
        private System.Windows.Forms.Button btnTeach;
    }
}
