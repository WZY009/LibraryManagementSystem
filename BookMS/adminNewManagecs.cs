using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BookMS
{
    public partial class adminNewManagecs : Form
    {
        System.Drawing.Color azure = Color.FromArgb(40,140,195);
        System.Drawing.Color darkBlue = Color.FromArgb(40,90,170);
        public adminNewManagecs()
        {
            InitializeComponent();
        }
        

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonRefresh_MouseEnter(object sender, EventArgs e)
        {
            buttonRefresh.BackColor = darkBlue;//(40, 90, 170)
        }

        private void buttonRefresh_MouseLeave(object sender, EventArgs e)
        {
            buttonRefresh.BackColor = azure;//get back to the (40,140,195)
        }

        private void buttonAdd_MouseEnter(object sender, EventArgs e)
        {
            buttonAdd.BackColor = darkBlue;//(40, 90, 170)
        }

        private void buttonAdd_MouseLeave(object sender, EventArgs e)
        {
            buttonAdd.BackColor = Color.FromArgb(40, 128, 185);//get back to the (40,140,195)
        }

        private void buttonVerify_MouseEnter(object sender, EventArgs e)
        {
            buttonVerify.BackColor = darkBlue;
        }

        private void buttonVerify_MouseLeave(object sender, EventArgs e)
        {
            buttonVerify.BackColor = azure;
        }

        private void buttonDelete_MouseEnter(object sender, EventArgs e)
        {
            buttonDelete.BackColor = darkBlue;
        }

        private void buttonDelete_MouseLeave(object sender, EventArgs e)
        {
            buttonDelete.BackColor = Color.FromArgb(40, 128, 185);
        }

        private void buttonCheckName_MouseEnter(object sender, EventArgs e)
        {
            buttonCheckName.BackColor = darkBlue; 
        }

        private void buttonCheckName_MouseLeave(object sender, EventArgs e)
        {
            buttonCheckName.BackColor = azure;
        }

        private void buttonCheckID_MouseEnter(object sender, EventArgs e)
        {
            buttonCheckID.BackColor = darkBlue;
        }

        private void buttonCheckID_MouseLeave(object sender, EventArgs e)
        {
            buttonCheckID.BackColor = Color.Transparent;
        }
    }
}
