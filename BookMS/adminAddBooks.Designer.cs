namespace BookMS
{
    partial class adminAddBooks
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxId = new System.Windows.Forms.TextBox();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxAuthor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxStore = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Flush = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.Location = new System.Drawing.Point(282, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "书号：";
            // 
            // textBoxId
            // 
            this.textBoxId.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.textBoxId.Location = new System.Drawing.Point(462, 29);
            this.textBoxId.Name = "textBoxId";
            this.textBoxId.Size = new System.Drawing.Size(443, 55);
            this.textBoxId.TabIndex = 1;
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.textBoxName.Location = new System.Drawing.Point(462, 114);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(443, 55);
            this.textBoxName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label2.Location = new System.Drawing.Point(282, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 46);
            this.label2.TabIndex = 2;
            this.label2.Text = "书名：";
            // 
            // textBoxAuthor
            // 
            this.textBoxAuthor.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.textBoxAuthor.Location = new System.Drawing.Point(462, 208);
            this.textBoxAuthor.Name = "textBoxAuthor";
            this.textBoxAuthor.Size = new System.Drawing.Size(443, 55);
            this.textBoxAuthor.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label3.Location = new System.Drawing.Point(282, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 46);
            this.label3.TabIndex = 4;
            this.label3.Text = "作者：";
            // 
            // textBoxPress
            // 
            this.textBoxPress.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.textBoxPress.Location = new System.Drawing.Point(462, 305);
            this.textBoxPress.Name = "textBoxPress";
            this.textBoxPress.Size = new System.Drawing.Size(443, 55);
            this.textBoxPress.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label4.Location = new System.Drawing.Point(282, 308);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 46);
            this.label4.TabIndex = 6;
            this.label4.Text = "出版社：";
            // 
            // textBoxStore
            // 
            this.textBoxStore.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.textBoxStore.Location = new System.Drawing.Point(462, 402);
            this.textBoxStore.Name = "textBoxStore";
            this.textBoxStore.Size = new System.Drawing.Size(443, 55);
            this.textBoxStore.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label5.Location = new System.Drawing.Point(282, 405);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 46);
            this.label5.TabIndex = 8;
            this.label5.Text = "库存：";
            // 
            // Flush
            // 
            this.Flush.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Flush.Location = new System.Drawing.Point(737, 522);
            this.Flush.Name = "Flush";
            this.Flush.Size = new System.Drawing.Size(232, 68);
            this.Flush.TabIndex = 11;
            this.Flush.Text = "清空";
            this.Flush.UseVisualStyleBackColor = true;
            this.Flush.Click += new System.EventHandler(this.Flush_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(268, 522);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(232, 68);
            this.button1.TabIndex = 12;
            this.button1.Text = "添加图书";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // admin2_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1238, 768);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Flush);
            this.Controls.Add(this.textBoxStore);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxPress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxAuthor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxId);
            this.Controls.Add(this.label1);
            this.Name = "admin2_1";
            this.Text = "添加图书";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxId;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxAuthor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxStore;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Flush;
        private System.Windows.Forms.Button button1;
    }
}