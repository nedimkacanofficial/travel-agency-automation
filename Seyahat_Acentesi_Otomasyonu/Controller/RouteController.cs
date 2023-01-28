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
    public class RouteController
    {
        public DataTable list()
        {
            DataTable dtb = new DataTable();
            using (SqlConnection conn=SqlaccessController.connect())
            {
                using (SqlCommand cmd=conn.CreateCommand())
                {
                    cmd.CommandText = "GuzergahListele";
                    cmd.CommandType = CommandType.StoredProcedure;
                    int result = SqlaccessController.openClose(cmd);
                    if (result==-1)
                    {
                        using (SqlDataAdapter adap=new SqlDataAdapter(cmd))
                        {
                            adap.Fill(dtb);
                        }
                    }
                }
            }
            if (dtb.Rows.Count>0)
            {
                return dtb;
            }
            else
            {
                return null;
            }
        }
        public bool insert(RouteModel routemod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "GuzergahEkle";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@personeller_id", routemod.personeler_id);
                    cmd.Parameters.AddWithValue("@guzergah_kodu", routemod.guzergah_kodu);
                    cmd.Parameters.AddWithValue("@baslangic_durak_id", routemod.baslangic_durak_id);
                    cmd.Parameters.AddWithValue("@bitis_durak_id", routemod.bitis_durak_id);
                    cmd.Parameters.AddWithValue("@subeler_id", routemod.subeler_id);
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
        public bool update(RouteModel routemod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "GuzergahGuncelle";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@personeller_id", routemod.personeler_id);
                    cmd.Parameters.AddWithValue("@guzergah_kodu", routemod.guzergah_kodu);
                    cmd.Parameters.AddWithValue("@baslangic_durak_id", routemod.baslangic_durak_id);
                    cmd.Parameters.AddWithValue("@bitis_durak_id", routemod.bitis_durak_id);
                    cmd.Parameters.AddWithValue("@subeler_id", routemod.subeler_id);
                    cmd.Parameters.AddWithValue("@id", routemod.id);
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
        public bool delete(RouteModel routemod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "GuzergahSil";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", routemod.id);
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
        public DataTable search(RouteModel routemod)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "GuzergahAra";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@aranacak_deger", string.Format("{0}%", routemod.guzergah_kodu));
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
        public bool registerControl(RouteModel routemod)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "GuzergahKontrol";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@guzergah_kodu", routemod.guzergah_kodu);
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
