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
    public partial class adminVerify : Form
    {
        string ID = "";
        public adminVerify()
        {
            InitializeComponent();
        }
        public adminVerify(string id, string name, string author, string press, string number)
        {
            InitializeComponent();
            ID = textBoxId.Text = id;
            textBoxName.Text = name;
            textBoxAuthor.Text = author;
            textBoxPress.Text = press;
            textBoxStore.Text = number;
        }

        private void buttonVerify_Click(object sender, EventArgs e)
        {
            string sql = $"update t_book set id='{textBoxId.Text}',[name]='{textBoxName.Text}',author='{textBoxAuthor.Text}',press='{textBoxPress.Text}',number='{textBoxStore.Text}' where id='{ID}'";
            Dao dao = new Dao();
            if(dao.Execute(sql)>0)
            {
                MessageBox.Show("修改成功");
                this.Close();
            }
        }

        private void buttonFlush_Click(object sender, EventArgs e)
        {
            textBoxId.Text = "";
            textBoxName.Text = "";
            textBoxAuthor.Text = "";
            textBoxPress.Text = "";
            textBoxStore.Text = "";
        }
    }
}
