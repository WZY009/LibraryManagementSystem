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
    public partial class login : Form {
        bool check = false;//定义不可查看的标志
        public login() {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            pictureBoxCheck.Image = Image.FromFile("../../../icons/Check_32.png");
        }


        //登陆方法，验证是否允许登录
        public void Login() {
            //用户
            if (uiRadioButtonUser.Checked == true) {
                User usr = Login_User(id: textBoxUserNum.Text, password: textBoxPassword.Text);
                if (usr != null)//读取数据,返回的是一个布尔型变量，如果读到了匹配的就返回一个真
                {
                    MessageBox.Show("you are successful to log in a user account");
                    Data.Uid = usr.Id;
                    Data.UName = usr.Name;
                    userNewManage user = new userNewManage(textBoxUserNum.Text);
                    this.Hide();//隐藏掉登录窗体
                    user.ShowDialog();//对话框模式打开新的user界面
                    this.Show();//结束掉user界面的进程后重新打开登录窗体
                }
                else {
                    MessageBox.Show("you are failed to log in");
                }
            }
            //管理员
            if (uiRadioButtonAdmin.Checked == true) {
                if (Login_Admin(id: textBoxUserNum.Text, password: textBoxPassword.Text) != null) {
                    MessageBox.Show("you are successful to log in an administrator account");
                    adminNewManagecs administrator = new adminNewManagecs();
                    this.Hide();
                    administrator.ShowDialog();
                    this.Show();

                }
                else {
                    MessageBox.Show("you are failed to log in");

                }
            }
        }
        private Admin Login_Admin(string id, string password) => new AdminController().Get(id, password);
        private User Login_User(string id, string password) => new UserController().Get(id, password);

        private void buttonLogin_Click(object sender, EventArgs e) {
            if (textBoxUserNum.Text != "" && textBoxPassword.Text != "") {
                this.Hide();
                Login();
                this.Show();
            }
            else {
                MessageBox.Show("some information has not been completed yet!", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
        }

        private void buttonClose_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        private void textBoxUserNum_Click(object sender, EventArgs e) {
            textBoxUserNum.BackColor = Color.White;
            panelUser.BackColor = Color.White;
            panelPassword.BackColor = Color.FromArgb(235, 243, 255);
            textBoxPassword.BackColor = Color.FromArgb(235, 243, 255);

        }


        private void textBoxPassword_Click(object sender, EventArgs e) {
            textBoxPassword.BackColor = Color.White;
            panelPassword.BackColor = Color.White;
            panelUser.BackColor = Color.FromArgb(235, 243, 255);
            textBoxUserNum.BackColor = Color.FromArgb(235, 243, 255);
            pictureBoxCheck.Image = Image.FromFile("../../../icons/Check_32.png");
            
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
            forget forgetter = new forget();
            this.Hide();
            forgetter.ShowDialog();
            this.Show();
        }

        private void pictureBoxCheck_Click(object sender, EventArgs e) {
            if (!check) {//如果不可查看成立
                textBoxPassword.UseSystemPasswordChar = true;
                pictureBoxCheck.Image=Image.FromFile("../../../icons/Check_32.png");
                check = !check;
            }
            else {
                textBoxPassword.UseSystemPasswordChar = false;
                pictureBoxCheck.Image = Image.FromFile("../../../icons/Uncheck_32.png");
                check = !check;
            }
        }


    }
}






