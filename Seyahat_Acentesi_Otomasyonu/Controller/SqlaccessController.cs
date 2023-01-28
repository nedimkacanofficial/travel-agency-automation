using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Controller
{
    public class SqlaccessController
    {
        public static SqlConnection connect()
        {
            SqlConnection conn = new SqlConnection("Server=localhost;Database=seyahat_acentesi_otomasyonu;UId=sql_kullanici_adiniz;Password=sql_sifreniz;");
            return conn;
        }
        public static int openClose(SqlCommand cmd)
        {
            cmd.Connection.Open();
            int sonuc = cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            return sonuc;
        }
    }
}
