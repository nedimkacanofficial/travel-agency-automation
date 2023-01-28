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
    public partial class ExpenseTypeForm : Form
    {
        ExpenseTypeController expensetypecont = new ExpenseTypeController();
        public ExpenseTypeForm()
        {
            InitializeComponent();
        }
        void listele()
        {
            if (expensetypecont.list()!=null)
            {
                dataGridView1.DataSource = expensetypecont.list();
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["silinme_durum"].Visible = false;
                dataGridView1.Columns["ad"].HeaderText = "MASRAF TÜRÜ ADI";
            }
            else
            {
                dataGridView1.DataSource = new DataTable();
            }
            
        }
        void temizle()
        {
            textBox1.Clear();
        }
        private void ExpenseTypeForm_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var expensetypemod = new ExpenseTypeModel();
            expensetypemod.ad = textBox1.Text;
            if (ValidationController.validControl(expensetypemod) == true)
            {
                var control = expensetypecont.registerControl(expensetypemod);
                if (control==false)
                {
                    var result = expensetypecont.insert(expensetypemod);
                    if (result == true)
                    {
                        MessageBox.Show("Masraf türü başarılı bir şekilde kayıt edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listele();
                        temizle();
                    }
                    else
                    {
                        MessageBox.Show("Masraf türü kayıt edilirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        listele();
                        temizle();
                    }
                }
                else
                {
                    MessageBox.Show("Masraf türü zaten kayıtlı lütfen başka bir isim ile tekrar deneyin !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ExpenseTypeEditForm expensetypeeditfrm = new ExpenseTypeEditForm();
            expensetypeeditfrm.label3.Text = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
            expensetypeeditfrm.textBox1.Text = dataGridView1.SelectedRows[0].Cells["ad"].Value.ToString();
            expensetypeeditfrm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var expensetypemod = new ExpenseTypeModel();
            expensetypemod.id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
            expensetypemod.ad = dataGridView1.SelectedRows[0].Cells["ad"].Value.ToString();
            DialogResult yesorno = MessageBox.Show(expensetypemod.ad + " masraf türü silinecek !", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (yesorno == DialogResult.Yes)
            {
                var result = expensetypecont.delete(expensetypemod);
                if (result == true)
                {
                    MessageBox.Show("Masraf türü başarılı bir şekilde silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele();
                    temizle();
                }
                else
                {
                    MessageBox.Show("Masraf türü silinirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    listele();
                    temizle();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var expensetypemod = new ExpenseTypeModel();
            expensetypemod.ad = textBox2.Text;
            var result = expensetypecont.search(expensetypemod);
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
                    label4.Text = expensetypemod.ad + " ile kayıt bulunmuyor !";
                }
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.Clear();
            label4.Text = "";
        }

        private void ExpenseTypeForm_Activated(object sender, EventArgs e)
        {
            listele();
        }
    }
}
