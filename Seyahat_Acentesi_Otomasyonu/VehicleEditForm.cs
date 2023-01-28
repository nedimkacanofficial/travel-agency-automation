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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Seyahat_Acentesi_Otomasyonu
{
    public partial class VehicleEditForm : Form
    {
        VehicleController vehiclecont = new VehicleController();
        public VehicleEditForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult yesorno = MessageBox.Show("Araç güncellenmek üzere onaylıyor musunuz ?", "Dikkat !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (yesorno == DialogResult.Yes)
            {
                if (Convert.ToInt32(comboBox1.SelectedValue) == 0)
                {
                    MessageBox.Show("Lütfen bir marka seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (Convert.ToInt32(comboBox2.SelectedValue) == 0)
                {
                    MessageBox.Show("Lütfen bir araç türü seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (Convert.ToInt32(comboBox3.SelectedValue) == 0)
                {
                    MessageBox.Show("Lütfen bir güzergah seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (Convert.ToInt32(comboBox4.SelectedValue) == 0)
                {
                    MessageBox.Show("Lütfen bir şube seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (string.IsNullOrEmpty(textBox3.Text))
                {
                    MessageBox.Show("Koltuk sayısı boş geçilemez !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox3.Text == ",")
                {
                    MessageBox.Show("Lütfen geçerli bir koltuk sayısı giriniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    var vehiclemod = new VehicleModel();
                    vehiclemod.plaka = textBox1.Text;
                    vehiclemod.koltuk_sayisi = Convert.ToByte(textBox3.Text);
                    vehiclemod.markalar_id = Convert.ToInt32(comboBox1.SelectedValue);
                    vehiclemod.model = textBox4.Text;
                    vehiclemod.yil = dateTimePicker1.Value;
                    vehiclemod.arac_turleri_id = Convert.ToInt32(comboBox2.SelectedValue);
                    vehiclemod.guzergahlar_id = Convert.ToInt32(comboBox3.SelectedValue);
                    vehiclemod.subeler_id = Convert.ToInt32(comboBox4.SelectedValue);
                    vehiclemod.alis_tarih = DateTime.Now;
                    vehiclemod.id = Convert.ToInt32(label3.Text);
                    if (radioButton1.Checked == true)
                    {
                        vehiclemod.aktifmi = true;
                    }
                    else if (radioButton2.Checked == true)
                    {
                        vehiclemod.aktifmi = false;
                    }
                    if (ValidationController.validControl(vehiclemod) == true)
                    {
                        var carcontrol = vehiclecont.carControl(vehiclemod);
                        if (carcontrol == false)
                        {
                            var result = vehiclecont.update(vehiclemod);
                            if (result == true)
                            {
                                MessageBox.Show("Araç başarılı bir şekilde güncellendi edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Araç güncellenirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Araç zaten kayıtlı lütfen başka bir plaka ile tekrar deneyin !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ayrac = ',';// buraya istediğiniz bir ayracı yazabilirsiniz.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ayrac))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ayrac) && ((sender as TextBox).Text.IndexOf(ayrac) > -1))//İlk karakterin '.' olup olmadığını kontrol ediyoruzuz
            {
                e.Handled = true;//Değilse görmezden geliyoruz.
            }
        }
    }
}
