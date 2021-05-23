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
        private Stack<DataTable> dtStack = new Stack<DataTable>();
        SpiderController spiderController;
        List<PictureBox> pictureBoxes = new List<PictureBox>();
        int no = 1;//书本在dataGridView的编号
        public searchBookInfo() {
            InitializeComponent();
            pictureBoxes.Add(pictureBoxStar1);
            pictureBoxes.Add(pictureBoxStar2);
            pictureBoxes.Add(pictureBoxStar3);
            pictureBoxes.Add(pictureBoxStar4);
            pictureBoxes.Add(pictureBoxStar5);
        }
        public searchBookInfo(string bookName) {
            InitializeComponent();
            uiTextBoxName.Text = bookName;
            pictureBoxes.Add(pictureBoxStar1);
            pictureBoxes.Add(pictureBoxStar2);
            pictureBoxes.Add(pictureBoxStar3);
            pictureBoxes.Add(pictureBoxStar4);
            pictureBoxes.Add(pictureBoxStar5);
        }

        private async void pictureBoxFind_Click(object sender, EventArgs e) {
            string bookName = uiTextBoxName.Text;
            spiderController = new SpiderController(bookName);
            if (bookName == "")
                MessageBox.Show("Please input book name before searching","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            _bookHtmlContents.AddRange(await spiderController.ReadNextAsync());
            foreach(var item in _bookHtmlContents) {
                uiDataGridViewBookInfo.AddRow(no.ToString(), item.Title, item.Rate, item.Subjects);
                no++;
            }
            pictureBoxFind.Enabled = false;//防止多次点击
        }
        private async void uiDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {//选择函数

            int number = int.Parse(uiDataGridViewBookInfo.SelectedRows[0].Cells[0].Value.ToString());

            textBoxTitle.Text = "《" + _bookHtmlContents[number - 1].Title + "》";//由于是从1开始所以要减1
            linkLabelUrl.Text = _bookHtmlContents[number - 1].Url;
            textBoxSubjects.Text = _bookHtmlContents[number - 1].Subjects;
            textBoxRate.Text = _bookHtmlContents[number - 1].Rate;
            textBoxDetail.Text = _bookHtmlContents[number - 1].Detail;
            starClear();
            if(textBoxRate.Text!="")
                getStar(double.Parse(textBoxRate.Text));
        }

        private void buttonClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void linkLabelUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            System.Diagnostics.Process.Start("cmd.exe", $"/c start {linkLabelUrl.Text}");
        }
        private void getStar(double rate) {
            string starSolid = "../../../icons/RateSolid_32.png";
            string starHalf = "../../../icons/RateHalf_32.png";
            string starEmpty = "../../../icons/Rate_32.png";
            int solidCount = (int)Math.Floor(rate / 2);
            int halfCount = (int)Math.Ceiling(rate / 2 - solidCount);
            //MessageBox.Show($"{pictureBoxes.Count}");
            for(int i = 0; i < solidCount; i++) 
                pictureBoxes[i].Image = Image.FromFile(starSolid);
            for (int i = 0; i < halfCount; i++)
                pictureBoxes[i + solidCount].Image = Image.FromFile(starHalf);
            for (int i = 0; i < 5-solidCount-halfCount; i++)
                pictureBoxes[i + solidCount + halfCount].Image = Image.FromFile(starEmpty);
        }
        private void starClear() {
            string starEmpty = "../../../icons/Rate_32.png";
            for (int i = 0; i < 5; i++) {
                pictureBoxes[i].Image = Image.FromFile(starEmpty);
            }
        }

        private async void pictureBoxNext_Click(object sender, EventArgs e) {
            if (!pictureBoxFind.Enabled) {//只有当搜索工作完成了以后，才允许点击下一栏
                DataTable dt = new DataTable();
                dt = GetDgvToTable(uiDataGridViewBookInfo);
                dtStack.Push(dt);
                uiDataGridViewBookInfo.Rows.Clear();
                try {
                    _bookHtmlContents.AddRange(await spiderController.ReadNextAsync());//继续加载下一个界面
                    foreach (var item in _bookHtmlContents) {
                        uiDataGridViewBookInfo.AddRow(no.ToString(), item.Title, item.Rate, item.Subjects);
                        no++;
                    }
                }
                catch (Exception error) {
                    MessageBox.Show(error.Message, "Error");
                }
            }

        }
        private void pictureBoxBefore_Click(object sender, EventArgs e) {
            //MessageBox.Show(dtStack.Pop().Rows[0].ItemArray[1].ToString());//不知道为啥，从栈弹出来的datatable就非常正常，然后绑定以后就没法继续显示了，里面全是空值
            if (!pictureBoxFind.Enabled){
                uiDataGridViewBookInfo.DataSource = dtStack.Pop();
            }

        }
        private DataTable GetDgvToTable(DataGridView dgv) {
            DataTable dt = new DataTable();
            // 列强制转换
            for (int count = 0; count < dgv.Columns.Count; count++) {
                DataColumn dc = new DataColumn(dgv.Columns[count].Name);
                dt.Columns.Add(dc);
            }
            // 循环行
            for (int count = 0; count < dgv.Rows.Count; count++) {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++) {
                    dr[countsub] = dgv.Rows[count].Cells[countsub].Value;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        private void uiTextBoxName_TextChanged(object sender, EventArgs e) {
            pictureBoxFind.Enabled = true;
        }
        
    }
}
