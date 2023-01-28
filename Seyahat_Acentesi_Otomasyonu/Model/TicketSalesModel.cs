using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TicketSalesModel
    {
        public int id { get; set; }
        [Required]
        public int personeller_id { get; set; }
        [Required]
        public int seferler_id { get; set; }
        [Required]
        public int kalkis_sehir_id { get; set; }
        [Required]
        public int varis_sehir_id { get; set; }
        [Required]
        public bool satismi_rezervasyonmu { get; set; }
        [Required,StringLength(11),Display(Name ="TC Kimlik No")]
        public string tc { get; set; }
        [Required,MinLength(1),MaxLength(50),Display(Name ="Ad")]
        public string ad { get; set; }
        [Required, MinLength(1), MaxLength(50), Display(Name = "Soyad")]
        public string soyad { get; set; }
        [Required,Phone,MinLength(1),MaxLength(15), Display(Name = "Telefon")]
        public string telefon { get; set; }
        [Required,EmailAddress, MinLength(1), MaxLength(100), Display(Name = "Ad")]
        public string email { get; set; }
        [Required]
        public bool cinsiyet { get; set; }
        [Required]
        public int sehirler_id { get; set; }
        [Required]
        public DateTime dogum_tarih { get; set; }
        [Required]
        public byte koltuk_no { get; set; }
        [Required]
        public int satis_tipleri_id { get; set; }
        [Required]
        public DateTime guncelleme_tarih { get; set; }
    }
}
