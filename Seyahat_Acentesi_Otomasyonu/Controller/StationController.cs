using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controller
{
    public class StationController
    {
        public DataTable list()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DurakListele";
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
        public bool insert(StationModel stationmod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DurakEkle";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@guzergahlar_id", stationmod.guzergahlar_id);
                    cmd.Parameters.AddWithValue("@kalkis_sehir_id", stationmod.kalkis_sehir_id);
                    cmd.Parameters.AddWithValue("@varis_sehir_id", stationmod.varis_sehir_id);
                    cmd.Parameters.AddWithValue("@ham_fiyat", stationmod.ham_fiyat);
                    cmd.Parameters.AddWithValue("@kar_yuzdesi", stationmod.kar_yuzdesi);
                    cmd.Parameters.AddWithValue("@tutar", stationmod.tutar);
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
        public bool update(StationModel stationmod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DurakGuncelle";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@guzergahlar_id", stationmod.guzergahlar_id);
                    cmd.Parameters.AddWithValue("@kalkis_sehir_id", stationmod.kalkis_sehir_id);
                    cmd.Parameters.AddWithValue("@varis_sehir_id", stationmod.varis_sehir_id);
                    cmd.Parameters.AddWithValue("@ham_fiyat", stationmod.ham_fiyat);
                    cmd.Parameters.AddWithValue("@kar_yuzdesi", stationmod.kar_yuzdesi);
                    cmd.Parameters.AddWithValue("@tutar", stationmod.tutar);
                    cmd.Parameters.AddWithValue("@id", stationmod.id);
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
        public bool delete(StationModel stationmod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DurakSil";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", stationmod.id);
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
        public DataTable search(StationModel stationmod)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DurakAra";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@aranacak_deger", string.Format("{0}%", stationmod.aranacak_deger));
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
        public bool stationcontrol(StationModel stationmod)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "DurakKontrol";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@guzergahlar_id", stationmod.guzergahlar_id);
                    cmd.Parameters.AddWithValue("@kalkis_sehir_id", stationmod.kalkis_sehir_id);
                    cmd.Parameters.AddWithValue("@varis_sehir_id", stationmod.varis_sehir_id);
                    cmd.Parameters.AddWithValue("@ham_fiyat", stationmod.ham_fiyat);
                    cmd.Parameters.AddWithValue("@kar_yuzdesi", stationmod.kar_yuzdesi);
                    cmd.Parameters.AddWithValue("@tutar", stationmod.tutar);
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
