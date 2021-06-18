using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BookMS.Views {
    public partial class sudoku : Form {
        int[,] map1 = new int[9, 9]  {  { 0,6,1,0,3,0,0,2,0 },
                                             { 0,5,0,0,0,8,1,0,7 },
                                             { 0,0,0,0,0,7,0,3,4 },
                                             { 0,0,9,0,0,6,3,7,8 },
                                             { 0,0,3,2,7,9,5,0,0 },
                                             { 5,7,0,3,0,0,9,0,2 },
                                             { 1,9,0,7,6,0,0,0,0 },
                                             { 8,0,2,4,0,0,7,6,0 },
                                             { 6,4,0,0,1,0,2,5,0 }
        };
        int[,] map2 = new int[9, 9] {   {7,5,0,0,9,0,0,4,6 },
                                        {9,0,1,0,0,0,3,0,2 },
                                        {0,0,0,0,0,0,0,0,0 },
                                        {2,0,0,6,0,1,0,0,7 },
                                        {0,8,0,0,0,0,0,2,0 },
                                        {1,0,0,3,0,8,0,0,5 },
                                        {0,0,0,0,0,0,0,0,0 },
                                        {3,0,9,0,0,0,2,0,4 },
                                        {8,4,0,0,3,0,0,7,9 }

        };
        int[,] map3 = new int[9, 9] {   {0,0,5,3,0,0,0,0,0 },
                                        {8,0,0,0,0,0,0,2,0 },
                                        {0,7,0,0,1,0,5,0,0 },
                                        {4,0,0,0,0,5,3,0,0 },
                                        {0,1,0,0,7,0,0,0,6 },
                                        {0,0,3,2,0,0,0,8,0 },
                                        {0,6,0,5,0,0,0,0,9 },
                                        {0,0,4,0,0,0,0,3,0 },
                                        {0,0,0,0,0,9,7,0,0 }

        };

        //int size = 50;
        int num = 0;                                    //用来标识选中的数字
        bool isEraser = false;                          //标识是否为橡皮擦
        private Button[] btns = new Button[10];              //存放1到9的按钮
        private Button[,] buttons = new Button[9, 9];       //存放地图
        private Button[] gradebtns = new Button[3];

        public sudoku() {
            InitializeComponent();
            createNum();
            //buttonPen.PerformClick();
        }

        public void createNum() {
            btns[0] = this.button1;
            btns[1] = this.button2;
            btns[2] = this.button3;
            btns[3] = this.button4;
            btns[4] = this.button5;
            btns[5] = this.button6;
            btns[6] = this.button7;
            btns[7] = this.button8;
            btns[8] = this.button9;
            btns[9] = this.buttonIcon;

            gradebtns[0] = this.buttonSimple;
            gradebtns[1] = this.buttonNormal;
            gradebtns[2] = this.buttonHard;
        }
        public void createMap(int[,] map) {

            for (int i = 0; i < 9; i++) {
                for (int j = 0; j < 9; j++) {
                    Button btn = new Button();
                    if (map[i, j] == 0) {
                        btn.Text = "";
                        btn.ForeColor = Color.FromArgb(255, 41, 128, 185);
                    }
                    else {
                        btn.Text = map[i, j].ToString();
                    }
                    btn.Size = new Size(50, 50);
                    btn.Location = new Point(80 + j * 50, i * 50);
                    btn.Font = new Font("宋体", 13, FontStyle.Bold);
                    btn.ForeColor = Color.Black;
                    if ((i < 3 && j < 3) || (i < 3 && j > 5) || (i >= 3 && j >= 3 && i <= 5 && j <= 5) || (i > 5 && j < 3) || (i > 5 && j > 5)) {
                        btn.BackColor = Color.FromArgb(255, 230, 230, 230);
                    }
                    btn.Click += new EventHandler(btn_Click);
                    //btn.FlatStyle = FlatStyle.Flat;
                    buttons[i, j] = btn;
                    this.panel3.Controls.Add(btn);
                }
            }
            //Button btn = new Button();
            //this.Controls.Add(btn);
        }

        public void btn_Click(object sender, System.EventArgs e) {
            Button btn = sender as Button;
            //MessageBox.Show(num.ToString());
            //MessageBox.Show(btn.Text);
            if (btn.Text == "" || btn.ForeColor == Color.FromArgb(255, 41, 128, 185)) {
                if (num != 0 && !isEraser) {
                    btn.Text = num.ToString();
                    btn.ForeColor = Color.FromArgb(255, 41, 128, 185);
                }
                else if (isEraser) {
                    btn.Text = "";
                }
            }
            //else {
            //    MessageBox.Show("btn不为空");
            //}
        }
        private void button1_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void gradeButton_Click(object sender, EventArgs e) {
            //createMap(map1);
            //默认选中画笔
            buttonPen.PerformClick();

            Button btn = sender as Button;
            int index = btn.TabIndex;
            switch (index) {
                case 1:
                    this.panel3.Controls.Clear();
                    createMap(map1);
                    break;
                case 2:
                    this.panel3.Controls.Clear();
                    createMap(map2);
                    break;
                case 3:
                    this.panel3.Controls.Clear();
                    createMap(map3);
                    break;
                default: break;
            }

        }


        private void button1_MouseClick(object sender, MouseEventArgs e) {
            Button btn = sender as Button;
            if (btn.Text != "") {
                int index = Int32.Parse(btn.Text) - 1;
                //if (num == 1) {
                //    num = 0;
                //    button1.BackColor = Color.White;
                //}
                if (num != 0) {
                    btns[num - 1].BackColor = Color.White;
                    num = index + 1;
                    btns[index].BackColor = Color.FromArgb(255, 40, 90, 170);

                }
                else {
                    num = index + 1;
                    btns[index].BackColor = Color.FromArgb(255, 40, 90, 170);
                }
            }
            else {
                if (num != 0) {
                    btns[num - 1].BackColor = Color.White;
                    num = 0;
                }

            }

            for (int i = 0; i < 9; i++) {
                for (int j = 0; j < 9; j++) {
                    if (buttons[i, j].Text != "") {
                        int number = Int32.Parse(buttons[i, j].Text);
                        if (number == num) {
                            buttons[i, j].BackColor = Color.Yellow;
                        }
                        else if (number != num && (i < 3 && j < 3) || (i < 3 && j > 5) || (i >= 3 && j >= 3 && i <= 5 && j <= 5) || (i > 5 && j < 3) || (i > 5 && j > 5)) {
                            buttons[i, j].BackColor = Color.FromArgb(255, 230, 230, 230);
                        }
                        else {
                            buttons[i, j].BackColor = Color.White;
                        }
                    }
                }
            }
        }

        private void buttonSubmit_MouseClick(object sender, MouseEventArgs e) {
            //bool flag = true ;                                                          //判断答案是否正确
            //判断每行是否有重复
            int[,] rows = new int[9, 9];                                 //记录每行是否有重复
            int[,] columns = new int[9, 9];                             //记录每列是否有重复
            int[,] blocks = new int[9, 9];                              //记录每个九宫格是否有重复

            for (int i = 0; i < 9; i++) {
                for (int j = 0; j < 9; j++) {
                    rows[i, j] = 0;
                    columns[i, j] = 0;
                    blocks[i, j] = 0;
                }
            }

            for (int row = 0; row < 9; row++) {
                for (int col = 0; col < 9; col++) {
                    if (buttons[row, col].Text == "") {
                        MessageBox.Show("请先填完所有空格！");
                        return;
                    }
                    int number = Int32.Parse(buttons[row, col].Text) - 1;
                    int blocknum = row - row % 3 + col / 3;                 //记录每个数字属于第几个九宫格
                    rows[row, number] = 1;
                    columns[number, col] = 1;
                    blocks[blocknum, number] = 1;
                }
            }

            for (int i = 0; i < 9; i++) {
                for (int j = 0; j < 9; j++) {
                    if (rows[i, j] == 0) {
                        MessageBox.Show("回答错误！");
                        return;
                    }
                    else if (columns[i, j] == 0) {
                        MessageBox.Show("回答错误！");
                        return;
                    }
                    else if (blocks[i, j] == 0) {
                        MessageBox.Show("回答错误！");
                        return;
                    }
                    else {
                        MessageBox.Show("回答正确！ 继续挑战下一关吧！");
                        return;
                    }
                }
            }
        }

        private void buttonEraser_Click(object sender, EventArgs e) {
            isEraser = true;
            buttonPen.BackColor = Color.White;
            buttonEraser.BackColor = Color.Pink;
        }

        private void buttonPen_Click(object sender, EventArgs e) {
            isEraser = false;
            buttonPen.BackColor = Color.Pink;
            buttonEraser.BackColor = Color.White;
        }


    }
}
