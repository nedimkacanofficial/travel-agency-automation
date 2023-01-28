using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using Model;

namespace Seyahat_Acentesi_Otomasyonu
{
    public partial class StationForm : Form
    {
        HelperController helpercont = new HelperController();
        StationController stationcont = new StationController();
        public StationForm()
        {
            InitializeComponent();
        }
        void stationList()
        {
            if (stationcont.list() != null)
            {
                dataGridView1.DataSource = stationcont.list();
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["guzergahlar_id"].Visible = false;
                dataGridView1.Columns["kalkis_sehir_id"].Visible = false;
                dataGridView1.Columns["varis_sehir_id"].Visible = false;
                dataGridView1.Columns["guzergahlar"].DisplayIndex = 0;
                dataGridView1.Columns["kalkis_sehir"].DisplayIndex = 1;
                dataGridView1.Columns["varis_sehir"].DisplayIndex = 2;
                dataGridView1.Columns["ham_fiyat"].DisplayIndex = 3;
                dataGridView1.Columns["kar_yuzdesi"].DisplayIndex = 4;
                dataGridView1.Columns["tutar"].DisplayIndex = 5;
                dataGridView1.Columns["kayit_tarih"].DisplayIndex = 6;
                dataGridView1.Columns["guzergahlar"].HeaderText = "GÜZERGAH";
                dataGridView1.Columns["kalkis_sehir"].HeaderText = "KALKIŞ DURAK";
                dataGridView1.Columns["varis_sehir"].HeaderText = "VARIŞ DURAK";
                dataGridView1.Columns["ham_fiyat"].HeaderText = "HAM FİYAT";
                dataGridView1.Columns["kar_yuzdesi"].HeaderText = "KAR ORANI";
                dataGridView1.Columns["tutar"].HeaderText = "TUTAR";
                dataGridView1.Columns["kayit_tarih"].HeaderText = "TARİH";
            }
            else
            {
                dataGridView1.DataSource = stationcont.list();
            }
        }
        void clear()
        {
            comboBox1.SelectedValue = 0;
            comboBox2.SelectedValue = 0;
            comboBox3.SelectedValue = 0;
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
        private void StationForm_Load(object sender, EventArgs e)
        {
            stationList();
            helpercont.comboFill("id", "guzergah", "GuzergahlarCombobox", comboBox1);
            helpercont.comboFill("id", "ad", "SehirlerCombobox", comboBox2);
            helpercont.comboFill("id", "ad", "SehirlerCombobox", comboBox3);
            clear();
        }

        private void button3_Click(object sender, EventArgs e)
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
            else if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Ham fiyat zorunludur !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (string.IsNullOrEmpty(textBox4.Text))
            {
                MessageBox.Show("Tutar boş geçilemez !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox1.Text.Length > 15)
            {
                MessageBox.Show("Girilen ham fiyat çok büyük !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox3.Text.Length > 15)
            {
                MessageBox.Show("Girilen kar oranı çok büyük !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox4.Text.Length > 15)
            {
                MessageBox.Show("Girilen tutar çok büyük !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox1.Text == ",")
            {
                MessageBox.Show("Lütfen geçerli bir fiyat giriniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox3.Text == ",")
            {
                MessageBox.Show("Lütfen geçerli bir kar oranı giriniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (textBox4.Text == ",")
            {
                MessageBox.Show("Lütfen geçerli bir tutar giriniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var stationmod = new StationModel();
                stationmod.guzergahlar_id = Convert.ToInt32(comboBox1.SelectedValue);
                stationmod.kalkis_sehir_id = Convert.ToInt32(comboBox2.SelectedValue);
                stationmod.varis_sehir_id = Convert.ToInt32(comboBox3.SelectedValue);
                stationmod.ham_fiyat = Convert.ToDecimal(textBox1.Text);
                if (textBox3.Text==""||string.IsNullOrEmpty(textBox3.Text))
                {
                    stationmod.kar_yuzdesi = 0.00000000000001m;
                }
                else
                {
                    stationmod.kar_yuzdesi = Convert.ToDecimal(textBox3.Text);
                }
                stationmod.tutar = Convert.ToDecimal(textBox4.Text);
                if (ValidationController.validControl(stationmod)==true)
                {
                    var stationcontrol = stationcont.stationcontrol(stationmod);
                    if (stationcontrol==false)
                    {
                        var result = stationcont.insert(stationmod);
                        if (result==true)
                        {
                            MessageBox.Show("Durak başarılı bir şekilde kayıt edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            stationList();
                            clear();
                        }
                        else
                        {
                            MessageBox.Show("Durak kayıt edilirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            stationList();
                            clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Durak zaten kayıtlı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var stationmod = new StationModel();
            stationmod.id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
            DialogResult yesorno = MessageBox.Show("Durak silinecek onaylıyor musunuz !", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (yesorno == DialogResult.Yes)
            {
                var result = stationcont.delete(stationmod);
                if (result == true)
                {
                    MessageBox.Show("Durak başarılı bir şekilde silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    stationList();
                    clear();
                }
                else
                {
                    MessageBox.Show("Durak silinirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    stationList();
                    clear();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StationEditForm stationeditfrm = new StationEditForm();
            stationeditfrm.label3.Text = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
            helpercont.comboFill("id", "guzergah", "GuzergahlarCombobox", stationeditfrm.comboBox1);
            helpercont.comboFill("id", "ad", "SehirlerCombobox", stationeditfrm.comboBox2);
            helpercont.comboFill("id", "ad", "SehirlerCombobox", stationeditfrm.comboBox3);
            stationeditfrm.comboBox1.SelectedValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["guzergahlar_id"].Value.ToString());
            stationeditfrm.comboBox2.SelectedValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["kalkis_sehir_id"].Value.ToString());
            stationeditfrm.comboBox3.SelectedValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["varis_sehir_id"].Value.ToString());
            stationeditfrm.textBox2.Text = dataGridView1.SelectedRows[0].Cells["ham_fiyat"].Value.ToString();
            stationeditfrm.textBox1.Text = dataGridView1.SelectedRows[0].Cells["kar_yuzdesi"].Value.ToString();
            stationeditfrm.textBox3.Text = dataGridView1.SelectedRows[0].Cells["tutar"].Value.ToString();
            stationeditfrm.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(textBox1.Text))&&(string.IsNullOrEmpty(textBox3.Text)))
            {
                textBox4.Text = textBox1.Text;
            }
            else
            {
                textBox4.Clear();
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(textBox3.Text))&&(!string.IsNullOrEmpty(textBox1.Text)))
            {
                textBox4.Text = Convert.ToDecimal((Convert.ToDecimal(textBox1.Text) * Convert.ToDecimal(textBox3.Text)) / 100 + (Convert.ToDecimal(textBox1.Text))).ToString();
            }
            else
            {
                textBox4.Text = textBox1.Text;
            }
        }

        private void StationForm_Activated(object sender, EventArgs e)
        {
            stationList();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var stationmod = new StationModel();
            stationmod.aranacak_deger = textBox2.Text;
            var result = stationcont.search(stationmod);
            if (result != null)
            {
                if (textBox2.Text == "")
                {
                    stationList();
                    label4.Text = "Lütfen aranacak birşeyler yaz.";
                }
                else
                {
                    dataGridView1.DataSource = result;
                    dataGridView1.Columns["id"].Visible = false;
                    dataGridView1.Columns["guzergahlar_id"].Visible = false;
                    dataGridView1.Columns["kalkis_sehir_id"].Visible = false;
                    dataGridView1.Columns["varis_sehir_id"].Visible = false;
                    dataGridView1.Columns["guzergahlar"].DisplayIndex = 0;
                    dataGridView1.Columns["kalkis_sehir"].DisplayIndex = 1;
                    dataGridView1.Columns["varis_sehir"].DisplayIndex = 2;
                    dataGridView1.Columns["ham_fiyat"].DisplayIndex = 3;
                    dataGridView1.Columns["kar_yuzdesi"].DisplayIndex = 4;
                    dataGridView1.Columns["tutar"].DisplayIndex = 5;
                    dataGridView1.Columns["kayit_tarih"].DisplayIndex = 6;
                    dataGridView1.Columns["guzergahlar"].HeaderText = "GÜZERGAH";
                    dataGridView1.Columns["kalkis_sehir"].HeaderText = "KALKIŞ DURAK";
                    dataGridView1.Columns["varis_sehir"].HeaderText = "VARIŞ DURAK";
                    dataGridView1.Columns["ham_fiyat"].HeaderText = "HAM FİYAT";
                    dataGridView1.Columns["kar_yuzdesi"].HeaderText = "KAR ORANI";
                    dataGridView1.Columns["tutar"].HeaderText = "TUTAR";
                    dataGridView1.Columns["kayit_tarih"].HeaderText = "TARİH";
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
                    label4.Text = stationmod.aranacak_deger + " ile kayıt bulunmuyor !";
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
