using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BookMS {
    public partial class register : Form {
        public register() {
            InitializeComponent();
        }

        private void textBoxISBN_TextChanged(object sender, EventArgs e) {

        }
        private void changeColor(TextBox changeBox, TextBox a0, TextBox a1, TextBox a2, Panel changePanel, Panel p0, Panel p1, Panel p2) {
            changeBox.BackColor = Color.White;
            changePanel.BackColor = Color.White;
            a0.BackColor = a1.BackColor = a2.BackColor =  Color.FromArgb(235, 243, 255);

            p0.BackColor = p1.BackColor = p2.BackColor =  Color.FromArgb(235, 243, 255);
        }

    }
}
