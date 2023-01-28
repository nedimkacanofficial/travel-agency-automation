using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seyahat_Acentesi_Otomasyonu
{
    public partial class PersonnelTitleEditForm : Form
    {
        PersonnelTitleController personneltitlecont = new PersonnelTitleController();
        public PersonnelTitleEditForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult yesorno = MessageBox.Show("Personel unvanı güncellenmek üzere onaylıyor musunuz ?", "Dikkat !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (yesorno == DialogResult.Yes)
            {
                var personneltitlemod = new PersonnelTitleModel();
                personneltitlemod.ad = textBox1.Text;
                personneltitlemod.id = Convert.ToInt32(label3.Text);
                if (ValidationController.validControl(personneltitlemod) == true)
                {
                    var control = personneltitlecont.personneltitlecontrol(personneltitlemod);
                    if (control == false)
                    {
                        var result = personneltitlecont.update(personneltitlemod);
                        if (result == true)
                        {
                            MessageBox.Show("Personel unvanı başarılı bir şekilde güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Personel unvanı güncellenirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Personel unvanı zaten kayıtlı lütfen başka bir isim ile tekrar güncelleyin !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
