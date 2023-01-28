using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class VoyageModel
    {
        public int id { get; set; }
        [Required, MinLength(1), MaxLength(10),Display(Name ="Sefer Kodu")]
        public string kod { get; set; }
        [Required,MinLength(1),MaxLength(5),Display(Name ="Kalkış Peron")]
        public string kalkis_peron { get; set; }
        [Required]
        public int personeller_id { get; set; }
        [Required]
        public int guzergahlar_id { get; set; }
        [Required]
        public int sofor_id { get; set; }
        [Required]
        public int muavin_id { get; set; }
        [Required]
        public int araclar_id { get; set; }
        [Required]
        public bool arac_ici_ikram { get; set; }
        [Required]
        public bool wifi { get; set; }
        [Required]
        public DateTime kalkis_tarih { get; set; }
        [Required]
        public DateTime varis_tarih { get; set; }
    }
}
