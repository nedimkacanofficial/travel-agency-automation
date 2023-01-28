using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Device.Location;

namespace Seyahat_Acentesi_Otomasyonu
{
    public partial class ManagerForm : Form
    {
        ManagerController managercont = new ManagerController();
        ManagerRegionalController managerregionalcont = new ManagerRegionalController();
        EmployeeController employeecont = new EmployeeController();
        WeatherApiController weatherapicont = new WeatherApiController();
        VisitorsStatisticsController visitorsstatisticscont = new VisitorsStatisticsController();
        public ManagerForm()
        {
            InitializeComponent();
        }

        private void ManagerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult exit = MessageBox.Show("Oturum sonlandırılacak eminmisiniz ?", "Dikkat !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (exit == DialogResult.Yes)
            {
                var visitorsstatisticsmod = new VisitorsStatisticsModel();
                visitorsstatisticsmod.cikis_tarih = DateTime.Now;
                visitorsstatisticsmod.personeller_id = Convert.ToInt32(label44.Text);
                visitorsstatisticscont.update(visitorsstatisticsmod);
                LoginForm loginfrm = new LoginForm();
                this.Hide();
                loginfrm.Show();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TicketForm ticketfrm = new TicketForm();
            ticketfrm.label1.Text = label44.Text;//id
            ticketfrm.label2.Text = label45.Text;//yetki_durum
            ticketfrm.label3.Text = label46.Text;//subeler_id
            ticketfrm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VoyageForm voyagefrm = new VoyageForm();
            voyagefrm.label7.Text = label44.Text;//id
            voyagefrm.label15.Text = label45.Text;//yetki_durum
            voyagefrm.label16.Text = label46.Text;//subeler_id
            voyagefrm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ExpenseForm expensefrm = new ExpenseForm();
            expensefrm.label11.Text = label44.Text;//id
            expensefrm.label12.Text = label45.Text;//yetki_durum
            expensefrm.label13.Text = label46.Text;//subeler_id
            expensefrm.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            VehicleForm vehiclefrm = new VehicleForm();
            vehiclefrm.label13.Text = label44.Text;//id
            vehiclefrm.label14.Text = label45.Text;//yetki_durum
            vehiclefrm.label15.Text = label46.Text;//subeler_id
            vehiclefrm.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PersonnelForm personnelfrm = new PersonnelForm();
            personnelfrm.label12.Text = label44.Text;//id
            personnelfrm.label20.Text = label45.Text;//yetki_durum
            personnelfrm.label21.Text = label46.Text;//subeler_id
            if (label45.Text=="0")
            {
                personnelfrm.radioButton3.Visible = true;
                personnelfrm.radioButton3.Checked = true;
            }
            else
            {
                personnelfrm.button5.Visible = false;
                personnelfrm.radioButton3.Visible = false;
                personnelfrm.radioButton7.Checked = true;
            }
            personnelfrm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            StationForm stationfrm = new StationForm();
            stationfrm.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            PersonnelTitleForm personneltitlefrm = new PersonnelTitleForm();
            personneltitlefrm.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RouteForm routefrm = new RouteForm();
            routefrm.label7.Text = label44.Text;
            routefrm.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            VehicleBrandForm vehiclebrandfrm = new VehicleBrandForm();
            vehiclebrandfrm.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            VehicleTypeForm vehicletypefrm = new VehicleTypeForm();
            vehicletypefrm.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DepartmentForm departmentfrm = new DepartmentForm();
            departmentfrm.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            ExpenseTypeForm expensetypefrm = new ExpenseTypeForm();
            expensetypefrm.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            CityForm cityfrm = new CityForm();
            cityfrm.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            PaymentTypeForm paymenttypefrm = new PaymentTypeForm();
            paymenttypefrm.ShowDialog();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            UserForm userfrm = new UserForm();
            var helpercont = new HelperController();
            var personnelcont = new PersonnelController();
            var personnelmod = new PersonnelModel();
            personnelmod.id = Convert.ToInt32(label44.Text);
            var result = personnelcont.usereditlist(personnelmod);
            if (result!=null)
            {
                helpercont.comboFill("id", "ad", "SehirlerCombobox", userfrm.comboBox1);
                userfrm.comboBox1.SelectedValue = Convert.ToInt32(result.Rows[0]["sehirler_id"]);
                userfrm.label3.Text = label44.Text;
                userfrm.textBox1.Text = result.Rows[0]["tc"].ToString();
                userfrm.textBox3.Text = result.Rows[0]["ad"].ToString();
                userfrm.textBox5.Text = result.Rows[0]["soyad"].ToString();
                userfrm.dateTimePicker1.Value = Convert.ToDateTime(result.Rows[0]["dogum_tarih"]);
                userfrm.textBox6.Text = result.Rows[0]["telefon"].ToString();
                if (Convert.ToBoolean(result.Rows[0]["cinsiyet"])==true)
                {
                    userfrm.radioButton1.Checked = true;
                }
                else
                {
                    userfrm.radioButton2.Checked = true;
                }
                userfrm.textBox10.Text = result.Rows[0]["adres"].ToString();
                userfrm.textBox8.Text = result.Rows[0]["email"].ToString();
                userfrm.textBox4.Text = result.Rows[0]["kullanici_ad"].ToString();
            }
            byte[] resim = new byte[0];
            if (result.Rows[0]["personel_resmi"] != DBNull.Value)
            {
                resim = (byte[])result.Rows[0]["personel_resmi"];
                MemoryStream memoryStream = new MemoryStream(resim);
                userfrm.pictureBox1.Image = Image.FromStream(memoryStream);
                userfrm.ShowDialog();
            }
            else
            {
                userfrm.ShowDialog();
            }
        }
        void homePage()
        {
            if (label45.Text=="0")
            {
                // Personel Sayısı
                var result1 = managercont.personelCountList();
                label15.Text = result1.Rows[0]["personel_sayisi"].ToString();
                // Günlük Masraf
                var result2 = managercont.dayExpenseAmount();
                label27.Text = result2.Rows[0]["gunluk_masraf"].ToString() + " ₺";
                // Aylık Masraf
                var result3 = managercont.monthExpenseAmount();
                label20.Text = result3.Rows[0]["aylik_masraf"].ToString() + " ₺";
                // Yıllık Masraf
                var result4 = managercont.yearExpenseAmount();
                label34.Text = result4.Rows[0]["yillik_masraf"].ToString() + " ₺";
                // Toplam Masraf
                var result5 = managercont.totalExpenseAmount();
                label42.Text = result5.Rows[0]["toplam_masraf"].ToString() + " ₺";
                // Araç Sayısı
                var result6 = managercont.carCountList();
                label17.Text = result6.Rows[0]["arac_sayisi"].ToString();
                // Sube Sayısı
                var result7 = managercont.departmentCountList();
                label9.Text = result7.Rows[0]["sube_sayisi"].ToString();
                // Günlük Sefer Sayısı
                var result8 = managercont.dayVoyageCount();
                label7.Text = result8.Rows[0]["gunluk_sefer_sayisi"].ToString();
                // Aylık Sefer Sayısı
                var result9 = managercont.monthVoyageCount();
                label33.Text = result9.Rows[0]["aylik_sefer_sayisi"].ToString();
                // Yıllık Sefer Sayısı
                var result10 = managercont.yearVoyageCount();
                label31.Text = result10.Rows[0]["yillik_sefer_sayisi"].ToString();
                // Toplam Sefer Sayısı
                var result11 = managercont.totalVoyageCount();
                label38.Text = result11.Rows[0]["toplam_sefer_sayisi"].ToString();
                // Güzergah Sayısı
                var result12 = managercont.routeCount();
                label11.Text = result12.Rows[0]["guzergah_sayisi"].ToString();
                // Günlük Satılan Bilet Sayısı
                var result13 = managercont.dailyTickets();
                label5.Text = result13.Rows[0]["gunluk_satilan_bilet"].ToString();
                // Aylık Satılan Bilet Sayısı
                var result14 = managercont.monthlyTickets();
                label13.Text = result14.Rows[0]["aylik_satilan_bilet"].ToString();
                // Yıllık Satılan Bilet Sayısı
                var result15 = managercont.yearlyTickets();
                label23.Text = result15.Rows[0]["yillik_satilan_bilet"].ToString();
                // Toplam Satılan Bilet Sayısı
                var result16 = managercont.totalTickets();
                label36.Text = result16.Rows[0]["toplam_satilan_bilet"].ToString();
                // Gunluk Kazanc Tutarı
                var result17 = managercont.dailyEarnings();
                label25.Text = result17.Rows[0]["gunluk_kazanc"].ToString() + " ₺";
                // Aylık Kazanc Tutarı
                var result18 = managercont.monthlyEarnings();
                label29.Text = result18.Rows[0]["aylik_kazanc"].ToString() + " ₺";
                // Yıllık Kazanc Tutarı
                var result19 = managercont.yearlyEarnings();
                label18.Text = result19.Rows[0]["yillik_kazanc"].ToString() + " ₺";
                // Toplam Kazanc Tutarı
                var result20 = managercont.totalEarnings();
                label40.Text = result20.Rows[0]["toplam_kazanc"].ToString() + " ₺";
            }
            else if (label45.Text=="1")
            {
                // Personel Sayısı
                var result1 = managerregionalcont.personelCountList(Convert.ToInt32(label46.Text));
                label15.Text = result1.Rows[0]["personel_sayisi"].ToString();
                // Günlük Masraf
                var result2 = managerregionalcont.dayExpenseAmount(Convert.ToInt32(label46.Text));
                label27.Text = result2.Rows[0]["gunluk_masraf"].ToString() + " ₺";
                // Aylık Masraf
                var result3 = managerregionalcont.monthExpenseAmount(Convert.ToInt32(label46.Text));
                label20.Text = result3.Rows[0]["aylik_masraf"].ToString() + " ₺";
                // Yıllık Masraf
                var result4 = managerregionalcont.yearExpenseAmount(Convert.ToInt32(label46.Text));
                label34.Text = result4.Rows[0]["yillik_masraf"].ToString() + " ₺";
                // Toplam Masraf
                var result5 = managerregionalcont.totalExpenseAmount(Convert.ToInt32(label46.Text));
                label42.Text = result5.Rows[0]["toplam_masraf"].ToString() + " ₺";
                // Araç Sayısı
                var result6 = managerregionalcont.carCountList(Convert.ToInt32(label46.Text));
                label17.Text = result6.Rows[0]["arac_sayisi"].ToString();
                // Günlük Sefer Sayısı
                var result8 = managerregionalcont.dayVoyageCount(Convert.ToInt32(label46.Text));
                label7.Text = result8.Rows[0]["gunluk_sefer_sayisi"].ToString();
                // Aylık Sefer Sayısı
                var result9 = managerregionalcont.monthVoyageCount(Convert.ToInt32(label46.Text));
                label33.Text = result9.Rows[0]["aylik_sefer_sayisi"].ToString();
                // Yıllık Sefer Sayısı
                var result10 = managerregionalcont.yearVoyageCount(Convert.ToInt32(label46.Text));
                label31.Text = result10.Rows[0]["yillik_sefer_sayisi"].ToString();
                // Toplam Sefer Sayısı
                var result11 = managerregionalcont.totalVoyageCount(Convert.ToInt32(label46.Text));
                label38.Text = result11.Rows[0]["toplam_sefer_sayisi"].ToString();
                // Güzergah Sayısı
                var result12 = managerregionalcont.routeCount(Convert.ToInt32(label46.Text));
                label11.Text = result12.Rows[0]["guzergah_sayisi"].ToString();
                // Günlük Satılan Bilet Sayısı
                var result13 = managerregionalcont.dailyTickets(Convert.ToInt32(label46.Text));
                label5.Text = result13.Rows[0]["gunluk_satilan_bilet"].ToString();
                // Aylık Satılan Bilet Sayısı
                var result14 = managerregionalcont.monthlyTickets(Convert.ToInt32(label46.Text));
                label13.Text = result14.Rows[0]["aylik_satilan_bilet"].ToString();
                // Yıllık Satılan Bilet Sayısı
                var result15 = managerregionalcont.yearlyTickets(Convert.ToInt32(label46.Text));
                label23.Text = result15.Rows[0]["yillik_satilan_bilet"].ToString();
                // Toplam Satılan Bilet Sayısı
                var result16 = managerregionalcont.totalTickets(Convert.ToInt32(label46.Text));
                label36.Text = result16.Rows[0]["toplam_satilan_bilet"].ToString();
                // Gunluk Kazanc Tutarı
                var result17 = managerregionalcont.dailyEarnings(Convert.ToInt32(label46.Text));
                label25.Text = result17.Rows[0]["gunluk_kazanc"].ToString() + " ₺";
                // Aylık Kazanc Tutarı
                var result18 = managerregionalcont.monthlyEarnings(Convert.ToInt32(label46.Text));
                label29.Text = result18.Rows[0]["aylik_kazanc"].ToString() + " ₺";
                // Yıllık Kazanc Tutarı
                var result19 = managerregionalcont.yearlyEarnings(Convert.ToInt32(label46.Text));
                label18.Text = result19.Rows[0]["yillik_kazanc"].ToString() + " ₺";
                // Toplam Kazanc Tutarı
                var result20 = managerregionalcont.totalEarnings(Convert.ToInt32(label46.Text));
                label40.Text = result20.Rows[0]["toplam_kazanc"].ToString() + " ₺";
            }
            else if (label45.Text=="2")
            {
                // Günlük Masraf
                var result2 = employeecont.dayExpenseAmount(Convert.ToInt32(label46.Text), Convert.ToInt32(label44.Text));
                label27.Text = result2.Rows[0]["gunluk_masraf"].ToString() + " ₺";
                // Aylık Masraf
                var result3 = employeecont.monthExpenseAmount(Convert.ToInt32(label46.Text), Convert.ToInt32(label44.Text));
                label20.Text = result3.Rows[0]["aylik_masraf"].ToString() + " ₺";
                // Yıllık Masraf
                var result4 = employeecont.yearExpenseAmount(Convert.ToInt32(label46.Text), Convert.ToInt32(label44.Text));
                label34.Text = result4.Rows[0]["yillik_masraf"].ToString() + " ₺";
                // Toplam Masraf
                var result5 = employeecont.totalExpenseAmount(Convert.ToInt32(label46.Text), Convert.ToInt32(label44.Text));
                label42.Text = result5.Rows[0]["toplam_masraf"].ToString() + " ₺";
                // Günlük Sefer Sayısı
                var result8 = employeecont.dayVoyageCount(Convert.ToInt32(label46.Text), Convert.ToInt32(label44.Text));
                label7.Text = result8.Rows[0]["gunluk_sefer_sayisi"].ToString();
                // Aylık Sefer Sayısı
                var result9 = employeecont.monthVoyageCount(Convert.ToInt32(label46.Text), Convert.ToInt32(label44.Text));
                label33.Text = result9.Rows[0]["aylik_sefer_sayisi"].ToString();
                // Yıllık Sefer Sayısı
                var result10 = employeecont.yearVoyageCount(Convert.ToInt32(label46.Text), Convert.ToInt32(label44.Text));
                label31.Text = result10.Rows[0]["yillik_sefer_sayisi"].ToString();
                // Toplam Sefer Sayısı
                var result11 = employeecont.totalVoyageCount(Convert.ToInt32(label46.Text), Convert.ToInt32(label44.Text));
                label38.Text = result11.Rows[0]["toplam_sefer_sayisi"].ToString();
                // Günlük Satılan Bilet Sayısı
                var result13 = employeecont.dailyTickets(Convert.ToInt32(label46.Text), Convert.ToInt32(label44.Text));
                label5.Text = result13.Rows[0]["gunluk_satilan_bilet"].ToString();
                // Aylık Satılan Bilet Sayısı
                var result14 = employeecont.monthlyTickets(Convert.ToInt32(label46.Text), Convert.ToInt32(label44.Text));
                label13.Text = result14.Rows[0]["aylik_satilan_bilet"].ToString();
                // Yıllık Satılan Bilet Sayısı
                var result15 = employeecont.yearlyTickets(Convert.ToInt32(label46.Text), Convert.ToInt32(label44.Text));
                label23.Text = result15.Rows[0]["yillik_satilan_bilet"].ToString();
                // Toplam Satılan Bilet Sayısı
                var result16 = employeecont.totalTickets(Convert.ToInt32(label46.Text), Convert.ToInt32(label44.Text));
                label36.Text = result16.Rows[0]["toplam_satilan_bilet"].ToString();
            }
        }
        private void ManagerForm_Load(object sender, EventArgs e)
        {
            homePage();
            weatherapicont.weatherForecast(pictureBox2, label49, label51, label52, label50, label48, textBox1, label53);
        }

        private void ManagerForm_Activated(object sender, EventArgs e)
        {
            homePage();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            weatherapicont.weatherForecast(pictureBox2, label49, label51, label52, label50, label48, textBox1, label53);
        }
    }
}
