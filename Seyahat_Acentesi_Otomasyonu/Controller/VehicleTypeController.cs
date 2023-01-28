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
    public class VehicleTypeController
    {
        public DataTable list()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "AracTuruListele";
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
        public bool insert(VehicleTypeModel vehicletypemod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "AracTuruEkle";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ad", vehicletypemod.ad);
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
        public bool update(VehicleTypeModel vehicletypemod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "AracTuruGuncelle";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ad", vehicletypemod.ad);
                    cmd.Parameters.AddWithValue("@id", vehicletypemod.id);
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
        public bool delete(VehicleTypeModel vehicletypemod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "AracTuruSil";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", vehicletypemod.id);
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
        public DataTable search(VehicleTypeModel vehicletypemod)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "AracTuruAra";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@aranacak_deger", string.Format("{0}%", vehicletypemod.ad));
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
        public bool registerControl(VehicleTypeModel vehicletypemod)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "AracTuruKontrol";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ad", vehicletypemod.ad);
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
