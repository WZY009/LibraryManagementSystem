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
    public partial class adminBasic : Form
    {
        public adminBasic()
        {
            InitializeComponent();
        }

        private void 图书管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            adminManage admin = new adminManage();
            admin.ShowDialog();
        }
    }
}
