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
    public partial class admin2_1 : Form
    {
        public admin2_1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {       
            if(textBoxId.Text!="" && textBoxName.Text != "" && textBoxAuthor.Text != "" && textBoxPress.Text != "" && textBoxStore.Text != "")//添加健壮性检查
            {
                Dao dao = new Dao();
                string sql = $"insert into t_book values('{textBoxId.Text}','{textBoxName.Text}','{textBoxAuthor.Text}','{textBoxPress.Text}',{textBoxStore.Text})";//最后一个是int类型的数据因此可以不单引号
                int n = dao.Execute(sql);
                if (n > 0)
                {
                    MessageBox.Show("添加成功");//弹出添加成功的窗口
                }
                else
                {
                    MessageBox.Show("添加失败");
                }
                //添加完毕以后就清空文本框所有内容
                textBoxName.Text = "";
                textBoxId.Text = "";
                textBoxAuthor.Text = "";
                textBoxPress.Text = "";
                textBoxStore.Text = "";
                //这里如果我想让之前的table更新咋做？（如果不写在admin2中只写这里面？）
                this.Close();//关闭窗口
            }
            else
            {
                MessageBox.Show("输入不合法，添加失败");
            }

        }

        private void Flush_Click(object sender, EventArgs e)
        {
            //清空文本框所有内容
            textBoxName.Text = "";
            textBoxId.Text = "";
            textBoxAuthor.Text = "";
            textBoxPress.Text = "";
            textBoxStore.Text = "";
        }
    }
}
