using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BookMS.Controllers;
using BookMS.Models;
using MySql.Data.MySqlClient;
using System.IO;
using Sunny.UI;

namespace BookMS.Views {
    public partial class adminNewManagecs : Form {
        public static string id, name, author, press, number;
        System.Drawing.Color azure = Color.FromArgb(40, 140, 195);
        System.Drawing.Color darkBlue = Color.FromArgb(40, 90, 170);
        System.Drawing.Color basicColor = Color.FromArgb(41, 128, 185);
        public adminNewManagecs() {
            InitializeComponent();
            Table();
            Bitmap userImage = new Bitmap("../../../icons/Admin_azure_128.png");
            userImage = ScaleImage(userImage, 180, 180);
            pictureBoxAdmin.Image = userImage;
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
        private void changeFontColor_MouseEnter(object sender, EventArgs e) {
            var currentButton = (UIImageButton)sender;
            currentButton.ForeColor = Color.Red;
        }
        private void changeFontColor_MouseLeave(object sender, EventArgs e) {
            var currentButton = (UIImageButton)sender;
            currentButton.ForeColor = basicColor;
        }
        private void changeButtonColor_MouseEnter(object sender, EventArgs e) {
            var currentButton = (Button)sender;
            currentButton.BackColor = darkBlue;
        }
        private void changeOddButtonColor_MouseLeave(object sender, EventArgs e) {//奇数变成azure
            var currentButton = (Button)sender;
            currentButton.BackColor = azure;
        }
        private void changeEvenButtonColor_MouseLeave(object sender, EventArgs e) {//偶数变透明
            var currentButton = (Button)sender;
            currentButton.BackColor = Color.Transparent;
        }
        public void Table()//display the table
        {
            uiDataGridView1.Rows.Clear();//flush the old data
            using BookController bookMapper = new BookController();
            foreach (Book book in bookMapper.GetAllBooks())
                uiDataGridView1.Rows.Add(book.ToStringArray());
        }
        public void TableID()//show data based on ID
        {
            uiDataGridView1.Rows.Clear();//flush old data
            using BookController bookMapper = new BookController();
            if (bookMapper.GetById(uiTextboxID.Text) == null) //如果返回的是一个空对象，那么就证明没有找到，在这里发现了调用堆栈查看错误的办法！shr，牛逼！
                MessageBox.Show("Sorry, we can not find what you want!");
            else
                uiDataGridView1.Rows.Add(bookMapper.GetById(uiTextboxID.Text).ToStringArray());
        }
        public void TableName()//check the books according to the name
        {
            uiDataGridView1.Rows.Clear();
            using BookController bookMapper = new BookController();
            foreach (Book book in bookMapper.GetByName(uiTextBoxName.Text))
                uiDataGridView1.Rows.Add(book.ToStringArray());
        }
        private void pictureBox2_Click(object sender, EventArgs e) {
            switch (comboBoxCheckCond.Text) {
                case "Check ID":
                    TableID();
                    uiTextboxID.Text = null;
                    uiTextBoxName.Text = null;
                    break;
                case "Check Name":
                    TableName();
                    uiTextboxID.Text = null;
                    uiTextBoxName.Text = null;
                    break;
                default:
                    MessageBox.Show("Please select a condition before starting searching ");
                    uiTextboxID.Text = null;
                    uiTextBoxName.Text = null;
                    break;
            }
        }
        private void buttonDelete_Click(object sender, EventArgs e) {
            try {
                if (int.Parse(number) != 0) {
                    DialogResult dr = MessageBox.Show("Confirm to delete?", "Tips", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK) {
                        int n = uiDataGridView1.SelectedRows.Count;
                        using BookController bookMapper = new BookController();
                        int deleteNum = 0;
                        for (int i = 0; i < n; ++i)
                            if (bookMapper.DeleteById(uiDataGridView1.SelectedRows[i].Cells[0].Value.ToString()) != 0) {
                                ++deleteNum;
                                MessageBox.Show($"Successful to delete: {uiDataGridView1.SelectedRows[i].Cells[1].Value.ToString()}");
                            }
                            else {
                                MessageBox.Show($"Failed to delete: {uiDataGridView1.SelectedRows[i].Cells[1].Value.ToString()}","Error",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            }
                        MessageBox.Show($"Successful to delete {deleteNum} pieces of infomation");
                        Table();
                    }
                }
                else {
                    DialogResult dr = MessageBox.Show("Confirm to delete? The book has been borrowed and its owner has not lend it back!", "Tips", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.OK) {
                        int n = uiDataGridView1.SelectedRows.Count;
                        using BookController bookMapper = new BookController();
                        int deleteNum = 0;
                        for (int i = 0; i < n; ++i)
                            if (bookMapper.DeleteById(uiDataGridView1.SelectedRows[i].Cells[0].Value.ToString()) != 0) {
                                ++deleteNum;
                                MessageBox.Show($"Successful to delete: {uiDataGridView1.SelectedRows[i].Cells[1].Value.ToString()}");
                            }
                            else {
                                MessageBox.Show($"Failed to delete: {uiDataGridView1.SelectedRows[i].Cells[1].Value.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        MessageBox.Show($"Successful to delete {deleteNum} pieces of infomation");
                        Table();
                    }
                }

            }
            catch {
                MessageBox.Show("Please select a book to delete", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void uiDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            for (int i = 0; i < 4; i++) {
                if(uiDataGridView1.SelectedRows[0].Cells[i].Value == null) {
                    MessageBox.Show("Sorry, please select a valid record!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            id = uiDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            name = uiDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            author = uiDataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            press = uiDataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            number = uiDataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBoxSelection.Text = $"{name}";
        }
        private void buttonLogOut_Click(object sender, EventArgs e) {
            this.Close();
        }
        private void uiTextboxID_Click(object sender, EventArgs e) {
            uiTextboxID.ForeColor = basicColor;
        }
        private void buttonACSecurity_Click(object sender, EventArgs e) {
            adminUserList list = new adminUserList();
            this.Hide();
            list.ShowDialog();
            this.Show();
        }
        private void uiImageButtonExport_Click(object sender, EventArgs e) {
            ExportToExcel.Export(uiDataGridView1,"All Books");
        }
        private void buttonRefresh_Click(object sender, EventArgs e) {
            Table();
            uiTextboxID.Text = null;
            uiTextBoxName.Text = null;
        }
        private void buttonAdd_Click(object sender, EventArgs e) {
            adminNewAddBooks admin = new adminNewAddBooks();
            admin.ShowDialog();
            Table();//update the data
        }
        private void buttonVerify_Click(object sender, EventArgs e) {
            if (id == "") {
                MessageBox.Show("opps! you did not choose a valid book!");
            }
            else {
                try {
                    adminNewVerify adminverify = new adminNewVerify(id, name, author, press, number);//将当前选中的值传过去修改界面，注意这里的构造函数进行了重载
                    adminverify.ShowDialog();
                    Table();//刷新数据
                }
                catch {
                    MessageBox.Show("Error！");
                }
            }

        }
    }
}
