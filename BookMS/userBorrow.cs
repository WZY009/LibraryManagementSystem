using BookMS.Controllers;
using BookMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BookMS {
    public partial class userBorrow : Form {
        string userId;
        public userBorrow(string userId) {
            MainView();
            Table();
            this.userId = userId;
        }
        public void MainView() {
            InitializeComponent();


        }
        public void Table()//显示表格
        {
            uiDataGridView1.Rows.Clear();//清空旧数据
            using BookController bookMapper = new BookController();
            foreach (Book book in bookMapper.GetAllBooks())
                uiDataGridView1.Rows.Add(book.ToStringArray());
        }
         private void button1_Click(object sender, EventArgs e) {
            string BookIsbn = uiDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            int number = int.Parse(uiDataGridView1.SelectedRows[0].Cells[4].Value.ToString());
            if (number < 1) {
                MessageBox.Show("The book is borrowed by other people so we suggest you to borrow it after someone lend it back","Tips",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else {
                using LendController lendMapper = new LendController();
                UserController usermap = new UserController();
                string userName = usermap.GetById(userId).Name;
                if (lendMapper.LendBook(userId, BookIsbn) > 0)
                {
                    MessageBox.Show($"{userName} borrows {uiDataGridView1.SelectedRows[0].Cells[1].Value.ToString()} successfully!");
                    Table();
                }
            }
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
                    MessageBox.Show("what you have done is illegal ");
                    uiTextboxID.Text = null;
                    uiTextBoxName.Text = null;
                    break;
            }
        }
        public void TableID()
        {
            uiDataGridView1.Rows.Clear();
            using BookController bookMapper = new BookController();
            if (bookMapper.GetById(uiTextboxID.Text) == null) 
                MessageBox.Show("Sorry, we can not find what you want!");
            else
                uiDataGridView1.Rows.Add(bookMapper.GetById(uiTextboxID.Text).ToStringArray());

        }
        public void TableName()
        {
            uiDataGridView1.Rows.Clear();
            using BookController bookMapper = new BookController();
            foreach (Book book in bookMapper.GetByName(uiTextBoxName.Text))
                uiDataGridView1.Rows.Add(book.ToStringArray());
        }

        private void buttonRefresh_Click(object sender, EventArgs e) {
            Table();
        }

        private void uiImageButtonExport_Click(object sender, EventArgs e) {
            ExportToExcel.Export(uiDataGridView1);
        }

        private void buttonClose_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
