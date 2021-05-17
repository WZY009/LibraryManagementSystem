using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BookMS {
    public partial class register : Form {
        public register() {
            InitializeComponent();
        }

        private void changeColor_MouseClick(TextBox changeBox, TextBox a0, TextBox a1, TextBox a2, Panel changePanel, Panel p0, Panel p1, Panel p2) {
            changeBox.BackColor = Color.White;
            changePanel.BackColor = Color.White;
            a0.BackColor = a1.BackColor = a2.BackColor =  Color.FromArgb(235, 243, 255);

            p0.BackColor = p1.BackColor = p2.BackColor =  Color.FromArgb(235, 243, 255);
        }

        private void buttonClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e) {
            string txtpath = null;
            OpenFileDialog opn = new OpenFileDialog();
            if (opn.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                txtpath = opn.FileName;
            }
            else
                return;
            //读取图片后将图片放进数据库中
        }

        private void textBoxName_Click(object sender, EventArgs e) {
            changeColor_MouseClick(textBoxName, textBoxID, textBoxPassword, textBoxRepeat, panelName, panelID, panelPassword, panelRepeat);
        }

        private void textBoxID_Click(object sender, EventArgs e) {
            changeColor_MouseClick(textBoxID, textBoxName, textBoxPassword, textBoxRepeat, panelID, panelName, panelPassword, panelRepeat);
        }

        private void textBoxPassword_Click(object sender, EventArgs e) {
            changeColor_MouseClick(textBoxPassword, textBoxName, textBoxID, textBoxRepeat, panelPassword, panelID, panelName, panelRepeat);
        }

        private void textBoxRepeat_Click(object sender, EventArgs e) {
            changeColor_MouseClick(textBoxRepeat, textBoxID, textBoxName, textBoxPassword, panelRepeat, panelPassword, panelID, panelName);
        }

        private void buttonFlush_Click(object sender, EventArgs e) {
            textBoxID.Text = textBoxName.Text = textBoxPassword.Text = textBoxRepeat.Text = textBoxAnswer.Text = null;
            comboBox1.Text = null;
        }

        private void textBoxAnswer_Click(object sender, EventArgs e) {
            if (comboBox1.SelectedItem != null) {
                textBoxAnswer.ReadOnly = false;
            }
            else {
                MessageBox.Show("Please complete all the information above before enter into your answer!", "Error tips", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBoxAnswer.ReadOnly = true;//选择栏不选不可写！
            }              
        }
        private bool isFulfill(TextBox t1, TextBox t2, TextBox t3, TextBox t4, TextBox t5,ComboBox c1) {
            return (t1.Text != null) && (t2.Text != null) && (t3.Text != null) && (t5.Text != null) && (c1.SelectedItem!= null);
        }

        private void buttonConfirm_Click(object sender, EventArgs e) {
            if (!isFulfill(textBoxID, textBoxName, textBoxPassword, textBoxRepeat, textBoxAnswer, comboBox1))
                MessageBox.Show("Please compelete all the information before register!","Error tips",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            else {
                if(isEqual(textBoxPassword,textBoxRepeat)) {
                    textBoxPassword.Enabled = true;
                    textBoxRepeat.Enabled = true;

                }
                else {
                    MessageBox.Show("Two inputs are inconsistent", "Error tips", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                //将信息注入到数据库中
            }
        }
        private bool isEqual(TextBox t1,TextBox t2) {
            if (t1.Text == t2.Text)
                return true;
            else
                return false;
        }
    }
}
