using BookMS.Controllers;
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
    public partial class userInformation : Form {
        string userId = null;
        public userInformation() {
            InitializeComponent();
        }
        public userInformation(string userId) {
            InitializeComponent();
            pictureBoxUser.Image = getImage(userId);
            textBoxID.Text = getUserInfo(userId)[0];
            textBoxName.Text = getUserInfo(userId)[1];
            textBoxPassword.Text = getUserInfo(userId)[2];
            textBoxRepeat.Text = getUserInfo(userId)[2];
            textBoxMajor.Text = getUserInfo(userId)[3];
            this.userId = userId;
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
            try {
                Bitmap userImage = new Bitmap(user.PhotoPath);
                userImage = ScaleImage(userImage, 128, 128);
                return userImage;
            }
            catch {
                MessageBox.Show("Sorry your id is not correct", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private string[] getUserInfo(string id) {
            string[] userInfo =new string[4];
            if (id != null) {
                UserController userMapper = new UserController();
                User user = userMapper.GetById(id);
                if (user != null) {
                    userInfo[0] = user.Id;
                    userInfo[1] = user.Name;
                    userInfo[2] = user.Password;
                    userInfo[3] = user.Major;
                    return userInfo;
                }
                else {
                    MessageBox.Show("Sorry,we can not find user according to your id!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }                   
            }
            else
                return null;
        }

        private void pictureBoxAltImg_Click(object sender, EventArgs e) {
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
                    string fileStore = $"../../../userImage/{filename}";
                    FileInfo saveFile = new FileInfo(fileStore);
                    System.IO.File.Copy(txtpath, saveFile.FullName, true);
                    Bitmap userImage = new Bitmap(saveFile.FullName);
                    userImage = ScaleImage(userImage, 128, 128);
                    pictureBoxUser.Image = userImage;
                    pictureBoxAltImg.BackColor = Color.Transparent;
                    UserController usermap = new UserController();
                    usermap.UploadPhoto(userId, fileStore);                  
                }
                catch (Exception) {
                    MessageBox.Show("Error! Please contact with me", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
                MessageBox.Show("You have chosen a wrong document! we only support .png and .jpg", "Error tips", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void buttonClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void pictureBoxVerifyName_Click(object sender, EventArgs e) {
            textBoxName.ReadOnly = false;
            textBoxName.Text = "";
        }

        private void pictureBoxVerifyMajor_Click(object sender, EventArgs e) {
            textBoxMajor.ReadOnly = true;
            textBoxMajor.Text = "";
        }

        private void PBnewPassword_Click(object sender, EventArgs e) {
            textBoxPassword.ReadOnly = true;
            textBoxRepeat.ReadOnly = true;
            textBoxPassword.Text = "";
            textBoxRepeat.Text = "";
        }
    }
}
