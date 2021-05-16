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

namespace BookMS {
    public partial class adminNewVerify : Form {
        string ID = null;

        public adminNewVerify() {
            InitializeComponent();
        }
        public adminNewVerify(string id, string name, string author, string press, string number) {//重构构造函数
            InitializeComponent();
            textBoxISBN.Text = id;
            ID = id;
            textBoxName.Text = name;
            textBoxAuthor.Text = author;
            textBoxPublish.Text = press;
            textBoxStorage.Text = number;            
        }
        private void buttonClose_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void buttonConfirm_Click(object sender, EventArgs e) {
            if(textBoxName.Text != null) {
                Book book = new Book() {
                    Id = ID,
                    Name = textBoxName.Text,
                    Author = textBoxAuthor.Text,
                    Press = textBoxPublish.Text,
                    Number = Convert.ToInt32(textBoxStorage.Text),
                };
                using BookMapper bookMapper = new BookMapper();
                if (bookMapper.UpdateBook(book) != null) {
                    MessageBox.Show("Successful!");
                    this.Close();
                }
            }
            else
                MessageBox.Show("Sorry ，please input the ISBN!");
        }

        private void buttonFlush_Click(object sender, EventArgs e) {
            ID = textBoxISBN.Text = null;
            textBoxName.Text = null;
            textBoxAuthor.Text = null;
            textBoxPublish.Text = null;
            textBoxStorage.Text = null;
        }

        private void textBoxISBN_Click(object sender, EventArgs e) {
            changeColor(textBoxISBN, textBoxName, textBoxPublish, textBoxStorage, textBoxAuthor, 
                         panelISBN, panelName, panelPulish, panelAuthor, panelStorage);
        }

        private void textBoxName_Click(object sender, EventArgs e) {
            changeColor(textBoxName, textBoxISBN, textBoxPublish, textBoxStorage, textBoxAuthor,
                        panelName, panelISBN, panelPulish, panelAuthor, panelStorage);
        }

        private void textBoxAuthor_Click(object sender, EventArgs e) {
            changeColor(textBoxAuthor, textBoxISBN, textBoxPublish, textBoxStorage, textBoxName,
            panelAuthor, panelISBN, panelPulish, panelName, panelStorage);
        }

        private void textBoxPublish_Click(object sender, EventArgs e) {
            changeColor(textBoxPublish, textBoxISBN, textBoxAuthor, textBoxStorage, textBoxName,
                        panelPulish, panelISBN, panelAuthor, panelName, panelStorage);
        }

        private void textBoxStorage_Click(object sender, EventArgs e) {
            changeColor(textBoxStorage, textBoxISBN, textBoxAuthor, textBoxPublish, textBoxName,
            panelStorage, panelISBN, panelAuthor, panelName, panelPulish);
        }    
        
        //有没有一种更加艺术的方式实现这个功能啊啊啊啊啊！！！！！！！
        private void changeColor(TextBox changeBox, TextBox a0, TextBox a1, TextBox a2,
                         TextBox a3, Panel changePanel, Panel p0, Panel p1, Panel p2, Panel p3) {
            changeBox.BackColor = Color.White;
            changePanel.BackColor = Color.White;
            a0.BackColor = a1.BackColor = a2.BackColor = a3.BackColor = Color.FromArgb(235, 243, 255);

            p0.BackColor=p1.BackColor = p2.BackColor = p3.BackColor = Color.FromArgb(235, 243, 255);
        }

    }
}
