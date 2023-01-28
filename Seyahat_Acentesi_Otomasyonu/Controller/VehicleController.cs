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
    public class VehicleController
    {
        public DataTable activecarlist()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn=SqlaccessController.connect())
            {
                using (SqlCommand cmd=conn.CreateCommand())
                {
                    cmd.CommandText = "AktifAracListele";
                    cmd.CommandType = CommandType.StoredProcedure;
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
                return dt;
            }
            else
            {
                return null;
            }
        }
        public DataTable activecarlistregional(int subeler_id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "AktifAracListeleRegional";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@subeler_id", subeler_id);
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
        public DataTable passivecarlist()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "PasifAracListele";
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
        public DataTable passivecarlistregional(int subeler_id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "PasifAracListeleRegional";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@subeler_id",subeler_id);
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
        public bool insert(VehicleModel vehiclemod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "AracEkle";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@plaka", vehiclemod.plaka);
                    cmd.Parameters.AddWithValue("@koltuk_sayisi", vehiclemod.koltuk_sayisi);
                    cmd.Parameters.AddWithValue("@markalar_id", vehiclemod.markalar_id);
                    cmd.Parameters.AddWithValue("@model", vehiclemod.model);
                    cmd.Parameters.AddWithValue("@yil", vehiclemod.yil);
                    cmd.Parameters.AddWithValue("@arac_turleri_id", vehiclemod.arac_turleri_id);
                    cmd.Parameters.AddWithValue("@guzergahlar_id", vehiclemod.guzergahlar_id);
                    cmd.Parameters.AddWithValue("@aktifmi", vehiclemod.aktifmi);
                    cmd.Parameters.AddWithValue("@subeler_id", vehiclemod.subeler_id);
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
        public bool update(VehicleModel vehiclemod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "AracGuncelle";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@plaka", vehiclemod.plaka);
                    cmd.Parameters.AddWithValue("@koltuk_sayisi", vehiclemod.koltuk_sayisi);
                    cmd.Parameters.AddWithValue("@markalar_id", vehiclemod.markalar_id);
                    cmd.Parameters.AddWithValue("@model", vehiclemod.model);
                    cmd.Parameters.AddWithValue("@yil", vehiclemod.yil);
                    cmd.Parameters.AddWithValue("@arac_turleri_id", vehiclemod.arac_turleri_id);
                    cmd.Parameters.AddWithValue("@guzergahlar_id", vehiclemod.guzergahlar_id);
                    cmd.Parameters.AddWithValue("@aktifmi", vehiclemod.aktifmi);
                    cmd.Parameters.AddWithValue("@alis_tarih", vehiclemod.alis_tarih);
                    cmd.Parameters.AddWithValue("@subeler_id", vehiclemod.subeler_id);
                    cmd.Parameters.AddWithValue("@id", vehiclemod.id);
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
        public bool delete(VehicleModel vehiclemod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "AracSil";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", vehiclemod.id);
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
        public DataTable activecarsearch(VehicleModel vehiclemod)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "AktifAracAra";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@aranacak_deger", string.Format("{0}%", vehiclemod.plaka));
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
        public DataTable activecarsearchregional(VehicleModel vehiclemod,int subeler_id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "AktifAracAraRegional";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@aranacak_deger", string.Format("{0}%", vehiclemod.plaka));
                    cmd.Parameters.AddWithValue("@subeler_id", subeler_id);
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
        public DataTable passivecarsearch(VehicleModel vehiclemod)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "PasifAracAra";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@aranacak_deger", string.Format("{0}%", vehiclemod.plaka));
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
        public DataTable passivecarsearchregional(VehicleModel vehiclemod,int subeler_id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "PasifAracAraRegional";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@aranacak_deger", string.Format("{0}%", vehiclemod.plaka));
                    cmd.Parameters.AddWithValue("@subeler_id", subeler_id);
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
        public bool carControl(VehicleModel vehiclemod)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "AracKontrol";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@plaka", vehiclemod.plaka);
                    cmd.Parameters.AddWithValue("@koltuk_sayisi", vehiclemod.koltuk_sayisi);
                    cmd.Parameters.AddWithValue("@markalar_id", vehiclemod.markalar_id);
                    cmd.Parameters.AddWithValue("@model", vehiclemod.model);
                    cmd.Parameters.AddWithValue("@yil", vehiclemod.yil);
                    cmd.Parameters.AddWithValue("@arac_turleri_id", vehiclemod.arac_turleri_id);
                    cmd.Parameters.AddWithValue("@guzergahlar_id", vehiclemod.guzergahlar_id);
                    cmd.Parameters.AddWithValue("@aktifmi", vehiclemod.aktifmi);
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
