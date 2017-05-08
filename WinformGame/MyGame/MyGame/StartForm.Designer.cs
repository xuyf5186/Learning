namespace MyGame
{
    partial class StartForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.NewGameBtn = new System.Windows.Forms.Button();
            this.ContinueBtn = new System.Windows.Forms.Button();
            this.QuitBtn = new System.Windows.Forms.Button();
            this.ReadBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NewGameBtn
            // 
            this.NewGameBtn.Location = new System.Drawing.Point(99, 140);
            this.NewGameBtn.Name = "NewGameBtn";
            this.NewGameBtn.Size = new System.Drawing.Size(75, 23);
            this.NewGameBtn.TabIndex = 0;
            this.NewGameBtn.Text = "新的游戏";
            this.NewGameBtn.UseVisualStyleBackColor = true;
            this.NewGameBtn.Click += new System.EventHandler(this.NewGameBtn_Click);
            // 
            // ContinueBtn
            // 
            this.ContinueBtn.Location = new System.Drawing.Point(99, 111);
            this.ContinueBtn.Name = "ContinueBtn";
            this.ContinueBtn.Size = new System.Drawing.Size(75, 23);
            this.ContinueBtn.TabIndex = 0;
            this.ContinueBtn.Text = "继续游戏";
            this.ContinueBtn.UseVisualStyleBackColor = true;
            // 
            // QuitBtn
            // 
            this.QuitBtn.Location = new System.Drawing.Point(99, 209);
            this.QuitBtn.Name = "QuitBtn";
            this.QuitBtn.Size = new System.Drawing.Size(75, 23);
            this.QuitBtn.TabIndex = 0;
            this.QuitBtn.Text = "退出";
            this.QuitBtn.UseVisualStyleBackColor = true;
            this.QuitBtn.Click += new System.EventHandler(this.QuitBtn_Click);
            // 
            // ReadBtn
            // 
            this.ReadBtn.Location = new System.Drawing.Point(99, 169);
            this.ReadBtn.Name = "ReadBtn";
            this.ReadBtn.Size = new System.Drawing.Size(75, 23);
            this.ReadBtn.TabIndex = 0;
            this.ReadBtn.Text = "读取游戏";
            this.ReadBtn.UseVisualStyleBackColor = true;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.QuitBtn);
            this.Controls.Add(this.ContinueBtn);
            this.Controls.Add(this.ReadBtn);
            this.Controls.Add(this.NewGameBtn);
            this.Name = "StartForm";
            this.Text = "点击游戏";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NewGameBtn;
        private System.Windows.Forms.Button ContinueBtn;
        private System.Windows.Forms.Button QuitBtn;
        private System.Windows.Forms.Button ReadBtn;
    }
}

