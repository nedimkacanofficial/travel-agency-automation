using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Environment;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Seyahat_Acentesi_Otomasyonu
{
    public partial class PersonnelForm : Form
    {
        LoginController logincont = new LoginController();
        HelperController helpercont = new HelperController();
        PersonnelController personnelcont = new PersonnelController();
        public PersonnelForm()
        {
            InitializeComponent();
        }
        public void activelist()
        {
            if (personnelcont.activepersonnellist() != null)
            {
                if (label20.Text=="0")
                {
                    dataGridView1.DataSource = personnelcont.activepersonnellist();
                }
                else if(label20.Text=="1")
                {
                    dataGridView1.DataSource = personnelcont.activepersonnellistRegional(Convert.ToInt32(label21.Text));
                }
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["sehir_id"].Visible = false;
                dataGridView1.Columns["subeler_id"].Visible = false;
                dataGridView1.Columns["personel_tipleri_id"].Visible = false;
                dataGridView1.Columns["sifre"].Visible = false;

                dataGridView1.Columns["resim"].DisplayIndex = 0;
                dataGridView1.Columns["tc"].DisplayIndex = 1;
                dataGridView1.Columns["ad"].DisplayIndex = 2;
                dataGridView1.Columns["soyad"].DisplayIndex = 3;
                dataGridView1.Columns["dogum_tarih"].DisplayIndex = 4;
                dataGridView1.Columns["telefon"].DisplayIndex = 5;
                dataGridView1.Columns["cinsiyet"].DisplayIndex = 6;
                dataGridView1.Columns["sehir"].DisplayIndex = 7;
                dataGridView1.Columns["adres"].DisplayIndex = 8;
                dataGridView1.Columns["unvan"].DisplayIndex = 9;
                dataGridView1.Columns["sube"].DisplayIndex = 10;
                dataGridView1.Columns["email"].DisplayIndex = 11;
                dataGridView1.Columns["kullanici_ad"].DisplayIndex = 12;
                dataGridView1.Columns["maas"].DisplayIndex = 13;
                dataGridView1.Columns["yetki_durum"].DisplayIndex = 14;
                dataGridView1.Columns["kayit_tarih"].DisplayIndex = 15;

                dataGridView1.Columns["resim"].HeaderText = "RESİM";
                dataGridView1.Columns["tc"].HeaderText = "TC KİMLİK";
                dataGridView1.Columns["ad"].HeaderText = "AD";
                dataGridView1.Columns["soyad"].HeaderText = "SOYAD";
                dataGridView1.Columns["dogum_tarih"].HeaderText = "DOĞUM TARİH";
                dataGridView1.Columns["telefon"].HeaderText = "TELEFON";
                dataGridView1.Columns["cinsiyet"].HeaderText = "CİNSİYET";
                dataGridView1.Columns["sehir"].HeaderText = "ŞEHİR";
                dataGridView1.Columns["adres"].HeaderText = "ADRES";
                dataGridView1.Columns["unvan"].HeaderText = "UNVAN";
                dataGridView1.Columns["sube"].HeaderText = "ŞUBE";
                dataGridView1.Columns["email"].HeaderText = "E MAİL";
                dataGridView1.Columns["kullanici_ad"].HeaderText = "KULLANICI AD";
                dataGridView1.Columns["maas"].HeaderText = "MAAŞ";
                dataGridView1.Columns["yetki_durum"].HeaderText = "YETKİ DURUM";
                dataGridView1.Columns["kayit_tarih"].HeaderText = "KAYIT TARİH";
                
            }
            else
            {
                dataGridView1.DataSource = null;
            }
        }
        public void passivelist()
        {
            if (personnelcont.passivepersonnellist() != null)
            {
                if (label20.Text == "0")
                {
                    dataGridView1.DataSource = personnelcont.passivepersonnellist();
                }
                else
                {
                    dataGridView1.DataSource = personnelcont.passivepersonnellistRegional(Convert.ToInt32(label21.Text));
                }
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["sehir_id"].Visible = false;
                dataGridView1.Columns["subeler_id"].Visible = false;
                dataGridView1.Columns["personel_tipleri_id"].Visible = false;
                dataGridView1.Columns["sifre"].Visible = false;

                dataGridView1.Columns["resim"].DisplayIndex = 0;
                dataGridView1.Columns["tc"].DisplayIndex = 1;
                dataGridView1.Columns["ad"].DisplayIndex = 2;
                dataGridView1.Columns["soyad"].DisplayIndex = 3;
                dataGridView1.Columns["dogum_tarih"].DisplayIndex = 4;
                dataGridView1.Columns["telefon"].DisplayIndex = 5;
                dataGridView1.Columns["cinsiyet"].DisplayIndex = 6;
                dataGridView1.Columns["sehir"].DisplayIndex = 7;
                dataGridView1.Columns["adres"].DisplayIndex = 8;
                dataGridView1.Columns["unvan"].DisplayIndex = 9;
                dataGridView1.Columns["sube"].DisplayIndex = 10;
                dataGridView1.Columns["email"].DisplayIndex = 11;
                dataGridView1.Columns["kullanici_ad"].DisplayIndex = 12;
                dataGridView1.Columns["maas"].DisplayIndex = 13;
                dataGridView1.Columns["yetki_durum"].DisplayIndex = 14;
                dataGridView1.Columns["ayrilma_tarih"].DisplayIndex = 15;

                dataGridView1.Columns["resim"].HeaderText = "RESİM";
                dataGridView1.Columns["tc"].HeaderText = "TC KİMLİK";
                dataGridView1.Columns["ad"].HeaderText = "AD";
                dataGridView1.Columns["soyad"].HeaderText = "SOYAD";
                dataGridView1.Columns["dogum_tarih"].HeaderText = "DOĞUM TARİH";
                dataGridView1.Columns["telefon"].HeaderText = "TELEFON";
                dataGridView1.Columns["cinsiyet"].HeaderText = "CİNSİYET";
                dataGridView1.Columns["sehir"].HeaderText = "ŞEHİR";
                dataGridView1.Columns["adres"].HeaderText = "ADRES";
                dataGridView1.Columns["unvan"].HeaderText = "UNVAN";
                dataGridView1.Columns["sube"].HeaderText = "ŞUBE";
                dataGridView1.Columns["email"].HeaderText = "E MAİL";
                dataGridView1.Columns["kullanici_ad"].HeaderText = "KULLANICI AD";
                dataGridView1.Columns["maas"].HeaderText = "MAAŞ";
                dataGridView1.Columns["yetki_durum"].HeaderText = "YETKİ DURUM";
                dataGridView1.Columns["ayrilma_tarih"].HeaderText = "AYRILMA TARİH";

            }
            else
            {
                dataGridView1.DataSource = null;
            }
        }
        public void clear()
        {
            pictureBox1.ImageLocation = null;
            textBox1.Clear();
            textBox3.Clear();
            textBox10.Clear();
            textBox6.Clear();
            textBox5.Clear();
            textBox8.Clear();
            textBox7.Clear();
            textBox9.Clear();
            comboBox1.SelectedValue = 0;
            textBox4.Clear();
            dateTimePicker1.ResetText();
            comboBox2.SelectedValue = 0;
            comboBox3.SelectedValue = 0;
            radioButton1.Checked = true;
        }
        PersonnelModel pathpersonnelmod = new PersonnelModel();
        private void button3_Click(object sender, EventArgs e)
        {
            // Burada resim seçmek için bir dosya açma sınıfı örneği oluşturduk. Daha sonra bunun sadece resim alması için filtreleme yaptık
            // ve bu seçilen resmi picture box lokasyonuna eşitledik. daha sonra proplarımızdan imagepath içerisine bu resmin dosya yolunu aldık
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...";
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
                pathpersonnelmod.imagepath = openFileDialog1.FileName.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
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
                personnelmod.tc = textBox1.Text;
                personnelmod.ad = textBox3.Text;
                personnelmod.soyad = textBox5.Text;
                personnelmod.dogum_tarih = dateTimePicker1.Value;
                personnelmod.telefon = textBox6.Text;
                personnelmod.sehirler_id= Convert.ToInt32(comboBox1.SelectedValue);
                if (radioButton1.Checked == true)
                {
                    personnelmod.cinsiyet = true;
                }
                else if (radioButton2.Checked == true)
                {
                    personnelmod.cinsiyet = false;
                }
                personnelmod.adres = textBox10.Text;
                personnelmod.personel_tipleri_id= Convert.ToInt32(comboBox2.SelectedValue);
                personnelmod.subeler_id= Convert.ToInt32(comboBox3.SelectedValue);
                personnelmod.email = textBox8.Text;
                personnelmod.kullanici_ad = textBox4.Text;
                personnelmod.sifre = logincont.convertToMd5(textBox7.Text);
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
                if (pathpersonnelmod.imagepath!=null)
                {
                    FileStream fs = new FileStream(pathpersonnelmod.imagepath, FileMode.Open, FileAccess.Read);
                    BinaryReader br = new BinaryReader(fs);
                    personnelmod.image = br.ReadBytes((int)fs.Length);
                    br.Close();
                    fs.Close();
                    if (ValidationController.validControl(personnelmod) == true)
                    {
                        var personnelcontrol = personnelcont.personnelcontrol(personnelmod);
                        if (personnelcontrol == false)
                        {
                            var result = personnelcont.insert(personnelmod);
                            if (result == true)
                            {
                                MessageBox.Show("Üye başarılı bir şekilde kayıt edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                activelist();
                                clear();
                            }
                            else
                            {
                                MessageBox.Show("Üye kayıt edilirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                activelist();
                                clear();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Üye zaten kayıtlı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    if (ValidationController.validControl(personnelmod) == true)
                    {
                        var personnelcontrol = personnelcont.personnelcontrol(personnelmod);
                        if (personnelcontrol == false)
                        {
                            var result = personnelcont.insertnullimage(personnelmod);
                            if (result == true)
                            {
                                MessageBox.Show("Üye başarılı bir şekilde kayıt edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                activelist();
                                clear();
                            }
                            else
                            {
                                MessageBox.Show("Üye kayıt edilirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                activelist();
                                clear();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Üye zaten kayıtlı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void PersonnelForm_Load(object sender, EventArgs e)
        {
            helpercont.comboFill("id", "ad", "SehirlerCombobox", comboBox1);
            helpercont.comboFill("id", "ad", "PersonelTipleriCombobox", comboBox2);
            if (label20.Text == "0")
            {
                helpercont.comboFill("id", "ad", "SubelerCombobox", comboBox3);
            }
            else
            {
                helpercont.comboFillFilter("id", "ad", Convert.ToInt32(label21.Text), "SubelerComboboxBolgeMudur", comboBox3);
            }
            
            clear();
            radioButton1.Checked = true;
            radioButton5.Checked = true;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            activelist();
            clear();
            if (radioButton5.Checked==true)
            {
                button1.Visible = true;
                button2.Visible = true;
                button4.Visible = true;
            }
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            passivelist();
            clear();
            button4.Visible = false;
            button2.Visible = false;
            button1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var personnelmod = new PersonnelModel();
            personnelmod.id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
            personnelmod.ayrılma_tarih = DateTime.Now;
            personnelmod.tc = dataGridView1.SelectedRows[0].Cells["tc"].Value.ToString();
            DialogResult yesorno = MessageBox.Show(personnelmod.tc + " tc numarasına sahip üye silinecek !", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (yesorno == DialogResult.Yes)
            {
                var result = personnelcont.delete(personnelmod);
                if (result == true)
                {
                    DialogResult ok=MessageBox.Show("Üye başarılı bir şekilde silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (ok==DialogResult.OK)
                    {
                        radioButton6.Checked = true;
                        passivelist();
                    }
                    else
                    {
                        radioButton5.Checked = true;
                        activelist();
                    }
                    clear();
                }
                else
                {
                    DialogResult ok = MessageBox.Show("Üye silinirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (ok == DialogResult.OK)
                    {
                        radioButton6.Checked = true;
                        passivelist();
                    }
                    else
                    {
                        radioButton5.Checked = true;
                        activelist();
                    }
                    clear();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PersonnelEditForm personneleditfrm = new PersonnelEditForm();
            helpercont.comboFill("id", "ad", "SehirlerCombobox", personneleditfrm.comboBox1);
            helpercont.comboFill("id", "ad", "PersonelTipleriCombobox", personneleditfrm.comboBox2);
            if (label20.Text == "0")
            {
                helpercont.comboFill("id", "ad", "SubelerCombobox", personneleditfrm.comboBox3);
            }
            else
            {
                helpercont.comboFillFilter("id", "ad", Convert.ToInt32(label21.Text), "SubelerComboboxBolgeMudur", personneleditfrm.comboBox3);
            }
            personneleditfrm.label3.Text = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
            personneleditfrm.textBox1.Text = dataGridView1.SelectedRows[0].Cells["tc"].Value.ToString();
            personneleditfrm.textBox3.Text = dataGridView1.SelectedRows[0].Cells["ad"].Value.ToString();
            personneleditfrm.textBox5.Text = dataGridView1.SelectedRows[0].Cells["soyad"].Value.ToString();
            personneleditfrm.dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells["dogum_tarih"].Value.ToString());
            personneleditfrm.textBox6.Text = dataGridView1.SelectedRows[0].Cells["telefon"].Value.ToString();
            if (dataGridView1.SelectedRows[0].Cells["cinsiyet"].Value.ToString() == "ERKEK")
            {
                    personneleditfrm.radioButton1.Checked = true;
            }
            else
            {
                    personneleditfrm.radioButton2.Checked = true;
            }
            personneleditfrm.textBox10.Text = dataGridView1.SelectedRows[0].Cells["adres"].Value.ToString();
            personneleditfrm.textBox8.Text = dataGridView1.SelectedRows[0].Cells["email"].Value.ToString();
            personneleditfrm.textBox4.Text = dataGridView1.SelectedRows[0].Cells["kullanici_ad"].Value.ToString();
            personneleditfrm.textBox9.Text = dataGridView1.SelectedRows[0].Cells["maas"].Value.ToString();
            if (label20.Text=="0")
            {
                if (dataGridView1.SelectedRows[0].Cells["yetki_durum"].Value.ToString() == "ADMİN")
                {
                    personneleditfrm.radioButton3.Checked = true;
                }
                else if (dataGridView1.SelectedRows[0].Cells["yetki_durum"].Value.ToString() == "MÜDÜR")
                {
                    personneleditfrm.radioButton4.Checked = true;
                }
                else if (dataGridView1.SelectedRows[0].Cells["yetki_durum"].Value.ToString() == "PERSONEL")
                {
                    personneleditfrm.radioButton7.Checked = true;
                }
            }
            else if (label20.Text=="1")
            {
                if (dataGridView1.SelectedRows[0].Cells["yetki_durum"].Value.ToString() == "MÜDÜR")
                {
                    personneleditfrm.radioButton4.Checked = true;
                }
                else if (dataGridView1.SelectedRows[0].Cells["yetki_durum"].Value.ToString() == "PERSONEL")
                {
                    personneleditfrm.radioButton7.Checked = true;
                }
                personneleditfrm.radioButton3.Visible = false;
            }
            personneleditfrm.comboBox1.SelectedValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["sehir_id"].Value.ToString());
            personneleditfrm.comboBox2.SelectedValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["personel_tipleri_id"].Value.ToString());
            personneleditfrm.comboBox3.SelectedValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["subeler_id"].Value.ToString());
            byte[] resim = new byte[0];
            if (dataGridView1.SelectedRows[0].Cells["resim"].Value != DBNull.Value)
            {
                resim = (byte[])dataGridView1.SelectedRows[0].Cells["resim"].Value;
                MemoryStream memoryStream = new MemoryStream(resim);
                personneleditfrm.pictureBox1.Image = Image.FromStream(memoryStream);
                personneleditfrm.ShowDialog();
            }
            else
            {
                personneleditfrm.ShowDialog();
            }
        }

        private void PersonnelForm_Activated(object sender, EventArgs e)
        {
            if (radioButton5.Checked)
            {
                activelist();
            }
            else if (radioButton6.Checked)
            {
                passivelist();
            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ayrac = ',';// buraya istediğiniz bir ayracı yazabilirsiniz.
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ayrac))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == ayrac) && ((sender as System.Windows.Forms.TextBox).Text.IndexOf(ayrac) > -1))//İlk karakterin '.' olup olmadığını kontrol ediyoruzuz
            {
                e.Handled = true;//Değilse görmezden geliyoruz.
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (radioButton5.Checked == true)
            {
                var personnelmod = new PersonnelModel();
                personnelmod.ad = textBox2.Text;
                DataTable result = null;
                if (label20.Text == "0")
                {
                    result = personnelcont.activepersonnelsearch(personnelmod);
                }
                else
                {
                    result = personnelcont.activepersonnelsearchreqional(personnelmod, Convert.ToInt32(label21.Text));
                }
                if (result != null)
                {
                    if (textBox2.Text == "")
                    {
                        activelist();
                        label4.Text = "Lütfen aranacak birşeyler yaz.";
                    }
                    else
                    {
                        dataGridView1.DataSource = result;
                        label4.Text = result.Rows.Count.ToString() + " kayıt bulundu.";
                    }
                }
                else
                {
                    if (textBox2.Text == "")
                    {
                        label4.Text = "Lütfen aranacak birşeyler yaz.";
                    }
                    else
                    {
                        label4.Text = personnelmod.ad + " ile kayıt bulunmuyor !";
                    }
                }
            }
            else if (radioButton6.Checked == true)
            {
                var personnelmod = new PersonnelModel();
                personnelmod.ad = textBox2.Text;
                DataTable result = null;
                if (label20.Text == "0")
                {
                    result = personnelcont.passivepersonnelsearch(personnelmod);
                }
                else
                {
                    result = personnelcont.passivepersonnelsearchregional(personnelmod, Convert.ToInt32(label21.Text));
                }
                if (result != null)
                {
                    if (textBox2.Text == "")
                    {
                        passivelist();
                        label4.Text = "Lütfen aranacak birşeyler yaz.";
                    }
                    else
                    {
                        dataGridView1.DataSource = result;
                        label4.Text = result.Rows.Count.ToString() + " kayıt bulundu.";
                    }
                }
                else
                {
                    if (textBox2.Text == "")
                    {
                        label4.Text = "Lütfen aranacak birşeyler yaz.";
                    }
                    else
                    {
                        label4.Text = personnelmod.ad + " ile kayıt bulunmuyor !";
                    }
                }
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.Clear();
            label4.Text = "";
        }

        private void dataGridView1_Leave(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.SelectedRows[0].Cells["resim"].Value != DBNull.Value)
            {
                byte[] resim = new byte[0];
                resim = (byte[])dataGridView1.SelectedRows[0].Cells["resim"].Value;
                MemoryStream memoryStream = new MemoryStream(resim);
                pictureBox1.Image = Image.FromStream(memoryStream);
            }
            else
            {
                pictureBox1.Image = null;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            VisitorsStatisticsForm visitorsstatisticsfrm = new VisitorsStatisticsForm();
            visitorsstatisticsfrm.ShowDialog();
        }
    }
}
