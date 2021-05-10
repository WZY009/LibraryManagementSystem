using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace datagrid
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(
                new object[]
                {
                    "201938252",
                    "数据库系统",
                    "高纬",
                    "成都电子科技大学",
                    5
                }
                );
            dataGridView1.Rows.Add(
                new object[]
                {
                    "201938252",
                    "数据库系统",
                    "高纬",
                    "成都电子科技大学",
                    5
                }
                );
            dataGridView1.Rows.Add(
                new object[]
                {
                    "201938252",
                    "数据库系统",
                    "高纬",
                    "成都电子科技大学",
                    5
                }
                );
            dataGridView1.Rows.Add(
                new object[]
                {
                    "201938252",
                    "数据库系统",
                    "高纬",
                    "成都电子科技大学",
                    5
                }
                );
        }

        
        private void button3_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            buttonBorrow.BackColor = Color.FromArgb(255, 40, 90, 170);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            buttonBorrow.BackColor = Color.FromArgb(255, 41, 128, 185);
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            buttonBack.BackColor = Color.FromArgb(255, 40, 90, 170);
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            buttonBack.BackColor = Color.FromArgb(255, 40, 140, 195);
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            buttonClose.BackColor = Color.FromArgb(255, 40, 90, 170);
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            buttonClose.BackColor = Color.FromArgb(255, 41, 128, 185);
        }
    }
}
