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
    public partial class VoyageForm : Form
    {
        VoyageController voyagecont = new VoyageController();
        HelperController helpercont = new HelperController();
        public VoyageForm()
        {
            InitializeComponent();
        }
        public void listele()
        {
            if (label15.Text=="0")
            {
                if (voyagecont.list() != null)
                {
                    dataGridView1.DataSource = voyagecont.list();
                    dataGridView1.Columns["id"].Visible = false;
                    dataGridView1.Columns["personeller_id"].Visible = false;
                    dataGridView1.Columns["sofor_id"].Visible = false;
                    dataGridView1.Columns["muavin_id"].Visible = false;
                    dataGridView1.Columns["guzergahlar_id"].Visible = false;
                    dataGridView1.Columns["araclar_id"].Visible = false;

                    dataGridView1.Columns["sefer_kodu"].DisplayIndex = 0;
                    dataGridView1.Columns["kalkis_durak"].DisplayIndex = 1;
                    dataGridView1.Columns["varis_durak"].DisplayIndex = 2;
                    dataGridView1.Columns["kalkis_peron"].DisplayIndex = 3;
                    dataGridView1.Columns["sofor"].DisplayIndex = 4;
                    dataGridView1.Columns["muavin"].DisplayIndex = 5;
                    dataGridView1.Columns["kalkis_tarih"].DisplayIndex = 6;
                    dataGridView1.Columns["varis_tarih"].DisplayIndex = 7;
                    dataGridView1.Columns["tahmini_varis_suresi"].DisplayIndex = 8;
                    dataGridView1.Columns["arac_ici_ikram"].DisplayIndex = 9;
                    dataGridView1.Columns["wifi"].DisplayIndex = 10;
                    dataGridView1.Columns["plaka"].DisplayIndex = 11;
                    dataGridView1.Columns["olusturma_tarih"].DisplayIndex = 12;

                    dataGridView1.Columns["sefer_kodu"].HeaderText = "SEFER KODU";
                    dataGridView1.Columns["kalkis_durak"].HeaderText = "KALKIŞ DURAK";
                    dataGridView1.Columns["varis_durak"].HeaderText = "VARIŞ DURAK";
                    dataGridView1.Columns["kalkis_peron"].HeaderText = "KALKIŞ PERON";
                    dataGridView1.Columns["sofor"].HeaderText = "ŞOFÖR";
                    dataGridView1.Columns["muavin"].HeaderText = "MUAVİN";
                    dataGridView1.Columns["kalkis_tarih"].HeaderText = "KALKIŞ TARİH";
                    dataGridView1.Columns["varis_tarih"].HeaderText = "VARIŞ TARİH";
                    dataGridView1.Columns["tahmini_varis_suresi"].HeaderText = "TAHMİNİ VARIŞ";
                    dataGridView1.Columns["arac_ici_ikram"].HeaderText = "ARAÇ İÇİ İKRAM";
                    dataGridView1.Columns["wifi"].HeaderText = "WİFİ";
                    dataGridView1.Columns["plaka"].HeaderText = "ARAÇ PLAKA";
                    dataGridView1.Columns["olusturma_tarih"].HeaderText = "KAYIT TARİH";
                }
                else
                {
                    dataGridView1.DataSource = null;
                }
            }
            else
            {
                if (voyagecont.listregional(Convert.ToInt32(label16.Text)) != null)
                {
                    dataGridView1.DataSource= voyagecont.listregional(Convert.ToInt32(label16.Text));
                    dataGridView1.Columns["id"].Visible = false;
                    dataGridView1.Columns["personeller_id"].Visible = false;
                    dataGridView1.Columns["sofor_id"].Visible = false;
                    dataGridView1.Columns["muavin_id"].Visible = false;
                    dataGridView1.Columns["guzergahlar_id"].Visible = false;
                    dataGridView1.Columns["araclar_id"].Visible = false;

                    dataGridView1.Columns["sefer_kodu"].DisplayIndex = 0;
                    dataGridView1.Columns["kalkis_durak"].DisplayIndex = 1;
                    dataGridView1.Columns["varis_durak"].DisplayIndex = 2;
                    dataGridView1.Columns["kalkis_peron"].DisplayIndex = 3;
                    dataGridView1.Columns["sofor"].DisplayIndex = 4;
                    dataGridView1.Columns["muavin"].DisplayIndex = 5;
                    dataGridView1.Columns["kalkis_tarih"].DisplayIndex = 6;
                    dataGridView1.Columns["varis_tarih"].DisplayIndex = 7;
                    dataGridView1.Columns["tahmini_varis_suresi"].DisplayIndex = 8;
                    dataGridView1.Columns["arac_ici_ikram"].DisplayIndex = 9;
                    dataGridView1.Columns["wifi"].DisplayIndex = 10;
                    dataGridView1.Columns["plaka"].DisplayIndex = 11;
                    dataGridView1.Columns["olusturma_tarih"].DisplayIndex = 12;

                    dataGridView1.Columns["sefer_kodu"].HeaderText = "SEFER KODU";
                    dataGridView1.Columns["kalkis_durak"].HeaderText = "KALKIŞ DURAK";
                    dataGridView1.Columns["varis_durak"].HeaderText = "VARIŞ DURAK";
                    dataGridView1.Columns["kalkis_peron"].HeaderText = "KALKIŞ PERON";
                    dataGridView1.Columns["sofor"].HeaderText = "ŞOFÖR";
                    dataGridView1.Columns["muavin"].HeaderText = "MUAVİN";
                    dataGridView1.Columns["kalkis_tarih"].HeaderText = "KALKIŞ TARİH";
                    dataGridView1.Columns["varis_tarih"].HeaderText = "VARIŞ TARİH";
                    dataGridView1.Columns["tahmini_varis_suresi"].HeaderText = "TAHMİNİ VARIŞ";
                    dataGridView1.Columns["arac_ici_ikram"].HeaderText = "ARAÇ İÇİ İKRAM";
                    dataGridView1.Columns["wifi"].HeaderText = "WİFİ";
                    dataGridView1.Columns["plaka"].HeaderText = "ARAÇ PLAKA";
                    dataGridView1.Columns["olusturma_tarih"].HeaderText = "KAYIT TARİH";
                }
                else
                {
                    dataGridView1.DataSource = null;
                }
            }
        }
        public void clear()
        {
            textBox1.Clear();
            textBox3.Clear();
            comboBox1.SelectedValue = 0;
            comboBox2.SelectedValue = 0;
            comboBox3.SelectedValue = 0;
            comboBox4.SelectedValue = 0;
            radioButton1.Checked = true;
            radioButton3.Checked = true;
            dateTimePicker1.ResetText();
            dateTimePicker2.ResetText();
        }
        private void VoyageForm_Load(object sender, EventArgs e)
        {
            listele();
            if (label15.Text=="0")
            {
                helpercont.comboFill("id", "guzergah", "GuzergahlarCombobox", comboBox2);
            }
            else
            {
                helpercont.comboFillFilter("id", "guzergah",Convert.ToInt32(label16.Text), "GuzergahlarComboboxRegional", comboBox2);
            }
            if (label15.Text=="0")
            {
                helpercont.comboFill("id", "plaka", "MasrafAracCombobox", comboBox4);
            }
            else
            {
                helpercont.comboFillFilter("id", "plaka",Convert.ToInt32(label16.Text), "MasrafAracComboboxRegional", comboBox4);
            }
            if (label15.Text=="0")
            {
                helpercont.comboFill("id", "adsoyad", "SoforCombobox", comboBox3);
            }
            else
            {
                helpercont.comboFillFilter("id", "adsoyad",Convert.ToInt32(label16.Text), "SoforComboboxRegional", comboBox3);
            }
            if (label15.Text=="0")
            {
                helpercont.comboFill("id", "adsoyad", "MuavinCombobox", comboBox1);
            }
            else
            {
                helpercont.comboFillFilter("id", "adsoyad",Convert.ToInt32(label16.Text), "MuavinComboboxRegional", comboBox1);
            }
            clear();
        }

        private void button3_Click(object sender, EventArgs e)
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
                voyagemod.personeller_id = Convert.ToInt32(label7.Text);
                voyagemod.kod = textBox1.Text;
                voyagemod.kalkis_peron = textBox3.Text;
                voyagemod.guzergahlar_id = Convert.ToInt32(comboBox2.SelectedValue);
                voyagemod.sofor_id = Convert.ToInt32(comboBox3.SelectedValue);
                voyagemod.muavin_id = Convert.ToInt32(comboBox1.SelectedValue);
                voyagemod.araclar_id = Convert.ToInt32(comboBox4.SelectedValue);
                if (radioButton1.Checked==true)
                {
                    voyagemod.arac_ici_ikram = true;
                }
                else if (radioButton2.Checked==true)
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
                    var routecontrol = voyagecont.registerControl(voyagemod);
                    if (routecontrol == false)
                    {
                        var result = voyagecont.insert(voyagemod);
                        if (result == true)
                        {
                            MessageBox.Show("Sefer başarılı bir şekilde kayıt edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            listele();
                            clear();
                        }
                        else
                        {
                            MessageBox.Show("Sefer kayıt edilirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            listele();
                            clear();
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var voyagemod = new VoyageModel();
            voyagemod.id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
            voyagemod.kod = dataGridView1.SelectedRows[0].Cells["sefer_kodu"].Value.ToString();
            DialogResult yesorno = MessageBox.Show(voyagemod.kod + " seferi silinecek !", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (yesorno == DialogResult.Yes)
            {
                var result = voyagecont.delete(voyagemod);
                if (result == true)
                {
                    MessageBox.Show("Sefer başarılı bir şekilde silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele();
                    clear();
                }
                else
                {
                    MessageBox.Show("Sefer silinirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    listele();
                    clear();
                }
            }
        }

        private void VoyageForm_Activated(object sender, EventArgs e)
        {
            listele();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var voyagemod = new VoyageModel();
            voyagemod.kod = textBox2.Text;
            DataTable result = null;
            if (label15.Text=="0")
            {
                result = voyagecont.search(voyagemod);
            }
            else
            {
                result = voyagecont.searchregional(voyagemod,Convert.ToInt32(label16.Text));
            }
            if (result != null)
            {
                if (textBox2.Text == "")
                {
                    listele();
                    label4.Text = "Lütfen aranacak birşeyler yaz.";
                }
                else
                {
                    dataGridView1.DataSource = result;
                    dataGridView1.Columns["id"].Visible = false;
                    dataGridView1.Columns["personeller_id"].Visible = false;
                    dataGridView1.Columns["sofor_id"].Visible = false;
                    dataGridView1.Columns["muavin_id"].Visible = false;
                    dataGridView1.Columns["guzergahlar_id"].Visible = false;
                    dataGridView1.Columns["araclar_id"].Visible = false;

                    dataGridView1.Columns["sefer_kodu"].DisplayIndex = 0;
                    dataGridView1.Columns["kalkis_durak"].DisplayIndex = 1;
                    dataGridView1.Columns["varis_durak"].DisplayIndex = 2;
                    dataGridView1.Columns["kalkis_peron"].DisplayIndex = 3;
                    dataGridView1.Columns["sofor"].DisplayIndex = 4;
                    dataGridView1.Columns["muavin"].DisplayIndex = 5;
                    dataGridView1.Columns["kalkis_tarih"].DisplayIndex = 6;
                    dataGridView1.Columns["varis_tarih"].DisplayIndex = 7;
                    dataGridView1.Columns["tahmini_varis_suresi"].DisplayIndex = 8;
                    dataGridView1.Columns["arac_ici_ikram"].DisplayIndex = 9;
                    dataGridView1.Columns["wifi"].DisplayIndex = 10;
                    dataGridView1.Columns["plaka"].DisplayIndex = 11;
                    dataGridView1.Columns["olusturma_tarih"].DisplayIndex = 12;

                    dataGridView1.Columns["sefer_kodu"].HeaderText = "SEFER KODU";
                    dataGridView1.Columns["kalkis_durak"].HeaderText = "KALKIŞ DURAK";
                    dataGridView1.Columns["varis_durak"].HeaderText = "VARIŞ DURAK";
                    dataGridView1.Columns["kalkis_peron"].HeaderText = "KALKIŞ PERON";
                    dataGridView1.Columns["sofor"].HeaderText = "ŞOFÖR";
                    dataGridView1.Columns["muavin"].HeaderText = "MUAVİN";
                    dataGridView1.Columns["kalkis_tarih"].HeaderText = "KALKIŞ TARİH";
                    dataGridView1.Columns["varis_tarih"].HeaderText = "VARIŞ TARİH";
                    dataGridView1.Columns["tahmini_varis_suresi"].HeaderText = "TAHMİNİ VARIŞ";
                    dataGridView1.Columns["arac_ici_ikram"].HeaderText = "ARAÇ İÇİ İKRAM";
                    dataGridView1.Columns["wifi"].HeaderText = "WİFİ";
                    dataGridView1.Columns["plaka"].HeaderText = "ARAÇ PLAKA";
                    dataGridView1.Columns["olusturma_tarih"].HeaderText = "KAYIT TARİH";
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
                    label4.Text = voyagemod.kod + " ile kayıt bulunmuyor !";
                }
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.Clear();
            label4.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VoyageEditForm voyageeditfrm = new VoyageEditForm();
            if (label15.Text == "0")
            {
                helpercont.comboFill("id", "guzergah", "GuzergahlarCombobox", voyageeditfrm.comboBox2);
            }
            else
            {
                helpercont.comboFillFilter("id", "guzergah", Convert.ToInt32(label16.Text), "GuzergahlarComboboxRegional", voyageeditfrm.comboBox2);
            }
            if (label15.Text == "0")
            {
                helpercont.comboFill("id", "plaka", "MasrafAracCombobox", voyageeditfrm.comboBox4);
            }
            else
            {
                helpercont.comboFillFilter("id", "plaka", Convert.ToInt32(label16.Text), "MasrafAracComboboxRegional", voyageeditfrm.comboBox4);
            }
            if (label15.Text == "0")
            {
                helpercont.comboFill("id", "adsoyad", "SoforCombobox", voyageeditfrm.comboBox3);
            }
            else
            {
                helpercont.comboFillFilter("id", "adsoyad", Convert.ToInt32(label16.Text), "SoforComboboxRegional", voyageeditfrm.comboBox3);
            }
            if (label15.Text == "0")
            {
                helpercont.comboFill("id", "adsoyad", "MuavinCombobox", voyageeditfrm.comboBox1);
            }
            else
            {
                helpercont.comboFillFilter("id", "adsoyad", Convert.ToInt32(label16.Text), "MuavinComboboxRegional", voyageeditfrm.comboBox1);
            }
            voyageeditfrm.label3.Text = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
            voyageeditfrm.label4.Text = label7.Text;
            voyageeditfrm.textBox1.Text = dataGridView1.SelectedRows[0].Cells["sefer_kodu"].Value.ToString();
            voyageeditfrm.textBox3.Text = dataGridView1.SelectedRows[0].Cells["kalkis_peron"].Value.ToString();
            voyageeditfrm.dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells["kalkis_tarih"].Value.ToString());
            voyageeditfrm.dateTimePicker2.Value = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells["varis_tarih"].Value.ToString());
            if (dataGridView1.SelectedRows[0].Cells["arac_ici_ikram"].Value.ToString()=="MEVCUT")
            {
                voyageeditfrm.radioButton1.Checked = true;
            }
            else
            {
                voyageeditfrm.radioButton2.Checked = true;
            }
            if (dataGridView1.SelectedRows[0].Cells["wifi"].Value.ToString() == "MEVCUT")
            {
                voyageeditfrm.radioButton3.Checked = true;
            }
            else
            {
                voyageeditfrm.radioButton4.Checked = true;
            }
            voyageeditfrm.comboBox2.SelectedValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["guzergahlar_id"].Value.ToString());
            voyageeditfrm.comboBox3.SelectedValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["sofor_id"].Value.ToString());
            voyageeditfrm.comboBox1.SelectedValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["muavin_id"].Value.ToString());
            voyageeditfrm.comboBox4.SelectedValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["araclar_id"].Value.ToString());
            voyageeditfrm.ShowDialog();
        }
    }
}
