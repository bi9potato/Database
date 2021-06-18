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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //登录事件
        private void button1_Click(object sender, EventArgs e)
        {
            if (login())
            {
                if (comboBox1.Text == "顾客")
                {
                    //读
                    string sql = "SELECT * FROM 买家 WHERE MID='" + textBox1.Text + "' AND MIMA='" + textBox2.Text + "'";
                    Dao dao = new Dao();//实例化Dao类
                    IDataReader dr = dao.read(sql);//执行sql语句并把返回值给dr
                    dr.Read();//读dr这个数据集
                    string mID = dr["MID"].ToString();//获取

                    Form3 form3 = new Form3(mID);
                    form3.Show();//显示窗体
                    this.Hide();//隐藏窗体
                    //this.Close();//关闭窗体,不能用这个，因为form1是主窗体，一旦主窗体关闭，全部关闭

                }
                else
                {
                    if (comboBox1.Text == "卖家")
                    {
                        //读
                        string sql2 = "SELECT * FROM 书店 WHERE BSID='" + textBox1.Text + "' AND MIMA='" + textBox2.Text + "'";
                        Dao dao = new Dao();//实例化Dao类
                        IDataReader dr = dao.read(sql2);//执行sql语句并把返回值给dr
                        dr.Read();//读dr这个数据集
                        string bsID = dr["BSID"].ToString();//获取

                        Form2 form2 = new Form2(bsID);
                        form2.Show();
                        this.Hide();
                    }
                    else
                    {
                        if (comboBox1.Text == "管理员")
                        {
                            Form5 form5 = new Form5();
                            form5.Show();
                            this.Hide();
                        }
                    }
                }
            }
        }
        private bool login()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("输入不完整，请重新输输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (comboBox1.Text == "顾客")
            {
                string sql = "SELECT * FROM 买家 WHERE MID='"+textBox1.Text+"' AND MIMA='"+textBox2.Text+"'";
                Dao dao = new Dao();
                IDataReader dr = dao.read(sql);
                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (comboBox1.Text == "卖家")
            {
                string sql = "select * from 书店 where BSID='" + textBox1.Text + "' AND MIMA='" + textBox2.Text + "'";
                Dao dao = new Dao();
                IDataReader dr = dao.read(sql);
                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            if (comboBox1.Text == "管理员")
            {
                string sql = "SELECT * FROM 管理员 WHERE GID='" + textBox1.Text + "' AND MIMA='" + textBox2.Text + "'";
                Dao dao = new Dao();
                IDataReader dr = dao.read(sql);
                if (dr.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            comboBox1.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {//顾客注册按钮
            
            
            Form11 f = new Form11();
            f.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
