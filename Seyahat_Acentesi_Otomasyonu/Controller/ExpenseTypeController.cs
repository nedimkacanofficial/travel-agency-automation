using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class ExpenseTypeController
    {
        public DataTable list()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "MasrafTipListele";
                    cmd.CommandType = CommandType.StoredProcedure;
                    int result = SqlaccessController.openClose(cmd);
                    if (result == -1)
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
                return dt;
            }
            else
            {
                return null;
            }
        }
        public bool insert(ExpenseTypeModel expensetypemod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "MasrafTipEkle";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ad", expensetypemod.ad);
                    int result = SqlaccessController.openClose(cmd);
                    if (result == -1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public bool update(ExpenseTypeModel expensetypemod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "MasrafTipGuncelle";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ad", expensetypemod.ad);
                    cmd.Parameters.AddWithValue("@id", expensetypemod.id);
                    int result = SqlaccessController.openClose(cmd);
                    if (result == -1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public bool delete(ExpenseTypeModel expensetypemod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "MasrafTipSil";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", expensetypemod.id);
                    int result = SqlaccessController.openClose(cmd);
                    if (result == -1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
        public DataTable search(ExpenseTypeModel expensetypemod)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "MasrafTipAra";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@aranacak_deger", string.Format("{0}%", expensetypemod.ad));
                    int result = SqlaccessController.openClose(cmd);
                    if (result == -1)
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
                return dt;
            }
            else
            {
                return null;
            }
        }
        public bool registerControl(ExpenseTypeModel expensetypemod)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "MasrafTipKontrol";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ad", expensetypemod.ad);
                    int result = SqlaccessController.openClose(cmd);
                    if (result == -1)
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
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
