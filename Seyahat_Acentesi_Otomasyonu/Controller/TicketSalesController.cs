using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Controller
{
    public class TicketSalesController
    {
        public DataTable ticketListSales()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "BiletListeleSatis";
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
        public DataTable ticketListSalesRegional(int subeler_id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "BiletListeleSatisRegional";
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
        public DataTable ticketListRezervation()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "BiletListeleRezervasyon";
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
        public DataTable ticketListRezervationRegional(int subeler_id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "BiletListeleRezervasyonRegional";
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
        public bool insert(TicketSalesModel ticketsalesmod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "BiletSat";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@personeller_id", ticketsalesmod.personeller_id);
                    cmd.Parameters.AddWithValue("@seferler_id",ticketsalesmod.seferler_id);
                    cmd.Parameters.AddWithValue("@kalkis_sehir_id",ticketsalesmod.kalkis_sehir_id);
                    cmd.Parameters.AddWithValue("@varis_sehir_id",ticketsalesmod.varis_sehir_id);
                    cmd.Parameters.AddWithValue("@satismi_rezervasyonmu",ticketsalesmod.satismi_rezervasyonmu);
                    cmd.Parameters.AddWithValue("@tc",ticketsalesmod.tc);
                    cmd.Parameters.AddWithValue("@ad",ticketsalesmod.ad);
                    cmd.Parameters.AddWithValue("@soyad",ticketsalesmod.soyad);
                    cmd.Parameters.AddWithValue("@telefon",ticketsalesmod.telefon);
                    cmd.Parameters.AddWithValue("@email",ticketsalesmod.email);
                    cmd.Parameters.AddWithValue("@cinsiyet",ticketsalesmod.cinsiyet);
                    cmd.Parameters.AddWithValue("@sehirler_id",ticketsalesmod.sehirler_id);
                    cmd.Parameters.AddWithValue("@dogum_tarih",ticketsalesmod.dogum_tarih);
                    cmd.Parameters.AddWithValue("@koltuk_no",ticketsalesmod.koltuk_no);
                    cmd.Parameters.AddWithValue("@satis_tipleri_id", ticketsalesmod.satis_tipleri_id);
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
        public bool update(TicketSalesModel ticketsalesmod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "BiletGuncelle";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@personeller_id", ticketsalesmod.personeller_id);
                    cmd.Parameters.AddWithValue("@satismi_rezervasyonmu", ticketsalesmod.satismi_rezervasyonmu);
                    cmd.Parameters.AddWithValue("@tc", ticketsalesmod.tc);
                    cmd.Parameters.AddWithValue("@ad", ticketsalesmod.ad);
                    cmd.Parameters.AddWithValue("@soyad", ticketsalesmod.soyad);
                    cmd.Parameters.AddWithValue("@telefon", ticketsalesmod.telefon);
                    cmd.Parameters.AddWithValue("@email", ticketsalesmod.email);
                    cmd.Parameters.AddWithValue("@cinsiyet", ticketsalesmod.cinsiyet);
                    cmd.Parameters.AddWithValue("@sehirler_id", ticketsalesmod.sehirler_id);
                    cmd.Parameters.AddWithValue("@dogum_tarih", ticketsalesmod.dogum_tarih);
                    cmd.Parameters.AddWithValue("@koltuk_no", ticketsalesmod.koltuk_no);
                    cmd.Parameters.AddWithValue("@satis_tipleri_id", ticketsalesmod.satis_tipleri_id);
                    cmd.Parameters.AddWithValue("@guncelleme_tarih", ticketsalesmod.guncelleme_tarih);
                    cmd.Parameters.AddWithValue("@id", ticketsalesmod.id);
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
        public bool delete(TicketSalesModel ticketsalesmod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "BiletSil";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", ticketsalesmod.id);
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
        public DataTable ticketSalesSearch(TicketSalesModel ticketsalesmod)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "BiletSatisAra";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@aranacak_deger", string.Format("{0}%", ticketsalesmod.ad));
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
        public DataTable ticketSalesSearchRegional(TicketSalesModel ticketsalesmod,int subeler_id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "BiletSatisAraRegional";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@aranacak_deger", string.Format("{0}%", ticketsalesmod.ad));
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
        public DataTable ticketRezervationSearch(TicketSalesModel ticketsalesmod)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "BiletRezervasyonAra";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@aranacak_deger", string.Format("{0}%", ticketsalesmod.ad));
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
        public DataTable ticketRezervationSearchRegional(TicketSalesModel ticketsalesmod,int subeler_id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "BiletRezervasyonAraRegional";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@aranacak_deger", string.Format("{0}%", ticketsalesmod.ad));
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
    }
}
