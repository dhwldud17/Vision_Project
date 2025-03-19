namespace JidamVision
{
    partial class NewModel
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
            this.lbModelName = new System.Windows.Forms.Label();
            this.txtModelName = new System.Windows.Forms.TextBox();
            this.lbModelInfo = new System.Windows.Forms.Label();
            this.txtModelInfo = new System.Windows.Forms.RichTextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbModelName
            // 
            this.lbModelName.AutoSize = true;
            this.lbModelName.Location = new System.Drawing.Point(61, 42);
            this.lbModelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbModelName.Name = "lbModelName";
            this.lbModelName.Size = new System.Drawing.Size(62, 18);
            this.lbModelName.TabIndex = 1;
            this.lbModelName.Text = "모델명";
            // 
            // txtModelName
            // 
            this.txtModelName.Location = new System.Drawing.Point(178, 42);
            this.txtModelName.Margin = new System.Windows.Forms.Padding(4);
            this.txtModelName.Name = "txtModelName";
            this.txtModelName.Size = new System.Drawing.Size(270, 28);
            this.txtModelName.TabIndex = 3;
            // 
            // lbModelInfo
            // 
            this.lbModelInfo.AutoSize = true;
            this.lbModelInfo.Location = new System.Drawing.Point(51, 112);
            this.lbModelInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbModelInfo.Name = "lbModelInfo";
            this.lbModelInfo.Size = new System.Drawing.Size(86, 18);
            this.lbModelInfo.TabIndex = 4;
            this.lbModelInfo.Text = "모델 정보";
            // 
            // txtModelInfo
            // 
            this.txtModelInfo.Location = new System.Drawing.Point(178, 112);
            this.txtModelInfo.Margin = new System.Windows.Forms.Padding(4);
            this.txtModelInfo.Name = "txtModelInfo";
            this.txtModelInfo.Size = new System.Drawing.Size(270, 154);
            this.txtModelInfo.TabIndex = 5;
            this.txtModelInfo.Text = "";
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(469, 307);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(113, 45);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "만들기";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // NewModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 375);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.txtModelInfo);
            this.Controls.Add(this.lbModelInfo);
            this.Controls.Add(this.txtModelName);
            this.Controls.Add(this.lbModelName);
            this.Name = "NewModel";
            this.Text = "NewModel";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbModelName;
        private System.Windows.Forms.TextBox txtModelName;
        private System.Windows.Forms.Label lbModelInfo;
        private System.Windows.Forms.RichTextBox txtModelInfo;
        private System.Windows.Forms.Button btnCreate;
    }
}