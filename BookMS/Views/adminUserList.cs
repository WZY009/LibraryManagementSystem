using BookMS.Controllers;
using BookMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BookMS.Views {
    public partial class adminUserList : Form {
        string StuId, Name, Sex, Password, Major, Question_id, Question_Answer;
        public adminUserList() {
            InitializeComponent();
            Table();
            
        }

        private void buttonClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void buttonSubmit_Click(object sender, EventArgs e) {
            UserController usermap = new UserController();
            DialogResult dr = MessageBox.Show($"Confirm to change {textBoxName.Text}'s information?", "Tips", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (textBoxID.Text != "" && textBoxMajor.Text != "" && textBoxName.Text != "" && textBoxPassword.Text != "" && textBoxQID.Text != "" && textBoxAnswer.Text != "") {
                if (dr == DialogResult.OK) {
                    try {
                        if (textBoxID.Text.Equals(StuId)) {
                            User userChange = usermap.GetById(StuId);
                            userChange.Name = textBoxName.Text;
                            if (comboBox1.SelectedIndex == 0)
                                userChange.Sex = true;
                            else
                                userChange.Sex = false;
                            userChange.Major = textBoxMajor.Text;
                            userChange.Password = textBoxPassword.Text;
                            userChange.Question_id = int.Parse(textBoxQID.Text);
                            userChange.Question_answer = textBoxAnswer.Text;
                            if (usermap.UpdateUserInfo(userChange) > 0)
                                MessageBox.Show("Successful to change information!");
                            else
                                MessageBox.Show("Failed to change your account information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else {
                            User oldUser = usermap.GetById(StuId);
                            LendController lendmap = new LendController();                          
                            // Lend lendList = lendmap.GetLendsByUid(StuId);
                            User userChange = new User();
                            userChange.Id = textBoxID.Text;
                            userChange.PhotoPath = oldUser.PhotoPath;
                            userChange.Name = textBoxName.Text;
                            if (comboBox1.SelectedIndex == 0)
                                userChange.Sex = true;
                            else
                                userChange.Sex = false;
                            userChange.Major = textBoxMajor.Text;
                            userChange.Password = textBoxPassword.Text;
                            userChange.Question_id = int.Parse(textBoxQID.Text);
                            userChange.Question_answer = textBoxAnswer.Text;                           
                            if (usermap.AddUser(userChange) > 0 && lendmap.VerifyBook(lendmap.GetAllLends(),StuId,textBoxID.Text) != 0) {
                                MessageBox.Show("Successful to change iinformation!");
                                usermap.DeleteById(StuId);
                            }
                                
                            else
                                MessageBox.Show("Failed to change your account information!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    catch (Exception error) {
                        throw new Exception(error.Message);
                    }
                }
                Table();
            }
            else
                MessageBox.Show("Please fulfill all the information!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
               

        private void buttonRefresh_Click(object sender, EventArgs e) {
            Table();
        }

        private void uiImageButtonExport_Click(object sender, EventArgs e) {
            ExportToExcel.Export(uiDataGridView1,"User");
        }

        private void buttonDelete_Click(object sender, EventArgs e) {
            try {
                DialogResult dr = MessageBox.Show("Confirm to delete?", "Tips", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK) {
                    using UserController userMapper = new UserController();
                    if (userMapper.DeleteById(textBoxID.Text) > 0) {
                        MessageBox.Show("Delete the user successfully");
                        Table();
                    }
                    else {
                        MessageBox.Show("Error");
                    }
                }
            }
            catch {
                MessageBox.Show("Please choose a user to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Table()//display the table
        {
            uiDataGridView1.Rows.Clear();//flush the old data
            using UserController userMapper = new UserController();
            foreach (User user in userMapper.GetAllUsers())
                uiDataGridView1.Rows.Add(UserExtentions.getUserDetails(user.ToStringArray()));
        }
        public void TableID()
        {
            uiDataGridView1.Rows.Clear();
            using UserController userMapper = new UserController();
            if (userMapper.GetById(uiTextboxID.Text) == null) 
                MessageBox.Show("Sorry, we can not find the user!","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);          
            else
                uiDataGridView1.Rows.Add(userMapper.GetById(uiTextboxID.Text).ToStringArray());
        }

        private void pictureBoxFind_Click(object sender, EventArgs e) {
            TableID();
        }
        private void uiDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            for (int i = 0; i < 4; i++) {
                if (uiDataGridView1.SelectedRows[0].Cells[i].Value == null) {
                    MessageBox.Show("Sorry, please select a valid record!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            textBoxID.Text = StuId = uiDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBoxName.Text = Name = uiDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            Sex = uiDataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBoxPassword.Text = Password = uiDataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBoxMajor.Text = Major = uiDataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBoxQID.Text = Question_id = uiDataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBoxAnswer.Text = Question_Answer = uiDataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            pictureBoxUser.Image = getImage(textBoxID.Text);
            UserController user = new UserController();

            if (user.GetById(StuId).Sex)
                comboBox1.SelectedIndex = 0;
            else
                comboBox1.SelectedIndex = 1;
        }
        private Bitmap ScaleImage(Image image, int maxWidth, int maxHeight) {//提供了自动缩放功能，不论什么分辨率都可以插入，但是要注意一点，就是尽量采用128*128的图片这样不至于损失
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
        private Bitmap getImage(string id) {
            UserController userMapper = new UserController();
            User user = userMapper.GetById(id);
            if (user != null) {
                try {
                    Bitmap userImage = new Bitmap(user.PhotoPath);
                    userImage = ScaleImage(userImage, 128, 128);
                    return userImage;
                }
                catch {
                    MessageBox.Show("Sorry this user does not have portrait!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            else {
                Bitmap userImage = new Bitmap("../../../icons/User_128.png");
                userImage = ScaleImage(userImage, 128, 128);
                return userImage;
            }
        }
    }
}
