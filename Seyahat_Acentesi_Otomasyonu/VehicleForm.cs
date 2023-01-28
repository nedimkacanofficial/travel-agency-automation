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
    public partial class VehicleForm : Form
    {
        HelperController helpercont = new HelperController();
        VehicleController vehiclecont = new VehicleController();
        public VehicleForm()
        {
            InitializeComponent();
        }
        public void activelist()
        {
            if (vehiclecont.activecarlist() != null)
            {
                if (label14.Text=="0")
                {
                    dataGridView1.DataSource = vehiclecont.activecarlist();
                }
                else
                {
                    dataGridView1.DataSource = vehiclecont.activecarlistregional(Convert.ToInt32(label15.Text));
                }
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["markalar_id"].Visible = false;
                dataGridView1.Columns["arac_turleri_id"].Visible = false;
                dataGridView1.Columns["guzergahlar_id"].Visible = false;
                dataGridView1.Columns["subeler_id"].Visible = false;

                dataGridView1.Columns["sube"].DisplayIndex = 0;
                dataGridView1.Columns["plaka"].DisplayIndex = 1;
                dataGridView1.Columns["koltuk_sayisi"].DisplayIndex = 2;
                dataGridView1.Columns["marka"].DisplayIndex = 3;
                dataGridView1.Columns["model"].DisplayIndex = 4;
                dataGridView1.Columns["trafige_cikma_yili"].DisplayIndex = 5;
                dataGridView1.Columns["arac_turu"].DisplayIndex = 6;
                dataGridView1.Columns["aracin_calistigi_guzergah"].DisplayIndex = 7;
                dataGridView1.Columns["arac_durum"].DisplayIndex = 8;
                dataGridView1.Columns["satinalma_tarih"].DisplayIndex = 9;

                dataGridView1.Columns["sube"].HeaderText = "ARAÇ ŞUBE";
                dataGridView1.Columns["plaka"].HeaderText = "PLAKA";
                dataGridView1.Columns["koltuk_sayisi"].HeaderText = "KOLTUK SAYISI";
                dataGridView1.Columns["marka"].HeaderText = "MARKA";
                dataGridView1.Columns["model"].HeaderText = "MODEL";
                dataGridView1.Columns["trafige_cikma_yili"].HeaderText = "TRAFİĞE ÇIKMA YILI";
                dataGridView1.Columns["arac_turu"].HeaderText = "ARAÇ TÜRÜ";
                dataGridView1.Columns["aracin_calistigi_guzergah"].HeaderText = "ÇALIŞTIĞI GÜZERGAH";
                dataGridView1.Columns["arac_durum"].HeaderText = "DURUM";
                dataGridView1.Columns["satinalma_tarih"].HeaderText = "ALIŞ TARİH";
            }
            else
            {
                dataGridView1.DataSource = vehiclecont.activecarlist();
            }
        }
        public void passivelist()
        {
            if (vehiclecont.passivecarlist() != null)
            {
                if (label14.Text == "0")
                {
                    dataGridView1.DataSource = vehiclecont.passivecarlist();
                }
                else
                {
                    dataGridView1.DataSource = vehiclecont.passivecarlistregional(Convert.ToInt32(label15.Text));
                }
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["markalar_id"].Visible = false;
                dataGridView1.Columns["arac_turleri_id"].Visible = false;
                dataGridView1.Columns["guzergahlar_id"].Visible = false;
                dataGridView1.Columns["subeler_id"].Visible = false;

                dataGridView1.Columns["sube"].DisplayIndex = 0;
                dataGridView1.Columns["plaka"].DisplayIndex = 1;
                dataGridView1.Columns["koltuk_sayisi"].DisplayIndex = 2;
                dataGridView1.Columns["marka"].DisplayIndex = 3;
                dataGridView1.Columns["model"].DisplayIndex = 4;
                dataGridView1.Columns["trafige_cikma_yili"].DisplayIndex = 5;
                dataGridView1.Columns["arac_turu"].DisplayIndex = 6;
                dataGridView1.Columns["aracin_calistigi_guzergah"].DisplayIndex = 7;
                dataGridView1.Columns["arac_durum"].DisplayIndex = 8;
                dataGridView1.Columns["satinalma_tarih"].DisplayIndex = 9;

                dataGridView1.Columns["sube"].HeaderText = "ARAÇ ŞUBE";
                dataGridView1.Columns["plaka"].HeaderText = "PLAKA";
                dataGridView1.Columns["koltuk_sayisi"].HeaderText = "KOLTUK SAYISI";
                dataGridView1.Columns["marka"].HeaderText = "MARKA";
                dataGridView1.Columns["model"].HeaderText = "MODEL";
                dataGridView1.Columns["trafige_cikma_yili"].HeaderText = "TRAFİĞE ÇIKMA YILI";
                dataGridView1.Columns["arac_turu"].HeaderText = "ARAÇ TÜRÜ";
                dataGridView1.Columns["aracin_calistigi_guzergah"].HeaderText = "ÇALIŞTIĞI GÜZERGAH";
                dataGridView1.Columns["arac_durum"].HeaderText = "DURUM";
                dataGridView1.Columns["satinalma_tarih"].HeaderText = "ALIŞ TARİH";
            }
            else
            {
                dataGridView1.DataSource = vehiclecont.passivecarlist();
            }
        }
        public void clear()
        {
            textBox1.Clear();
            textBox3.Clear();
            comboBox1.SelectedValue = 0;
            textBox4.Clear();
            dateTimePicker1.ResetText();
            comboBox2.SelectedValue = 0;
            comboBox3.SelectedValue = 0;
            comboBox4.SelectedValue = 0;
            radioButton1.Checked = true;
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            activelist();
            clear();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            passivelist();
            clear();
        }

        private void VehicleForm_Load(object sender, EventArgs e)
        {
            helpercont.comboFill("id", "ad", "MarkalarCombobox", comboBox1);
            helpercont.comboFill("id", "ad", "AracTurleriCombobox", comboBox2);
            if (label14.Text == "0")
            {
                helpercont.comboFill("id", "guzergah", "GuzergahlarCombobox", comboBox3);
            }
            else
            {
                helpercont.comboFillFilter("id", "guzergah",Convert.ToInt32(label15.Text), "GuzergahlarComboboxRegional", comboBox3);
            }
            if (label14.Text == "0")
            {
                helpercont.comboFill("id", "ad", "SubelerCombobox", comboBox4);
            }
            else
            {
                helpercont.comboFillFilter("id", "ad", Convert.ToInt32(label15.Text), "SubelerComboboxBolgeMudur", comboBox4);
            }
            clear();
            radioButton1.Checked = true;
            radioButton3.Checked = true;
        }

        private void button3_Click(object sender, EventArgs e)
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
                vehiclemod.arac_turleri_id= Convert.ToInt32(comboBox2.SelectedValue);
                vehiclemod.guzergahlar_id= Convert.ToInt32(comboBox3.SelectedValue);
                vehiclemod.subeler_id = Convert.ToInt32(comboBox4.SelectedValue);
                if (radioButton1.Checked==true)
                {
                    vehiclemod.aktifmi = true;
                }
                else if (radioButton2.Checked==true)
                {
                    vehiclemod.aktifmi = false;
                }
                if (ValidationController.validControl(vehiclemod) == true)
                {
                    var carcontrol = vehiclecont.carControl(vehiclemod);
                    if (carcontrol==false)
                    {
                        var result = vehiclecont.insert(vehiclemod);
                        if (result == true)
                        {
                            MessageBox.Show("Araç başarılı bir şekilde kayıt edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (radioButton1.Checked == true)
                            {
                                activelist();
                                radioButton3.Checked = true;
                            }
                            else if (radioButton2.Checked == true)
                            {
                                passivelist();
                                radioButton4.Checked = true;
                            }
                            clear();
                        }
                        else
                        {
                            MessageBox.Show("Araç kayıt edilirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            if (radioButton1.Checked == true)
                            {
                                activelist();
                                radioButton3.Checked = true;
                            }
                            else if (radioButton2.Checked == true)
                            {
                                passivelist();
                                radioButton4.Checked = true;
                            }
                            clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Araç zaten kayıtlı lütfen başka bir plaka ile tekrar deneyin !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var vehiclemod = new VehicleModel();
            vehiclemod.id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
            vehiclemod.plaka = dataGridView1.SelectedRows[0].Cells["plaka"].Value.ToString();
            DialogResult yesorno = MessageBox.Show(vehiclemod.plaka + " plakalı araç silinecek !", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (yesorno == DialogResult.Yes)
            {
                var result = vehiclecont.delete(vehiclemod);
                if (result == true)
                {
                    MessageBox.Show("Araç başarılı bir şekilde silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (radioButton3.Checked == true)
                    {
                        activelist();
                    }
                    else if (radioButton4.Checked == true)
                    {
                        passivelist();
                    }
                    clear();
                }
                else
                {
                    MessageBox.Show("Araç silinirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    if (radioButton3.Checked == true)
                    {
                        activelist();
                    }
                    else if (radioButton4.Checked == true)
                    {
                        passivelist();
                    }
                    clear();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VehicleEditForm vehicleeditfrm = new VehicleEditForm();
            helpercont.comboFill("id", "ad", "MarkalarCombobox", vehicleeditfrm.comboBox1);
            helpercont.comboFill("id", "ad", "AracTurleriCombobox", vehicleeditfrm.comboBox2);
            if (label14.Text == "0")
            {
                helpercont.comboFill("id", "guzergah", "GuzergahlarCombobox", vehicleeditfrm.comboBox3);
            }
            else
            {
                helpercont.comboFillFilter("id", "guzergah", Convert.ToInt32(label15.Text), "GuzergahlarComboboxRegional", vehicleeditfrm.comboBox3);
            }
            if (label14.Text == "0")
            {
                helpercont.comboFill("id", "ad", "SubelerCombobox", vehicleeditfrm.comboBox4);
            }
            else
            {
                helpercont.comboFillFilter("id", "ad", Convert.ToInt32(label15.Text), "SubelerComboboxBolgeMudur", vehicleeditfrm.comboBox4);
            }
            vehicleeditfrm.label3.Text = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
            vehicleeditfrm.textBox1.Text = dataGridView1.SelectedRows[0].Cells["plaka"].Value.ToString();
            vehicleeditfrm.textBox3.Text = dataGridView1.SelectedRows[0].Cells["koltuk_sayisi"].Value.ToString();
            vehicleeditfrm.textBox4.Text = dataGridView1.SelectedRows[0].Cells["model"].Value.ToString();
            vehicleeditfrm.dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells["trafige_cikma_yili"].Value.ToString());
            if (dataGridView1.SelectedRows[0].Cells["arac_durum"].Value.ToString()=="AKTİF")
            {
                vehicleeditfrm.radioButton1.Checked = true;
            }
            else
            {
                vehicleeditfrm.radioButton2.Checked = true;
            }
            vehicleeditfrm.comboBox1.SelectedValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["markalar_id"].Value.ToString());
            vehicleeditfrm.comboBox2.SelectedValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["arac_turleri_id"].Value.ToString());
            vehicleeditfrm.comboBox3.SelectedValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["guzergahlar_id"].Value.ToString());
            vehicleeditfrm.comboBox4.SelectedValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["subeler_id"].Value.ToString());
            vehicleeditfrm.ShowDialog();
        }

        private void VehicleForm_Activated(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                activelist();
            }
            else if (radioButton4.Checked)
            {
                passivelist();
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
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
            if (radioButton3.Checked==true)
            {
                var vehiclemod = new VehicleModel();
                vehiclemod.plaka = textBox2.Text;
                DataTable result = null;
                if (label14.Text == "0")
                {
                    result = vehiclecont.activecarsearch(vehiclemod);
                }
                else
                {
                    result = vehiclecont.activecarsearchregional(vehiclemod,Convert.ToInt32(label15.Text));
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
                        label4.Text = vehiclemod.plaka + " ile kayıt bulunmuyor !";
                    }
                }
            }
            else if (radioButton4.Checked==true)
            {
                var vehiclemod = new VehicleModel();
                vehiclemod.plaka = textBox2.Text;
                DataTable result = null;
                if (label14.Text == "0")
                {
                    result = vehiclecont.passivecarsearch(vehiclemod);
                }
                else
                {
                    result = vehiclecont.passivecarsearchregional(vehiclemod, Convert.ToInt32(label15.Text));
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
                        label4.Text = vehiclemod.plaka + " ile kayıt bulunmuyor !";
                    }
                }
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.Clear();
            label4.Text = "";
        }
    }
}
