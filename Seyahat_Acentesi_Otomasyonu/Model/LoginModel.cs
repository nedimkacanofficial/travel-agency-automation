using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LoginModel
    {
        [Required,MinLength(3),MaxLength(100),Display(Name ="Kullanıcı Adı veya E Mail")]
        public string kullanici_ad_veya_email { get; set; }
        [Required,MinLength(6),MaxLength(50),Display(Name ="Şifre")]
        public string sifre { get; set; }
    }
}
