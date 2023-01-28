using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class VehicleModel
    {
        public int id { get; set; }
        [Required,MinLength(1),MaxLength(15),Display(Name ="Plaka")]
        public string plaka { get; set; }
        [Required]
        public byte koltuk_sayisi { get; set; }
        [Required]
        public int markalar_id { get; set; }
        [Required,MinLength(1),MaxLength(50),Display(Name ="Model")]
        public string model { get; set; }
        [Required]
        public DateTime yil { get; set; }
        [Required]
        public int arac_turleri_id { get; set; }
        [Required]
        public int guzergahlar_id { get; set; }
        [Required]
        public bool aktifmi { get; set; }
        [Required]
        public DateTime alis_tarih { get; set; }
        [Required]
        public int subeler_id { get; set; }
    }
}
