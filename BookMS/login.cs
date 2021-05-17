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
                MessageBox.Show("输入有空项，请重新输入 ");
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
            panelPassword.BackColor = SystemColors.Control;
            textBoxPassword.BackColor = SystemColors.Control;

        }


        private void textBoxPassword_Click(object sender, EventArgs e)
        {
            textBoxPassword.BackColor = Color.White;
            panelPassword.BackColor = Color.White;
            panelUser.BackColor = SystemColors.Control;
            textBoxUserNum.BackColor = SystemColors.Control;
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
    }
}

    //1、如何实现点击一下就改变图片，然后再点击一下又变回原来那个？
    //2、如何自定义组件库？下面这个是我想使用的自定义组件库
    
    //public partial class JaRadioButton : RadioButton
    //{
    //    bool isMouseMove = false;
    //    public JaRadioButton()
    //    {
    //        InitializeComponent();
    //        this.MouseMove += JaRadioButton_MouseMove;
    //        this.MouseLeave += JaRadioButton_MouseLeave;
    //    }

    //    private void JaRadioButton_MouseLeave(object sender, EventArgs e)
    //    {
    //        isMouseMove = false;
    //        this.Invalidate();
    //    }

    //    private void JaRadioButton_MouseMove(object sender, MouseEventArgs e)
    //    {
    //        isMouseMove = true;
    //        this.Invalidate();
    //    }

    //    private Color selectRadioForeColor = Color.FromArgb(0X33, 0X70, 0XCC);
    //    [Description("选中后选择框颜色"), Category("自定义")]
    //    public Color SelectRadioForeColor
    //    {
    //        get { return selectRadioForeColor; }
    //        set
    //        {
    //            selectRadioForeColor = value;
    //            this.Invalidate();
    //        }
    //    }

    //    private Color selectTextForeColor = Color.FromArgb(0X33, 0X70, 0XCC);
    //    [Description("选中后文本颜色,可根据ChangeTextForeColor属性来决定是否改变"), Category("自定义")]
    //    public Color SelectTextForeColor
    //    {
    //        get { return selectTextForeColor; }
    //        set
    //        {
    //            selectTextForeColor = value;
    //            this.Invalidate();
    //        }
    //    }
    //    private bool changeTextForeColor = false;
    //    [Description("是否改变选中后文本颜色,默认为false"), Category("自定义")]
    //    public bool ChangeTextForeColor
    //    {
    //        get { return changeTextForeColor; }
    //        set
    //        {
    //            changeTextForeColor = value;
    //            this.Invalidate();
    //        }
    //    }

    //    private void JaRadioButton_Paint(object sender, PaintEventArgs e)
    //    {
    //        RadioButton rButton = (RadioButton)sender;
    //        Graphics g = e.Graphics;
    //        g.Clear(this.BackColor);
    //        //double px = ((this.Font.Size * 3) / 4) + 0.4f;//字体pt换成像素px
    //        int px = this.Height;//字体pt换成像素px
    //        Rectangle radioButtonrect = new Rectangle(1, 1, 12, 12);

    //        if (px > 14)
    //        {
    //            radioButtonrect = new Rectangle(1, (px - 12) / 2, 12, 12);
    //        }
    //        g.SmoothingMode = SmoothingMode.AntiAlias;
    //        if (rButton.Checked)
    //        {
    //            radioButtonrect.Inflate(1, 1);
    //            g.FillEllipse(new SolidBrush(selectRadioForeColor), radioButtonrect);
    //            radioButtonrect.Inflate(-4, -4);
    //            g.FillEllipse(new SolidBrush(this.BackColor), radioButtonrect);
    //            StringFormat sf = new StringFormat();
    //            sf.Alignment = StringAlignment.Center;
    //            sf.LineAlignment = StringAlignment.Center;
    //            Rectangle rectangleText = new Rectangle(8, 0, this.Width, this.Height);

    //            if (changeTextForeColor)//改变文字颜色
    //            {
    //                g.DrawString(Text, this.Font, new SolidBrush(selectTextForeColor), rectangleText, sf);
    //            }
    //            else
    //            {
    //                g.DrawString(Text, this.Font, new SolidBrush(ForeColor), rectangleText, sf);
    //            }
    //        }
    //        else
    //        {
    //            if (isMouseMove)//鼠标移入
    //            {
    //                using (Pen pen = new Pen(Color.FromArgb(0X33, 0X70, 0XCC)))
    //                {
    //                    g.DrawEllipse(pen, radioButtonrect);
    //                }
    //            }
    //            else
    //            {
    //                using (Pen pen = new Pen(Color.FromArgb(0X96, 0X97, 0X99)))
    //                {
    //                    g.DrawEllipse(pen, radioButtonrect);
    //                }
    //            }
    //            StringFormat sf = new StringFormat();
    //            sf.Alignment = StringAlignment.Center;
    //            sf.LineAlignment = StringAlignment.Center;
    //            Rectangle rectangleText = new Rectangle(8, 0, this.Width, this.Height);
    //            g.DrawString(Text, this.Font, new SolidBrush(ForeColor), rectangleText, sf);//字体
    //        }
    //        //g.Dispose();
    //    }
    //}




