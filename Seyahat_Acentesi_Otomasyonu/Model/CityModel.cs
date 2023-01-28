using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class CityModel
    {
        public int id { get; set; }
        [Required, MinLength(1), MaxLength(50), Display(Name = "Şehir Adı")]
        public string ad { get; set; }
    }
}
