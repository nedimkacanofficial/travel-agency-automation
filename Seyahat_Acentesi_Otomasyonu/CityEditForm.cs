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
    public partial class CityEditForm : Form
    {
        CityController citycont = new CityController();
        public CityEditForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult yesorno = MessageBox.Show("Şehir güncellenmek üzere onaylıyor musunuz ?", "Dikkat !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (yesorno == DialogResult.Yes)
            {
                var citymod = new CityModel();
                citymod.ad = textBox1.Text;
                citymod.id = Convert.ToInt32(label3.Text);
                if (ValidationController.validControl(citymod) == true)
                {
                    var control = citycont.registerControl(citymod);
                    if (control == false)
                    {
                        var result = citycont.update(citymod);
                        if (result == true)
                        {
                            MessageBox.Show("Şehir başarılı bir şekilde güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Şehir güncellenirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şehir zaten kayıtlı lütfen başka bir isim ile tekrar güncelleyin !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
