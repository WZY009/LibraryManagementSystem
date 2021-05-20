using BookMS.Controllers;
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

namespace BookMS.Views {
    public partial class bookCheck : Form {
        public bookCheck() {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void bookCheck_Load(object sender, EventArgs e) {
            Table();
        }
        public void Table()//显示表格
        {
            dataGridView1.Rows.Clear();//清空旧数据
            using BookController bookMapper = new BookController();
            foreach (Book book in bookMapper.GetAllBooks())
                dataGridView1.Rows.Add(book.ToStringArray());
            //Dao dao = new Dao();
            //string sql = $"select  * from t_book";
            //IDataReader dc = dao.read(sql);
            //string a0, a1, a2, a3, a4;
            //while (dc.Read())//Read()函数是一个boolean型函数，如果读不到了就会返回false退出该循环
            //{
            //    //这样更容易对数据进行操作
            //    a0 = dc[0].ToString();
            //    a1 = dc[1].ToString();
            //    a2 = dc[2].ToString();
            //    a3 = dc[3].ToString();
            //    a4 = dc[4].ToString();
            //    string[] table = { a0, a1, a2, a3, a4 };
            //    //将数据库内的数据显示在grid中      
            //    dataGridView1.Rows.Add(table);
            //}
            //dc.Close();
            //dao.DaoClose();
        }

        private void button1_Click(object sender, EventArgs e) {
            string id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//获取书号
            int number = int.Parse(dataGridView1.SelectedRows[0].Cells[4].Value.ToString());//获取库存
            if (number < 1) {
                MessageBox.Show("库存不足，请等待其他用户归还图书后再借书");
            }
            else {
                //string sql = $"insert into t_lend([uid], bid, [datetime]) values('{Data.Uid}','{id}', getdate()); update t_book set number = number - 1 where id ='{id}'";
                //Dao dao = new Dao();
                using LendController lendMapper = new LendController();
                if (lendMapper.LendBook(Data.Uid, id) > 0)//这里的意思指的是如果执行成功将会返回sql语句成功的数量，大于一才是都执行成功
                {
                    MessageBox.Show($"用户{Data.UName}借出了图书{id}");
                    Table();
                }
            }

        }
    }
}
