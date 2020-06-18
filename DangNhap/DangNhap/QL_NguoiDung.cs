using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace DangNhap
{
    class QL_NguoiDung
    {
        public int check_Config()
        {
            if (Properties.Settings.Default.ABC == string.Empty)
                return 1; 
            SqlConnection con = new SqlConnection(Properties.Settings.Default.ABC);
            try
            {
                if (con.State == System.Data.ConnectionState.Closed)
                    con.Open();
                return 0; 
            }
            catch
            {
                return 2; 
            }
        }
        public int check_user(string user, string password)
        {
            SqlDataAdapter da = new SqlDataAdapter("select * from NGUOIDUNG where TENDANGNHAP='" + user + "' and MATKHAU ='" + password + "'", Properties.Settings.Default.ABC);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                return -1;
            }
            if (dt.Rows[0][2] == null || dt.Rows[0][2].ToString() == "False")
            {
                return 0;
            }
            return 1;
        }
        public DataTable getServerName()
        {
            DataTable dt = new DataTable();
            dt = SqlDataSourceEnumerator.Instance.GetDataSources();
            return dt;
        }
        public DataTable getDataBaseName(string server, string user, string pass)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select name from sys.Databases", "Data Source=" + server + ";Initial Catalog=master;User ID=" + user + ";pwd=" + pass + "");
            da.Fill(dt);
            return dt;
        }
        public void luuCauHinh(string server, string user, string pass, string db)
        {
            DangNhap.Properties.Settings.Default.ABC = "Data Source" + server + ";Initial Catalog=" + db + ";User ID=" + user + ";pwd=" + pass + "";
            DangNhap.Properties.Settings.Default.Save();
        }
    }
}
