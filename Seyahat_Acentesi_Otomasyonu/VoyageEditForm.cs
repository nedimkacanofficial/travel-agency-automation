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
    public partial class VoyageEditForm : Form
    {
        VoyageController voyagecont = new VoyageController();
        public VoyageEditForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult yesorno = MessageBox.Show("Sefer güncellenmek üzere onaylıyor musunuz ?", "Dikkat !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (yesorno == DialogResult.Yes)
            {
                if (Convert.ToInt32(comboBox1.SelectedValue) == 0)
                {
                    MessageBox.Show("Lütfen bir muavin seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (Convert.ToInt32(comboBox2.SelectedValue) == 0)
                {
                    MessageBox.Show("Lütfen bir güzergah seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (Convert.ToInt32(comboBox3.SelectedValue) == 0)
                {
                    MessageBox.Show("Lütfen bir şoför seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (Convert.ToInt32(comboBox4.SelectedValue) == 0)
                {
                    MessageBox.Show("Lütfen bir araç seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var voyagemod = new VoyageModel();
                    voyagemod.id = Convert.ToInt32(label3.Text);
                    voyagemod.personeller_id = Convert.ToInt32(label4.Text);
                    voyagemod.kod = textBox1.Text;
                    voyagemod.kalkis_peron = textBox3.Text;
                    voyagemod.guzergahlar_id = Convert.ToInt32(comboBox2.SelectedValue);
                    voyagemod.sofor_id = Convert.ToInt32(comboBox3.SelectedValue);
                    voyagemod.muavin_id = Convert.ToInt32(comboBox1.SelectedValue);
                    voyagemod.araclar_id = Convert.ToInt32(comboBox4.SelectedValue);
                    if (radioButton1.Checked == true)
                    {
                        voyagemod.arac_ici_ikram = true;
                    }
                    else if (radioButton2.Checked == true)
                    {
                        voyagemod.arac_ici_ikram = false;
                    }
                    if (radioButton3.Checked == true)
                    {
                        voyagemod.wifi = true;
                    }
                    else if (radioButton4.Checked == true)
                    {
                        voyagemod.wifi = false;
                    }
                    voyagemod.kalkis_tarih = dateTimePicker1.Value;
                    voyagemod.varis_tarih = dateTimePicker2.Value;
                    if (ValidationController.validControl(voyagemod) == true)
                    {
                        var result = voyagecont.update(voyagemod);
                        if (result == true)
                        {
                            MessageBox.Show("Sefer başarılı bir şekilde güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Sefer güncellenirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}
