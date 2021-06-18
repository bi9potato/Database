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
    //异常通知
    public partial class Form3 : Form
    {
        class MyException : Exception
        {
            public MyException(string message)
                : base(message)
            {
            }
        }

        string mID;
        public Form3(string a)
        {
            mID = a;//直接传过来的只是形参，离开了这个函数就无法使用！一定要赋值给一个变量！
                    //mID记录登录购买页面的买家的账号
            InitializeComponent();
            Table();
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//结束整个程序，不让他在后台跑
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        //让表显示数据
        private void Table()
        {
            
            dataGridView1.Rows.Clear(); //刷新后不重复显示数据
            string sql = "SELECT * FROM 图书";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d, e, g, h;
                a = dr["BID"].ToString();
                b = dr["NAME"].ToString();
                c = dr["WRITER"].ToString();
                d = dr["PUBLISHING"].ToString();
                e = dr["PRICE"].ToString();
                //f = dr["CLASSIFICTION"].ToString();
                g = dr["MARGIN"].ToString();
                h = dr["BSID"].ToString();
                string[] str = { a, b, c, d, e, g, h };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();//关闭连接
        }

        //按类别查询
        private void TableCLASSIFICATION()
        {
            dataGridView1.Rows.Clear(); //刷新后不重复显示数据
            string sql = "SELECT * FROM 图书,类别,分类 where 类别.CLASSIFICATION LIKE '%" + textBox5.Text + "%' AND 类别.CLASSIFICATION=分类.CLASSIFICATION and 分类.BID=图书.BID";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d, e, g, h;
                a = dr["BID"].ToString();
                b = dr["NAME"].ToString();
                c = dr["WRITER"].ToString();
                d = dr["PUBLISHING"].ToString();
                e = dr["PRICE"].ToString();
                //f = dr["CLASSIFICTION"].ToString();
                g = dr["MARGIN"].ToString();
                h = dr["BSID"].ToString();
                string[] str = { a, b, c, d, e, g, h };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();//关闭连接
        }

        //按书编号查询
        private void TableBID()
        {
            dataGridView1.Rows.Clear(); //刷新后不重复显示数据
            string sql = "SELECT * FROM 图书 where BID LIKE '%" + textBox2.Text + "%' ";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d, e, g, h;
                a = dr["BID"].ToString();
                b = dr["NAME"].ToString();
                c = dr["WRITER"].ToString();
                d = dr["PUBLISHING"].ToString();
                e = dr["PRICE"].ToString();
                //f = dr["CLASSIFICTION"].ToString();
                g = dr["MARGIN"].ToString();
                h = dr["BSID"].ToString();
                string[] str = { a, b, c, d, e, g, h };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();//关闭连接
        }

        //按书名查询
        private void TableNAME()
        {
            dataGridView1.Rows.Clear(); //刷新后不重复显示数据
            string sql = "SELECT * FROM 图书 where NAME LIKE '%" + textBox1.Text + "%' ";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d, e, g, h;
                a = dr["BID"].ToString();
                b = dr["NAME"].ToString();
                c = dr["WRITER"].ToString();
                d = dr["PUBLISHING"].ToString();
                e = dr["PRICE"].ToString();
                //f = dr["CLASSIFICTION"].ToString();
                g = dr["MARGIN"].ToString();
                h = dr["BSID"].ToString();
                string[] str = { a, b, c, d, e, g, h };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();//关闭连接
        }

        //按作者查询
        private void TableWRITER()
        {
            dataGridView1.Rows.Clear(); //刷新后不重复显示数据
            string sql = "SELECT * FROM 图书 where WRITER LIKE '%" + textBox3.Text + "%' ";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d, e, g, h;
                a = dr["BID"].ToString();
                b = dr["NAME"].ToString();
                c = dr["WRITER"].ToString();
                d = dr["PUBLISHING"].ToString();
                e = dr["PRICE"].ToString();
               // f = dr["CLASSIFICTION"].ToString();
                g = dr["MARGIN"].ToString();
                h = dr["BSID"].ToString();
                string[] str = { a, b, c, d, e, g, h };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();//关闭连接
        }

        //按出版社查询
        private void TablePUBLISHING()
        {
            dataGridView1.Rows.Clear(); //刷新后不重复显示数据
            string sql = "SELECT * FROM 图书 where PUBLISHING LIKE '%" + textBox4.Text + "%' ";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d, e, g, h;
                a = dr["BID"].ToString();
                b = dr["NAME"].ToString();
                c = dr["WRITER"].ToString();
                d = dr["PUBLISHING"].ToString();
                e = dr["PRICE"].ToString();
                //f = dr["CLASSIFICTION"].ToString();
                g = dr["MARGIN"].ToString();
                h = dr["BSID"].ToString();
                string[] str = { a, b, c, d, e, g, h };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();//关闭连接
        }

        private void 购买ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int mg=0;//一定要赋初值，不然系统会认为mg可能读不到值，所以mg>0会报错
            string sql3 = "SELECT * FROM 图书 where BID='" + dataGridView1.SelectedCells[0].Value.ToString() + "'";
            Dao dao3 = new Dao();
            IDataReader dr3 = dao3.read(sql3);
            while (dr3.Read())
            {
                string v;
                v = dr3["MARGIN"].ToString();

                mg = int.Parse(v);
                
            }
            //dr3.Close();//关闭连接
            
            string bID = dataGridView1.SelectedCells[0].Value.ToString();//获取选中的书籍编号
            //判断是否借过这本书，借过不给再借
            string sql1 = "select MID,BID from 订单明细 where  BID='" + bID + "'and MID='" + mID + "'";
            Dao dao = new Dao();
            IDataReader dc = dao.read(sql1);
            if (!dc.Read())//读不到东西的话返回true
            {
                //接收异常
                
                try
                    {
                        if (mg <= 0) throw new MyException("余量不足，禁止借阅");
                    }
                    catch (MyException myException)
                    {
                        MessageBox.Show(myException.Message);
                    }
                //
                

                if (mg > 0)
                {
                    //string sql = "insert into 订单明细(MID,BID) values('" + mID + "','" + bID + "') ";
                    string sql = "insert into 订单明细(MID,BID,DAT) values('" + mID + "','" + bID + "','" + DateTime.Now.ToLocalTime().ToString() + "') ";//DateTime.Now.ToLocalTime().ToString() 获取当前时间函数
                    //Dao dao = new Dao();
                    int i = dao.Excute(sql);
                    if (i > 0)
                    {
                        MessageBox.Show("借阅成功");
                    }
                }
                else
                {
                    //MessageBox.Show("余量不足，禁止借阅");
                }
            }
            else
            {
                MessageBox.Show("禁止重复借阅同一本书");
            }
            
        }

        private void 我的订单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form31 f = new Form31(mID);
            f.Show();

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMI f = new FormMI(mID);
            f.ShowDialog();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Table();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TableNAME();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TableBID();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TableWRITER();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TablePUBLISHING();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Table();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TableCLASSIFICATION();
        }

        
    }
}
