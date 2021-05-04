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
    public partial class login : Form {
        public login() {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) {
            if (textBox1.Text != "" && textBox2.Text != "") {
                Login();
            }
            else {
                MessageBox.Show("输入有空项，请重新输入 ");
            }

        }
        //登陆方法，验证是否允许登录
        public void Login() {
            //用户
            if (radioButtonUser.Checked == true) {
                Dao dao = new Dao();
                string sql = "select * from t_user where id='" + textBox1.Text + "' and password='" + textBox2.Text + "' ";
                //MessageBox.Show(sql);  //中间的某次检验
                IDataReader dc = dao.read(sql);
                if (dc.Read())//读取数据,返回的是一个布尔型变量，如果读到了匹配的就返回一个真
                {
                    MessageBox.Show("用户登陆成功");
                    Data.Uid = dc["id"].ToString();//将数据库的id赋给data
                    Data.UName = dc["name"].ToString();

                    user1 user = new user1();
                    this.Hide();//隐藏掉登录窗体
                    user.ShowDialog();//对话框模式打开新的user界面
                    this.Show();//结束掉user界面的进程后重新打开登录窗体
                }
                else {
                    MessageBox.Show("用户登陆失败");
                }
            }

            //管理员
            if (radioButtonAdmin.Checked == true) {
                if (Login_Admin(id: textBox1.Text, password: textBox2.Text) != null) {
                    MessageBox.Show("管理员登陆成功");
                    admin1 administrator = new admin1();
                    this.Hide();
                    administrator.ShowDialog();
                    this.Show();

                }
                else {
                    MessageBox.Show("管理员登陆失败");

                }
            }
        }
        private Admin Login_Admin(string id, string password) => new AdminMapper().Get(id, password);
    }
}
