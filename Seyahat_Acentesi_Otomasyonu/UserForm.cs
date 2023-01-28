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

namespace Seyahat_Acentesi_Otomasyonu
{
    public partial class UserForm : Form
    {
        LoginController logincont = new LoginController();
        PersonnelController personnelcont = new PersonnelController();
        public UserForm()
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
            else if (string.IsNullOrEmpty(textBox9.Text))
            {
                MessageBox.Show("Bilgilerinizi güncellemek için şifre zorunludur !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                personnelmod.email = textBox8.Text;
                personnelmod.kullanici_ad = textBox4.Text;
                personnelmod.sifre = logincont.convertToMd5(textBox9.Text);
                if (pathimage.imagepath != null)
                {
                    FileStream fs = new FileStream(pathimage.imagepath, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    personnelmod.image = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();
                    if (ValidationController.validControl(personnelmod) == true)
                    {
                        var result = personnelcont.userupdate(personnelmod);
                        if (result == true)
                        {
                            MessageBox.Show("Profiliniz başarılı bir şekilde güncellendi edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Profiliniz güncellenirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                }
                else
                {
                    if (ValidationController.validControl(personnelmod) == true)
                    {
                        var result = personnelcont.userupdatenullimage(personnelmod);
                        if (result == true)
                        {
                            MessageBox.Show("Profiliniz başarılı bir şekilde güncellendi edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Profiliniz güncellenirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}
