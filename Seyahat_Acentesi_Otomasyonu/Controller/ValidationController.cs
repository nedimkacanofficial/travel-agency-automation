using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Controller
{
    public class ValidationController
    {
        public static IEnumerable<ValidationResult> validasyonObjesi(object obje)
        {
            var validasyon = new List<ValidationResult>();
            var icerik = new ValidationContext(obje, null, null);
            if (Validator.TryValidateObject(obje, icerik, validasyon, true))
            {
                return null;
            }
            else
            {
                return validasyon;
            }
        }
        public static bool validControl(object obj)
        {
            var error = validasyonObjesi(obj);
            if (error != null)
            {
                foreach (var erro in error)
                {
                    MessageBox.Show(erro.ErrorMessage, "Uyarı !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                }
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
