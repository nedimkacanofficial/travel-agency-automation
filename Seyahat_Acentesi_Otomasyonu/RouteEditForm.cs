using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seyahat_Acentesi_Otomasyonu
{
    public partial class RouteEditForm : Form
    {
        RouteController routecont = new RouteController();
        public RouteEditForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult yesorno = MessageBox.Show("Güzergah güncellenmek üzere onaylıyor musunuz ?", "Dikkat !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (yesorno == DialogResult.Yes)
            {
                var routemod = new RouteModel();
                routemod.personeler_id = Convert.ToInt32(label4.Text);
                routemod.guzergah_kodu = textBox1.Text;
                routemod.baslangic_durak_id = Convert.ToInt32(comboBox2.SelectedValue);
                routemod.bitis_durak_id = Convert.ToInt32(comboBox3.SelectedValue);
                routemod.subeler_id = Convert.ToInt32(comboBox1.SelectedValue);
                routemod.id = Convert.ToInt32(label3.Text);
                if (ValidationController.validControl(routemod) == true)
                {
                    var result = routecont.update(routemod);
                    if (result == true)
                    {
                        MessageBox.Show("Güzergah başarılı bir şekilde güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Güzergah güncellenirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
            }
        }
    }
}
