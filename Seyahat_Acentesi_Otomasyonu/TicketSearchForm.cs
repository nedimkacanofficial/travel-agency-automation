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
    public partial class TicketSearchForm : Form
    {
        TicketSearchController ticketsearchcont = new TicketSearchController();
        public TicketSearchForm()
        {
            InitializeComponent();
        }
        void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            dateTimePicker1.ResetText();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var ticketsearchmod = new TicketSearchModel();
            ticketsearchmod.nereden = textBox1.Text;
            ticketsearchmod.nereye = textBox2.Text;
            ticketsearchmod.kalkis_tarih = dateTimePicker1.Value;
            if (ValidationController.validControl(ticketsearchmod) == true)
            {
                var result = ticketsearchcont.list(ticketsearchmod);
                if (result != null)
                {
                    dataGridView1.DataSource = result;
                    dataGridView1.Columns["seferler_id"].Visible = false;
                    dataGridView1.Columns["kalkis_id"].Visible = false;
                    dataGridView1.Columns["varis_id"].Visible = false;

                    dataGridView1.Columns["sefer_kodu"].DisplayIndex = 0;
                    dataGridView1.Columns["guzergah_kodu"].DisplayIndex = 1;
                    dataGridView1.Columns["plaka"].DisplayIndex = 2;
                    dataGridView1.Columns["kalkis"].DisplayIndex = 3;
                    dataGridView1.Columns["varis"].DisplayIndex = 4;
                    dataGridView1.Columns["arac_turu"].DisplayIndex = 5;
                    dataGridView1.Columns["koltuk_sayisi"].DisplayIndex = 6;
                    dataGridView1.Columns["kalkis_tarih"].DisplayIndex = 7;
                    dataGridView1.Columns["varis_tarih"].DisplayIndex = 8;
                    dataGridView1.Columns["sofor"].DisplayIndex = 9;
                    dataGridView1.Columns["muavin"].DisplayIndex = 10;
                    dataGridView1.Columns["arac_ici_ikram"].DisplayIndex = 11;
                    dataGridView1.Columns["wifi"].DisplayIndex = 12;
                    dataGridView1.Columns["tutar"].DisplayIndex = 13;

                    dataGridView1.Columns["sefer_kodu"].HeaderText = "SEFER KODU";
                    dataGridView1.Columns["guzergah_kodu"].HeaderText = "GUZERGAH KODU";
                    dataGridView1.Columns["plaka"].HeaderText = "ARAÇ PLAKA";
                    dataGridView1.Columns["kalkis"].HeaderText = "NEREDEN";
                    dataGridView1.Columns["varis"].HeaderText = "NEREYE";
                    dataGridView1.Columns["arac_turu"].HeaderText = "ARAÇ TÜRÜ";
                    dataGridView1.Columns["koltuk_sayisi"].HeaderText = "KOLTUK SAYISI";
                    dataGridView1.Columns["kalkis_tarih"].HeaderText = "KALKIŞ TARİH";
                    dataGridView1.Columns["varis_tarih"].HeaderText = "VARIŞ TARIH";
                    dataGridView1.Columns["sofor"].HeaderText = "ŞOFÖR";
                    dataGridView1.Columns["muavin"].HeaderText = "MUAVİN";
                    dataGridView1.Columns["arac_ici_ikram"].HeaderText = "ARAÇ İÇİ İKRAM";
                    dataGridView1.Columns["wifi"].HeaderText = "WİFİ";
                    dataGridView1.Columns["tutar"].HeaderText = "TUTAR";
                    label5.Text = result.Rows.Count.ToString() + " kayıt bulundu.";
                }
                else
                {
                    dataGridView1.DataSource = result;
                    label5.Text = "Belirtilen değerler ile\neşleşen sefer bulunmuyor !";
                }
            }
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.DataSource != null)
            {
                SeatSelectionForm seatselectionfrm = new SeatSelectionForm();
                int koltuk_sayisi = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["koltuk_sayisi"].Value);
                var ticketsearchmod = new TicketSearchModel();
                ticketsearchmod.nereden = dataGridView1.SelectedRows[0].Cells["seferler_id"].Value.ToString();
                if (koltuk_sayisi == 48)
                {
                    int soldan = 15, yukaridan = -35;
                    for (int i = 0; i < koltuk_sayisi; i++)
                    {
                        Button koltuk = new Button();
                        koltuk.Height = koltuk.Width = 50;
                        koltuk.Text = (i + 1).ToString();
                        koltuk.FlatStyle = FlatStyle.Flat;
                        koltuk.Cursor = Cursors.Hand;
                        koltuk.BackColor = Color.Gold;
                        koltuk.Click += new EventHandler(koltuk_Click);
                        if (i % 12 == 0)
                        {
                            soldan = 25;
                            yukaridan += 60;
                        }
                        koltuk.Top = yukaridan;
                        koltuk.Left = soldan;
                        seatselectionfrm.panel1.Controls.Add(koltuk);
                        soldan += 60;
                        ticketsearchmod.nereye = (i + 1).ToString();
                        var resultmale = ticketsearchcont.maleFilledSeatCheck(ticketsearchmod);
                        if (resultmale != null)
                        {
                            koltuk.BackColor = Color.Aqua;
                            koltuk.Enabled = false;
                        }
                        var resultfamele = ticketsearchcont.famaleFilledSeatCheck(ticketsearchmod);
                        if (resultfamele != null)
                        {
                            koltuk.BackColor = Color.FromArgb(255, 128, 128);
                            koltuk.Enabled = false;
                        }
                        var resultreservation = ticketsearchcont.reservationControl(ticketsearchmod);
                        if (resultreservation != null)
                        {
                            koltuk.BackColor = Color.Magenta;
                            koltuk.Enabled = false;
                        }
                    }
                }
                else
                {
                    int soldan = 15, yukaridan = -5;
                    for (int i = 0; i < koltuk_sayisi; i++)
                    {
                        Button koltuk = new Button();
                        koltuk.Height = koltuk.Width = 50;
                        koltuk.Text = (i + 1).ToString();
                        koltuk.FlatStyle = FlatStyle.Flat;
                        koltuk.Cursor = Cursors.Hand;
                        koltuk.BackColor = Color.Gold;
                        koltuk.Click += new EventHandler(koltuk_Click);
                        if (i % 12 == 0)
                        {
                            soldan = 25;
                            yukaridan += 60;
                        }
                        koltuk.Top = yukaridan;
                        koltuk.Left = soldan;
                        seatselectionfrm.panel1.Controls.Add(koltuk);
                        soldan += 60;
                        ticketsearchmod.nereye = (i + 1).ToString();
                        var resultmale = ticketsearchcont.maleFilledSeatCheck(ticketsearchmod);
                        if (resultmale != null)
                        {
                            koltuk.BackColor = Color.Aqua;
                            koltuk.Enabled = false;
                        }
                        var resultfamele = ticketsearchcont.famaleFilledSeatCheck(ticketsearchmod);
                        if (resultfamele != null)
                        {
                            koltuk.BackColor = Color.FromArgb(255, 128, 128);
                            koltuk.Enabled = false;
                        }
                        var resultreservation = ticketsearchcont.reservationControl(ticketsearchmod);
                        if (resultreservation != null)
                        {
                            koltuk.BackColor = Color.Magenta;
                            koltuk.Enabled = false;
                        }
                    }
                }
                seatselectionfrm.Show();
            }
        }
        public int tiklanan_koltuk_no { get; set; }
        public void koltuk_Click(object sender, EventArgs e)
        {
            // tıklanan Butonu yakala
            Button tiklananKoltuk = (Button)sender;
            tiklananKoltuk.BackColor = Color.Lime;
            tiklanan_koltuk_no = Convert.ToInt32(tiklananKoltuk.Text);
            TicketPurchaseForm ticketpurchasefrm = new TicketPurchaseForm();
            ticketpurchasefrm.label16.Text = dataGridView1.SelectedRows[0].Cells["seferler_id"].Value.ToString();
            ticketpurchasefrm.label17.Text = dataGridView1.SelectedRows[0].Cells["kalkis_id"].Value.ToString();
            ticketpurchasefrm.label19.Text = dataGridView1.SelectedRows[0].Cells["varis_id"].Value.ToString();
            ticketpurchasefrm.label22.Text = dataGridView1.SelectedRows[0].Cells["kalkis_tarih"].Value.ToString();
            ticketpurchasefrm.label23.Text = dataGridView1.SelectedRows[0].Cells["plaka"].Value.ToString();
            ticketpurchasefrm.label20.Text = label6.Text;

            ticketpurchasefrm.textBox6.Text = dataGridView1.SelectedRows[0].Cells["sefer_kodu"].Value.ToString();
            ticketpurchasefrm.textBox7.Text = dataGridView1.SelectedRows[0].Cells["kalkis"].Value.ToString();
            ticketpurchasefrm.textBox8.Text = dataGridView1.SelectedRows[0].Cells["varis"].Value.ToString();
            ticketpurchasefrm.textBox9.Text = tiklanan_koltuk_no.ToString();
            ticketpurchasefrm.textBox10.Text= dataGridView1.SelectedRows[0].Cells["tutar"].Value.ToString() + " ₺";
            ticketpurchasefrm.Show();
            tiklananKoltuk.BackColor = Color.Gold;
            SeatSelectionForm seatselectionfrm2 = new SeatSelectionForm();
            seatselectionfrm2.Close();
        }
        private void TicketSearchForm_Activated(object sender, EventArgs e)
        {
            clear();
            label5.Text="";
        }
    }
}