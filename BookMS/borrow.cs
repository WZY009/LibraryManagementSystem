using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookMS
{
    public partial class borrow : Form
    {
        public borrow()
        {
            InitializeComponent();
            Table();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void Table()//显示表格
        {
            dataGridView1.Rows.Clear();//清空旧数据
            Dao dao = new Dao();
            string sql = $"select [no],[bid],[datetime] from t_lend where [uid] ='{Data.Uid}'";//从
            IDataReader dc = dao.read(sql);
            string a0, a1, a2;
            while (dc.Read())//Read()函数是一个boolean型函数，如果读不到了就会返回false退出该循环
            {
                //这样更容易对数据进行操作
                a0 = dc[0].ToString();
                a1 = dc[1].ToString();
                a2 = dc[2].ToString();
                string[] table = { a0, a1, a2 };
                //将数据库内的数据显示在grid中      
                dataGridView1.Rows.Add(table);
            }
            dc.Close();
            dao.DaoClose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string no = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            string id = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            string sql = $"delete from t_lend where [no]={no};update t_book set number = number +1 where id = '{id}'";
            Dao dao = new Dao();
            if(dao.Execute(sql)>1)
            {
                MessageBox.Show("归还成功");
                Table();
            }
        }
    }
}
