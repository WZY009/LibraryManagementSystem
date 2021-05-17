using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BookMS {
    public partial class forget : Form {
        public forget() {
            InitializeComponent();
        }
        private bool isEqual(TextBox t1, TextBox t2) {
            if (t1.Text == t2.Text)
                return true;
            else
                return false;
        }

        private void buttonClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void buttonFlush_Click(object sender, EventArgs e) {
            textBoxID.Text=textBoxName.Text=null;
        }

        private void buttonConfirm_Click(object sender, EventArgs e) {

        }
        private void buttonVerify_Click(object sender, EventArgs e) {
            if (isValid(textBoxID, textBoxAnswer)) {
                if (isValid(textBoxID, textBoxAnswer)) {
                    textBoxPassword.Enabled = textBoxRepeat.Enabled = true;
                    buttonConfirm.Enabled = buttonFlush2.Enabled = true;
                }
            }
        }
        private bool isValid(TextBox id,TextBox anwser) {
            return true;
        }
    }

}
