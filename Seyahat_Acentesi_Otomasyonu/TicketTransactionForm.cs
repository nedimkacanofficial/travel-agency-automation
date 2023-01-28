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
    public partial class TicketTransactionForm : Form
    {
        TicketSalesController ticketsalescont = new TicketSalesController();
        HelperController helpercont = new HelperController();
        public TicketTransactionForm()
        {
            InitializeComponent();
        }
        public void listele()
        {
            if ((ticketsalescont.ticketListSales() != null)||(ticketsalescont.ticketListRezervation()!=null))
            {
                if (radioButton2.Checked==true)
                {
                    if (label3.Text=="0")
                    {
                        if (ticketsalescont.ticketListSales() != null)
                        {
                            dataGridView1.DataSource = ticketsalescont.ticketListSales();
                            dataGridView1.Columns["id"].Visible = false;
                            dataGridView1.Columns["yasadigi_sehir_id"].Visible = false;
                            dataGridView1.Columns["satis_tipleri_id"].Visible = false;

                            dataGridView1.Columns["satis_personeli"].DisplayIndex = 0;
                            dataGridView1.Columns["sefer_kodu"].DisplayIndex = 1;
                            dataGridView1.Columns["plaka"].DisplayIndex = 2;
                            dataGridView1.Columns["kalkis_sehir"].DisplayIndex = 3;
                            dataGridView1.Columns["varis_sehir"].DisplayIndex = 4;
                            dataGridView1.Columns["tc"].DisplayIndex = 5;
                            dataGridView1.Columns["ad"].DisplayIndex = 6;
                            dataGridView1.Columns["soyad"].DisplayIndex = 7;
                            dataGridView1.Columns["cinsiyet"].DisplayIndex = 8;
                            dataGridView1.Columns["yasadigi_sehir_ad"].DisplayIndex = 9;
                            dataGridView1.Columns["dogum_tarih"].DisplayIndex = 10;
                            dataGridView1.Columns["telefon"].DisplayIndex = 11;
                            dataGridView1.Columns["email"].DisplayIndex = 12;
                            dataGridView1.Columns["koltuk_no"].DisplayIndex = 13;
                            dataGridView1.Columns["kalkis_tarih"].DisplayIndex = 14;
                            dataGridView1.Columns["varis_tarih"].DisplayIndex = 15;
                            dataGridView1.Columns["tutar"].DisplayIndex = 16;
                            dataGridView1.Columns["satismi_rezervasyonmu"].DisplayIndex = 17;
                            dataGridView1.Columns["satis_tip"].DisplayIndex = 18;
                            dataGridView1.Columns["kesim_tarih"].DisplayIndex = 19;

                            dataGridView1.Columns["satis_personeli"].HeaderText = "İŞLEMİ YAPAN";
                            dataGridView1.Columns["sefer_kodu"].HeaderText = "SEFER KODU";
                            dataGridView1.Columns["plaka"].HeaderText = "ARAÇ PLAKA";
                            dataGridView1.Columns["kalkis_sehir"].HeaderText = "NEREDEN";
                            dataGridView1.Columns["varis_sehir"].HeaderText = "NEREYE";
                            dataGridView1.Columns["tc"].HeaderText = "TC KİMLİK NO";
                            dataGridView1.Columns["ad"].HeaderText = "AD";
                            dataGridView1.Columns["soyad"].HeaderText = "SOYAD";
                            dataGridView1.Columns["cinsiyet"].HeaderText = "CİNSİYET";
                            dataGridView1.Columns["yasadigi_sehir_ad"].HeaderText = "YAŞADIĞI İL";
                            dataGridView1.Columns["dogum_tarih"].HeaderText = "DOĞUM TARİHİ";
                            dataGridView1.Columns["telefon"].HeaderText = "TELEFON";
                            dataGridView1.Columns["email"].HeaderText = "E MAİL";
                            dataGridView1.Columns["koltuk_no"].HeaderText = "KOLTUK NO";
                            dataGridView1.Columns["kalkis_tarih"].HeaderText = "KALKIŞ TARİH";
                            dataGridView1.Columns["varis_tarih"].HeaderText = "VARIŞ TARİH";
                            dataGridView1.Columns["tutar"].HeaderText = "TUTAR";
                            dataGridView1.Columns["satismi_rezervasyonmu"].HeaderText = "BİLET DURUMU";
                            dataGridView1.Columns["satis_tip"].HeaderText = "SATIŞ TÜRÜ";
                            dataGridView1.Columns["kesim_tarih"].HeaderText = "KESİM TARİH";
                        }
                        else
                        {
                            dataGridView1.DataSource = null;
                        }
                    }
                    else
                    {
                        if (ticketsalescont.ticketListSalesRegional(Convert.ToInt32(label5.Text)) != null)
                        {
                            dataGridView1.DataSource = ticketsalescont.ticketListSalesRegional(Convert.ToInt32(label5.Text));
                            dataGridView1.Columns["id"].Visible = false;
                            dataGridView1.Columns["yasadigi_sehir_id"].Visible = false;
                            dataGridView1.Columns["satis_tipleri_id"].Visible = false;

                            dataGridView1.Columns["satis_personeli"].DisplayIndex = 0;
                            dataGridView1.Columns["sefer_kodu"].DisplayIndex = 1;
                            dataGridView1.Columns["plaka"].DisplayIndex = 2;
                            dataGridView1.Columns["kalkis_sehir"].DisplayIndex = 3;
                            dataGridView1.Columns["varis_sehir"].DisplayIndex = 4;
                            dataGridView1.Columns["tc"].DisplayIndex = 5;
                            dataGridView1.Columns["ad"].DisplayIndex = 6;
                            dataGridView1.Columns["soyad"].DisplayIndex = 7;
                            dataGridView1.Columns["cinsiyet"].DisplayIndex = 8;
                            dataGridView1.Columns["yasadigi_sehir_ad"].DisplayIndex = 9;
                            dataGridView1.Columns["dogum_tarih"].DisplayIndex = 10;
                            dataGridView1.Columns["telefon"].DisplayIndex = 11;
                            dataGridView1.Columns["email"].DisplayIndex = 12;
                            dataGridView1.Columns["koltuk_no"].DisplayIndex = 13;
                            dataGridView1.Columns["kalkis_tarih"].DisplayIndex = 14;
                            dataGridView1.Columns["varis_tarih"].DisplayIndex = 15;
                            dataGridView1.Columns["tutar"].DisplayIndex = 16;
                            dataGridView1.Columns["satismi_rezervasyonmu"].DisplayIndex = 17;
                            dataGridView1.Columns["satis_tip"].DisplayIndex = 18;
                            dataGridView1.Columns["kesim_tarih"].DisplayIndex = 19;

                            dataGridView1.Columns["satis_personeli"].HeaderText = "İŞLEMİ YAPAN";
                            dataGridView1.Columns["sefer_kodu"].HeaderText = "SEFER KODU";
                            dataGridView1.Columns["plaka"].HeaderText = "ARAÇ PLAKA";
                            dataGridView1.Columns["kalkis_sehir"].HeaderText = "NEREDEN";
                            dataGridView1.Columns["varis_sehir"].HeaderText = "NEREYE";
                            dataGridView1.Columns["tc"].HeaderText = "TC KİMLİK NO";
                            dataGridView1.Columns["ad"].HeaderText = "AD";
                            dataGridView1.Columns["soyad"].HeaderText = "SOYAD";
                            dataGridView1.Columns["cinsiyet"].HeaderText = "CİNSİYET";
                            dataGridView1.Columns["yasadigi_sehir_ad"].HeaderText = "YAŞADIĞI İL";
                            dataGridView1.Columns["dogum_tarih"].HeaderText = "DOĞUM TARİHİ";
                            dataGridView1.Columns["telefon"].HeaderText = "TELEFON";
                            dataGridView1.Columns["email"].HeaderText = "E MAİL";
                            dataGridView1.Columns["koltuk_no"].HeaderText = "KOLTUK NO";
                            dataGridView1.Columns["kalkis_tarih"].HeaderText = "KALKIŞ TARİH";
                            dataGridView1.Columns["varis_tarih"].HeaderText = "VARIŞ TARİH";
                            dataGridView1.Columns["tutar"].HeaderText = "TUTAR";
                            dataGridView1.Columns["satismi_rezervasyonmu"].HeaderText = "BİLET DURUMU";
                            dataGridView1.Columns["satis_tip"].HeaderText = "SATIŞ TÜRÜ";
                            dataGridView1.Columns["kesim_tarih"].HeaderText = "KESİM TARİH";
                        }
                        else
                        {
                            dataGridView1.DataSource = null;
                        }
                    }
                }
                else if (radioButton1.Checked==true)
                {
                    if (label3.Text=="0")
                    {
                        if (ticketsalescont.ticketListRezervation() != null)
                        {
                            dataGridView1.DataSource = ticketsalescont.ticketListRezervation();
                            dataGridView1.Columns["id"].Visible = false;
                            dataGridView1.Columns["yasadigi_sehir_id"].Visible = false;
                            dataGridView1.Columns["satis_tipleri_id"].Visible = false;

                            dataGridView1.Columns["satis_personeli"].DisplayIndex = 0;
                            dataGridView1.Columns["sefer_kodu"].DisplayIndex = 1;
                            dataGridView1.Columns["plaka"].DisplayIndex = 2;
                            dataGridView1.Columns["kalkis_sehir"].DisplayIndex = 3;
                            dataGridView1.Columns["varis_sehir"].DisplayIndex = 4;
                            dataGridView1.Columns["tc"].DisplayIndex = 5;
                            dataGridView1.Columns["ad"].DisplayIndex = 6;
                            dataGridView1.Columns["soyad"].DisplayIndex = 7;
                            dataGridView1.Columns["cinsiyet"].DisplayIndex = 8;
                            dataGridView1.Columns["yasadigi_sehir_ad"].DisplayIndex = 9;
                            dataGridView1.Columns["dogum_tarih"].DisplayIndex = 10;
                            dataGridView1.Columns["telefon"].DisplayIndex = 11;
                            dataGridView1.Columns["email"].DisplayIndex = 12;
                            dataGridView1.Columns["koltuk_no"].DisplayIndex = 13;
                            dataGridView1.Columns["kalkis_tarih"].DisplayIndex = 14;
                            dataGridView1.Columns["varis_tarih"].DisplayIndex = 15;
                            dataGridView1.Columns["tutar"].DisplayIndex = 16;
                            dataGridView1.Columns["satismi_rezervasyonmu"].DisplayIndex = 17;
                            dataGridView1.Columns["satis_tip"].DisplayIndex = 18;
                            dataGridView1.Columns["kesim_tarih"].DisplayIndex = 19;

                            dataGridView1.Columns["satis_personeli"].HeaderText = "İŞLEMİ YAPAN";
                            dataGridView1.Columns["sefer_kodu"].HeaderText = "SEFER KODU";
                            dataGridView1.Columns["plaka"].HeaderText = "ARAÇ PLAKA";
                            dataGridView1.Columns["kalkis_sehir"].HeaderText = "NEREDEN";
                            dataGridView1.Columns["varis_sehir"].HeaderText = "NEREYE";
                            dataGridView1.Columns["tc"].HeaderText = "TC KİMLİK NO";
                            dataGridView1.Columns["ad"].HeaderText = "AD";
                            dataGridView1.Columns["soyad"].HeaderText = "SOYAD";
                            dataGridView1.Columns["cinsiyet"].HeaderText = "CİNSİYET";
                            dataGridView1.Columns["yasadigi_sehir_ad"].HeaderText = "YAŞADIĞI İL";
                            dataGridView1.Columns["dogum_tarih"].HeaderText = "DOĞUM TARİHİ";
                            dataGridView1.Columns["telefon"].HeaderText = "TELEFON";
                            dataGridView1.Columns["email"].HeaderText = "E MAİL";
                            dataGridView1.Columns["koltuk_no"].HeaderText = "KOLTUK NO";
                            dataGridView1.Columns["kalkis_tarih"].HeaderText = "KALKIŞ TARİH";
                            dataGridView1.Columns["varis_tarih"].HeaderText = "VARIŞ TARİH";
                            dataGridView1.Columns["tutar"].HeaderText = "TUTAR";
                            dataGridView1.Columns["satismi_rezervasyonmu"].HeaderText = "BİLET DURUMU";
                            dataGridView1.Columns["satis_tip"].HeaderText = "SATIŞ TÜRÜ";
                            dataGridView1.Columns["kesim_tarih"].HeaderText = "KESİM TARİH";
                        }
                        else
                        {
                            dataGridView1.DataSource = null;
                        }
                    }
                    else
                    {
                        if (ticketsalescont.ticketListRezervationRegional(Convert.ToInt32(label5.Text))!=null)
                        {
                            dataGridView1.DataSource = ticketsalescont.ticketListRezervationRegional(Convert.ToInt32(label5.Text));
                            dataGridView1.Columns["id"].Visible = false;
                            dataGridView1.Columns["yasadigi_sehir_id"].Visible = false;
                            dataGridView1.Columns["satis_tipleri_id"].Visible = false;

                            dataGridView1.Columns["satis_personeli"].DisplayIndex = 0;
                            dataGridView1.Columns["sefer_kodu"].DisplayIndex = 1;
                            dataGridView1.Columns["plaka"].DisplayIndex = 2;
                            dataGridView1.Columns["kalkis_sehir"].DisplayIndex = 3;
                            dataGridView1.Columns["varis_sehir"].DisplayIndex = 4;
                            dataGridView1.Columns["tc"].DisplayIndex = 5;
                            dataGridView1.Columns["ad"].DisplayIndex = 6;
                            dataGridView1.Columns["soyad"].DisplayIndex = 7;
                            dataGridView1.Columns["cinsiyet"].DisplayIndex = 8;
                            dataGridView1.Columns["yasadigi_sehir_ad"].DisplayIndex = 9;
                            dataGridView1.Columns["dogum_tarih"].DisplayIndex = 10;
                            dataGridView1.Columns["telefon"].DisplayIndex = 11;
                            dataGridView1.Columns["email"].DisplayIndex = 12;
                            dataGridView1.Columns["koltuk_no"].DisplayIndex = 13;
                            dataGridView1.Columns["kalkis_tarih"].DisplayIndex = 14;
                            dataGridView1.Columns["varis_tarih"].DisplayIndex = 15;
                            dataGridView1.Columns["tutar"].DisplayIndex = 16;
                            dataGridView1.Columns["satismi_rezervasyonmu"].DisplayIndex = 17;
                            dataGridView1.Columns["satis_tip"].DisplayIndex = 18;
                            dataGridView1.Columns["kesim_tarih"].DisplayIndex = 19;

                            dataGridView1.Columns["satis_personeli"].HeaderText = "İŞLEMİ YAPAN";
                            dataGridView1.Columns["sefer_kodu"].HeaderText = "SEFER KODU";
                            dataGridView1.Columns["plaka"].HeaderText = "ARAÇ PLAKA";
                            dataGridView1.Columns["kalkis_sehir"].HeaderText = "NEREDEN";
                            dataGridView1.Columns["varis_sehir"].HeaderText = "NEREYE";
                            dataGridView1.Columns["tc"].HeaderText = "TC KİMLİK NO";
                            dataGridView1.Columns["ad"].HeaderText = "AD";
                            dataGridView1.Columns["soyad"].HeaderText = "SOYAD";
                            dataGridView1.Columns["cinsiyet"].HeaderText = "CİNSİYET";
                            dataGridView1.Columns["yasadigi_sehir_ad"].HeaderText = "YAŞADIĞI İL";
                            dataGridView1.Columns["dogum_tarih"].HeaderText = "DOĞUM TARİHİ";
                            dataGridView1.Columns["telefon"].HeaderText = "TELEFON";
                            dataGridView1.Columns["email"].HeaderText = "E MAİL";
                            dataGridView1.Columns["koltuk_no"].HeaderText = "KOLTUK NO";
                            dataGridView1.Columns["kalkis_tarih"].HeaderText = "KALKIŞ TARİH";
                            dataGridView1.Columns["varis_tarih"].HeaderText = "VARIŞ TARİH";
                            dataGridView1.Columns["tutar"].HeaderText = "TUTAR";
                            dataGridView1.Columns["satismi_rezervasyonmu"].HeaderText = "BİLET DURUMU";
                            dataGridView1.Columns["satis_tip"].HeaderText = "SATIŞ TÜRÜ";
                            dataGridView1.Columns["kesim_tarih"].HeaderText = "KESİM TARİH";
                        }
                        else
                        {
                            dataGridView1.DataSource = null;
                        }
                    }
                }
            }
            else
            {
                if (radioButton2.Checked == true)
                {
                    dataGridView1.DataSource = null;
                }
                else if (radioButton1.Checked == true)
                {
                    dataGridView1.DataSource = null;
                }
            }
        }
        private void TicketTransactionForm_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
            listele();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listele();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listele();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked==true)
            {
                var ticketsalesmod = new TicketSalesModel();
                ticketsalesmod.ad = textBox1.Text;
                DataTable result = null;
                if (label3.Text=="0")
                {
                    result = ticketsalescont.ticketSalesSearch(ticketsalesmod);
                }
                else
                {
                    result = ticketsalescont.ticketSalesSearchRegional(ticketsalesmod,Convert.ToInt32(label5.Text));
                }
                if (result != null)
                {
                    if (textBox1.Text == "")
                    {
                        listele();
                        label4.Text = "Lütfen aranacak birşeyler yaz.";
                    }
                    else
                    {
                        dataGridView1.DataSource = result;
                        dataGridView1.Columns["id"].Visible = false;
                        dataGridView1.Columns["yasadigi_sehir_id"].Visible = false;

                        dataGridView1.Columns["satis_personeli"].DisplayIndex = 0;
                        dataGridView1.Columns["sefer_kodu"].DisplayIndex = 1;
                        dataGridView1.Columns["plaka"].DisplayIndex = 2;
                        dataGridView1.Columns["kalkis_sehir"].DisplayIndex = 3;
                        dataGridView1.Columns["varis_sehir"].DisplayIndex = 4;
                        dataGridView1.Columns["tc"].DisplayIndex = 5;
                        dataGridView1.Columns["ad"].DisplayIndex = 6;
                        dataGridView1.Columns["soyad"].DisplayIndex = 7;
                        dataGridView1.Columns["cinsiyet"].DisplayIndex = 8;
                        dataGridView1.Columns["yasadigi_sehir_ad"].DisplayIndex = 9;
                        dataGridView1.Columns["dogum_tarih"].DisplayIndex = 10;
                        dataGridView1.Columns["telefon"].DisplayIndex = 11;
                        dataGridView1.Columns["email"].DisplayIndex = 12;
                        dataGridView1.Columns["koltuk_no"].DisplayIndex = 13;
                        dataGridView1.Columns["kalkis_tarih"].DisplayIndex = 14;
                        dataGridView1.Columns["varis_tarih"].DisplayIndex = 15;
                        dataGridView1.Columns["tutar"].DisplayIndex = 16;
                        dataGridView1.Columns["satismi_rezervasyonmu"].DisplayIndex = 17;
                        dataGridView1.Columns["satis_tip"].DisplayIndex = 18;
                        dataGridView1.Columns["kesim_tarih"].DisplayIndex = 19;

                        dataGridView1.Columns["satis_personeli"].HeaderText = "İŞLEMİ YAPAN";
                        dataGridView1.Columns["sefer_kodu"].HeaderText = "SEFER KODU";
                        dataGridView1.Columns["plaka"].HeaderText = "ARAÇ PLAKA";
                        dataGridView1.Columns["kalkis_sehir"].HeaderText = "NEREDEN";
                        dataGridView1.Columns["varis_sehir"].HeaderText = "NEREYE";
                        dataGridView1.Columns["tc"].HeaderText = "TC KİMLİK NO";
                        dataGridView1.Columns["ad"].HeaderText = "AD";
                        dataGridView1.Columns["soyad"].HeaderText = "SOYAD";
                        dataGridView1.Columns["cinsiyet"].HeaderText = "CİNSİYET";
                        dataGridView1.Columns["yasadigi_sehir_ad"].HeaderText = "YAŞADIĞI İL";
                        dataGridView1.Columns["dogum_tarih"].HeaderText = "DOĞUM TARİHİ";
                        dataGridView1.Columns["telefon"].HeaderText = "TELEFON";
                        dataGridView1.Columns["email"].HeaderText = "E MAİL";
                        dataGridView1.Columns["koltuk_no"].HeaderText = "KOLTUK NO";
                        dataGridView1.Columns["kalkis_tarih"].HeaderText = "KALKIŞ TARİH";
                        dataGridView1.Columns["varis_tarih"].HeaderText = "VARIŞ TARİH";
                        dataGridView1.Columns["tutar"].HeaderText = "TUTAR";
                        dataGridView1.Columns["satismi_rezervasyonmu"].HeaderText = "BİLET DURUMU";
                        dataGridView1.Columns["satis_tip"].HeaderText = "SATIŞ TÜRÜ";
                        dataGridView1.Columns["kesim_tarih"].HeaderText = "KESİM TARİH";
                        label4.Text = result.Rows.Count.ToString() + " kayıt bulundu.";
                    }
                }
                else
                {
                    if (textBox1.Text == "")
                    {
                        label4.Text = "Lütfen aranacak birşeyler yaz.";
                    }
                    else
                    {
                        label4.Text = ticketsalesmod.ad + " ile kayıt bulunmuyor !";
                    }
                }
            }
            else if (radioButton1.Checked==true)
            {
                var ticketsalesmod = new TicketSalesModel();
                ticketsalesmod.ad = textBox1.Text;
                DataTable result = null;
                if (label3.Text == "0")
                {
                    result = ticketsalescont.ticketRezervationSearch(ticketsalesmod);
                }
                else
                {
                    result = ticketsalescont.ticketRezervationSearchRegional(ticketsalesmod, Convert.ToInt32(label5.Text));
                }
                if (result != null)
                {
                    if (textBox1.Text == "")
                    {
                        listele();
                        label4.Text = "Lütfen aranacak birşeyler yaz.";
                    }
                    else
                    {
                        dataGridView1.DataSource = result;
                        dataGridView1.Columns["id"].Visible = false;
                        dataGridView1.Columns["yasadigi_sehir_id"].Visible = false;

                        dataGridView1.Columns["satis_personeli"].DisplayIndex = 0;
                        dataGridView1.Columns["sefer_kodu"].DisplayIndex = 1;
                        dataGridView1.Columns["plaka"].DisplayIndex = 2;
                        dataGridView1.Columns["kalkis_sehir"].DisplayIndex = 3;
                        dataGridView1.Columns["varis_sehir"].DisplayIndex = 4;
                        dataGridView1.Columns["tc"].DisplayIndex = 5;
                        dataGridView1.Columns["ad"].DisplayIndex = 6;
                        dataGridView1.Columns["soyad"].DisplayIndex = 7;
                        dataGridView1.Columns["cinsiyet"].DisplayIndex = 8;
                        dataGridView1.Columns["yasadigi_sehir_ad"].DisplayIndex = 9;
                        dataGridView1.Columns["dogum_tarih"].DisplayIndex = 10;
                        dataGridView1.Columns["telefon"].DisplayIndex = 11;
                        dataGridView1.Columns["email"].DisplayIndex = 12;
                        dataGridView1.Columns["koltuk_no"].DisplayIndex = 13;
                        dataGridView1.Columns["kalkis_tarih"].DisplayIndex = 14;
                        dataGridView1.Columns["varis_tarih"].DisplayIndex = 15;
                        dataGridView1.Columns["tutar"].DisplayIndex = 16;
                        dataGridView1.Columns["satismi_rezervasyonmu"].DisplayIndex = 17;
                        dataGridView1.Columns["satis_tip"].DisplayIndex = 18;
                        dataGridView1.Columns["kesim_tarih"].DisplayIndex = 19;

                        dataGridView1.Columns["satis_personeli"].HeaderText = "İŞLEMİ YAPAN";
                        dataGridView1.Columns["sefer_kodu"].HeaderText = "SEFER KODU";
                        dataGridView1.Columns["plaka"].HeaderText = "ARAÇ PLAKA";
                        dataGridView1.Columns["kalkis_sehir"].HeaderText = "NEREDEN";
                        dataGridView1.Columns["varis_sehir"].HeaderText = "NEREYE";
                        dataGridView1.Columns["tc"].HeaderText = "TC KİMLİK NO";
                        dataGridView1.Columns["ad"].HeaderText = "AD";
                        dataGridView1.Columns["soyad"].HeaderText = "SOYAD";
                        dataGridView1.Columns["cinsiyet"].HeaderText = "CİNSİYET";
                        dataGridView1.Columns["yasadigi_sehir_ad"].HeaderText = "YAŞADIĞI İL";
                        dataGridView1.Columns["dogum_tarih"].HeaderText = "DOĞUM TARİHİ";
                        dataGridView1.Columns["telefon"].HeaderText = "TELEFON";
                        dataGridView1.Columns["email"].HeaderText = "E MAİL";
                        dataGridView1.Columns["koltuk_no"].HeaderText = "KOLTUK NO";
                        dataGridView1.Columns["kalkis_tarih"].HeaderText = "KALKIŞ TARİH";
                        dataGridView1.Columns["varis_tarih"].HeaderText = "VARIŞ TARİH";
                        dataGridView1.Columns["tutar"].HeaderText = "TUTAR";
                        dataGridView1.Columns["satismi_rezervasyonmu"].HeaderText = "BİLET DURUMU";
                        dataGridView1.Columns["satis_tip"].HeaderText = "SATIŞ TÜRÜ";
                        dataGridView1.Columns["kesim_tarih"].HeaderText = "KESİM TARİH";
                        label4.Text = result.Rows.Count.ToString() + " kayıt bulundu.";
                    }
                }
                else
                {
                    if (textBox1.Text == "")
                    {
                        label4.Text = "Lütfen aranacak birşeyler yaz.";
                    }
                    else
                    {
                        label4.Text = ticketsalesmod.ad + " ile kayıt bulunmuyor !";
                    }
                }
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            textBox1.Clear();
            label4.Text = "";
        }

        private void TicketTransactionForm_Activated(object sender, EventArgs e)
        {
            listele();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TicketEditForm ticketeditfrm = new TicketEditForm();
            ticketeditfrm.textBox1.Text = dataGridView1.SelectedRows[0].Cells["tc"].Value.ToString();
            ticketeditfrm.textBox2.Text = dataGridView1.SelectedRows[0].Cells["ad"].Value.ToString();
            ticketeditfrm.textBox3.Text = dataGridView1.SelectedRows[0].Cells["soyad"].Value.ToString();
            ticketeditfrm.textBox4.Text = dataGridView1.SelectedRows[0].Cells["telefon"].Value.ToString();
            ticketeditfrm.textBox5.Text = dataGridView1.SelectedRows[0].Cells["email"].Value.ToString();
            helpercont.comboFill("id", "ad", "SehirlerCombobox", ticketeditfrm.comboBox2);
            helpercont.comboFill("id", "ad", "SatisTipleriCombobox", ticketeditfrm.comboBox5);
            ticketeditfrm.comboBox2.SelectedValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["yasadigi_sehir_id"].Value);
            ticketeditfrm.comboBox5.SelectedValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["satis_tipleri_id"].Value);
            ticketeditfrm.dateTimePicker1.Value = Convert.ToDateTime(dataGridView1.SelectedRows[0].Cells["dogum_tarih"].Value.ToString());
            ticketeditfrm.textBox6.Text = dataGridView1.SelectedRows[0].Cells["sefer_kodu"].Value.ToString();
            ticketeditfrm.textBox7.Text = dataGridView1.SelectedRows[0].Cells["kalkis_sehir"].Value.ToString();
            ticketeditfrm.textBox8.Text = dataGridView1.SelectedRows[0].Cells["varis_sehir"].Value.ToString();
            ticketeditfrm.textBox9.Text = dataGridView1.SelectedRows[0].Cells["koltuk_no"].Value.ToString();
            ticketeditfrm.textBox10.Text = dataGridView1.SelectedRows[0].Cells["tutar"].Value.ToString();
            if (dataGridView1.SelectedRows[0].Cells["cinsiyet"].Value.ToString()=="ERKEK")
            {
                ticketeditfrm.radioButton7.Checked = true;
            }
            else
            {
                ticketeditfrm.radioButton4.Checked = true;
            }
            if (dataGridView1.SelectedRows[0].Cells["satismi_rezervasyonmu"].Value.ToString() == "SATIŞ")
            {
                ticketeditfrm.radioButton2.Checked = true;
            }
            else
            {
                ticketeditfrm.radioButton1.Checked = true;
            }
            ticketeditfrm.label20.Text = label20.Text;
            ticketeditfrm.label16.Text= dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
            ticketeditfrm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var ticketsalesmod = new TicketSalesModel();
            ticketsalesmod.id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
            ticketsalesmod.ad = dataGridView1.SelectedRows[0].Cells["ad"].Value.ToString();
            ticketsalesmod.soyad = dataGridView1.SelectedRows[0].Cells["soyad"].Value.ToString();
            ticketsalesmod.koltuk_no = Convert.ToByte(dataGridView1.SelectedRows[0].Cells["koltuk_no"].Value);
            var seferkodu = dataGridView1.SelectedRows[0].Cells["sefer_kodu"].Value.ToString();
            DialogResult yesorno = MessageBox.Show(seferkodu + " sefer kodlu " + ticketsalesmod.koltuk_no + " koltuk numarasına sahip " + ticketsalesmod.ad + " " + ticketsalesmod.soyad + " isimli yolcunun bileti silinmek üzere onaylıyor musunuz !", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (yesorno == DialogResult.Yes)
            {
                var result = ticketsalescont.delete(ticketsalesmod);
                if (result == true)
                {
                    MessageBox.Show("Bilet başarılı bir şekilde silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele();
                }
                else
                {
                    MessageBox.Show("Bilet silinirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    listele();
                }
            }
        }
    }
}
