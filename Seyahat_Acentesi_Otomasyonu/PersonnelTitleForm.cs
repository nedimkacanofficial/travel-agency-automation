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
    public partial class PersonnelTitleForm : Form
    {
        PersonnelTitleController personneltitlecont = new PersonnelTitleController();
        public PersonnelTitleForm()
        {
            InitializeComponent();
        }
        public void listele()
        {
            if (personneltitlecont.list() != null)
            {
                dataGridView1.DataSource = personneltitlecont.list();
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["silinme_durum"].Visible = false;
                dataGridView1.Columns["ad"].HeaderText = "PERSONEL UNVAN ADI";
            }
            else
            {
                dataGridView1.DataSource = personneltitlecont.list();
            }
        }
        void temizle()
        {
            textBox1.Clear();
        }
        private void PersonnelTitleForm_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var personneltitlemod = new PersonnelTitleModel();
            personneltitlemod.ad = textBox1.Text;
            if (ValidationController.validControl(personneltitlemod) == true)
            {
                var control = personneltitlecont.personneltitlecontrol(personneltitlemod);
                if (control == false)
                {
                    var result = personneltitlecont.insert(personneltitlemod);
                    if (result == true)
                    {
                        MessageBox.Show("Personel unvanı başarılı bir şekilde kayıt edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listele();
                        temizle();
                    }
                    else
                    {
                        MessageBox.Show("Personel unvanı kayıt edilirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        listele();
                        temizle();
                    }
                }
                else
                {
                    MessageBox.Show("Personel unvanı zaten kayıtlı lütfen başka bir isim ile tekrar deneyin !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PersonnelTitleEditForm personneltitleeditfrm = new PersonnelTitleEditForm();
            personneltitleeditfrm.label3.Text = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
            personneltitleeditfrm.textBox1.Text = dataGridView1.SelectedRows[0].Cells["ad"].Value.ToString();
            personneltitleeditfrm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var personneltitlemod = new PersonnelTitleModel();
            personneltitlemod.id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
            personneltitlemod.ad = dataGridView1.SelectedRows[0].Cells["ad"].Value.ToString();
            DialogResult yesorno = MessageBox.Show(personneltitlemod.ad + " unvanı silinecek !", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (yesorno == DialogResult.Yes)
            {
                var result = personneltitlecont.delete(personneltitlemod);
                if (result == true)
                {
                    MessageBox.Show("Personel unvanı başarılı bir şekilde silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele();
                    temizle();
                }
                else
                {
                    MessageBox.Show("Personel unvanı silinirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    listele();
                    temizle();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var personneltitlemod = new PersonnelTitleModel();
            personneltitlemod.ad = textBox2.Text;
            var result = personneltitlecont.search(personneltitlemod);
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
                    label4.Text = personneltitlemod.ad + " ile kayıt bulunmuyor !";
                }
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.Clear();
            label4.Text = "";
        }

        private void PersonnelTitleForm_Activated(object sender, EventArgs e)
        {
            listele();
        }
    }
}
