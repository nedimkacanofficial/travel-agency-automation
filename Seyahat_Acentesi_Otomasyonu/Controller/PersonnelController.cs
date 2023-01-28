using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Security.Policy;

namespace Controller
{
    public class PersonnelController
    {
        public DataTable activepersonnellist()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "AktifPersonelListele";
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
        public DataTable activepersonnellistRegional(int subeler_id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "AktifPersonelListeleBolgeMudur";
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
        public DataTable passivepersonnellist()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "AyrilmisPersonelListele";
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
        public DataTable passivepersonnellistRegional(int subeler_id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "PasifPersonelListeleBolgeMudur";
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
        public bool insert(PersonnelModel personnelmod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "PersonelEkle";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tc", personnelmod.tc);
                    cmd.Parameters.AddWithValue("@ad", personnelmod.ad);
                    cmd.Parameters.AddWithValue("@soyad", personnelmod.soyad);
                    cmd.Parameters.AddWithValue("@email", personnelmod.email);
                    cmd.Parameters.AddWithValue("@telefon", personnelmod.telefon);
                    cmd.Parameters.AddWithValue("@cinsiyet", personnelmod.cinsiyet);
                    cmd.Parameters.AddWithValue("@dogum_tarih", personnelmod.dogum_tarih);
                    cmd.Parameters.AddWithValue("@sehirler_id", personnelmod.sehirler_id);
                    cmd.Parameters.AddWithValue("@adres", personnelmod.adres);
                    cmd.Parameters.AddWithValue("@maas", personnelmod.maas);
                    cmd.Parameters.AddWithValue("@kullanici_ad", personnelmod.kullanici_ad);
                    cmd.Parameters.AddWithValue("@sifre", personnelmod.sifre);
                    cmd.Parameters.AddWithValue("@subeler_id", personnelmod.subeler_id);
                    cmd.Parameters.AddWithValue("@personel_tipleri_id", personnelmod.personel_tipleri_id);
                    cmd.Parameters.AddWithValue("@yetki_durum", personnelmod.yetki_durum);
                    cmd.Parameters.AddWithValue("@personel_resmi", personnelmod.image);
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
        public bool insertnullimage(PersonnelModel personnelmod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "PersonelEkleResimsiz";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tc", personnelmod.tc);
                    cmd.Parameters.AddWithValue("@ad", personnelmod.ad);
                    cmd.Parameters.AddWithValue("@soyad", personnelmod.soyad);
                    cmd.Parameters.AddWithValue("@email", personnelmod.email);
                    cmd.Parameters.AddWithValue("@telefon", personnelmod.telefon);
                    cmd.Parameters.AddWithValue("@cinsiyet", personnelmod.cinsiyet);
                    cmd.Parameters.AddWithValue("@dogum_tarih", personnelmod.dogum_tarih);
                    cmd.Parameters.AddWithValue("@sehirler_id", personnelmod.sehirler_id);
                    cmd.Parameters.AddWithValue("@adres", personnelmod.adres);
                    cmd.Parameters.AddWithValue("@maas", personnelmod.maas);
                    cmd.Parameters.AddWithValue("@kullanici_ad", personnelmod.kullanici_ad);
                    cmd.Parameters.AddWithValue("@sifre", personnelmod.sifre);
                    cmd.Parameters.AddWithValue("@subeler_id", personnelmod.subeler_id);
                    cmd.Parameters.AddWithValue("@personel_tipleri_id", personnelmod.personel_tipleri_id);
                    cmd.Parameters.AddWithValue("@yetki_durum", personnelmod.yetki_durum);
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
        public bool update(PersonnelModel personnelmod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "PersonelGuncelle";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tc", personnelmod.tc);
                    cmd.Parameters.AddWithValue("@ad", personnelmod.ad);
                    cmd.Parameters.AddWithValue("@soyad", personnelmod.soyad);
                    cmd.Parameters.AddWithValue("@email", personnelmod.email);
                    cmd.Parameters.AddWithValue("@telefon", personnelmod.telefon);
                    cmd.Parameters.AddWithValue("@cinsiyet", personnelmod.cinsiyet);
                    cmd.Parameters.AddWithValue("@dogum_tarih", personnelmod.dogum_tarih);
                    cmd.Parameters.AddWithValue("@sehirler_id", personnelmod.sehirler_id);
                    cmd.Parameters.AddWithValue("@adres", personnelmod.adres);
                    cmd.Parameters.AddWithValue("@maas", personnelmod.maas);
                    cmd.Parameters.AddWithValue("@kullanici_ad", personnelmod.kullanici_ad);
                    cmd.Parameters.AddWithValue("@subeler_id", personnelmod.subeler_id);
                    cmd.Parameters.AddWithValue("@personel_tipleri_id", personnelmod.personel_tipleri_id);
                    cmd.Parameters.AddWithValue("@yetki_durum", personnelmod.yetki_durum);
                    cmd.Parameters.AddWithValue("@personel_resmi", personnelmod.image);
                    cmd.Parameters.AddWithValue("@id", personnelmod.id);
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
        public bool updatenullimage(PersonnelModel personnelmod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "PersonelGuncelleResimsiz";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tc", personnelmod.tc);
                    cmd.Parameters.AddWithValue("@ad", personnelmod.ad);
                    cmd.Parameters.AddWithValue("@soyad", personnelmod.soyad);
                    cmd.Parameters.AddWithValue("@email", personnelmod.email);
                    cmd.Parameters.AddWithValue("@telefon", personnelmod.telefon);
                    cmd.Parameters.AddWithValue("@cinsiyet", personnelmod.cinsiyet);
                    cmd.Parameters.AddWithValue("@dogum_tarih", personnelmod.dogum_tarih);
                    cmd.Parameters.AddWithValue("@sehirler_id", personnelmod.sehirler_id);
                    cmd.Parameters.AddWithValue("@adres", personnelmod.adres);
                    cmd.Parameters.AddWithValue("@maas", personnelmod.maas);
                    cmd.Parameters.AddWithValue("@kullanici_ad", personnelmod.kullanici_ad);
                    cmd.Parameters.AddWithValue("@subeler_id", personnelmod.subeler_id);
                    cmd.Parameters.AddWithValue("@personel_tipleri_id", personnelmod.personel_tipleri_id);
                    cmd.Parameters.AddWithValue("@yetki_durum", personnelmod.yetki_durum);
                    cmd.Parameters.AddWithValue("@id", personnelmod.id);
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
        public bool delete(PersonnelModel personnelmod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "PersonelSil";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", personnelmod.id);
                    cmd.Parameters.AddWithValue("@ayrilma_tarih", personnelmod.ayrılma_tarih);
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
        public DataTable activepersonnelsearch(PersonnelModel personnelmod)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "AktifPersonelAra";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@aranacak_deger", string.Format("{0}%", personnelmod.ad));
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
        public DataTable activepersonnelsearchreqional(PersonnelModel personnelmod,int subeler_id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "AktifPersonelAraBolgeMudur";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@aranacak_deger", string.Format("{0}%", personnelmod.ad));
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
        public DataTable passivepersonnelsearch(PersonnelModel personnelmod)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "AyrilmisPersonelAra";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@aranacak_deger", string.Format("{0}%", personnelmod.ad));
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
        public DataTable passivepersonnelsearchregional(PersonnelModel personnelmod,int subeler_id)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "PasifPersonelAraBolgeMudur";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@aranacak_deger", string.Format("{0}%", personnelmod.ad));
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
        public bool personnelcontrol(PersonnelModel personnelmod)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "PersonelKontrol";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tc", personnelmod.tc);
                    cmd.Parameters.AddWithValue("@email", personnelmod.email);
                    cmd.Parameters.AddWithValue("@telefon", personnelmod.telefon);
                    cmd.Parameters.AddWithValue("@kullanici_ad", personnelmod.kullanici_ad);
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
        public DataTable usereditlist(PersonnelModel personnelmod)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "KullaniciProfilListele";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", personnelmod.id);
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
        public bool userupdate(PersonnelModel personnelmod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "KullaniciProfilGuncelleme";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tc", personnelmod.tc);
                    cmd.Parameters.AddWithValue("@ad", personnelmod.ad);
                    cmd.Parameters.AddWithValue("@soyad", personnelmod.soyad);
                    cmd.Parameters.AddWithValue("@email", personnelmod.email);
                    cmd.Parameters.AddWithValue("@telefon", personnelmod.telefon);
                    cmd.Parameters.AddWithValue("@cinsiyet", personnelmod.cinsiyet);
                    cmd.Parameters.AddWithValue("@dogum_tarih", personnelmod.dogum_tarih);
                    cmd.Parameters.AddWithValue("@sehirler_id", personnelmod.sehirler_id);
                    cmd.Parameters.AddWithValue("@adres", personnelmod.adres);
                    cmd.Parameters.AddWithValue("@sifre", personnelmod.sifre);
                    cmd.Parameters.AddWithValue("@kullanici_ad", personnelmod.kullanici_ad);
                    cmd.Parameters.AddWithValue("@personel_resmi", personnelmod.image);
                    cmd.Parameters.AddWithValue("@id", personnelmod.id);
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
        public bool userupdatenullimage(PersonnelModel personnelmod)
        {
            using (SqlConnection conn = SqlaccessController.connect())
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "KullaniciProfilGuncellemeResimsiz";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tc", personnelmod.tc);
                    cmd.Parameters.AddWithValue("@ad", personnelmod.ad);
                    cmd.Parameters.AddWithValue("@soyad", personnelmod.soyad);
                    cmd.Parameters.AddWithValue("@email", personnelmod.email);
                    cmd.Parameters.AddWithValue("@telefon", personnelmod.telefon);
                    cmd.Parameters.AddWithValue("@cinsiyet", personnelmod.cinsiyet);
                    cmd.Parameters.AddWithValue("@dogum_tarih", personnelmod.dogum_tarih);
                    cmd.Parameters.AddWithValue("@sehirler_id", personnelmod.sehirler_id);
                    cmd.Parameters.AddWithValue("@adres", personnelmod.adres);
                    cmd.Parameters.AddWithValue("@sifre", personnelmod.sifre);
                    cmd.Parameters.AddWithValue("@kullanici_ad", personnelmod.kullanici_ad);
                    cmd.Parameters.AddWithValue("@id", personnelmod.id);
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
    }
}
