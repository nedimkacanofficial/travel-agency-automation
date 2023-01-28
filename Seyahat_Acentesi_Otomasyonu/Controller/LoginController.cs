using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class LoginController
    {
        public DataTable loginControl(LoginModel loginmod)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn=SqlaccessController.connect())
            {
                using (SqlCommand cmd=conn.CreateCommand())
                {
                    cmd.CommandText = "LoginControl";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@kullanici_ad_veya_email",loginmod.kullanici_ad_veya_email);
                    cmd.Parameters.AddWithValue("@sifre", loginmod.sifre);
                    int result = SqlaccessController.openClose(cmd);
                    if (result == -1)
                    {
                        using (SqlDataAdapter adap=new SqlDataAdapter(cmd))
                        {
                            adap.Fill(dt);
                        }
                    }
                }
            }
            if (dt.Rows.Count > 0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        public string convertToMd5(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            //md5 nesnesi türettik.
            byte[] bsifre = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(text));
            //texti(girilen parolayı) Encoding.UTF8 in GetBytes() methodu ile bir byte dizisine çevirdik.
            StringBuilder sb = new StringBuilder();
            // string builder sınıfından bir nesne türetip , byte dizimizdeki değerleri 
            // Append methodu yardımıyla bir string ifadeye çevirdik.
            foreach (var by in bsifre)
            {
                //x2 burda string'e çevirirken vermesini istediğimiz format.
                //çıktısında göreceğimiz gibi sayılar ve harflerden oluşucaktır.
                sb.Append(by.ToString("x2").ToLower());
            }
            //oluşturduğumuz string ifadeyi geri döndürdük.
            return sb.ToString();
        }
    }
}
