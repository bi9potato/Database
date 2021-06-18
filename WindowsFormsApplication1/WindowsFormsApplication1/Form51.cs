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
    public partial class Form51 : Form
    {
        string[] str = new string[4];//用于记录原值，与输入值比较是否相同，不同则修改
        public Form51()
        {
            InitializeComponent();
            button3.Visible = false;//保存时隐藏修改按钮
        }

         public Form51(string[] a)
        {//重载构造函数，用于修改，参数为一个string数组           
            InitializeComponent();
            for (int i = 0; i < 4; i++)
            {
                str[i] = a[i];
            }
            //将原值传入文本框
            textBox1.Text = str[0];
            textBox2.Text = str[1];
            textBox3.Text = str[2];
            textBox4.Text = str[3];
            //
            button1.Visible = false;//修改时隐藏（插入）保存按钮
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {//此处小心不可写成null，null可以，不可以空
                MessageBox.Show("输入不完整，请重新输输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
               
                string sql = "INSERT INTO 书店(BSID,NAME,TEL,MIMA) VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                //MessageBox.Show(sql);
                Dao dao = new Dao();
                int i = dao.Excute(sql);
                if (i > 0)
                {
                    MessageBox.Show("插入成功");
                }
            }
            //插入成功后清除所有空，方便下次输入
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {//取消按钮
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //修改按钮
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {//此处""小心不可写成null，null可以，不可以空
                MessageBox.Show("修改内容有空项，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (textBox1.Text != str[0])//将框内值与原值比较，若不等则为修改过
                {
                    string sql = "update 书店 set BSID='" + textBox1.Text + "' WHERE BSID='" + str[0] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[0] = textBox1.Text;//更新str[0]，再修改时能看到新数据
                }
                if (textBox2.Text != str[1])//将框内值与原值比较，若不等则为修改过
                {
                    string sql = "update 书店 set NAME='" + textBox2.Text + "' WHERE BSID='" + str[0] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[1] = textBox2.Text;
                }
                if (textBox3.Text != str[2])
                {
                    string sql = "update 书店 set TEL='" + textBox3.Text + "' WHERE BSID='" + str[0] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[2] = textBox3.Text;
                }
                if (textBox4.Text != str[3])
                {
                    string sql = "update 书店 set MIMA='" + textBox4.Text + "' WHERE BSID='" + str[0] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[3] = textBox4.Text;
                }
                MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
        }

        private void Form51_Load(object sender, EventArgs e)
        {

        }
    }
}
