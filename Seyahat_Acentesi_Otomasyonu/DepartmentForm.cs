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
    public partial class DepartmentForm : Form
    {
        DepartmentController departmentcont = new DepartmentController();
        HelperController helpercont = new HelperController();
        public DepartmentForm()
        {
            InitializeComponent();
        }
        public void listele()
        {
            if (departmentcont.list() != null)
            {
                dataGridView1.DataSource = departmentcont.list();
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["sehirler_id"].Visible = false;
                dataGridView1.Columns["sube_ad"].HeaderText = "ŞUBE ADI";
                dataGridView1.Columns["bulundugu_sehir"].HeaderText = "BULUNDUĞU ŞEHİR";
                dataGridView1.Columns["sube_acilis_tarih"].HeaderText = "AÇILIŞ TARİH";
                dataGridView1.Columns["sube_ad"].DisplayIndex = 0;
                dataGridView1.Columns["bulundugu_sehir"].DisplayIndex = 1;
                dataGridView1.Columns["sube_acilis_tarih"].DisplayIndex = 2;
            }
            else
            {
                dataGridView1.DataSource = departmentcont.list();
            }
        }
        void temizle()
        {
            textBox1.Clear();
            comboBox1.SelectedValue = 0;
        }
        private void DepartmentForm_Load(object sender, EventArgs e)
        {
            listele();
            helpercont.comboFill("id", "ad", "SehirlerCombobox", comboBox1);
            temizle();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(comboBox1.SelectedValue)==0)
            {
                MessageBox.Show("Lütfen bir şehir seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var departmentmod = new DepartmentModel();
                departmentmod.ad = textBox1.Text;
                departmentmod.sehirler_id = Convert.ToInt32(comboBox1.SelectedValue);
                if (ValidationController.validControl(departmentmod) == true)
                {
                    var control = departmentcont.registerControl(departmentmod);
                    if (control == false)
                    {
                        var result = departmentcont.insert(departmentmod);
                        if (result == true)
                        {
                            MessageBox.Show("Şube başarılı bir şekilde kayıt edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            listele();
                            temizle();
                        }
                        else
                        {
                            MessageBox.Show("Şube kayıt edilirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            listele();
                            temizle();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Şube zaten kayıtlı lütfen başka bir isim ile tekrar deneyin !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DepartmentEditForm departmenteditfrm = new DepartmentEditForm();
            departmenteditfrm.label3.Text = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
            departmenteditfrm.textBox1.Text = dataGridView1.SelectedRows[0].Cells["sube_ad"].Value.ToString();
            helpercont.comboFill("id", "ad", "SehirlerCombobox", departmenteditfrm.comboBox1);
            departmenteditfrm.comboBox1.SelectedValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["sehirler_id"].Value.ToString());
            departmenteditfrm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var departmentmod = new DepartmentModel();
            departmentmod.id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
            departmentmod.ad = dataGridView1.SelectedRows[0].Cells["sube_ad"].Value.ToString();
            DialogResult yesorno = MessageBox.Show(departmentmod.ad + " isimli şube silinecek !", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (yesorno == DialogResult.Yes)
            {
                var result = departmentcont.delete(departmentmod);
                if (result == true)
                {
                    MessageBox.Show("Şube başarılı bir şekilde silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele();
                    temizle();
                }
                else
                {
                    MessageBox.Show("Şube silinirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    listele();
                    temizle();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var departmentmod = new DepartmentModel();
            departmentmod.ad = textBox2.Text;
            var result = departmentcont.search(departmentmod);
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
                    dataGridView1.Columns["sube_ad"].DisplayIndex = 0;
                    dataGridView1.Columns["bulundugu_sehir"].DisplayIndex = 1;
                    dataGridView1.Columns["sube_acilis_tarih"].DisplayIndex = 2;
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
                    label4.Text = departmentmod.ad + " ile kayıt bulunmuyor !";
                }
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.Clear();
            label4.Text = "";
        }

        private void DepartmentForm_Activated(object sender, EventArgs e)
        {
            listele();
        }
    }
}
