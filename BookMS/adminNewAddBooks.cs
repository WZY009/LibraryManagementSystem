using BookMS.Mappers;
using BookMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using OfficeOpenXml;
using System.IO;

namespace BookMS {
    public partial class adminNewAddBooks : Form {
        string ID;
        public adminNewAddBooks() {
            InitializeComponent();
            //加载用户头像
        }


        private void buttonConfirm_Click(object sender, EventArgs e) {
             if (textBoxISBN.Text != "" && textBoxName.Text != "" && textBoxAuthor.Text != "" && textBoxPublish.Text != "" && textBoxStorage.Text != "")//添加健壮性检查
            {

                Book book = new Book() {
                    Id = textBoxISBN.Text,
                    Name = textBoxName.Text,
                    Author = textBoxAuthor.Text,
                    Press = textBoxPublish.Text,
                    Number = Convert.ToInt32(textBoxStorage.Text),
                };
                using BookMapper bookMapper = new BookMapper();

                if (bookMapper.AddBook(book) != null) {
                    MessageBox.Show("you are successful to add new books!");
                }
                else {
                    MessageBox.Show("you are failed to add new books!");
                }
                textBoxName.Text = "";
                textBoxISBN.Text = "";
                textBoxAuthor.Text = "";
                textBoxPublish.Text = "";
                textBoxStorage.Text = "";
                this.Close();
            }
            else {
                MessageBox.Show("the input is illegal!");
            }
        }

        private void buttonFlush_Click(object sender, EventArgs e) {
            ID = textBoxISBN.Text = null;
            textBoxName.Text = null;
            textBoxAuthor.Text = null;
            textBoxPublish.Text = null;
            textBoxStorage.Text = null;
        }

        private void textBoxName_Click(object sender, EventArgs e) {
            changeColor(textBoxName, textBoxISBN, textBoxPublish, textBoxStorage, textBoxAuthor,
                        panelName, panelISBN, panelPulish, panelAuthor, panelStorage);
        }

        private void textBoxAuthor_Click(object sender, EventArgs e) {
            changeColor(textBoxAuthor, textBoxISBN, textBoxPublish, textBoxStorage, textBoxName,
                        panelAuthor, panelISBN, panelPulish, panelName, panelStorage);
        }

        private void textBoxPublish_Click(object sender, EventArgs e) {
            changeColor(textBoxPublish, textBoxISBN, textBoxAuthor, textBoxStorage, textBoxName,
                        panelPulish, panelISBN, panelAuthor, panelName, panelStorage);
        }

        private void textBoxStorage_Click(object sender, EventArgs e) {
            changeColor(textBoxStorage, textBoxISBN, textBoxAuthor, textBoxPublish, textBoxName,
                        panelStorage, panelISBN, panelAuthor, panelName, panelPulish);
        }

        private void buttonClose_Click(object sender, EventArgs e) {
            //发现一个bug？不知道原理在哪里，当我从其他地方复制一个代码过来的时候，此时不会发生时间关联，必须
            //要自己动手双击button，然而此时生成的函数却要在末尾加一个_1，然而，不能够在designer.cs文件中解绑事件，否则仍然会报错！必须要重启以后，删掉原来的代码才行
            this.Close();
        }
        private void changeColor(TextBox changeBox, TextBox a0, TextBox a1, TextBox a2,

                 TextBox a3, Panel changePanel, Panel p0, Panel p1, Panel p2, Panel p3) {
            changeBox.BackColor = Color.White;
            changePanel.BackColor = Color.White;
            a0.BackColor = a1.BackColor = a2.BackColor = a3.BackColor = Color.FromArgb(235, 243, 255);

            p0.BackColor = p1.BackColor = p2.BackColor = p3.BackColor = Color.FromArgb(235, 243, 255);
        }

        private void textBoxISBN_Click(object sender, EventArgs e) {
            changeColor(textBoxISBN, textBoxName, textBoxPublish, textBoxStorage, textBoxAuthor,
             panelISBN, panelName, panelPulish, panelAuthor, panelStorage);
        }

        private void buttonImport_Click(object sender, EventArgs e) {
            string txtpath = null;
            OpenFileDialog opn = new OpenFileDialog();
            if (opn.ShowDialog() == System.Windows.Forms.DialogResult.OK) {
                txtpath = opn.FileName;
            }
            else
                return;
            Match match = Regex.Match(txtpath, @"[^\.]*$");
            if (match.Groups[0].Value == "xlsx" || match.Groups[0].Value == "xls" || match.Groups[0].Value == "csv") {//健壮性检验
                try {
                    DataTable dt = getDataTableFromExcel(txtpath);
                    foreach(DataRow row in dt.Rows) {
                        //MessageBox.Show(row[0].ToString());  //I find the datatable begins at 0 which does not inclues the headers.                       
                        Book newBook = new Book();
                        newBook.Id = row[0].ToString();
                        newBook.Name = row[1].ToString();
                        newBook.Author = row[2].ToString();
                        newBook.Press = row[3].ToString();
                        newBook.Number = int.Parse(row[4].ToString());                       
                        using BookMapper bookMapper = new BookMapper();
                        if (bookMapper.AddBook(newBook) == null) {
                            MessageBox.Show("bookID:"+newBook.Id+"is failed to add");
                        }
                    }

                }
                catch (System.IO.IOException) {
                    MessageBox.Show("you should not occupy the process of Excel and you need to close it before importing data! ");
                    throw;
                }
                catch (Microsoft.EntityFrameworkCore.DbUpdateException) {
                    MessageBox.Show("we are regret to tell you that there are some items that are same as those in database, so you need to check carefully! ");
                    throw;
                }
                catch(Exception ex) {
                    MessageBox.Show("You have met some errors so you need to contact with the developer! The error information is:" + ex.Message);
                }
            }
            else
                MessageBox.Show("opps! you have chosen a wrong document! we only support .xlsx, .xls and csv");
        }
        public static DataTable getDataTableFromExcel(string path) {
            using (var pck = new OfficeOpenXml.ExcelPackage()) {
                using (var stream = File.OpenRead(path)) {
                    pck.Load(stream);
                }
                var ws = pck.Workbook.Worksheets.First();
                DataTable tbl = new DataTable();

                bool hasHeader = true; 
                foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column]) {
                    tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
                }
                var startRow = hasHeader ? 2 : 1;
                for (var rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++) {
                    var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                    var row = tbl.NewRow();
                    foreach (var cell in wsRow) {
                        row[cell.Start.Column - 1] = cell.Text;
                    }
                    tbl.Rows.Add(row);
                }
                return tbl;
            }
        }

    }
}
