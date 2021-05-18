using BookMS.Mappers;
using BookMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BookMS {
    public partial class forget : Form {
        public forget() {
            InitializeComponent();
        }
        private bool isEqual(TextBox t1, TextBox t2) {
            if (t1.Text == t2.Text)
                return true;
            else
                return false;
        }

        private void buttonClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void buttonFlush_Click(object sender, EventArgs e) {
            textBoxID.Text=textBoxName.Text=null;
        }

        private void buttonConfirm_Click(object sender, EventArgs e) {
            if (isEqual(textBoxPassword.Text, textBoxRepeat.Text)) {
                UserMapper userVerify = new UserMapper();
                User fogetter = userVerify.GetById(textBoxID.Text);
                fogetter.Password = textBoxPassword.Text;
                if(userVerify.ChangePassword(fogetter)!=null)
                    MessageBox.Show("Successful!");
            }
            else
                MessageBox.Show("Two inputs are inconsistent", "Error tips", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        private void buttonVerify_Click(object sender, EventArgs e) {
            if (isValid(textBoxID.Text, textBoxName.Text,textBoxAnswer.Text)) {
                textBoxPassword.ReadOnly = textBoxRepeat.ReadOnly = false;
                buttonConfirm.Enabled = buttonFlush2.Enabled = true;
                buttonFlush.Enabled = false;//禁用掉之前的flush
            }
            else
                MessageBox.Show("Sorry, the verification does not pass! ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private bool isValid(string id, string name,string anwser) {//是否能够通过验证
            if (id != "" && name != "") {//woc，原来string类型的“”和null是两回事啊
                UserMapper userVerify = new UserMapper();
                User forgetter = userVerify.GetById(id);//根据Id查找到的人
                if (forgetter.Question_answer.Equals(anwser) && forgetter.Name.Equals(name))//如果名字和Id能对上，问题回答和答案能对上
                    return true;
                else
                    return false;
            }
            else
                MessageBox.Show("Please complete your name and id!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
        private bool isEqual(string password,string repeat) {//验证密码和重复密码是否相同
            if (password.Equals(repeat) && password!="")
                return true;
            else
                return false;
        }

        
        private void buttonFlush2_Click(object sender, EventArgs e) {
            textBoxPassword.Text = textBoxRepeat.Text = null;
        }

        private void textBoxAnswer_Click(object sender, EventArgs e) {//显示问题
            textBoxAnswer.ReadOnly = true;
            if (textBoxID.Text != "" && textBoxName.Text != "") {
                UserMapper usermap = new UserMapper();
                User forgetter = usermap.GetById(textBoxID.Text);               
                if(forgetter != null && forgetter.Name == textBoxName.Text) {//前面一个是没有找到Id对应的user，后一个是虽然找到了，但是对不上
                    foreach (VerifyQuestion question in usermap.GetAllQuestions()) {
                        if (question.ID == forgetter.Question_id)
                            textBoxQuestion.Text = question.Question;
                    }
                    textBoxAnswer.ReadOnly = false;
                }
                else {
                    MessageBox.Show("your Name and Id do not match!", "Error!");
                    return;
                }

            }
            else
                MessageBox.Show("Please input your Name and Id before answering question");
        }


    }

}
