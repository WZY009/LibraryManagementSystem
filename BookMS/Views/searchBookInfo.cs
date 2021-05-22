using BookMS.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookMS.Views {
    public partial class searchBookInfo : Form {
        private List<SpiderController.BookHtmlContent> _bookHtmlContents = new List<SpiderController.BookHtmlContent>();
        int number = 0;
        public searchBookInfo() {
            InitializeComponent();          
        }
        public searchBookInfo(string bookName) {
            InitializeComponent();
            uiTextBoxName.Text = bookName;
        }

        private async void pictureBoxFind_Click(object sender, EventArgs e) {
            string bookName = uiTextBoxName.Text;
            SpiderController spiderController = new SpiderController(bookName);
            int no = 1;
            if (bookName == "") MessageBox.Show("请输入书名");
            _bookHtmlContents.AddRange(await spiderController.ReadNextAsync());
            foreach(var item in _bookHtmlContents) {
                uiDataGridViewBookInfo.AddRow(no.ToString(), item.Title, item.Rate, item.Subjects);
                no++;
            }
        }
        private async void uiDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
             number = int.Parse(uiDataGridViewBookInfo.SelectedRows[0].Cells[0].Value.ToString());
            //_bookHtmlContents[number-1]
            textBoxTitle.Text = _bookHtmlContents[number - 1].Title;
            linkLabelUrl.Text = _bookHtmlContents[number - 1].Url;
            textBoxSubjects.Text = _bookHtmlContents[number - 1].Subjects;
            textBoxRate.Text = _bookHtmlContents[number - 1].Rate;
            
        }

        private void buttonClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void linkLabelUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("cmd.exe", $"/c start {linkLabelUrl.Text}");
        }
    }
}
