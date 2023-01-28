using Controller;
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
    public partial class VisitorsStatisticsForm : Form
    {
        VisitorsStatisticsController visitorsstatisticscont = new VisitorsStatisticsController();
        public VisitorsStatisticsForm()
        {
            InitializeComponent();
        }
        void listele()
        {
            if (visitorsstatisticscont.listLastVisitor() != null)
            {
                dataGridView1.DataSource = visitorsstatisticscont.listLastVisitor();
                dataGridView1.Columns["adsoyad"].HeaderText = "AD SOYAD";
                dataGridView1.Columns["cinsiyet"].HeaderText = "CİNSİYET";
                dataGridView1.Columns["email"].HeaderText = "E MAİL";
                dataGridView1.Columns["telefon"].HeaderText = "TELEFON";
                dataGridView1.Columns["yetki_durum"].HeaderText = "YETKİ";
                dataGridView1.Columns["unvan"].HeaderText = "UNVAN";
                dataGridView1.Columns["sube"].HeaderText = "ŞUBE";
                dataGridView1.Columns["giris_tarih"].HeaderText = "GİRİŞ TARİH";
                dataGridView1.Columns["cikis_tarih"].HeaderText = "ÇIKIŞ TARİH";
            }
            else
            {
                dataGridView1.DataSource = null;
            }
            var activeuserlist= visitorsstatisticscont.activeUserList();
            label5.Text = activeuserlist.Rows[0]["aktif_kullanici"].ToString();
            var dayvisitorlist = visitorsstatisticscont.dayVisitorList();
            label2.Text = dayvisitorlist.Rows[0]["gunluk_ziyaretci"].ToString();
            var monthvisitorlist = visitorsstatisticscont.monthVisitorList();
            label6.Text = monthvisitorlist.Rows[0]["aylik_ziyaretci"].ToString();
            var yearvisitorlist = visitorsstatisticscont.yearVisitorList();
            label8.Text = yearvisitorlist.Rows[0]["yillik_ziyaretci"].ToString();
            var totalvisitorlist = visitorsstatisticscont.totalVisitorList();
            label10.Text = totalvisitorlist.Rows[0]["toplam_ziyaretci"].ToString();
        }
        private void VisitorsStatisticsForm_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void VisitorsStatisticsForm_Activated(object sender, EventArgs e)
        {
            listele();
        }
    }
}
