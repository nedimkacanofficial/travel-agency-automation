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
    public partial class VehicleTypeEditForm : Form
    {
        VehicleTypeController vehicletypecont = new VehicleTypeController();
        public VehicleTypeEditForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult yesorno = MessageBox.Show("Araç türü güncellenmek üzere onaylıyor musunuz ?", "Dikkat !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (yesorno == DialogResult.Yes)
            {
                var vehicletypemod = new VehicleTypeModel();
                vehicletypemod.ad = textBox1.Text;
                vehicletypemod.id = Convert.ToInt32(label3.Text);
                if (ValidationController.validControl(vehicletypemod) == true)
                {
                    var control = vehicletypecont.registerControl(vehicletypemod);
                    if (control == false)
                    {
                        var result = vehicletypecont.update(vehicletypemod);
                        if (result == true)
                        {
                            MessageBox.Show("Araç türü başarılı bir şekilde güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Araç türü güncellenirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Araç türü zaten kayıtlı lütfen başka bir isim ile tekrar güncelleyin !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
