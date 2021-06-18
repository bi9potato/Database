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
    

    public partial class Form21 : Form
    {
        string[] str = new string[8];//用于记录原值，与输入值比较是否相同，不同则修改
        string bsID;

        public Form21(string a)
        {//用于保存，无参数
            bsID = a;
            InitializeComponent();
            button3.Visible = false;//保存时隐藏修改按钮
        }

        public Form21(string[] a)
        {//重载构造函数，用于修改，参数为一个string数组           
            InitializeComponent();
            for (int i = 0; i < 7; i++)
            {
                str[i] = a[i];
            }
            //将原值传入文本框
            textBox1.Text = str[0];
            textBox2.Text = str[1];
            textBox3.Text = str[2];
            textBox4.Text = str[3];
            textBox5.Text = str[4];
            //textBox6.Text = str[5];
            textBox7.Text = str[5];
            //
            button1.Visible = false;//修改时隐藏（插入）保存按钮
        }

        private void Form21_Load(object sender, EventArgs e)
        {

        }

        //添加一条图书记录
        private void button1_Click(object sender, EventArgs e)
        {//保存按钮
            int flag = 0;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == ""  || textBox7.Text == "" )
            {//此处小心不可写成null，null可以，不可以空
                MessageBox.Show("输入不完整，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Dao dao1 = new Dao();

                string v;
                string sql2 = "select BID from 图书 ";
                IDataReader dr3 = dao1.read(sql2);
                while (dr3.Read())
                {

                    v = dr3["BID"].ToString();
                    if (textBox1.Text == v) flag = 1;

                }

                if (flag == 0)
                {
                    string sql = "INSERT INTO 图书 VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox7.Text + "','" + bsID + "' ) ";
                    //MessageBox.Show(sql);
                    Dao dao = new Dao();
                    int i = dao.Excute(sql);
                    if (i > 0)
                    {
                        MessageBox.Show("插入成功");
                    }
                    else
                    {
                        MessageBox.Show("插入失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }
                else
                {
                    MessageBox.Show("该书籍编号已存在，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                }

            }
            //插入成功后清除所有空，方便下次输入
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            //textBox6.Text = null;
            textBox7.Text = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {//取消按钮
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            //textBox6.Text = null;
            textBox7.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {//修改按钮
            int flag = 0;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox7.Text == "" )
            {//此处""小心不可写成null，null可以，不可以空
                MessageBox.Show("修改内容有空项，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (textBox1.Text != str[0])//将框内值与原值比较，若不等则为修改过
                {
                    Dao dao1 = new Dao();

                    string v;
                    string sql2 = "select BID from 图书 ";
                    IDataReader dr3 = dao1.read(sql2);
                    while (dr3.Read())
                    {
                        
                        v = dr3["BID"].ToString();
                        if (textBox1.Text == v) flag = 1;

                    }

                    if (flag == 0)
                    {
                        string sql = "update 图书 set BID='" + textBox1.Text + "' WHERE BID='" + str[0] + "'";
                        Dao dao = new Dao();
                        dao.Excute(sql);
                        str[0] = textBox1.Text;//更新str[0]，再修改时能看到新数据
                        MessageBox.Show("书籍编号修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    else
                    {
                        MessageBox.Show("该书籍编号已存在，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    
                }
                if (textBox2.Text != str[1])//将框内值与原值比较，若不等则为修改过
                {
                    string sql = "update 图书 set NAME='" + textBox2.Text + "' WHERE BID='" + str[0] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[1] = textBox2.Text;
                    MessageBox.Show("书名修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                if (textBox3.Text != str[2])
                {
                    string sql = "update 图书 set WRITER='" + textBox3.Text + "' WHERE BID='" + str[0] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[2] = textBox3.Text;
                    MessageBox.Show("作者修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                if (textBox4.Text != str[3])
                {
                    string sql = "update 图书 set PUBLISHING='" + textBox4.Text + "' WHERE BID='" + str[0] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[3] = textBox4.Text;
                    MessageBox.Show("出版社修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                if (textBox5.Text != str[4])
                {
                    string sql = "update 图书 set PRICE='" + textBox5.Text + "' WHERE BID='" + str[0] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[4] = textBox5.Text;
                    MessageBox.Show("价格修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                /*if (textBox6.Text != str[5])
                {
                    string sql = "update 图书 set CLASSIFICTION='" + textBox6.Text + "' WHERE BID='" + str[0] + "'";
                    Dao dao = new Dao();
                    dao.Excute(sql);
                    str[5] = textBox6.Text;
                    MessageBox.Show("类别修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                }*/
                if (textBox7.Text != str[5])
                {
                    if (int.Parse(textBox7.Text) < 0)
                    {
                        MessageBox.Show("余量不可小于0，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string sql = "update 图书 set MARGIN='" + textBox7.Text + "' WHERE BID='" + str[0] + "'";
                        Dao dao = new Dao();
                        dao.Excute(sql);
                        str[6] = textBox7.Text;
                        MessageBox.Show("余量修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }
                /*if (textBox8.Text != str[7])
                {
                    
                    Dao dao = new Dao();


                    string sql2 = "select BSID from 书店 ";
                    IDataReader dr3 = dao.read(sql2);
                    while (dr3.Read())
                    {
                        string v;
                        v = dr3["BSID"].ToString();
                        if (textBox8.Text == v) flag = 1;

                    }

                    if (flag == 1)
                    {
                        string sql = "update 图书 set BSID='" + textBox8.Text + "' WHERE BID='" + str[0] + "'";
                        dao.Excute(sql);
                        str[7] = textBox8.Text;
                        MessageBox.Show("所属书店号修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                    else
                    {
                        MessageBox.Show("无此书店，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                    }
                }*/
                /*
                if (int.Parse(textBox7.Text) >= 0 || flag == 1)
                {

                    MessageBox.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None);
                }
                else
                {
                    MessageBox.Show("修改失败！", "警告", MessageBoxButtons.OK, MessageBoxIcon.None);
                }*/
            }

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
            
        
    }
}
