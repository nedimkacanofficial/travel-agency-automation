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
    public partial class VehicleBrandEditForm : Form
    {
        VehicleBrandController vehiclebrandcont = new VehicleBrandController();
        public VehicleBrandEditForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult yesorno = MessageBox.Show("Araç markası güncellenmek üzere onaylıyor musunuz ?", "Dikkat !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (yesorno == DialogResult.Yes)
            {
                var vehiclebrandmod = new VehicleBrandModel();
                vehiclebrandmod.ad = textBox1.Text;
                vehiclebrandmod.id = Convert.ToInt32(label3.Text);
                if (ValidationController.validControl(vehiclebrandmod) == true)
                {
                    var control = vehiclebrandcont.registerControl(vehiclebrandmod);
                    if (control == false)
                    {
                        var result = vehiclebrandcont.update(vehiclebrandmod);
                        if (result == true)
                        {
                            MessageBox.Show("Araç markası başarılı bir şekilde güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Araç markası güncellenirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Araç markası zaten kayıtlı lütfen başka bir isim ile tekrar güncelleyin !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

     
    }
}
