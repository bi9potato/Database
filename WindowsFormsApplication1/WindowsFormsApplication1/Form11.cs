using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form11_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {//添加用户信息至买家表
            int flag = 0;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {//此处小心不可写成null，null可以，不可以空
                MessageBox.Show("输入不完整，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                
                    Dao dao1 = new Dao();

                    string v;
                    string sql2 = "select MID from 买家 ";
                    IDataReader dr3 = dao1.read(sql2);
                    while (dr3.Read())
                    {

                        v = dr3["MID"].ToString();
                        if (textBox1.Text == v) flag = 1;

                    }

                    if (flag == 0)
                    {
                        string sql = "insert into 买家 values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "')";
                        Dao dao = new Dao();
                        int i = dao.Excute(sql);
                        if (i > 0)
                        {
                            MessageBox.Show("注册成功！");
                        }
                        else
                        {
                            MessageBox.Show("注册失败", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("该买家账号已存在，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }

                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;

        }
    }
}
