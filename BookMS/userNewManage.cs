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
    public partial class userNewManage : Form {
        public userNewManage() {
            InitializeComponent();
        }
        public void Table()//显示表格
{
            uiDataGridView1.Rows.Clear();//清空旧数据
            using LendController lendMapper = new LendController();
            //foreach (Lend lend in lendMapper.GetLendsByUid(Data.Uid)) {
            //    uiDataGridView1.Rows.Add(new string[] {
            //        lend.No.ToString(),
            //        lend.Bid,
            //        lend.LendTime.ToString("F"),
            //    });
            //}

        }

        private void label3_Click(object sender, EventArgs e) {

        }
    }
}
