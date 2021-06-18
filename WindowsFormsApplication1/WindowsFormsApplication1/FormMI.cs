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
    public partial class FormMI : Form
    {
        string mID;
        public FormMI()
        {
            InitializeComponent();
        }

        public FormMI(string a)
        {
            mID = a;
            InitializeComponent();
            string sql = "select * from 买家 where MID='" + mID + "'";
            Dao dao = new Dao();
            dao.read(sql);
            IDataReader dr = dao.read(sql);
            dr.Read();
            textBox1.Text = dr["MIMA"].ToString();
            dr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "update 买家 set MIMA='" + textBox2.Text + "' where MID='" + mID + "' ";
            Dao dao = new Dao();
            int i=dao.Excute(sql);
            if (i > 0)
            {
                MessageBox.Show("修改成功");
            }
            else
            {
                MessageBox.Show("修改失败");
            }
        
        }

        private void FormMI_Load(object sender, EventArgs e)
        {

        }
    }
}
