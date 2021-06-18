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
    public partial class FormBSMI : Form
    {
        string bsID;
        public FormBSMI()
        {
            
            InitializeComponent();
        }

        public FormBSMI(string a)
        {
            bsID = a;
            InitializeComponent();
            string sql = "select * from 书店 where BSID='" + bsID + "'";
            Dao dao = new Dao();
            dao.read(sql);
            IDataReader dr = dao.read(sql);
            dr.Read();
            textBox1.Text = dr["MIMA"].ToString();
            dr.Close();
        }

        private void FormBSMI_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "update 书店 set MIMA='" + textBox2.Text + "' where BSID='" + bsID + "' ";
            Dao dao = new Dao();
            int i = dao.Excute(sql);
            if (i > 0)
            {
                MessageBox.Show("修改成功");
            }
        }
    }
}
