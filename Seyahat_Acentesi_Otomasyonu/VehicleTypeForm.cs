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
    public partial class VehicleTypeForm : Form
    {
        VehicleTypeController vehicletypecont = new VehicleTypeController();
        public VehicleTypeForm()
        {
            InitializeComponent();
        }
        public void listele()
        {
            if (vehicletypecont.list() != null)
            {
                dataGridView1.DataSource = vehicletypecont.list();
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["silinme_durum"].Visible = false;
                dataGridView1.Columns["ad"].HeaderText = "ARAÇ TÜR ADI";
            }
            else
            {
                dataGridView1.DataSource = vehicletypecont.list();
            }
        }
        void temizle()
        {
            textBox1.Clear();
        }
        private void VehicleTypeForm_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var vehicletypemod = new VehicleTypeModel();
            vehicletypemod.ad = textBox1.Text;
            if (ValidationController.validControl(vehicletypemod) == true)
            {
                var control = vehicletypecont.registerControl(vehicletypemod);
                if (control == false)
                {
                    var result = vehicletypecont.insert(vehicletypemod);
                    if (result == true)
                    {
                        MessageBox.Show("Araç türü başarılı bir şekilde kayıt edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listele();
                        temizle();
                    }
                    else
                    {
                        MessageBox.Show("Araç türü kayıt edilirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        listele();
                        temizle();
                    }
                }
                else
                {
                    MessageBox.Show("Araç türü zaten kayıtlı lütfen başka bir isim ile tekrar deneyin !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VehicleTypeEditForm vehicletypeeditfrm = new VehicleTypeEditForm();
            vehicletypeeditfrm.label3.Text = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
            vehicletypeeditfrm.textBox1.Text = dataGridView1.SelectedRows[0].Cells["ad"].Value.ToString();
            vehicletypeeditfrm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var vehicletypemod = new VehicleTypeModel();
            vehicletypemod.id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
            vehicletypemod.ad = dataGridView1.SelectedRows[0].Cells["ad"].Value.ToString();
            DialogResult yesorno = MessageBox.Show(vehicletypemod.ad + " araç türü silinecek !", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (yesorno == DialogResult.Yes)
            {
                var result = vehicletypecont.delete(vehicletypemod);
                if (result == true)
                {
                    MessageBox.Show("Araç türü başarılı bir şekilde silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele();
                    temizle();
                }
                else
                {
                    MessageBox.Show("Araç türü silinirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    listele();
                    temizle();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var vehicletypemod = new VehicleTypeModel();
            vehicletypemod.ad = textBox2.Text;
            var result = vehicletypecont.search(vehicletypemod);
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
                    label4.Text = vehicletypemod.ad + " ile kayıt bulunmuyor !";
                }
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.Clear();
            label4.Text = "";
        }

        private void VehicleTypeForm_Activated(object sender, EventArgs e)
        {
            listele();
        }
    }
}
