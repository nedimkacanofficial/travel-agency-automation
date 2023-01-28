using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Model
{
    public class PersonnelModel
    {
        public int id { get; set; }
        [Required,StringLength(11),Display(Name ="TC Kimlik Numarası")]
        public string tc { get; set; }
        [Required,MinLength(1),MaxLength(100),Display(Name ="Ad")]
        public string ad { get; set; }
        [Required, MinLength(1), MaxLength(100), Display(Name = "Soyad")]
        public string soyad { get; set; }
        [Required, EmailAddress, MinLength(1), MaxLength(100), Display(Name = "E Mail")]
        public string email { get; set; }
        [Required, Phone, MaxLength(15), Display(Name = "Telefon")]
        public string telefon { get; set; }
        [Required, Display(Name = "Cinsiyet")]
        public bool cinsiyet { get; set; }
        [Required, Display(Name = "Doğum Tarihi")]
        public DateTime dogum_tarih { get; set; }
        public int sehirler_id { get; set; }
        [MaxLength(255), Display(Name = "Adres")]
        public string adres { get; set; }
        [Required, Display(Name = "Maaş")]
        public decimal maas { get; set; }
        [Required, MinLength(1), MaxLength(100), Display(Name = "Kullanıcı Adı")]
        public string kullanici_ad { get; set; }
        [MinLength(6), MaxLength(50), Display(Name = "Şifre")]
        public string sifre { get; set; }
        public int subeler_id { get; set; }
        public int personel_tipleri_id { get; set; }
        public byte yetki_durum { get; set; }
        public DateTime ayrılma_tarih { get; set; }
        public byte[] image { get; set; }
        public string imagepath { get; set; }
    }
}
