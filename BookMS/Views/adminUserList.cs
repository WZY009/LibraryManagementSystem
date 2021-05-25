using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BookMS.Views {
    public partial class adminUserList : Form {
        public adminUserList() {
            InitializeComponent();
        }

        private void buttonClose_Click(object sender, EventArgs e) {
            this.Close();
        }
    }
}
