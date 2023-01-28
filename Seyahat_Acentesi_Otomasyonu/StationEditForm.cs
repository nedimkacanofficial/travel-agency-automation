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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Seyahat_Acentesi_Otomasyonu
{
    public partial class StationEditForm : Form
    {
        StationController stationcont = new StationController();
        HelperController helpercont = new HelperController();
        public StationEditForm()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(textBox2.Text)) && (string.IsNullOrEmpty(textBox1.Text)))
            {
                textBox3.Text = textBox2.Text;
            }
            else
            {
                textBox3.Clear();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(textBox1.Text)) && (!string.IsNullOrEmpty(textBox2.Text)))
            {
                textBox3.Text = Convert.ToDecimal((Convert.ToDecimal(textBox2.Text) * Convert.ToDecimal(textBox1.Text)) / 100 + (Convert.ToDecimal(textBox2.Text))).ToString();
            }
            else
            {
                textBox3.Text = textBox2.Text;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(comboBox1.SelectedValue) == 0)
            {
                MessageBox.Show("Lütfen bir güzergah seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (Convert.ToInt32(comboBox2.SelectedValue) == 0)
            {
                MessageBox.Show("Lütfen bir kalkış durak seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (Convert.ToInt32(comboBox3.SelectedValue) == 0)
            {
                MessageBox.Show("Lütfen bir varış durak seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Ham fiyat zorunludur !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Tutar boş geçilemez !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox2.Text.Length > 15)
            {
                MessageBox.Show("Girilen ham fiyat çok büyük !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox1.Text.Length > 15)
            {
                MessageBox.Show("Girilen kar oranı çok büyük !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox3.Text.Length > 15)
            {
                MessageBox.Show("Girilen tutar çok büyük !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox2.Text == ",")
            {
                MessageBox.Show("Lütfen geçerli bir fiyat giriniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox1.Text == ",")
            {
                MessageBox.Show("Lütfen geçerli bir kar oranı giriniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox3.Text == ",")
            {
                MessageBox.Show("Lütfen geçerli bir tutar giriniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var stationmod = new StationModel();
                stationmod.guzergahlar_id = Convert.ToInt32(comboBox1.SelectedValue);
                stationmod.kalkis_sehir_id = Convert.ToInt32(comboBox2.SelectedValue);
                stationmod.varis_sehir_id = Convert.ToInt32(comboBox3.SelectedValue);
                stationmod.ham_fiyat = Convert.ToDecimal(textBox2.Text);
                stationmod.kar_yuzdesi = Convert.ToDecimal(textBox1.Text);
                stationmod.tutar = Convert.ToDecimal(textBox3.Text);
                stationmod.id = Convert.ToInt32(label3.Text);
                if (ValidationController.validControl(stationmod) == true)
                {
                    var stationcontrol = stationcont.stationcontrol(stationmod);
                    if (stationcontrol == false)
                    {
                        var result = stationcont.update(stationmod);
                        if (result == true)
                        {
                            MessageBox.Show("Durak başarılı bir şekilde güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Durak güncellenirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme yapabilmek için lütfen birşeyler değiştiriniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
