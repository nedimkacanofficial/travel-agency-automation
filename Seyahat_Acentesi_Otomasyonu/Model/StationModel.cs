using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class StationModel
    {
        public int id { get; set; }
        [Required]
        public int guzergahlar_id { get; set; }
        [Required]
        public int kalkis_sehir_id { get; set; }
        [Required]
        public int varis_sehir_id { get; set; }
        [Required]
        public decimal ham_fiyat { get; set; }
        [Required]
        public decimal kar_yuzdesi { get; set; }
        [Required]
        public decimal tutar { get; set; }
        public string aranacak_deger { get; set; }
    }
}
