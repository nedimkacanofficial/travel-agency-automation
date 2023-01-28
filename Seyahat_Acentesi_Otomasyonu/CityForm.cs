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
    public partial class CityForm : Form
    {
        CityController citycont = new CityController();
        public CityForm()
        {
            InitializeComponent();
        }
        public void listele()
        {
            if (citycont.list() != null)
            {
                dataGridView1.DataSource = citycont.list();
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["silinme_durum"].Visible = false;
                dataGridView1.Columns["ad"].HeaderText = "ŞEHİR ADI";
            }
            else
            {
                dataGridView1.DataSource = citycont.list();
            }
        }
        void temizle()
        {
            textBox1.Clear();
        }
        private void CityForm_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var citymod = new CityModel();
            citymod.ad = textBox1.Text;
            if (ValidationController.validControl(citymod)==true)
            {
                var control = citycont.registerControl(citymod);
                if (control == false)
                {
                    var result = citycont.insert(citymod);
                    if (result == true)
                    {
                        MessageBox.Show("Şehir başarılı bir şekilde kayıt edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listele();
                        temizle();
                    }
                    else
                    {
                        MessageBox.Show("Şehir kayıt edilirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        listele();
                        temizle();
                    }
                }
                else
                {
                    MessageBox.Show("Şehir zaten kayıtlı lütfen başka bir isim ile tekrar deneyin !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CityEditForm cityeditfrm = new CityEditForm();
            cityeditfrm.label3.Text = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
            cityeditfrm.textBox1.Text = dataGridView1.SelectedRows[0].Cells["ad"].Value.ToString();
            cityeditfrm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var citymod = new CityModel();
            citymod.id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
            citymod.ad = dataGridView1.SelectedRows[0].Cells["ad"].Value.ToString();
            DialogResult yesorno = MessageBox.Show(citymod.ad + " isimli şehir silinecek !", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (yesorno == DialogResult.Yes)
            {
                var result = citycont.delete(citymod);
                if (result == true)
                {
                    MessageBox.Show("Şehir başarılı bir şekilde silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele();
                    temizle();
                }
                else
                {
                    MessageBox.Show("Şehir silinirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    listele();
                    temizle();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var citymod = new CityModel();
            citymod.ad = textBox2.Text;
            var result = citycont.search(citymod);
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
                    label4.Text = citymod.ad + " ile kayıt bulunmuyor !";
                }
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.Clear();
            label4.Text = "";
        }

        private void CityForm_Activated(object sender, EventArgs e)
        {
            listele();
        }
    }
}
