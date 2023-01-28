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
    public partial class PaymentTypeForm : Form
    {
        PaymentTypeController paymenttypecont = new PaymentTypeController();
        public PaymentTypeForm()
        {
            InitializeComponent();
        }
        void listele()
        {
            if (paymenttypecont.list() != null)
            {
                dataGridView1.DataSource = paymenttypecont.list();
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["silinme_durum"].Visible = false;
                dataGridView1.Columns["ad"].HeaderText = "ÖDEME TÜRÜ ADI";
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
        private void PaymentTypeForm_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var paymenttypemod = new PaymentTypeModel();
            paymenttypemod.ad = textBox1.Text;
            if (ValidationController.validControl(paymenttypemod) == true)
            {
                var control = paymenttypecont.registerControl(paymenttypemod);
                if (control==false)
                {
                    var result = paymenttypecont.insert(paymenttypemod);
                    if (result == true)
                    {
                        MessageBox.Show("Ödeme türü başarılı bir şekilde kayıt edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listele();
                        temizle();
                    }
                    else
                    {
                        MessageBox.Show("Ödeme türü kayıt edilirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        listele();
                        temizle();
                    }
                }
                else
                {
                    MessageBox.Show("Ödeme türü zaten kayıtlı lütfen başka bir isimle tekrar deneyin !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PaymentTypeEditForm paymenttypeeditfrm = new PaymentTypeEditForm();
            paymenttypeeditfrm.label3.Text = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
            paymenttypeeditfrm.textBox1.Text = dataGridView1.SelectedRows[0].Cells["ad"].Value.ToString();
            paymenttypeeditfrm.ShowDialog();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var paymenttypemod = new PaymentTypeModel();
            paymenttypemod.id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
            paymenttypemod.ad = dataGridView1.SelectedRows[0].Cells["ad"].Value.ToString();
            DialogResult yesorno = MessageBox.Show(paymenttypemod.ad + " ödeme türü silinecek !", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (yesorno == DialogResult.Yes)
            {
                var result = paymenttypecont.delete(paymenttypemod);
                if (result == true)
                {
                    MessageBox.Show("Ödeme türü başarılı bir şekilde silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele();
                    temizle();
                }
                else
                {
                    MessageBox.Show("Ödeme türü silinirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    listele();
                    temizle();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var paymenttypemod = new PaymentTypeModel();
            paymenttypemod.ad = textBox2.Text;
            var result = paymenttypecont.search(paymenttypemod);
            if (result != null)
            {
                if (textBox2.Text=="")
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
                    label4.Text ="Lütfen aranacak birşeyler yaz.";
                }
                else
                {
                    label4.Text = paymenttypemod.ad + " ile kayıt bulunmuyor !";
                }
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.Clear();
            label4.Text = "";
        }

        private void PaymentTypeForm_Activated(object sender, EventArgs e)
        {
            listele();
        }
    }
}
