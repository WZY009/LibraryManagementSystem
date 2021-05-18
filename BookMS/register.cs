using BookMS.Mappers;
using BookMS.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BookMS {
    public partial class register : Form {
        string fileStore = null;
        TextBox[] textbox = new TextBox[] { };
        Panel[] panel = new Panel[] { };
        public register() {
            InitializeComponent();
            textbox = new TextBox[] {textBoxName, textBoxID, textBoxPassword, textBoxRepeat, textBoxMajor};//注意，以下这两个数组的顺序绝对不可以颠倒！
            panel = new Panel[] { panelName, panelID, panelPassword, panelRepeat, panelMajor };
            comboBox1.Items.AddRange(strQuestionList());
        }
        private string[] strQuestionList() {
            UserMapper newUser = new UserMapper();
            ArrayList arrQuestionList = new ArrayList();
            foreach (var question in newUser.GetAllQuestions()) {
                arrQuestionList.Add(question.Question.ToString());
            }
            string[] questionList = (string[])arrQuestionList.ToArray(typeof(string));
            return questionList;
        }
        private void changeColor_MouseClick(TextBox changeBox, TextBox a0, TextBox a1, TextBox a2, Panel changePanel, Panel p0, Panel p1, Panel p2) {
            changeBox.BackColor = Color.White;
            changePanel.BackColor = Color.White;
            a0.BackColor = a1.BackColor = a2.BackColor =  Color.FromArgb(235, 243, 255);

            p0.BackColor = p1.BackColor = p2.BackColor =  Color.FromArgb(235, 243, 255);
        }

        private void changeColor_MouseClick(TextBox[] textbox, Panel[] panel,int change) {
            foreach(TextBox item in textbox) {
                item.BackColor= Color.FromArgb(235, 243, 255);
            }
            foreach(Panel item in panel) {
                item.BackColor= Color.FromArgb(235, 243, 255); 
            }
            textbox[change].BackColor = Color.White;
            panel[change].BackColor = Color.White;
        }
        private void buttonClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void textBoxName_Click(object sender, EventArgs e) {
            changeColor_MouseClick(textbox,panel,0);
        }

        private void textBoxID_Click(object sender, EventArgs e) {
            changeColor_MouseClick(textbox, panel, 1);
        }

        private void textBoxPassword_Click(object sender, EventArgs e) {
            changeColor_MouseClick(textbox, panel, 2);
        }

        private void textBoxRepeat_Click(object sender, EventArgs e) {
            changeColor_MouseClick(textbox, panel, 3);
        }

        private void textBoxMajor_Click(object sender, EventArgs e) {
            changeColor_MouseClick(textbox, panel, 4);
        }
        private void buttonFlush_Click(object sender, EventArgs e) {
            textBoxID.Text = textBoxName.Text = textBoxPassword.Text = textBoxRepeat.Text = textBoxAnswer.Text = null;
            comboBox1.Text = null;
        }

        private void textBoxAnswer_Click(object sender, EventArgs e) {           
            if (comboBox1.SelectedItem != null) {
                textBoxAnswer.ReadOnly = false;
                textBoxAnswer.Text = null;//清空预置的Answer字符串
                textBoxAnswer.BackColor = Color.White;
            }
            else {
                MessageBox.Show("Please complete all the information above before enter into your answer!", "Error tips", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxAnswer.ReadOnly = true;//选择栏不选不可写！
            }              
        }
        private bool isFulfill(TextBox[] textbox,ComboBox c1) {
            bool flag = true ;
            foreach(TextBox item in textbox) {
                if(item.Text==null) {
                    flag = false;
                    return flag ;
                }
            }
            return flag && (c1.SelectedItem != null);
        }

        private void buttonConfirm_Click(object sender, EventArgs e) {
            if (!(isFulfill(textbox,comboBox1)&&(textBoxAnswer!=null)))
                MessageBox.Show("Please compelete all the information before register!","Error tips",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            else {
                if(isEqual(textBoxPassword,textBoxRepeat)) {
                    //将信息注入到数据库中
                    int question_id = 0;
                    UserMapper newUser = new UserMapper();
                    foreach(VerifyQuestion question in newUser.GetAllQuestions()) {
                        if (comboBox1.Text == question.Question)
                            question_id = question.ID;
                    }
                    if (question_id > 0) {
                        User user = new User() {
                            Id = textBoxID.Text,
                            Name = textBoxName.Text,
                            Password = textBoxPassword.Text,
                            PhotoPath = fileStore,
                            Major = textBoxMajor.Text,
                            Question_answer = textBoxAnswer.Text,
                            Sex = uiRadioButtonMale.Checked ? true : false,
                            Question_id = question_id
                        };
                        if (newUser.AddUser(user) != null) {
                            MessageBox.Show("Successful to register", "Tips window", MessageBoxButtons.OK);
                            this.Close();
                        }
                    }
                    else
                        MessageBox.Show("Sorry, the question is not included in the table","Error");
                }
                else {
                    MessageBox.Show("Two inputs are inconsistent", "Error tips", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
        }
        private bool isEqual(TextBox t1,TextBox t2) {
            if (t1.Text == t2.Text)
                return true;
            else
                return false;
        }
        private void pictureBox1_Click(object sender, EventArgs e) {
            string txtpath = null;//这个是用户选择的图片的绝对路径

            OpenFileDialog opn = new OpenFileDialog();
            if (opn.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                txtpath = opn.FileName;                
            }
            else
                return;
            Match match1 = Regex.Match(txtpath, @"[^\.]*$");
            string filename = Path.GetFileName(txtpath);
            if (match1.Groups[0].Value == "png" || match1.Groups[0].Value == "jpg") {//健壮性检验
                try {
                    fileStore = $"../../../userImage/{filename}";
                    FileInfo saveFile = new FileInfo(fileStore);
                    System.IO.File.Copy(txtpath, saveFile.FullName, true);
                    Bitmap userImage = new Bitmap(saveFile.FullName);
                    userImage = ScaleImage(userImage,128,128);                   
                    pictureBoxAdmin.Image = userImage;
                    pictureBoxAltImg.BackColor = Color.Transparent;
                }
                catch (Exception) {
                    MessageBox.Show("Error! Please contact with me", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("You have chosen a wrong document! we only support .png and .jpg","Error tips", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        static public Bitmap ScaleImage(Image image, int maxWidth, int maxHeight) {//提供了自动缩放功能，不论什么分辨率都可以插入，但是要注意一点，就是尽量采用128*128的图片这样不至于损失
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);
            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);
            var newImage = new Bitmap(newWidth, newHeight);
            Graphics.FromImage(newImage).DrawImage(image, 0, 0, newWidth, newHeight);
            Bitmap bmp = new Bitmap(newImage);
            return bmp;
        }
    }
}
