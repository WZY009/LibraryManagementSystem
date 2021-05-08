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
    public partial class userBasic : Form
    {
        public userBasic()
        {
            InitializeComponent();
        }

        private void user1_Load(object sender, EventArgs e)
        {

        }

        private void 图书查看和借阅ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bookCheck user = new bookCheck();
            user.ShowDialog();
        }

        private void 当前结束图书和归还ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            borrow user = new borrow();
            user.ShowDialog();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void 帮助ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Help");
        }
    }
}
