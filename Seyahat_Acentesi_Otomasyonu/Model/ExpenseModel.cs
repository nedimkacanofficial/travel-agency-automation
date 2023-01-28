using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class ExpenseModel
    {
        public int id { get; set; }

        [Required,Display(Name ="Personel")]
        public int personeller_id { get; set; }
        [Required,Display(Name ="Şube")]
        public int subeler_id { get; set; }

        [Display(Name = "Araç")]
        public int araclar_id { get; set; }

        [Display(Name = "Sefer")]
        public int seferler_id { get; set; }

        [Required, Display(Name = "Masraf Türü")]
        public int masraf_tipleri_id { get; set; }
        public decimal tutar { get; set; }

        [Display(Name = "Açıklama")]
        public string aciklama { get; set; }

        [Required, Display(Name = "Araç mı Şube mi")]
        public bool arac_sube { get; set; }
        public DateTime masraf_tarih { get; set; }
    }
}
