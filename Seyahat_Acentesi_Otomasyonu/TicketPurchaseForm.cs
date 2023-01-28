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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Seyahat_Acentesi_Otomasyonu
{
    public partial class TicketPurchaseForm : Form
    {
        HelperController helpercont = new HelperController();
        TicketSalesController ticketsalescont = new TicketSalesController();
        MailerController mailercont = new MailerController();
        public TicketPurchaseForm()
        {
            InitializeComponent();
        }
        void listele()
        {
            helpercont.comboFill("id", "ad", "SehirlerCombobox", comboBox2);
            helpercont.comboFill("id", "ad", "SatisTipleriCombobox", comboBox5);
        }
        void clear()
        {
            radioButton7.Checked = true;
            radioButton2.Checked = true;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            dateTimePicker1.ResetText();
            comboBox2.SelectedValue = 0;
            comboBox5.SelectedValue = 0;
        }
        private void button3_Click(object sender, EventArgs e)
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
                ticketsalesmod.seferler_id = Convert.ToInt32(label16.Text);
                ticketsalesmod.kalkis_sehir_id= Convert.ToInt32(label17.Text);
                ticketsalesmod.varis_sehir_id=Convert.ToInt32(label19.Text);
                if (radioButton2.Checked==true)
                {
                    ticketsalesmod.satismi_rezervasyonmu = true;
                }
                else if (radioButton1.Checked==true)
                {
                    ticketsalesmod.satismi_rezervasyonmu = false;
                }
                ticketsalesmod.tc = textBox1.Text;
                ticketsalesmod.ad = textBox2.Text;
                ticketsalesmod.soyad = textBox3.Text;
                ticketsalesmod.telefon = textBox4.Text;
                ticketsalesmod.email = textBox5.Text;
                if (radioButton7.Checked==true)
                {
                    ticketsalesmod.cinsiyet = true;
                }
                else if (radioButton4.Checked==true)
                {
                    ticketsalesmod.cinsiyet = false;
                }
                ticketsalesmod.sehirler_id = Convert.ToInt32(comboBox2.SelectedValue);
                ticketsalesmod.dogum_tarih = dateTimePicker1.Value;
                ticketsalesmod.koltuk_no = Convert.ToByte(textBox9.Text);
                ticketsalesmod.satis_tipleri_id = Convert.ToInt32(comboBox5.SelectedValue);
                if (ValidationController.validControl(ticketsalesmod)==true)
                {
                    var result = ticketsalescont.insert(ticketsalesmod);
                    if (result==true)
                    {
                        string mailSendResult = mailercont.sendMail(ticketsalesmod.ad, ticketsalesmod.soyad, ticketsalesmod.email, ticketsalesmod.telefon, textBox7.Text, textBox8.Text, label22.Text, label23.Text, textBox9.Text, textBox10.Text);
                        MessageBox.Show("Bilet satışı başarılı bir şekilde gerçekleşti.\n" + mailSendResult, "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        clear();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Bilet satışı sırasında bir sorun ile karşılaşıldı !", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }
        }

        private void TicketPurchaseForm_Load(object sender, EventArgs e)
        {
            listele();
            clear();
        }
    }
}
