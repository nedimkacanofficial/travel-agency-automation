using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class RouteModel
    {
        public int id { get; set; }
        [Required]
        public int personeler_id { get; set; }
        [Required,MinLength(1),MaxLength(50),Display(Name ="Güzergah Kodu")]
        public string guzergah_kodu { get; set; }
        [Required]
        public int baslangic_durak_id { get; set; }
        [Required]
        public int bitis_durak_id { get; set; }
        [Required]
        public int subeler_id { get; set; }
    }
}
