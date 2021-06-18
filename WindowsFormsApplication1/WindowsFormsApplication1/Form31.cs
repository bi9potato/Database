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
    public partial class Form31 : Form
    {
        string mID;
        public Form31(string a)
        {
            mID = a;
            InitializeComponent();
            Table();
            
        }

        private void Form31_Load(object sender, EventArgs e)
        {

        }

        //让表显示数据
        private void Table()
        {

            dataGridView1.Rows.Clear(); //刷新后不重复显示数据
            string sql = "SELECT MID,BID,DAT FROM 订单明细 where MID='" + mID + "'";
            Dao dao = new Dao();
            IDataReader dr = dao.read(sql);
            while (dr.Read())
            {
                string bID = dr["BID"].ToString();
                string sql2 = "select * from 图书 where BID='" + bID + "'";
                IDataReader dr2 = dao.read(sql2);
                dr2.Read();//不要忘记读！上一句知识将数据读到dr2集中，这句才是将内容读出来！！
                string a, b, c, d, e,f;
                a = dr2["BID"].ToString();
                b = dr2["NAME"].ToString();
                c = dr2["WRITER"].ToString();
                d = dr2["PUBLISHING"].ToString();
                e = dr2["PRICE"].ToString();
                f = dr["DAT"].ToString();
                string[] str = { a, b, c, d, e ,f};
                dataGridView1.Rows.Add(str);
                dr2.Close();
            }
            dr.Close();//关闭连接
        }

        

        private void 取消购买ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string bID = dataGridView1.SelectedCells[0].Value.ToString();//从选中的那行获取BID
            string sql = "delete from 订单明细 where BID='" + bID + "' AND MID='" + mID + "'";
            Dao dao = new Dao();
            dao.Excute(sql);
            Table();
        }

        
    }
}
