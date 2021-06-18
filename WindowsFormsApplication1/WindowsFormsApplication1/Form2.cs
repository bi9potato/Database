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
    public partial class Form2 : Form
    {
        string bsID;
        public Form2(string a)
        {
            bsID = a;

            InitializeComponent();
            Table();
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//结束整个程序，不让他在后台跑
        }

        //让表显示数据
        private void Table()
        {
            dataGridView1.Rows.Clear(); //刷新后不重复显示数据
            string sql = "SELECT * FROM 图书 WHERE BSID='"+bsID+"'";
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

        /*//按类别查询
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
        }*/

        //按书编号查询
        private void TableBID()
        {
            dataGridView1.Rows.Clear(); //刷新后不重复显示数据
            string sql = "SELECT * FROM 图书 where BID='" + textBox2.Text + "' ";
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
            //MessageBox.Show(sql);
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
                //f = dr["CLASSIFICTION"].ToString();
                g = dr["MARGIN"].ToString();
                h = dr["BSID"].ToString();
                string[] str = { a, b, c, d, e, g, h };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();//关闭连接
        }

        //按作者查询
        private void TablePUBLISHING()
        {
            dataGridView1.Rows.Clear(); //刷新后不重复显示数据
            string sql = "SELECT * FROM 图书 where PUBLISHING LIKE '%" + textBox4.Text + "%' ";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d, e, g,h;
                a = dr["BID"].ToString();
                b = dr["NAME"].ToString();
                c = dr["WRITER"].ToString();
                d = dr["PUBLISHING"].ToString();
                e = dr["PRICE"].ToString();
                //f = dr["CLASSIFICTION"].ToString();
                g = dr["MARGIN"].ToString();
                h = dr["BSID"].ToString();
                string[] str = { a, b, c, d, e, g ,h};
                dataGridView1.Rows.Add(str);
            }
            dr.Close();//关闭连接
        }

        private void 添加ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form21 f = new Form21(bsID);
            f.ShowDialog();
        }

        private void 修改书籍信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] str = { dataGridView1.SelectedCells[0].Value.ToString(), dataGridView1.SelectedCells[1].Value.ToString(), dataGridView1.SelectedCells[2].Value.ToString(), dataGridView1.SelectedCells[3].Value.ToString(), dataGridView1.SelectedCells[4].Value.ToString(), dataGridView1.SelectedCells[5].Value.ToString(), dataGridView1.SelectedCells[6].Value.ToString() };
            //获取选中的那一行第[]号单元格数据
            //MessageBox.Show(str[0]+str[1]+str[2]+str[3]+str[4]+str[5]+str[6]+str[7]);
            Form21 f = new Form21(str);
            f.ShowDialog();
        }

        private void 删除书籍信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel);
            //返回值为DialogResult.OK或DialogResult.Cancel
            if (r == DialogResult.OK)
            {
                string id, name;
                id = dataGridView1.SelectedCells[0].Value.ToString();//获取选中的那一行第0号单元格
                name = dataGridView1.SelectedCells[1].Value.ToString();
                string sql = "delete from 图书 where BID='" + id + "'";
                //MessageBox.Show(sql);
                Dao dao = new Dao();
                dao.Excute(sql);
                Table();//重新显示数据，即刷新数据库
            }
            else
            {
                //空操作
            }

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {//刷新按钮，即用Table()重新显示
            Table();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TableBID();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            TableNAME();
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

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBSMI f = new FormBSMI(bsID);
            f.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }
    }
}
