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
    public partial class ExpenseForm : Form
    {
        HelperController helpercont = new HelperController();
        ExpenseController expensecont = new ExpenseController();
        public ExpenseForm()
        {
            InitializeComponent();
        }
        void carExpenseListesi()
        {
            if (label12.Text == "0")
            {
                if (expensecont.carExpenseList() != null)
                {
                    dataGridView1.DataSource = expensecont.carExpenseList();
                    dataGridView1.Columns["id"].Visible = false;
                    dataGridView1.Columns["arac_sube"].Visible = false;
                    dataGridView1.Columns["personeller_id"].Visible = false;
                    dataGridView1.Columns["araclar_id"].Visible = false;
                    dataGridView1.Columns["seferler_id"].Visible = false;
                    dataGridView1.Columns["masraf_tipleri_id"].Visible = false;
                    dataGridView1.Columns["masrafi_yapan_personel"].DisplayIndex = 0;
                    dataGridView1.Columns["unvan"].DisplayIndex = 1;
                    dataGridView1.Columns["masraf_yapilan_arac"].DisplayIndex = 2;
                    dataGridView1.Columns["masraf_yapilan_sefer_kodu"].DisplayIndex = 3;
                    dataGridView1.Columns["masraf_tipi"].DisplayIndex = 4;
                    dataGridView1.Columns["aciklama"].DisplayIndex = 5;
                    dataGridView1.Columns["tutar"].DisplayIndex = 6;
                    dataGridView1.Columns["tarih"].DisplayIndex = 7;
                    dataGridView1.Columns["masrafi_yapan_personel"].HeaderText = "PERSONEL";
                    dataGridView1.Columns["unvan"].HeaderText = "UNVAN";
                    dataGridView1.Columns["masraf_yapilan_arac"].HeaderText = "ARAÇ PLAKA";
                    dataGridView1.Columns["masraf_yapilan_sefer_kodu"].HeaderText = "SEFER KODU";
                    dataGridView1.Columns["masraf_tipi"].HeaderText = "MASRAF TÜRÜ";
                    dataGridView1.Columns["aciklama"].HeaderText = "AÇIKLAMA";
                    dataGridView1.Columns["tutar"].HeaderText = "TUTAR";
                    dataGridView1.Columns["tarih"].HeaderText = "TARİH";
                }
                else
                {
                    dataGridView1.DataSource = null;
                }
            }
            else if (label12.Text == "1")
            {
                if (expensecont.carExpenseListregional(Convert.ToInt32(label13.Text)) != null)
                {
                    dataGridView1.DataSource = expensecont.carExpenseListregional(Convert.ToInt32(label13.Text));
                    dataGridView1.Columns["id"].Visible = false;
                    dataGridView1.Columns["arac_sube"].Visible = false;
                    dataGridView1.Columns["personeller_id"].Visible = false;
                    dataGridView1.Columns["araclar_id"].Visible = false;
                    dataGridView1.Columns["seferler_id"].Visible = false;
                    dataGridView1.Columns["masraf_tipleri_id"].Visible = false;
                    dataGridView1.Columns["masrafi_yapan_personel"].DisplayIndex = 0;
                    dataGridView1.Columns["unvan"].DisplayIndex = 1;
                    dataGridView1.Columns["masraf_yapilan_arac"].DisplayIndex = 2;
                    dataGridView1.Columns["masraf_yapilan_sefer_kodu"].DisplayIndex = 3;
                    dataGridView1.Columns["masraf_tipi"].DisplayIndex = 4;
                    dataGridView1.Columns["aciklama"].DisplayIndex = 5;
                    dataGridView1.Columns["tutar"].DisplayIndex = 6;
                    dataGridView1.Columns["tarih"].DisplayIndex = 7;
                    dataGridView1.Columns["masrafi_yapan_personel"].HeaderText = "PERSONEL";
                    dataGridView1.Columns["unvan"].HeaderText = "UNVAN";
                    dataGridView1.Columns["masraf_yapilan_arac"].HeaderText = "ARAÇ PLAKA";
                    dataGridView1.Columns["masraf_yapilan_sefer_kodu"].HeaderText = "SEFER KODU";
                    dataGridView1.Columns["masraf_tipi"].HeaderText = "MASRAF TÜRÜ";
                    dataGridView1.Columns["aciklama"].HeaderText = "AÇIKLAMA";
                    dataGridView1.Columns["tutar"].HeaderText = "TUTAR";
                    dataGridView1.Columns["tarih"].HeaderText = "TARİH";
                }
                else
                {
                    dataGridView1.DataSource = null;
                }
            }
            else
            {
                if (expensecont.carExpenseListpersonnel(Convert.ToInt32(label11.Text)) != null)
                {
                    dataGridView1.DataSource = expensecont.carExpenseListpersonnel(Convert.ToInt32(label11.Text));
                    dataGridView1.Columns["id"].Visible = false;
                    dataGridView1.Columns["arac_sube"].Visible = false;
                    dataGridView1.Columns["personeller_id"].Visible = false;
                    dataGridView1.Columns["araclar_id"].Visible = false;
                    dataGridView1.Columns["seferler_id"].Visible = false;
                    dataGridView1.Columns["masraf_tipleri_id"].Visible = false;
                    dataGridView1.Columns["masrafi_yapan_personel"].DisplayIndex = 0;
                    dataGridView1.Columns["unvan"].DisplayIndex = 1;
                    dataGridView1.Columns["masraf_yapilan_arac"].DisplayIndex = 2;
                    dataGridView1.Columns["masraf_yapilan_sefer_kodu"].DisplayIndex = 3;
                    dataGridView1.Columns["masraf_tipi"].DisplayIndex = 4;
                    dataGridView1.Columns["aciklama"].DisplayIndex = 5;
                    dataGridView1.Columns["tutar"].DisplayIndex = 6;
                    dataGridView1.Columns["tarih"].DisplayIndex = 7;
                    dataGridView1.Columns["masrafi_yapan_personel"].HeaderText = "PERSONEL";
                    dataGridView1.Columns["unvan"].HeaderText = "UNVAN";
                    dataGridView1.Columns["masraf_yapilan_arac"].HeaderText = "ARAÇ PLAKA";
                    dataGridView1.Columns["masraf_yapilan_sefer_kodu"].HeaderText = "SEFER KODU";
                    dataGridView1.Columns["masraf_tipi"].HeaderText = "MASRAF TÜRÜ";
                    dataGridView1.Columns["aciklama"].HeaderText = "AÇIKLAMA";
                    dataGridView1.Columns["tutar"].HeaderText = "TUTAR";
                    dataGridView1.Columns["tarih"].HeaderText = "TARİH";
                }
                else
                {
                    dataGridView1.DataSource = null;
                }
            }
        }
        void departmentExpenseListesi()
        {
            if (label12.Text=="0")
            {
                if (expensecont.departmentExpenseList() != null)
                {
                    dataGridView1.DataSource = expensecont.departmentExpenseList();
                    dataGridView1.Columns["id"].Visible = false;
                    dataGridView1.Columns["arac_sube"].Visible = false;
                    dataGridView1.Columns["personeller_id"].Visible = false;
                    dataGridView1.Columns["masraf_tipleri_id"].Visible = false;
                    dataGridView1.Columns["subeler_id"].Visible = false;
                    dataGridView1.Columns["masrafi_yapan_personel"].HeaderText = "PERSONEL";
                    dataGridView1.Columns["unvan"].HeaderText = "UNVAN";
                    dataGridView1.Columns["sube"].HeaderText = "ŞUBE";
                    dataGridView1.Columns["masraf_tipi"].HeaderText = "MASRAF TÜRÜ";
                    dataGridView1.Columns["aciklama"].HeaderText = "AÇIKLAMA";
                    dataGridView1.Columns["tutar"].HeaderText = "TUTAR";
                    dataGridView1.Columns["tarih"].HeaderText = "TARİH";
                }
                else
                {
                    dataGridView1.DataSource = null;
                }
            }
            else if (label12.Text=="1")
            {
                if (expensecont.departmentExpenseListregional(Convert.ToInt32(label13.Text)) != null)
                {
                    dataGridView1.DataSource = expensecont.departmentExpenseListregional(Convert.ToInt32(label13.Text));
                    dataGridView1.Columns["id"].Visible = false;
                    dataGridView1.Columns["arac_sube"].Visible = false;
                    dataGridView1.Columns["personeller_id"].Visible = false;
                    dataGridView1.Columns["masraf_tipleri_id"].Visible = false;
                    dataGridView1.Columns["subeler_id"].Visible = false;
                    dataGridView1.Columns["masrafi_yapan_personel"].HeaderText = "PERSONEL";
                    dataGridView1.Columns["unvan"].HeaderText = "UNVAN";
                    dataGridView1.Columns["sube"].HeaderText = "ŞUBE";
                    dataGridView1.Columns["masraf_tipi"].HeaderText = "MASRAF TÜRÜ";
                    dataGridView1.Columns["aciklama"].HeaderText = "AÇIKLAMA";
                    dataGridView1.Columns["tutar"].HeaderText = "TUTAR";
                    dataGridView1.Columns["tarih"].HeaderText = "TARİH";
                }
                else
                {
                    dataGridView1.DataSource = null;
                }
            }
            else
            {
                if (expensecont.departmentExpenseListpersonnel(Convert.ToInt32(label11.Text)) != null)
                {
                    dataGridView1.DataSource = expensecont.departmentExpenseListpersonnel(Convert.ToInt32(label11.Text));
                    dataGridView1.Columns["id"].Visible = false;
                    dataGridView1.Columns["arac_sube"].Visible = false;
                    dataGridView1.Columns["personeller_id"].Visible = false;
                    dataGridView1.Columns["masraf_tipleri_id"].Visible = false;
                    dataGridView1.Columns["subeler_id"].Visible = false;
                    dataGridView1.Columns["masrafi_yapan_personel"].HeaderText = "PERSONEL";
                    dataGridView1.Columns["unvan"].HeaderText = "UNVAN";
                    dataGridView1.Columns["sube"].HeaderText = "ŞUBE";
                    dataGridView1.Columns["masraf_tipi"].HeaderText = "MASRAF TÜRÜ";
                    dataGridView1.Columns["aciklama"].HeaderText = "AÇIKLAMA";
                    dataGridView1.Columns["tutar"].HeaderText = "TUTAR";
                    dataGridView1.Columns["tarih"].HeaderText = "TARİH";
                }
                else
                {
                    dataGridView1.DataSource = null;
                }
            }
        }
        void clear()
        {
            comboBox1.SelectedValue = 0;
            comboBox2.SelectedValue = 0;
            comboBox3.SelectedValue = 0;
            comboBox4.SelectedValue = 0;
            textBox1.Clear();
            textBox3.Clear();
        }
        private void ExpenseForm_Load(object sender, EventArgs e)
        {
            if ((radioButton1.Checked)||(radioButton3.Checked))
            {
                carExpenseListesi();
            }
            else if ((radioButton2.Checked)||(radioButton4.Checked))
            {
                departmentExpenseListesi();
            }
            if (label12.Text=="0")
            {
                helpercont.comboFill("id", "ad_soyad", "MasrafPersonelCombobox", comboBox1);
            }
            else if (label12.Text=="1")
            {
                helpercont.comboFillFilter("id", "ad_soyad",Convert.ToInt32(label13.Text), "MasrafPersonelComboboxRegional", comboBox1);
            }
            else
            {
                helpercont.comboFillFilter("id", "ad_soyad",Convert.ToInt32(label11.Text), "MasrafPersonelComboboxPersonel", comboBox1);
            }
            helpercont.comboFill("id", "ad", "MasrafTuruCombobox", comboBox4);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label5.Visible = true;
            comboBox2.Visible = true;
            label6.Visible = true;
            comboBox3.Visible = true;
            label5.Text = "ARAÇ";
            if (label12.Text == "0")
            {
                helpercont.comboFill("id", "plaka", "MasrafAracCombobox", comboBox2);
            }
            else
            {
                helpercont.comboFillFilter("id", "plaka", Convert.ToInt32(label13.Text), "MasrafAracComboboxRegional", comboBox2);
            }
            if (label12.Text == "0")
            {
                helpercont.comboFill("id", "kod", "MasrafSeferCombobox", comboBox3);
            }
            else
            {
                helpercont.comboFillFilter("id", "kod", Convert.ToInt32(label13.Text), "MasrafSeferComboboxRegional", comboBox3);
            }
            if (radioButton1.Checked)
            {
                radioButton3.Checked = true;
                radioButton2.Checked = false;
                radioButton4.Checked = false;
                carExpenseListesi();
            }
            clear();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label6.Visible = false;
            comboBox3.Visible = false;
            label5.Text = "ŞUBE";
            if (label12.Text == "0")
            {
                helpercont.comboFill("id", "ad", "MasrafSubeCombobox", comboBox2);
            }
            else
            {
                helpercont.comboFillFilter("id", "ad", Convert.ToInt32(label13.Text), "MasrafSubeComboboxRegional", comboBox2);
            }
            if (radioButton2.Checked)
            {
                radioButton4.Checked = true;
                radioButton1.Checked = false;
                radioButton3.Checked = false;
                departmentExpenseListesi();
            }
            clear();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            label5.Visible = true;
            comboBox2.Visible = true;
            label6.Visible = true;
            comboBox3.Visible = true;
            label5.Text = "ARAÇ";
            if (label12.Text == "0")
            {
                helpercont.comboFill("id", "plaka", "MasrafAracCombobox", comboBox2);
            }
            else
            {
                helpercont.comboFillFilter("id", "plaka", Convert.ToInt32(label13.Text), "MasrafAracComboboxRegional", comboBox2);
            }
            if (label12.Text == "0")
            {
                helpercont.comboFill("id", "kod", "MasrafSeferCombobox", comboBox3);
            }
            else
            {
                helpercont.comboFillFilter("id", "kod", Convert.ToInt32(label13.Text), "MasrafSeferComboboxRegional", comboBox3);
            }
            if (radioButton3.Checked)
            {
                radioButton1.Checked = true;
                radioButton2.Checked = false;
                radioButton4.Checked = false;
                carExpenseListesi();
            }
            clear();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            label6.Visible = false;
            comboBox3.Visible = false;
            label5.Text = "ŞUBE";
            if (label12.Text == "0")
            {
                helpercont.comboFill("id", "ad", "MasrafSubeCombobox", comboBox2);
            }
            else
            {
                helpercont.comboFillFilter("id", "ad", Convert.ToInt32(label13.Text), "MasrafSubeComboboxRegional", comboBox2);
            }
            if (radioButton4.Checked)
            {
                radioButton2.Checked = true;
                radioButton1.Checked = false;
                radioButton3.Checked = false;
                departmentExpenseListesi();
            }
            clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                var expensemod = new ExpenseModel();
                if (Convert.ToInt32(comboBox1.SelectedValue)==0)
                {
                    MessageBox.Show("Lütfen bir personel seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (Convert.ToInt32(comboBox2.SelectedValue)==0)
                {
                    MessageBox.Show("Lütfen bir araç seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (Convert.ToInt32(comboBox3.SelectedValue)==0)
                {
                    MessageBox.Show("Lütfen bir sefer seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (Convert.ToInt32(comboBox4.SelectedValue)==0)
                {
                    MessageBox.Show("Lütfen bir masraf türü seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Tutar boş geçilemez !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox1.Text == ",")
                {
                    MessageBox.Show("Lütfen geçerli bir tutar giriniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    expensemod.personeller_id = Convert.ToInt32(comboBox1.SelectedValue);
                    expensemod.araclar_id = Convert.ToInt32(comboBox2.SelectedValue);
                    expensemod.seferler_id = Convert.ToInt32(comboBox3.SelectedValue);
                    expensemod.masraf_tipleri_id = Convert.ToInt32(comboBox4.SelectedValue);
                    expensemod.tutar = Convert.ToDecimal(textBox1.Text);
                    expensemod.aciklama = textBox3.Text;
                    expensemod.arac_sube = true;
                    if (ValidationController.validControl(expensemod) == true)
                    {
                        var result = expensecont.carExpenseInsert(expensemod);
                        if (result == true)
                        {
                            MessageBox.Show("Araç masrafı başarılı bir şekilde kayıt edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            carExpenseListesi();
                            clear();
                        }
                        else
                        {
                            MessageBox.Show("Araç masrafı kayıt edilirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            carExpenseListesi();
                            clear();
                        }
                    }
                }
            }
            else if (radioButton2.Checked)
            {
                var expensemod = new ExpenseModel();
                if (Convert.ToInt32(comboBox1.SelectedValue)==0)
                {
                    MessageBox.Show("Lütfen bir personel seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (Convert.ToInt32(comboBox4.SelectedValue) == 0)
                {
                    MessageBox.Show("Lütfen masraf türü seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Tutar boş geçilemez !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (textBox1.Text == ",")
                {
                    MessageBox.Show("Lütfen geçerli bir tutar giriniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
                else
                {
                    expensemod.personeller_id = Convert.ToInt32(comboBox1.SelectedValue);
                    expensemod.subeler_id = Convert.ToInt32(comboBox2.SelectedValue);
                    expensemod.masraf_tipleri_id = Convert.ToInt32(comboBox4.SelectedValue);
                    expensemod.tutar = Convert.ToDecimal(textBox1.Text);
                    expensemod.aciklama = textBox3.Text;
                    expensemod.arac_sube = false;
                    if (ValidationController.validControl(expensemod) == true)
                    {
                        var result = expensecont.departmentExpenseInsert(expensemod);
                        if (result == true)
                        {
                            MessageBox.Show("Şube masrafı başarılı bir şekilde kayıt edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            departmentExpenseListesi();
                            clear();
                        }
                        else
                        {
                            MessageBox.Show("Şube masrafı kayıt edilirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            departmentExpenseListesi();
                            clear();
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                var expensemod = new ExpenseModel();
                expensemod.id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                expensemod.aciklama = dataGridView1.SelectedRows[0].Cells["masraf_yapilan_arac"].Value.ToString();
                DialogResult yesorno = MessageBox.Show(expensemod.aciklama + " plakalı araç masrafı silinecek onaylıyor musunuz !", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (yesorno == DialogResult.Yes)
                {
                    var result = expensecont.delete(expensemod);
                    if (result == true)
                    {
                        MessageBox.Show("Araç masrafı başarılı bir şekilde silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        carExpenseListesi();
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Araç masrafı silinirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        carExpenseListesi();
                        clear();
                    }
                }
            }
            else if (radioButton2.Checked)
            {
                var expensemod = new ExpenseModel();
                expensemod.id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
                expensemod.aciklama = dataGridView1.SelectedRows[0].Cells["sube"].Value.ToString();
                DialogResult yesorno = MessageBox.Show(expensemod.aciklama + " isimli şube masrafı silinecek onaylıyor musunuz !", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (yesorno == DialogResult.Yes)
                {
                    var result = expensecont.delete(expensemod);
                    if (result == true)
                    {
                        MessageBox.Show("Şube masrafı başarılı bir şekilde silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        departmentExpenseListesi();
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Şube masrafı silinirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        departmentExpenseListesi();
                        clear();
                    }
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            ExpenseEditForm expenseeditfrm = new ExpenseEditForm();
            if (label12.Text == "0")
            {
                helpercont.comboFill("id", "ad_soyad", "MasrafPersonelCombobox", expenseeditfrm.comboBox1);
            }
            else if (label12.Text == "1")
            {
                helpercont.comboFillFilter("id", "ad_soyad", Convert.ToInt32(label13.Text), "MasrafPersonelComboboxRegional", expenseeditfrm.comboBox1);
            }
            else
            {
                helpercont.comboFillFilter("id", "ad_soyad", Convert.ToInt32(label11.Text), "MasrafPersonelComboboxPersonel", expenseeditfrm.comboBox1);
            }
            
            if (label12.Text == "0")
            {
                helpercont.comboFill("id", "kod", "MasrafSeferCombobox", expenseeditfrm.comboBox3);
            }
            else
            {
                helpercont.comboFillFilter("id", "kod", Convert.ToInt32(label13.Text), "MasrafSeferComboboxRegional", expenseeditfrm.comboBox3);
            }
            helpercont.comboFill("id", "ad", "MasrafTuruCombobox", expenseeditfrm.comboBox4);
            expenseeditfrm.label3.Text = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
            if (Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells["arac_sube"].Value)==true)
            {
                expenseeditfrm.radioButton2.Visible = false;
                expenseeditfrm.radioButton1.Checked = true;
                expenseeditfrm.label5.Visible = true;
                expenseeditfrm.comboBox2.Visible = true;
                expenseeditfrm.label6.Visible = true;
                expenseeditfrm.comboBox3.Visible = true;
                expenseeditfrm.label5.Text = "ARAÇ";
                expenseeditfrm.comboBox2.DataSource = null;
                if (label12.Text == "0")
                {
                    helpercont.comboFill("id", "plaka", "MasrafAracCombobox", expenseeditfrm.comboBox2);
                }
                else
                {
                    helpercont.comboFillFilter("id", "plaka", Convert.ToInt32(label13.Text), "MasrafAracComboboxRegional", expenseeditfrm.comboBox2);
                }
                expenseeditfrm.comboBox1.SelectedValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["personeller_id"].Value.ToString());
                expenseeditfrm.comboBox4.SelectedValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["masraf_tipleri_id"].Value.ToString());
                expenseeditfrm.comboBox2.SelectedValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["araclar_id"].Value.ToString());
                expenseeditfrm.comboBox3.SelectedValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["seferler_id"].Value.ToString());
                expenseeditfrm.textBox1.Text = dataGridView1.SelectedRows[0].Cells["tutar"].Value.ToString();
                expenseeditfrm.textBox3.Text = dataGridView1.SelectedRows[0].Cells["aciklama"].Value.ToString();
            }
            else if (Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells["arac_sube"].Value)==false)
            {
                expenseeditfrm.radioButton1.Visible = false;
                expenseeditfrm.radioButton2.Checked = true;
                expenseeditfrm.label6.Visible = false;
                expenseeditfrm.comboBox3.Visible = false;
                expenseeditfrm.label5.Text = "ŞUBE";
                expenseeditfrm.comboBox2.DataSource = null;
                if (label12.Text == "0")
                {
                    helpercont.comboFill("id", "ad", "MasrafSubeCombobox", expenseeditfrm.comboBox2);
                }
                else
                {
                    helpercont.comboFillFilter("id", "ad", Convert.ToInt32(label13.Text), "MasrafSubeComboboxRegional", expenseeditfrm.comboBox2);
                }
                
                expenseeditfrm.comboBox1.SelectedValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["personeller_id"].Value.ToString());
                expenseeditfrm.comboBox4.SelectedValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["masraf_tipleri_id"].Value.ToString());
                expenseeditfrm.comboBox2.SelectedValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["subeler_id"].Value.ToString());
                expenseeditfrm.textBox1.Text = dataGridView1.SelectedRows[0].Cells["tutar"].Value.ToString();
                expenseeditfrm.textBox3.Text = dataGridView1.SelectedRows[0].Cells["aciklama"].Value.ToString();
            }
            expenseeditfrm.ShowDialog();
        }

        private void ExpenseForm_Activated(object sender, EventArgs e)
        {
            if ((radioButton1.Checked) || (radioButton3.Checked))
            {
                carExpenseListesi();
            }
            else if ((radioButton2.Checked) || (radioButton4.Checked))
            {
                departmentExpenseListesi();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if ((radioButton1.Checked) || (radioButton3.Checked))
            {
                var expensemod = new ExpenseModel();
                expensemod.aciklama = textBox2.Text;
                DataTable result = null;
                if (label12.Text=="0")
                {
                    result = expensecont.carExpenseSearch(expensemod);
                }
                else if (label12.Text=="1")
                {
                    result = expensecont.carExpenseSearchregional(expensemod,Convert.ToInt32(label13.Text));
                }
                else
                {
                    result = expensecont.carExpenseSearchpersonnel(expensemod, Convert.ToInt32(label11.Text));
                }
               
                if (result != null)
                {
                    if (textBox2.Text == "")
                    {
                        carExpenseListesi();
                        label4.Text = "Lütfen aranacak birşeyler yaz.";
                    }
                    else
                    {
                        dataGridView1.DataSource = result;
                        dataGridView1.Columns["sube"].Visible = false;
                        dataGridView1.Columns["kalkisvarisyeri"].Visible = false;
                        dataGridView1.Columns["masrafi_yapan_personel"].DisplayIndex = 0;
                        dataGridView1.Columns["unvan"].DisplayIndex = 1;
                        dataGridView1.Columns["masraf_yapilan_arac"].DisplayIndex = 2;
                        dataGridView1.Columns["masraf_yapilan_sefer_kodu"].DisplayIndex = 3;
                        dataGridView1.Columns["masraf_tipi"].DisplayIndex = 4;
                        dataGridView1.Columns["aciklama"].DisplayIndex = 5;
                        dataGridView1.Columns["tutar"].DisplayIndex = 6;
                        dataGridView1.Columns["tarih"].DisplayIndex = 7;
                        dataGridView1.Columns["masrafi_yapan_personel"].HeaderText = "PERSONEL";
                        dataGridView1.Columns["unvan"].HeaderText = "UNVAN";
                        dataGridView1.Columns["masraf_yapilan_arac"].HeaderText = "ARAÇ PLAKA";
                        dataGridView1.Columns["masraf_yapilan_sefer_kodu"].HeaderText = "SEFER KODU";
                        dataGridView1.Columns["masraf_tipi"].HeaderText = "MASRAF TÜRÜ";
                        dataGridView1.Columns["aciklama"].HeaderText = "AÇIKLAMA";
                        dataGridView1.Columns["tutar"].HeaderText = "TUTAR";
                        dataGridView1.Columns["tarih"].HeaderText = "TARİH";
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
                        label4.Text = expensemod.aciklama + " ile kayıt bulunmuyor !";
                    }
                }
            }
            else if ((radioButton2.Checked) || (radioButton4.Checked))
            {
                var expensemod = new ExpenseModel();
                expensemod.aciklama = textBox2.Text;
                DataTable result = null;
                if (label12.Text == "0")
                {
                    result = expensecont.departmentExpenseSearch(expensemod);
                }
                else if (label12.Text == "1")
                {
                    result = expensecont.departmentExpenseSearchregional(expensemod, Convert.ToInt32(label13.Text));
                }
                else
                {
                    result = expensecont.departmentExpenseSearchpersonnel(expensemod, Convert.ToInt32(label11.Text));
                }
                if (result != null)
                {
                    if (textBox2.Text == "")
                    {
                        departmentExpenseListesi();
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
                        label4.Text = expensemod.aciklama + " ile kayıt bulunmuyor !";
                    }
                }
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.Text = "";
            label4.Text = "";
        }
    }
}
