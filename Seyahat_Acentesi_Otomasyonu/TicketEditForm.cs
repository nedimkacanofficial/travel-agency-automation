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
    public partial class TicketEditForm : Form
    {
        TicketSalesController ticketsalescont = new TicketSalesController();
        public TicketEditForm()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult yesorno = MessageBox.Show("Bilet güncellenmek üzere onaylıyor musunuz ?", "Dikkat !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (yesorno == DialogResult.Yes)
            {
                if (Convert.ToInt32(comboBox2.SelectedValue) == 0)
                {
                    MessageBox.Show("Lütfen bir şehir seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (Convert.ToInt32(comboBox5.SelectedValue) == 0)
                {
                    MessageBox.Show("Lütfen bir ödeme türü seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var ticketsalesmod = new TicketSalesModel();
                    ticketsalesmod.personeller_id = Convert.ToInt32(label20.Text);
                    if (radioButton2.Checked == true)
                    {
                        ticketsalesmod.satismi_rezervasyonmu = true;
                    }
                    else if (radioButton1.Checked == true)
                    {
                        ticketsalesmod.satismi_rezervasyonmu = false;
                    }
                    ticketsalesmod.tc = textBox1.Text;
                    ticketsalesmod.ad = textBox2.Text;
                    ticketsalesmod.soyad = textBox3.Text;
                    ticketsalesmod.telefon = textBox4.Text;
                    ticketsalesmod.email = textBox5.Text;
                    if (radioButton7.Checked == true)
                    {
                        ticketsalesmod.cinsiyet = true;
                    }
                    else if (radioButton4.Checked == true)
                    {
                        ticketsalesmod.cinsiyet = false;
                    }
                    ticketsalesmod.sehirler_id = Convert.ToInt32(comboBox2.SelectedValue);
                    ticketsalesmod.dogum_tarih = dateTimePicker1.Value;
                    ticketsalesmod.koltuk_no = Convert.ToByte(textBox9.Text);
                    ticketsalesmod.satis_tipleri_id = Convert.ToInt32(comboBox5.SelectedValue);
                    ticketsalesmod.guncelleme_tarih = DateTime.Now;
                    ticketsalesmod.id = Convert.ToInt32(label16.Text);
                    if (ValidationController.validControl(ticketsalesmod) == true)
                    {
                        var result = ticketsalescont.update(ticketsalesmod);
                        if (result == true)
                        {
                            MessageBox.Show("Bilet  başarılı bir şekilde güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Bilet güncelleme sırasında bir sorun ile karşılaşıldı !", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                    }
                }
            }
        }
    }
}
