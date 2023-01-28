using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controller
{
    public class HelperController
    {
        // value arkada tutulan id olacak display kullanıcıya gösterilen değer olacak 
        public void comboFill(string valuemember, string displaymember, string sp_name, ComboBox combo_name)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sp_name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    int sonuc = SqlaccessController.openClose(cmd);
                    if (sonuc == -1)
                    {
                        using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                        {
                            adap.Fill(dt);
                        }
                    }
                }
            }
            if (dt.Rows.Count>0)
            {
                combo_name.DataSource = dt;
                combo_name.DisplayMember = displaymember;
                combo_name.ValueMember = valuemember;
            }
            else
            {
                combo_name.Enabled = false;
                combo_name.DisplayMember = "Kayıt bulunmuyor !";
                combo_name.ValueMember = null;
            }
        }
        public void comboFillFilter(string valuemember, string displaymember,int subeler_id, string sp_name, ComboBox combo_name)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sp_name;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@subeler_id", subeler_id);
                    int sonuc = SqlaccessController.openClose(cmd);
                    if (sonuc == -1)
                    {
                        using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                        {
                            adap.Fill(dt);
                        }
                    }
                }
            }
            if (dt.Rows.Count > 0)
            {
                combo_name.DataSource = dt;
                combo_name.DisplayMember = displaymember;
                combo_name.ValueMember = valuemember;
            }
            else
            {
                combo_name.Enabled = false;
                combo_name.DisplayMember = "Kayıt bulunmuyor !";
                combo_name.ValueMember = null;
            }
        }
    }
}
