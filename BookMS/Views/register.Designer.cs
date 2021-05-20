
using BookMS.Controllers;
using System.Collections;

namespace BookMS.Views {
    partial class register {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(register));
            this.buttonFlush = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.panelRepeat = new System.Windows.Forms.Panel();
            this.pictureBoxRepeat = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxRepeat = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panelPassword = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.panelID = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxID = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBoxAdmin = new System.Windows.Forms.PictureBox();
            this.panelName = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBoxAnswer = new System.Windows.Forms.TextBox();
            this.pictureBoxAltImg = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.uiRadioButtonMale = new Sunny.UI.UIRadioButton();
            this.uiRadioButtonFemale = new Sunny.UI.UIRadioButton();
            this.panelMajor = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxMajor = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelRepeat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRepeat)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panelPassword.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.panelID.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAdmin)).BeginInit();
            this.panelName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAltImg)).BeginInit();
            this.panelMajor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFlush
            // 
            this.buttonFlush.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.buttonFlush.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonFlush.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFlush.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonFlush.ForeColor = System.Drawing.Color.White;
            this.buttonFlush.Location = new System.Drawing.Point(470, 1092);
            this.buttonFlush.Name = "buttonFlush";
            this.buttonFlush.Size = new System.Drawing.Size(187, 70);
            this.buttonFlush.TabIndex = 31;
            this.buttonFlush.Text = "Flush";
            this.buttonFlush.UseVisualStyleBackColor = false;
            this.buttonFlush.Click += new System.EventHandler(this.buttonFlush_Click);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.buttonConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonConfirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonConfirm.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonConfirm.ForeColor = System.Drawing.Color.White;
            this.buttonConfirm.Location = new System.Drawing.Point(218, 1092);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(187, 70);
            this.buttonConfirm.TabIndex = 30;
            this.buttonConfirm.Text = "Confirm";
            this.buttonConfirm.UseVisualStyleBackColor = false;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // panelRepeat
            // 
            this.panelRepeat.BackColor = System.Drawing.Color.Transparent;
            this.panelRepeat.Controls.Add(this.pictureBoxRepeat);
            this.panelRepeat.Controls.Add(this.label6);
            this.panelRepeat.Controls.Add(this.textBoxRepeat);
            this.panelRepeat.Controls.Add(this.pictureBox5);
            this.panelRepeat.Location = new System.Drawing.Point(1, 697);
            this.panelRepeat.Name = "panelRepeat";
            this.panelRepeat.Size = new System.Drawing.Size(900, 90);
            this.panelRepeat.TabIndex = 27;
            // 
            // pictureBoxRepeat
            // 
            this.pictureBoxRepeat.Location = new System.Drawing.Point(840, 34);
            this.pictureBoxRepeat.Name = "pictureBoxRepeat";
            this.pictureBoxRepeat.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxRepeat.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRepeat.TabIndex = 41;
            this.pictureBoxRepeat.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(77, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 32);
            this.label6.TabIndex = 6;
            this.label6.Text = "Repeat";
            // 
            // textBoxRepeat
            // 
            this.textBoxRepeat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.textBoxRepeat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxRepeat.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxRepeat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.textBoxRepeat.Location = new System.Drawing.Point(188, 29);
            this.textBoxRepeat.Name = "textBoxRepeat";
            this.textBoxRepeat.Size = new System.Drawing.Size(630, 37);
            this.textBoxRepeat.TabIndex = 1;
            this.textBoxRepeat.Click += new System.EventHandler(this.textBoxRepeat_Click);
            this.textBoxRepeat.TextChanged += new System.EventHandler(this.textBoxRepeat_TextChanged);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(23, 18);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(48, 48);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 0;
            this.pictureBox5.TabStop = false;
            // 
            // panelPassword
            // 
            this.panelPassword.BackColor = System.Drawing.Color.Transparent;
            this.panelPassword.Controls.Add(this.label5);
            this.panelPassword.Controls.Add(this.textBoxPassword);
            this.panelPassword.Controls.Add(this.pictureBox4);
            this.panelPassword.Location = new System.Drawing.Point(-1, 565);
            this.panelPassword.Name = "panelPassword";
            this.panelPassword.Size = new System.Drawing.Size(900, 90);
            this.panelPassword.TabIndex = 28;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(79, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 32);
            this.label5.TabIndex = 5;
            this.label5.Text = "Password";
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.textBoxPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxPassword.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.textBoxPassword.Location = new System.Drawing.Point(228, 33);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(662, 37);
            this.textBoxPassword.TabIndex = 1;
            this.textBoxPassword.Click += new System.EventHandler(this.textBoxPassword_Click);
            this.textBoxPassword.TextChanged += new System.EventHandler(this.textBoxPassword_TextChanged);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(25, 22);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(48, 48);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 0;
            this.pictureBox4.TabStop = false;
            // 
            // panelID
            // 
            this.panelID.BackColor = System.Drawing.Color.Transparent;
            this.panelID.Controls.Add(this.label4);
            this.panelID.Controls.Add(this.textBoxID);
            this.panelID.Controls.Add(this.pictureBox3);
            this.panelID.Location = new System.Drawing.Point(-1, 433);
            this.panelID.Name = "panelID";
            this.panelID.Size = new System.Drawing.Size(900, 90);
            this.panelID.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(79, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 32);
            this.label4.TabIndex = 4;
            this.label4.Text = "Stu.ID";
            // 
            // textBoxID
            // 
            this.textBoxID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.textBoxID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxID.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.textBoxID.Location = new System.Drawing.Point(188, 33);
            this.textBoxID.Name = "textBoxID";
            this.textBoxID.Size = new System.Drawing.Size(700, 37);
            this.textBoxID.TabIndex = 1;
            this.textBoxID.Click += new System.EventHandler(this.textBoxID_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(25, 22);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 48);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 0;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBoxAdmin
            // 
            this.pictureBoxAdmin.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxAdmin.Image")));
            this.pictureBoxAdmin.Location = new System.Drawing.Point(382, 67);
            this.pictureBoxAdmin.Name = "pictureBoxAdmin";
            this.pictureBoxAdmin.Size = new System.Drawing.Size(128, 128);
            this.pictureBoxAdmin.TabIndex = 32;
            this.pictureBoxAdmin.TabStop = false;
            // 
            // panelName
            // 
            this.panelName.BackColor = System.Drawing.Color.Transparent;
            this.panelName.Controls.Add(this.label2);
            this.panelName.Controls.Add(this.textBoxName);
            this.panelName.Controls.Add(this.pictureBox2);
            this.panelName.Location = new System.Drawing.Point(-1, 313);
            this.panelName.Name = "panelName";
            this.panelName.Size = new System.Drawing.Size(900, 90);
            this.panelName.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(79, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // textBoxName
            // 
            this.textBoxName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.textBoxName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxName.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.textBoxName.Location = new System.Drawing.Point(188, 24);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(700, 37);
            this.textBoxName.TabIndex = 1;
            this.textBoxName.Click += new System.EventHandler(this.textBoxName_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(25, 21);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(104, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(700, 56);
            this.label1.TabIndex = 24;
            this.label1.Text = "Register A New User Account";
            // 
            // buttonClose
            // 
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.FlatAppearance.BorderSize = 0;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Font = new System.Drawing.Font("Verdana", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonClose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.buttonClose.Location = new System.Drawing.Point(819, 0);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(80, 80);
            this.buttonClose.TabIndex = 23;
            this.buttonClose.Text = "X";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.comboBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(144, 955);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(628, 41);
            this.comboBox1.TabIndex = 33;
            // 
            // textBoxAnswer
            // 
            this.textBoxAnswer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.textBoxAnswer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAnswer.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textBoxAnswer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.textBoxAnswer.Location = new System.Drawing.Point(144, 1002);
            this.textBoxAnswer.Multiline = true;
            this.textBoxAnswer.Name = "textBoxAnswer";
            this.textBoxAnswer.Size = new System.Drawing.Size(628, 41);
            this.textBoxAnswer.TabIndex = 34;
            this.textBoxAnswer.Text = "Answer";
            this.textBoxAnswer.Click += new System.EventHandler(this.textBoxAnswer_Click);
            // 
            // pictureBoxAltImg
            // 
            this.pictureBoxAltImg.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxAltImg.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBoxAltImg.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxAltImg.Image")));
            this.pictureBoxAltImg.Location = new System.Drawing.Point(432, 199);
            this.pictureBoxAltImg.Name = "pictureBoxAltImg";
            this.pictureBoxAltImg.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxAltImg.TabIndex = 37;
            this.pictureBoxAltImg.TabStop = false;
            this.pictureBoxAltImg.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(247, 915);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(362, 37);
            this.label7.TabIndex = 38;
            this.label7.Text = "Select a security answer";
            // 
            // uiRadioButtonMale
            // 
            this.uiRadioButtonMale.Checked = true;
            this.uiRadioButtonMale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiRadioButtonMale.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uiRadioButtonMale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.uiRadioButtonMale.ImageInterval = 2;
            this.uiRadioButtonMale.Location = new System.Drawing.Point(247, 1046);
            this.uiRadioButtonMale.Margin = new System.Windows.Forms.Padding(0);
            this.uiRadioButtonMale.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRadioButtonMale.Name = "uiRadioButtonMale";
            this.uiRadioButtonMale.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.uiRadioButtonMale.Radius = 3;
            this.uiRadioButtonMale.Size = new System.Drawing.Size(103, 43);
            this.uiRadioButtonMale.Style = Sunny.UI.UIStyle.Custom;
            this.uiRadioButtonMale.TabIndex = 39;
            this.uiRadioButtonMale.Text = "Male";
            // 
            // uiRadioButtonFemale
            // 
            this.uiRadioButtonFemale.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiRadioButtonFemale.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.uiRadioButtonFemale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.uiRadioButtonFemale.Location = new System.Drawing.Point(487, 1046);
            this.uiRadioButtonFemale.Margin = new System.Windows.Forms.Padding(0);
            this.uiRadioButtonFemale.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiRadioButtonFemale.Name = "uiRadioButtonFemale";
            this.uiRadioButtonFemale.Padding = new System.Windows.Forms.Padding(22, 0, 0, 0);
            this.uiRadioButtonFemale.Size = new System.Drawing.Size(136, 43);
            this.uiRadioButtonFemale.Style = Sunny.UI.UIStyle.Custom;
            this.uiRadioButtonFemale.TabIndex = 40;
            this.uiRadioButtonFemale.Text = "Female";
            // 
            // panelMajor
            // 
            this.panelMajor.BackColor = System.Drawing.Color.Transparent;
            this.panelMajor.Controls.Add(this.label8);
            this.panelMajor.Controls.Add(this.textBoxMajor);
            this.panelMajor.Controls.Add(this.pictureBox1);
            this.panelMajor.Location = new System.Drawing.Point(1, 822);
            this.panelMajor.Name = "panelMajor";
            this.panelMajor.Size = new System.Drawing.Size(900, 90);
            this.panelMajor.TabIndex = 26;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(79, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 32);
            this.label8.TabIndex = 2;
            this.label8.Text = "Major";
            // 
            // textBoxMajor
            // 
            this.textBoxMajor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.textBoxMajor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxMajor.Font = new System.Drawing.Font("Century Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxMajor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.textBoxMajor.Location = new System.Drawing.Point(188, 24);
            this.textBoxMajor.Name = "textBoxMajor";
            this.textBoxMajor.Size = new System.Drawing.Size(700, 37);
            this.textBoxMajor.TabIndex = 1;
            this.textBoxMajor.Click += new System.EventHandler(this.textBoxMajor_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(25, 21);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // register
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(900, 1200);
            this.Controls.Add(this.panelMajor);
            this.Controls.Add(this.uiRadioButtonMale);
            this.Controls.Add(this.uiRadioButtonFemale);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBoxAltImg);
            this.Controls.Add(this.textBoxAnswer);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonFlush);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.panelRepeat);
            this.Controls.Add(this.panelPassword);
            this.Controls.Add(this.panelID);
            this.Controls.Add(this.pictureBoxAdmin);
            this.Controls.Add(this.panelName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonClose);
            this.Font = new System.Drawing.Font("Century Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "register";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "register";
            this.panelRepeat.ResumeLayout(false);
            this.panelRepeat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRepeat)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panelPassword.ResumeLayout(false);
            this.panelPassword.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.panelID.ResumeLayout(false);
            this.panelID.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAdmin)).EndInit();
            this.panelName.ResumeLayout(false);
            this.panelName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAltImg)).EndInit();
            this.panelMajor.ResumeLayout(false);
            this.panelMajor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        //private string[] strQuestionList() {
        //    UserMapper newUser = new UserMapper();
        //    ArrayList arrQuestionList = new ArrayList();
        //    foreach (var question in newUser.GetAllQuestions()) {
        //        arrQuestionList.Add(question.Question.ToString());
        //    }
        //    string[] questionList = (string[])arrQuestionList.ToArray(typeof(string));
        //    return questionList;
        //}

        #endregion


        private System.Windows.Forms.Button buttonFlush;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Panel panelRepeat;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxRepeat;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Panel panelPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Panel panelID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxID;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBoxAdmin;
        private System.Windows.Forms.Panel panelName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBoxAnswer;
        private System.Windows.Forms.PictureBox pictureBoxAltImg;
        private System.Windows.Forms.Label label7;
        private Sunny.UI.UIRadioButton uiRadioButtonMale;
        private Sunny.UI.UIRadioButton uiRadioButtonFemale;
        private System.Windows.Forms.Panel panelMajor;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxMajor;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBoxRepeat;
    }
}