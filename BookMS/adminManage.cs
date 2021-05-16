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

namespace BookMS {
    public partial class adminManage : Form {
        public adminManage() {
            InitializeComponent();
        }

        private void admin2_Load(object sender, EventArgs e) {
            Table();//放在这里和放在上面其实差不多，放在这里表示的是当整个窗体构建完成以后开始显示table表格
            //label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString()+" "+ dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//注意这里默认选用第一行
        }
        //从数据库读取数据，显示在表格控件中
        public void Table()//显示表格
        {
            dataGridView1.Rows.Clear();//清空旧数据
            using BookMapper bookMapper = new BookMapper();
            foreach (Book book in bookMapper.GetAllBooks())
                dataGridView1.Rows.Add(book.ToStringArray());

            //Dao dao = new Dao();
            //string sql = $"select  * from t_book";
            //IDataReader dc = dao.read(sql);
            //string a0, a1, a2, a3, a4;
            //while(dc.Read())//Read()函数是一个boolean型函数，如果读不到了就会返回false退出该循环
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
        public void TableID()//根据书号显示数据
        {
            dataGridView1.Rows.Clear();//清空旧数据
            using BookMapper bookMapper = new BookMapper();
            dataGridView1.Rows.Add(bookMapper.GetById(textBoxIDCheck.Text).ToStringArray());

            //Dao dao = new Dao();
            //string sql = $"select  * from t_book where id = '{textBoxIDCheck.Text}'";//通过where语句进行查询
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
        public void TableName()//根据书名进行模糊查询
        {
            dataGridView1.Rows.Clear();//清空旧数据
            using BookMapper bookMapper = new BookMapper();
            foreach (Book book in bookMapper.GetByName(textBoxNameCheck.Text))
                dataGridView1.Rows.Add(book.ToStringArray());

            //Dao dao = new Dao();
            //string sql = $"select  * from t_book where name like '%{textBoxNameCheck.Text}'";//通过where语句进行查询
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
        private void button2_Click(object sender, EventArgs e) {
            try {
                DialogResult dr = MessageBox.Show("确认删除吗？", "信息提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)//假如它选的是ok
                {
                    //string sql = $"delete from t_book where id='{id}'";//sql的删除语句
                    //Dao dao = new Dao();
                    using BookMapper bookMapper = new BookMapper();
                    //if (dao.Execute(sql) > 0) 
                    if (bookMapper.DeleteById(id) != null) {
                        MessageBox.Show("删除成功");
                        Table();
                    }
                    else {
                        MessageBox.Show("删除失败");
                    }
                }
            }
            catch {
                MessageBox.Show("请现在表格中选择要删除的图书记录", "信息提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 添加图书
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e) {
            adminAddBooks admin = new adminAddBooks();
            admin.ShowDialog();
            Table();//刷新数据
        }


        private void dataGridView1_Click(object sender, EventArgs e)//点击表格元素进行选择的函数
        {
            label2.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString() + " " + "《" + dataGridView1.SelectedRows[0].Cells[1].Value.ToString() + "》";//选中一栏
            id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();//将选中的单元格的第0行的第0格里面的值转化成字符串表示，即获取书号
            name = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();//获取name
            author = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();//获取作者
            press = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();//获取出版社
            number = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();//获取库存量
        }
        public string id, name, author, press, number;

        private void buttonMultiDelete_Click(object sender, EventArgs e)//多行删除
        {
            int n = dataGridView1.SelectedRows.Count;//获取当前选中的行数
            //string sql = $"delete from t_book where id in(";
            //for (int i = 0; i < n; i++) {
            //    sql += $"'{dataGridView1.SelectedRows[i].Cells[0].Value.ToString()}',";
            //}
            //sql = sql.Remove(sql.Length - 1);//删除最后一个字符
            //sql += ")";
            //Dao dao = new Dao();
            using BookMapper bookMapper = new BookMapper();
            int deleteNum = 0;
            for (int i = 0; i < n; ++i)
                if (bookMapper.DeleteById(dataGridView1.SelectedRows[i].Cells[0].Value.ToString()) != null)
                    ++deleteNum;
            //if (dao.Execute(sql) > n - 1) {
            MessageBox.Show($"成功删除{deleteNum}条图书信息");
            Table();//刷新
            //}
        }

        private void button6_Click(object sender, EventArgs e)//书名查询
        {
            TableName();
            textBoxNameCheck.Text = "";//清空
        }

        private void button5_Click(object sender, EventArgs e)//书号查询
        {
            TableID();
            textBoxIDCheck.Text = "";//清空
        }

        private void button4_Click(object sender, EventArgs e)//刷新按钮
        {
            Table();
            textBoxNameCheck.Text = "";//清空
            textBoxIDCheck.Text = "";//清空
        }

        private void button3_Click(object sender, EventArgs e)//修改
        {
            try {
                adminVerify adminverify = new adminVerify(id, name, author, press, number);//将当前选中的值传过去修改界面，注意这里的构造函数进行了重载
                adminverify.ShowDialog();
                Table();//刷新数据
            }
            catch {
                MessageBox.Show("错误！");
            }

        }
    }
}
