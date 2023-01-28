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
    public partial class VehicleBrandForm : Form
    {
        VehicleBrandController vehiclebrandcont = new VehicleBrandController();
        public VehicleBrandForm()
        {
            InitializeComponent();
        }
        public void listele()
        {
            if (vehiclebrandcont.list() != null)
            {
                dataGridView1.DataSource = vehiclebrandcont.list();
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["silinme_durum"].Visible = false;
                dataGridView1.Columns["ad"].HeaderText = "MARKA ADI";
            }
            else
            {
                dataGridView1.DataSource = vehiclebrandcont.list();
            }
        }
        void temizle()
        {
            textBox1.Clear();
        }
        private void VehicleBrandForm_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var vehiclebrandmod = new VehicleBrandModel();
            vehiclebrandmod.ad = textBox1.Text;
            if (ValidationController.validControl(vehiclebrandmod) == true)
            {
                var control = vehiclebrandcont.registerControl(vehiclebrandmod);
                if (control == false)
                {
                    var result = vehiclebrandcont.insert(vehiclebrandmod);
                    if (result == true)
                    {
                        MessageBox.Show("Araç markası başarılı bir şekilde kayıt edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listele();
                        temizle();
                    }
                    else
                    {
                        MessageBox.Show("Araç markası kayıt edilirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        listele();
                        temizle();
                    }
                }
                else
                {
                    MessageBox.Show("Araç markası zaten kayıtlı lütfen başka bir isim ile tekrar deneyin !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VehicleBrandEditForm vehiclebrandeditfrm = new VehicleBrandEditForm();
            vehiclebrandeditfrm.label3.Text = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
            vehiclebrandeditfrm.textBox1.Text = dataGridView1.SelectedRows[0].Cells["ad"].Value.ToString();
            vehiclebrandeditfrm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var vehiclebrandmod = new VehicleBrandModel();
            vehiclebrandmod.id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
            vehiclebrandmod.ad = dataGridView1.SelectedRows[0].Cells["ad"].Value.ToString();
            DialogResult yesorno = MessageBox.Show(vehiclebrandmod.ad + " araç markası silinecek !", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (yesorno == DialogResult.Yes)
            {
                var result = vehiclebrandcont.delete(vehiclebrandmod);
                if (result == true)
                {
                    MessageBox.Show("Araç markası başarılı bir şekilde silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele();
                    temizle();
                }
                else
                {
                    MessageBox.Show("Araç markası silinirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    listele();
                    temizle();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var vehiclebrandmod = new VehicleBrandModel();
            vehiclebrandmod.ad = textBox2.Text;
            var result = vehiclebrandcont.search(vehiclebrandmod);
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
                    label4.Text = vehiclebrandmod.ad + " ile kayıt bulunmuyor !";
                }
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.Clear();
            label4.Text = "";
        }

        private void VehicleBrandForm_Activated(object sender, EventArgs e)
        {
            listele();
        }
    }
}
