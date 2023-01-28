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
    public class VoyageController
    {
        public DataTable list()
        {
            DataTable dtb = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SeferListele";
                    cmd.CommandType = CommandType.StoredProcedure;
                    int result = SqlaccessController.openClose(cmd);
                    if (result == -1)
                    {
                        using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                        {
                            adap.Fill(dtb);
                        }
                    }
                }
            }
            if (dtb.Rows.Count > 0)
            {
                return dtb;
            }
            else
            {
                return null;
            }
        }
        public DataTable listregional(int subeler_id)
        {
            DataTable dtb = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SeferListeleRegional";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@subeler_id", subeler_id);
                    int result = SqlaccessController.openClose(cmd);
                    if (result == -1)
                    {
                        using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                        {
                            adap.Fill(dtb);
                        }
                    }
                }
            }
            if (dtb.Rows.Count > 0)
            {
                return dtb;
            }
            else
            {
                return null;
            }
        }
        public bool insert(VoyageModel voyagemod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SeferEkle";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@kod", voyagemod.kod);
                    cmd.Parameters.AddWithValue("@guzergahlar_id", voyagemod.guzergahlar_id);
                    cmd.Parameters.AddWithValue("@kalkis_peron", voyagemod.kalkis_peron);
                    cmd.Parameters.AddWithValue("@personeller_id", voyagemod.personeller_id);
                    cmd.Parameters.AddWithValue("@sofor_id", voyagemod.sofor_id);
                    cmd.Parameters.AddWithValue("@muavin_id", voyagemod.muavin_id);
                    cmd.Parameters.AddWithValue("@kalkis_tarih", voyagemod.kalkis_tarih);
                    cmd.Parameters.AddWithValue("@varis_tarih", voyagemod.varis_tarih);
                    cmd.Parameters.AddWithValue("@arac_ici_ikram", voyagemod.arac_ici_ikram);
                    cmd.Parameters.AddWithValue("@wifi", voyagemod.wifi);
                    cmd.Parameters.AddWithValue("@araclar_id", voyagemod.araclar_id);
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
        public bool update(VoyageModel voyagemod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SeferGuncelle";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@kod", voyagemod.kod);
                    cmd.Parameters.AddWithValue("@guzergahlar_id", voyagemod.guzergahlar_id);
                    cmd.Parameters.AddWithValue("@kalkis_peron", voyagemod.kalkis_peron);
                    cmd.Parameters.AddWithValue("@personeller_id", voyagemod.personeller_id);
                    cmd.Parameters.AddWithValue("@sofor_id", voyagemod.sofor_id);
                    cmd.Parameters.AddWithValue("@muavin_id", voyagemod.muavin_id);
                    cmd.Parameters.AddWithValue("@kalkis_tarih", voyagemod.kalkis_tarih);
                    cmd.Parameters.AddWithValue("@varis_tarih", voyagemod.varis_tarih);
                    cmd.Parameters.AddWithValue("@arac_ici_ikram", voyagemod.arac_ici_ikram);
                    cmd.Parameters.AddWithValue("@wifi", voyagemod.wifi);
                    cmd.Parameters.AddWithValue("@araclar_id", voyagemod.araclar_id);
                    cmd.Parameters.AddWithValue("@id", voyagemod.id);
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
        public bool delete(VoyageModel voyagemod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SeferSil";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", voyagemod.id);
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
        public DataTable search(VoyageModel voyagemod)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SeferAra";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@aranacak_deger", string.Format("{0}%", voyagemod.kod));
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
        public DataTable searchregional(VoyageModel voyagemod,int subeler_id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SeferAraRegional";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@aranacak_deger", string.Format("{0}%", voyagemod.kod));
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
        public bool registerControl(VoyageModel voyagemod)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "SeferKontrol";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@kod", voyagemod.kod);
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
