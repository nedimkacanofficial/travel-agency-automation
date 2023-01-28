using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
    public class PaymentTypeController
    {
        public DataTable list()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn=SqlaccessController.connect())
            {
                using (SqlCommand cmd=conn.CreateCommand())
                {
                    cmd.CommandText = "SatisTipListele";
                    cmd.CommandType = CommandType.StoredProcedure;
                    int result=SqlaccessController.openClose(cmd);
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
        public bool insert(PaymentTypeModel paymenttypemod)
        {
            using (SqlConnection conn=SqlaccessController.connect())
            {
                using (SqlCommand cmd=conn.CreateCommand())
                {
                    cmd.CommandText = "SatisTipEkle";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ad", paymenttypemod.ad);
                    int result=SqlaccessController.openClose(cmd);
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
        public bool update(PaymentTypeModel paymenttypemod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SatisTipGuncelle";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ad", paymenttypemod.ad);
                    cmd.Parameters.AddWithValue("@id", paymenttypemod.id);
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
        public bool delete(PaymentTypeModel paymenttypemod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SatisTipSil";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", paymenttypemod.id);
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
        public DataTable search(PaymentTypeModel paymenttypemod)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn=SqlaccessController.connect())
            {
                using (SqlCommand cmd=conn.CreateCommand())
                {
                    cmd.CommandText = "SatisTipAra";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@aranacak_deger", string.Format("{0}%", paymenttypemod.ad));
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
            if (dt.Rows.Count>0)
            {
                return dt;
            }
            else
            {
                return null;
            }
        }
        public bool registerControl(PaymentTypeModel paymenttypemod)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn=SqlaccessController.connect())
            {
                using (SqlCommand cmd=conn.CreateCommand())
                {
                    cmd.CommandText = "SatisTipKontrol";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ad", paymenttypemod.ad);
                    int result = SqlaccessController.openClose(cmd);
                    if (result==-1)
                    {
                        using (SqlDataAdapter adap=new SqlDataAdapter(cmd))
                        {
                            adap.Fill(dt);
                        }
                    }
                }
            }
            if (dt.Rows.Count>0)
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
