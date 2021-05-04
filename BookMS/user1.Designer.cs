namespace BookMS
{
    partial class user1
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
            this.系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.联系管理员ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图书查看和借阅ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.当前结束图书和归还ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(36, 36);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.系统ToolStripMenuItem,
            this.图书查看和借阅ToolStripMenuItem,
            this.当前结束图书和归还ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1154, 47);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 系统ToolStripMenuItem
            // 
            this.系统ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助ToolStripMenuItem,
            this.退出ToolStripMenuItem,
            this.联系管理员ToolStripMenuItem});
            this.系统ToolStripMenuItem.Name = "系统ToolStripMenuItem";
            this.系统ToolStripMenuItem.Size = new System.Drawing.Size(91, 43);
            this.系统ToolStripMenuItem.Text = "系统";
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(403, 48);
            this.帮助ToolStripMenuItem.Text = "帮助";
            this.帮助ToolStripMenuItem.Click += new System.EventHandler(this.帮助ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(403, 48);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // 联系管理员ToolStripMenuItem
            // 
            this.联系管理员ToolStripMenuItem.Name = "联系管理员ToolStripMenuItem";
            this.联系管理员ToolStripMenuItem.Size = new System.Drawing.Size(403, 48);
            this.联系管理员ToolStripMenuItem.Text = "联系管理员";
            // 
            // 图书查看和借阅ToolStripMenuItem
            // 
            this.图书查看和借阅ToolStripMenuItem.Name = "图书查看和借阅ToolStripMenuItem";
            this.图书查看和借阅ToolStripMenuItem.Size = new System.Drawing.Size(226, 43);
            this.图书查看和借阅ToolStripMenuItem.Text = "图书查看和借阅";
            this.图书查看和借阅ToolStripMenuItem.Click += new System.EventHandler(this.图书查看和借阅ToolStripMenuItem_Click);
            // 
            // 当前结束图书和归还ToolStripMenuItem
            // 
            this.当前结束图书和归还ToolStripMenuItem.Name = "当前结束图书和归还ToolStripMenuItem";
            this.当前结束图书和归还ToolStripMenuItem.Size = new System.Drawing.Size(280, 43);
            this.当前结束图书和归还ToolStripMenuItem.Text = "当前结束图书和归还";
            this.当前结束图书和归还ToolStripMenuItem.Click += new System.EventHandler(this.当前结束图书和归还ToolStripMenuItem_Click);
            // 
            // user1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 600);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "user1";
            this.Text = "用户主页面";
            this.Load += new System.EventHandler(this.user1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 联系管理员ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图书查看和借阅ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 当前结束图书和归还ToolStripMenuItem;
    }
}