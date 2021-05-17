using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace newUser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            dataGridView2.Rows.Add(
                new object[]
                {
                    "3896432895727",
                    "Database System",
                    "Li hua",
                    "Wuhan University",
                    "2019-5-12"
                }
                );
        }

        private void buttonClose_MouseEnter(object sender, EventArgs e)
        {
            buttonClose.BackColor = Color.FromArgb(255, 220, 220, 220);
        }

        private void buttonClose_MouseLeave(object sender, EventArgs e)
        {
            buttonClose.BackColor = Color.FromArgb(255, 235, 243, 255);
        }

        private void buttonClose_MouseClick(object sender, MouseEventArgs e)
        {
            Application.Exit();
        }

        private void buttonInformation_MouseEnter(object sender, EventArgs e)
        {
            buttonInformation.BackColor = Color.FromArgb(255, 40, 90, 170);
        }

        private void buttonInformation_MouseLeave(object sender, EventArgs e)
        {
            buttonInformation.BackColor = Color.FromArgb(255, 40, 140, 195);
        }

        private void buttonBorrow_MouseEnter(object sender, EventArgs e)
        {
            buttonBorrow.BackColor = Color.FromArgb(255, 40, 90, 170);
        }

        private void buttonBorrow_MouseLeave(object sender, EventArgs e)
        {
            buttonBorrow.BackColor = Color.FromArgb(255, 41, 128, 185);
        }

        private void buttonHelp_MouseEnter(object sender, EventArgs e)
        {
            buttonHelp.BackColor = Color.FromArgb(255, 40, 90, 170);
        }

        private void buttonHelp_MouseLeave(object sender, EventArgs e)
        {
            buttonHelp.BackColor = Color.FromArgb(255, 40, 140, 195);
        }

        private void buttonCommunication_MouseEnter(object sender, EventArgs e)
        {
            buttonCommunication.BackColor = Color.FromArgb(255, 40, 90, 170);
        }

        private void buttonCommunication_MouseLeave(object sender, EventArgs e)
        {
            buttonCommunication.BackColor = Color.FromArgb(255, 41, 128, 185);
        }

        private void buttonLogOut_MouseEnter(object sender, EventArgs e)
        {
            buttonLogOut.BackColor = Color.FromArgb(255, 40, 90, 170);
        }

        private void buttonLogOut_MouseLeave(object sender, EventArgs e)
        {
            buttonLogOut.BackColor = Color.FromArgb(255, 40, 140, 195);
        }

        private void buttonFind_MouseEnter(object sender, EventArgs e)
        {
            buttonFind.BackColor = Color.FromArgb(255, 40, 90, 170);
        }

        private void buttonFind_MouseLeave(object sender, EventArgs e)
        {
            buttonFind.BackColor = Color.FromArgb(255, 41, 128, 185);
        }

        private void buttonExport_MouseEnter(object sender, EventArgs e)
        {
            buttonExport.BackColor = Color.FromArgb(255, 235, 243, 255);
        }

        private void buttonReturn_MouseEnter(object sender, EventArgs e)
        {
            buttonReturn.BackColor = Color.FromArgb(255, 235, 243, 255);
        }

        private void buttonRefresh_MouseEnter(object sender, EventArgs e)
        {
            buttonRefresh.BackColor = Color.FromArgb(255, 235, 243, 255);
        }
    }
}
