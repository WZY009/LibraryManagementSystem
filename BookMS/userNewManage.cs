using BookMS.Controllers;
using BookMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Globalization;

namespace BookMS {
    public partial class userNewManage : Form {
        public static string borrowNum,bookId, bookName, lendTime, expense;
        string lenderId;
        public userNewManage(string userId) {
            InitializeComponent();
            lenderId = userId;
            pictureBoxUser.Image = getImage(userId);
            uiLabelUserName.Text = getUserName(userId);
            Table(userId);
        }
        public userNewManage() {
            InitializeComponent();
        }
        public void Table(string id)
        {
            uiDataGridView1.Rows.Clear();
            using LendController lendMapper = new LendController();
            foreach(UserLend item in lendMapper.GetLendsByUid(id)) {//对借过的所有书进行遍历
                uiDataGridView1.Rows.Add(item.LandNo,item.BookID,item.BookName,item.LendTime,getExpense(item));
            }           
        }

        private double getExpense(UserLend lend) {//传入的是借阅的某一本书
            DateTime now = DateTime.Now;
            double time = (now - lend.LendTime).TotalDays;
            if (time <= 15.0)
                return 0;
            else
                return (time - 15) * 2;
        }
        private string getUserName(string id) {
            if (id != null) {
                UserController userMapper = new UserController();
                User user = userMapper.GetById(id);
                if (user != null) {
                    return user.Name;
                }
                else
                    return "";
            }
            else
                return null;
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

        private void buttonRefresh_Click(object sender, EventArgs e) {
            Table(lenderId);
        }

        private void uiImageButtonExport_Click(object sender, EventArgs e) {
            ExportToExcel.Export(uiDataGridView1);
        }

        private void pictureBoxFind_Click(object sender, EventArgs e) {
            switch (comboBoxCheckCond.Text) {
                case "Check ID":
                    TableID(lenderId);
                    uiTextboxID.Text = "";
                    uiTextBoxName.Text = "";
                    break;
                case "Check Name":
                    TableName(lenderId);
                    uiTextboxID.Text = "";
                    uiTextBoxName.Text = "";
                    break;
                default:
                    MessageBox.Show("what you have done is illegal ");
                    uiTextboxID.Text = "";
                    uiTextBoxName.Text = "";
                    break;
            }
        }
        public void TableID(string lenderId)//show data based on ID
        {
            uiDataGridView1.Rows.Clear();//flush old data
            using LendController bookMapper = new LendController();
            foreach(var item in bookMapper.GetLendsByUid(lenderId)) {
                if(item.BookID==uiTextboxID.Text) {
                    uiDataGridView1.Rows.Add(item.LandNo, item.BookID, item.BookName, item.LendTime, getExpense(item));
                    return;
                }
            }

        }
        public void TableName(string lenderId)//check the books according to the name
        {
            uiDataGridView1.Rows.Clear();//清空旧数据
            using LendController bookMapper = new LendController();
            foreach (var item in bookMapper.GetLendsByUid(lenderId)) {
                if (item.BookName.Equals(uiTextBoxName.Text)) {
                    uiDataGridView1.Rows.Add(item.LandNo, item.BookID, item.BookName, item.LendTime, getExpense(item));
                    return;
                }
            }
        }

        private void uiDataGridView1_CellClick(object sender, DataGridViewCellEventArgs e) {
            for(int i=0; i< uiDataGridView1.ColumnCount;i++) {
                if (uiDataGridView1.SelectedRows[0].Cells[i].Value == null) {
                    MessageBox.Show("you can not select a invalid cell!","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    return;
                }
            }
            borrowNum = uiDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            bookId = uiDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            bookName = uiDataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            lendTime = uiDataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            expense = uiDataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            uiTextBoxSelect.Text = bookName;
        }

        private void buttonLend_Click(object sender, EventArgs e) {
            using LendController lendMapper = new LendController();         
            if (lendMapper.ReturnBook(Convert.ToInt32(borrowNum)) > 1) {
                MessageBox.Show("Successful to lend back");
                Table(lenderId);
            }
            else {
                throw new Exception("Failed to lend back");
            }
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
        private void buttonClose_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
