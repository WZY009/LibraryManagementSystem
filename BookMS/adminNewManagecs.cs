using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BookMS.Mappers;
using BookMS.Models;

namespace BookMS
{
    public partial class adminNewManagecs : Form
    {
        public string id, name, author, press, number;
        System.Drawing.Color azure = Color.FromArgb(40,140,195);
        System.Drawing.Color darkBlue = Color.FromArgb(40,90,170);
        public adminNewManagecs()
        {
            InitializeComponent();
            Table();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRefresh_MouseEnter(object sender, EventArgs e)
        {
            buttonOverview.BackColor = darkBlue;//(40, 90, 170)
        }

        private void buttonRefresh_MouseLeave(object sender, EventArgs e)
        {
            buttonOverview.BackColor = azure;//get back to the (40,140,195)
        }

        private void buttonAdd_MouseEnter(object sender, EventArgs e)
        {
            buttonProfile.BackColor = darkBlue;//(40, 90, 170)
        }

        private void buttonAdd_MouseLeave(object sender, EventArgs e)
        {
            buttonProfile.BackColor = Color.FromArgb(40, 128, 185);//get back to the (40,140,195)
        }

        private void buttonVerify_MouseEnter(object sender, EventArgs e)
        {
            buttonACSecurity.BackColor = darkBlue;
        }

        private void buttonVerify_MouseLeave(object sender, EventArgs e)
        {
            buttonACSecurity.BackColor = azure;
        }

        private void buttonDelete_MouseEnter(object sender, EventArgs e)
        {
            buttonCommunication.BackColor = darkBlue;
        }

        private void buttonDelete_MouseLeave(object sender, EventArgs e)
        {
            buttonCommunication.BackColor = Color.FromArgb(40, 128, 185);
        }

        private void buttonCheckName_MouseEnter(object sender, EventArgs e)
        {
            buttonHelp.BackColor = darkBlue; 
        }

        private void buttonCheckName_MouseLeave(object sender, EventArgs e)
        {
            buttonHelp.BackColor = azure;
        }

        private void buttonCheckID_MouseEnter(object sender, EventArgs e)
        {
            buttonLogOut.BackColor = darkBlue;
        }

        private void buttonCheckID_MouseLeave(object sender, EventArgs e)
        {
            buttonLogOut.BackColor = Color.Transparent;
        }
        public void Table()//display the table
{
            uiDataGridView1.Rows.Clear();//flush the old data
            using BookMapper bookMapper = new BookMapper();
            foreach (Book book in bookMapper.GetAllBooks())
                uiDataGridView1.Rows.Add(book.ToStringArray());
        }
        public void TableID()//show data based on ID
{
            uiDataGridView1.Rows.Clear();//flush old data
            using BookMapper bookMapper = new BookMapper();
            uiDataGridView1.Rows.Add(bookMapper.GetById(uiTextboxID.Text).ToStringArray());
        }
        public void TableName()//check the books according to the name
        {
            uiDataGridView1.Rows.Clear();//清空旧数据
            using BookMapper bookMapper = new BookMapper();
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
                    MessageBox.Show("what you have done is illegal ");
                    uiTextboxID.Text = null;
                    uiTextBoxName.Text = null;
                    break;
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e) {
            try {
                DialogResult dr = MessageBox.Show("Confirm to delete?", "Tips", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    using BookMapper bookMapper = new BookMapper();
                    if (bookMapper.DeleteById(id) != null) {
                        MessageBox.Show("Delete the book successfully");
                        Table();
                    }
                    else {
                        MessageBox.Show("Error");
                    }
                }
            }
            catch {
                MessageBox.Show("请现在表格中选择要删除的图书记录", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e) {
            Table();
            uiTextboxID.Text = null;
            uiTextBoxName.Text = null;
        }

        private void buttonAdd_Click(object sender, EventArgs e) {
            adminAddBooks admin = new adminAddBooks();
            admin.ShowDialog();
            Table();//update the data
        }

        private void buttonVerify_Click(object sender, EventArgs e) {
            try {
                adminVerify adminverify = new adminVerify(id, name, author, press, number);
                adminverify.ShowDialog();
                Table();
            }
            catch {
                MessageBox.Show("Error！");
            }
        }
        private void uiDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            id = uiDataGridView1.SelectedRows[0].Cells[0].Value.ToString();//transfer the information inside the selected units row's first cell into string, so we get the id
            name = uiDataGridView1.SelectedRows[0].Cells[1].Value.ToString();//get name
            author = uiDataGridView1.SelectedRows[0].Cells[2].Value.ToString();//get author
            press = uiDataGridView1.SelectedRows[0].Cells[3].Value.ToString();//get publish
            number = uiDataGridView1.SelectedRows[0].Cells[4].Value.ToString();//get store
        }

    }
}
