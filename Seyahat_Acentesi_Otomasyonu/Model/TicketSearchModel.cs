using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TicketSearchModel
    {
        [Required,MinLength(1),MaxLength(50),Display(Name ="Nereden")]
        public string nereden { get; set; }
        [Required, MinLength(1), MaxLength(50), Display(Name = "Nereye")]
        public string nereye { get; set; }
        [Required,Display(Name = "Kalkış Tarih")]
        public DateTime kalkis_tarih { get; set; }
    }
}
