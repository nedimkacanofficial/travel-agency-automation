using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Seyahat_Acentesi_Otomasyonu
{
    public partial class PersonnelEditForm : Form
    {
        PersonnelController personnelcont = new PersonnelController();
        public PersonnelEditForm()
        {
            InitializeComponent();
        }
        PersonnelModel pathimage = new PersonnelModel();
        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                pathimage.imagepath = openFileDialog1.FileName.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(comboBox1.SelectedValue) == 0)
            {
                MessageBox.Show("Lütfen bir şehir seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (Convert.ToInt32(comboBox2.SelectedValue) == 0)
            {
                MessageBox.Show("Lütfen bir unvan seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (Convert.ToInt32(comboBox3.SelectedValue) == 0)
            {
                MessageBox.Show("Lütfen bir şube seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (string.IsNullOrEmpty(textBox9.Text))
            {
                MessageBox.Show("Maaş boş geçilemez !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox9.Text == ",")
            {
                MessageBox.Show("Lütfen geçerli bir miktar giriniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                var personnelmod = new PersonnelModel();
                personnelmod.id = Convert.ToInt32(label3.Text);
                personnelmod.tc = textBox1.Text;
                personnelmod.ad = textBox3.Text;
                personnelmod.soyad = textBox5.Text;
                personnelmod.dogum_tarih = dateTimePicker1.Value;
                personnelmod.telefon = textBox6.Text;
                personnelmod.sehirler_id = Convert.ToInt32(comboBox1.SelectedValue);
                if (radioButton1.Checked == true)
                {
                    personnelmod.cinsiyet = true;
                }
                else if (radioButton2.Checked == true)
                {
                    personnelmod.cinsiyet = false;
                }
                personnelmod.adres = textBox10.Text;
                personnelmod.personel_tipleri_id = Convert.ToInt32(comboBox2.SelectedValue);
                personnelmod.subeler_id = Convert.ToInt32(comboBox3.SelectedValue);
                personnelmod.email = textBox8.Text;
                personnelmod.kullanici_ad = textBox4.Text;
                personnelmod.maas = Convert.ToDecimal(textBox9.Text);
                if (radioButton3.Checked == true)
                {
                    personnelmod.yetki_durum = 0;
                }
                else if (radioButton4.Checked == true)
                {
                    personnelmod.yetki_durum = 1;
                }
                else if (radioButton7.Checked==true)
                {
                    personnelmod.yetki_durum = 2;
                }
                if (pathimage.imagepath!=null)
                {
                    FileStream fs = new FileStream(pathimage.imagepath, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    personnelmod.image = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();
                    if (ValidationController.validControl(personnelmod) == true)
                    {
                        var result = personnelcont.update(personnelmod);
                        if (result == true)
                        {
                            MessageBox.Show("Üye başarılı bir şekilde güncellendi edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Üye güncellenirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                }
                else
                {
                    if (ValidationController.validControl(personnelmod) == true)
                    {
                        var result = personnelcont.updatenullimage(personnelmod);
                        if (result == true)
                        {
                            MessageBox.Show("Üye başarılı bir şekilde güncellendi edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Üye güncellenirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                }
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
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
