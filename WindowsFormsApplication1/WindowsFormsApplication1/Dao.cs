using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
namespace WindowsFormsApplication1
{
    class Dao
    {
        //链接数据库方法
        public SqlConnection connection()
        {
            string str = "Data Source=DESKTOP-3D388D8;Initial Catalog=SHUDIAN;Persist Security Info=True;User ID=sa;pwd=1";
            SqlConnection sc = new SqlConnection(str);
            sc.Open();//打开数据库链接
            return sc;//返回受链接对象
        }

        public SqlCommand command(string sql)
        {
            SqlCommand sc = new SqlCommand(sql, connection());
            return sc;
        }

        //用于delete update insert,返回受影响行数
        public int Excute(string sql)
        {
            return command(sql).ExecuteNonQuery();
        }

        //用于select，返回SqlDataReader对象，包含select到的数据
        public SqlDataReader read(string sql)
        {
            return command(sql).ExecuteReader();
        }
    }
}
