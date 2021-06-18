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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            Table();
        }

        private void 系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void Form5_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//结束整个程序，不让他在后台跑
        }

        //让表显示数据
        private void Table()
        {
            dataGridView1.Rows.Clear();//刷新后不重复显示数据
            string sql = "SELECT * FROM 书店";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string a, b, c, d;
                a = dr["BSID"].ToString();
                b = dr["NAME"].ToString();
                c = dr["TEL"].ToString();
                d = dr["MIMA"].ToString();
                string[] str = { a, b, c, d };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();//关闭连接
        }

        private void 添加书店ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form51 f = new Form51();
            f.ShowDialog();
        }

        private void 修改书店ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] str = { dataGridView1.SelectedCells[0].Value.ToString(), dataGridView1.SelectedCells[1].Value.ToString(), dataGridView1.SelectedCells[2].Value.ToString(), dataGridView1.SelectedCells[3].Value.ToString() };
            //获取选中的那一行第[]号单元格数据
            //MessageBox.Show(str[0]+str[1]+str[2]);
            Form51 f = new Form51(str);
            f.ShowDialog();
        }

        private void 删除书店ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel);
            //返回值为DialogResult.OK或DialogResult.Cancel
            if (r == DialogResult.OK)
            {
                string id, name;
                id = dataGridView1.SelectedCells[0].Value.ToString();//获取选中的那一行第0号单元格
                name = dataGridView1.SelectedCells[1].Value.ToString();
                string sql = "delete from 书店 where BSID='" + id + "'";
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

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Table();//重新显示数据，即刷新数据库
        }
    }
}
