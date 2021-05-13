using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BookMS.Mappers;
using BookMS.Models;
using MySql.Data.MySqlClient;
using System.IO;

namespace BookMS {
    public partial class adminNewManagecs : Form {
        public string id, name, author, press, number;
        System.Drawing.Color azure = Color.FromArgb(40, 140, 195);
        System.Drawing.Color darkBlue = Color.FromArgb(40, 90, 170);
        public adminNewManagecs() {
            InitializeComponent();
            Table();
        }

        private void buttonClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void buttonRefresh_MouseEnter(object sender, EventArgs e) {
            buttonOverview.BackColor = darkBlue;//(40, 90, 170)
        }

        private void buttonRefresh_MouseLeave(object sender, EventArgs e) {
            buttonOverview.BackColor = azure;//get back to the (40,140,195)
        }

        private void buttonAdd_MouseEnter(object sender, EventArgs e) {
            buttonProfile.BackColor = darkBlue;//(40, 90, 170)
        }

        private void buttonAdd_MouseLeave(object sender, EventArgs e) {
            buttonProfile.BackColor = Color.FromArgb(40, 128, 185);//get back to the (40,140,195)
        }

        private void buttonVerify_MouseEnter(object sender, EventArgs e) {
            buttonACSecurity.BackColor = darkBlue;
        }

        private void buttonVerify_MouseLeave(object sender, EventArgs e) {
            buttonACSecurity.BackColor = azure;
        }

        private void buttonDelete_MouseEnter(object sender, EventArgs e) {
            buttonCommunication.BackColor = darkBlue;
        }

        private void buttonDelete_MouseLeave(object sender, EventArgs e) {
            buttonCommunication.BackColor = Color.FromArgb(40, 128, 185);
        }

        private void buttonCheckName_MouseEnter(object sender, EventArgs e) {
            buttonHelp.BackColor = darkBlue;
        }

        private void buttonCheckName_MouseLeave(object sender, EventArgs e) {
            buttonHelp.BackColor = azure;
        }

        private void buttonCheckID_MouseEnter(object sender, EventArgs e) {
            buttonLogOut.BackColor = darkBlue;
        }

        private void buttonCheckID_MouseLeave(object sender, EventArgs e) {
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
                if (dr == DialogResult.OK) {
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
        private void uiImageButtonExport_Click(object sender, EventArgs e) {

            ExportToExcel.Export(uiDataGridView1);
            //d.OutputAsExcelFile(uiDataGridView1);

            //using (excelengine engine = new excelengine()) {
            //    iapplication application = engine.excel;
            //    application.defaultversion = excelversion.xlsx;

            //    //create a new workbook
            //    iworkbook workbook = application.workbooks.create(1);
            //    iworksheet sheet = workbook.worksheetgroup[0];

            //    //create a dataset from xml file 
            //    dataset dataset = new dataset();

            //    dataset.readxml(path.getfullpath(@"../../data/employees.xml"));

            //    //create a datable from the dataset
            //    datatable datatable = new datatable();
            //    datatable = dataset.tables[0];

            //    //import data from the data table
            //    sheet.importdatatable(datatable, true, 1, 1, true);

            //    //create excel table or list object and apply table style
            //    ilistobject table = sheet.listobjects.create("employee_personal_details", sheet.usedrange);
            //    table.builtintablestyle = tablebuiltinstyles.tablestylelight14;

            //    //autofit the columns
            //    sheet.usedrange.autofitcolumns();

            //    //save the file
            //    stream excelstream = file.create(path.getfullpath(@"datatable-to-excel.xlsx"));
            //    workbook.saveas(excelstream);
            //    excelstream.dispose();
            //}

            //saveexceldialog.initialdirectory = "c:";
            //saveexceldialog.title = "save as ecel file";
            //saveexceldialog.filename = "books table";
            //saveexceldialog.filter = "excel file(2003）|.xls";
            //if (saveexceldialog.showdialog() != dialogresult.cancel) {
            //    object misvalue = system.reflection.missing.value;
            //    excel.application excellapp = new excel.application();
            //    excellapp.visible = false;
            //    excel.workbook wb = excellapp.workbooks.add(excel.xlwbatemplate.xlwbatworksheet);
            //    excel.worksheet ws = (excel.worksheet)wb.activesheet;

            //    using bookmapper bookmapper = new bookmapper();//using语句的功能为当实例调用完毕后可以自动释放，这个我也不是特别清楚，可能日后还是要重学
            //    list<book> books = bookmapper.getallbooks() as list<book>;
            //    //var books = bookmapper.getallbooks();//books已经成为一个迭代器


            //    ws = (excel.worksheet)excellapp.worksheets.add(misvalue, misvalue, misvalue, misvalue);
            //    ws.name = "information";
            //    for (int j = 0; j < 5; j++) {
            //        ws.cells[1, j + 1] = "isbn";
            //        ws.cells[1, j + 1] = "book name";
            //        ws.cells[1, j + 1] = "author";
            //        ws.cells[1, j + 1] = "press";
            //        ws.cells[1, j + 1] = "storage";
            //    }
            //    int i = 0;
            //    foreach (var book in books) {
            //        for (int j = 0; j < 5; j++) {
            //            switch (j) {
            //                case 0:
            //                    ws.cells[i + 2, j + 1] = book.id;
            //                    break;
            //                case 1:
            //                    ws.cells[i + 2, j + 1] = book.name;
            //                    break;
            //                case 2:
            //                    ws.cells[i + 2, j + 1] = book.author;
            //                    break;
            //                case 3:
            //                    ws.cells[i + 2, j + 1] = book.press;
            //                    break;
            //                case 4:
            //                    ws.cells[i + 2, j + 1] = book.number.tostring();
            //                    break;
            //                default:
            //                    messagebox.show("error");
            //                    break;
            //            }
            //        }
            //        i++;
            //    }
            //    wb.saveas(saveexceldialog.filename, excel.xlfileformat.xlworkbooknormal, misvalue, misvalue, misvalue, misvalue, excel.xlsaveasaccessmode.xlexclusive, misvalue, misvalue, misvalue, misvalue, misvalue);
            //    wb.close(true, misvalue, misvalue);
            //    excellapp.quit();
            //    messagebox.show("successfully export!");
            //}


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
