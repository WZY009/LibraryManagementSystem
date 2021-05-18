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
using System.Drawing.Drawing2D;

namespace BookMS
{
    public partial class login : Form
    {
        public login()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }


        //登陆方法，验证是否允许登录
        public void Login()
        {
            //用户
            if (uiRadioButtonUser.Checked == true)
            {
                User usr = Login_User(id: textBoxUserNum.Text, password: textBoxPassword.Text);
                if (usr != null)//读取数据,返回的是一个布尔型变量，如果读到了匹配的就返回一个真
                {
                    MessageBox.Show("you are successful to log in a user account");
                    Data.Uid = usr.Id;
                    Data.UName = usr.Name;

                    userBasic user = new userBasic();
                    this.Hide();//隐藏掉登录窗体
                    user.ShowDialog();//对话框模式打开新的user界面
                    this.Show();//结束掉user界面的进程后重新打开登录窗体
                }
                else
                {
                    MessageBox.Show("you are failed to log in");
                }
            }

            //管理员
            if (uiRadioButtonAdmin.Checked == true)
            {
                if (Login_Admin(id: textBoxUserNum.Text, password: textBoxPassword.Text) != null)
                {
                    MessageBox.Show("you are successful to log in an administrator account");
                    adminNewManagecs administrator = new adminNewManagecs();
                    this.Hide();
                    administrator.ShowDialog();
                    this.Show();

                }
                else
                {
                    MessageBox.Show("you are failed to log in");

                }
            }
        }
        private Admin Login_Admin(string id, string password) => new AdminMapper().Get(id, password);
        private User Login_User(string id, string password) => new UserMapper().Get(id, password);

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (textBoxUserNum.Text != "" && textBoxPassword.Text != "")
            {
                Login();
            }
            else
            {
                MessageBox.Show("some information has not been completed yet!","Error",MessageBoxButtons.YesNo,MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBoxUserNum_Click(object sender, EventArgs e)
        {
            textBoxUserNum.BackColor = Color.White;
            panelUser.BackColor = Color.White;
            panelPassword.BackColor = Color.FromArgb(235, 243, 255);
            textBoxPassword.BackColor = Color.FromArgb(235, 243, 255);

        }


        private void textBoxPassword_Click(object sender, EventArgs e)
        {
            textBoxPassword.BackColor = Color.White;
            panelPassword.BackColor = Color.White;
            panelUser.BackColor = Color.FromArgb(235, 243, 255);
            textBoxUserNum.BackColor = Color.FromArgb(235, 243, 255);
        }

        private void pictureBoxPassword_MouseDown(object sender, MouseEventArgs e)
        {
            if(textBoxPassword.UseSystemPasswordChar)
                textBoxPassword.UseSystemPasswordChar = false;
            else
                textBoxPassword.UseSystemPasswordChar = true;
        }

        private void buttonRegister_Click(object sender, EventArgs e) {
            register newUser = new register();
            this.Hide();
            newUser.ShowDialog();
            this.Show();
        }

        private void buttonForget_MouseEnter(object sender, EventArgs e) {
            buttonForget.ForeColor = Color.Red;
        }

        private void buttonForget_MouseLeave(object sender, EventArgs e) {
            buttonForget.ForeColor = Color.FromArgb(41, 128, 185);
        }

        private void buttonForget_Click(object sender, EventArgs e) {
            forget user = new forget();
            user.ShowDialog();
            this.Hide();
        }
    }
}

 




