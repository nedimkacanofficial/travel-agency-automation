using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seyahat_Acentesi_Otomasyonu
{
    public partial class LoginForm : Form
    {
        LoginController logincont = new LoginController();
        VisitorsStatisticsController visitorsstatisticscont = new VisitorsStatisticsController();
        public LoginForm()
        {
            InitializeComponent();
        }
        void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var loginmod = new LoginModel();
            loginmod.kullanici_ad_veya_email = textBox1.Text;
            loginmod.sifre = logincont.convertToMd5(textBox2.Text);
            if (ValidationController.validControl(loginmod) == true)
            {
                var result = logincont.loginControl(loginmod);
                if (result != null)
                {
                    var visitorsstatisticsmod = new VisitorsStatisticsModel();
                    visitorsstatisticsmod.personeller_id = Convert.ToInt32(result.Rows[0]["id"].ToString());
                    visitorsstatisticscont.insert(visitorsstatisticsmod);
                    byte[] resim = new byte[0];
                    if (Convert.ToByte(result.Rows[0]["yetki_durum"]) == 0)
                    {
                        ManagerForm managerfrm = new ManagerForm();
                        this.Hide();
                        clear();
                        if (result.Rows[0]["personel_resmi"] !=DBNull.Value)
                        {
                            resim = (byte[])result.Rows[0]["personel_resmi"];
                            MemoryStream memoryStream = new MemoryStream(resim);
                            managerfrm.pictureBox1.Image = Image.FromStream(memoryStream);
                            managerfrm.label1.Text = result.Rows[0]["ad"] + " " + result.Rows[0]["soyad"];
                            managerfrm.label2.Text = result.Rows[0]["personel_tip"].ToString();
                            managerfrm.label3.Text = result.Rows[0]["sube"].ToString();
                            managerfrm.label44.Text = result.Rows[0]["id"].ToString();
                            managerfrm.label45.Text = result.Rows[0]["yetki_durum"].ToString();
                            managerfrm.label46.Text = result.Rows[0]["subeler_id"].ToString();
                            managerfrm.ShowDialog();
                        }
                        else
                        {
                            managerfrm.label1.Text = result.Rows[0]["ad"] + " " + result.Rows[0]["soyad"];
                            managerfrm.label2.Text = result.Rows[0]["personel_tip"].ToString();
                            managerfrm.label3.Text = result.Rows[0]["sube"].ToString();
                            managerfrm.label44.Text = result.Rows[0]["id"].ToString();
                            managerfrm.label45.Text = result.Rows[0]["yetki_durum"].ToString();
                            managerfrm.label46.Text = result.Rows[0]["subeler_id"].ToString();
                            managerfrm.ShowDialog();
                        }
                    }
                    else if (Convert.ToByte(result.Rows[0]["yetki_durum"]) == 1)
                    {
                        ManagerForm managerformregional = new ManagerForm();
                        this.Hide();
                        clear();
                        if (result.Rows[0]["personel_resmi"] != DBNull.Value)
                        {
                            resim = (byte[])result.Rows[0]["personel_resmi"];
                            MemoryStream memoryStream = new MemoryStream(resim);
                            managerformregional.pictureBox1.Image = Image.FromStream(memoryStream);
                            managerformregional.label1.Text = result.Rows[0]["ad"] + " " + result.Rows[0]["soyad"];
                            managerformregional.label2.Text = result.Rows[0]["personel_tip"].ToString();
                            managerformregional.label3.Text = result.Rows[0]["sube"].ToString();
                            managerformregional.label44.Text = result.Rows[0]["id"].ToString();
                            managerformregional.label45.Text = result.Rows[0]["yetki_durum"].ToString();
                            managerformregional.label46.Text = result.Rows[0]["subeler_id"].ToString();
                            managerformregional.button6.Visible = false;
                            managerformregional.button7.Visible = false;
                            managerformregional.button8.Visible = false;
                            managerformregional.button9.Visible = false;
                            managerformregional.button10.Visible = false;
                            managerformregional.button11.Visible = false;
                            managerformregional.button12.Visible = false;
                            managerformregional.button13.Visible = false;
                            managerformregional.button14.Visible = false;
                            managerformregional.panel21.Visible = false;
                            managerformregional.label8.Visible = false;
                            managerformregional.label9.Visible = false;
                            managerformregional.ShowDialog();
                        }
                        else
                        {
                            managerformregional.label1.Text = result.Rows[0]["ad"] + " " + result.Rows[0]["soyad"];
                            managerformregional.label2.Text = result.Rows[0]["personel_tip"].ToString();
                            managerformregional.label3.Text = result.Rows[0]["sube"].ToString();
                            managerformregional.label44.Text = result.Rows[0]["id"].ToString();
                            managerformregional.label45.Text = result.Rows[0]["yetki_durum"].ToString();
                            managerformregional.label46.Text = result.Rows[0]["subeler_id"].ToString();
                            managerformregional.button6.Visible = false;
                            managerformregional.button7.Visible = false;
                            managerformregional.button8.Visible = false;
                            managerformregional.button9.Visible = false;
                            managerformregional.button10.Visible = false;
                            managerformregional.button11.Visible = false;
                            managerformregional.button12.Visible = false;
                            managerformregional.button13.Visible = false;
                            managerformregional.button14.Visible = false;
                            managerformregional.panel21.Visible = false;
                            managerformregional.label8.Visible = false;
                            managerformregional.label9.Visible = false;
                            managerformregional.ShowDialog();
                        }
                    }
                    else
                    {
                        ManagerForm managerformemployee = new ManagerForm();
                        this.Hide();
                        clear();
                        if (result.Rows[0]["personel_resmi"] !=DBNull.Value)
                        {
                            resim = (byte[])result.Rows[0]["personel_resmi"];
                            MemoryStream memoryStream = new MemoryStream(resim);
                            managerformemployee.pictureBox1.Image = Image.FromStream(memoryStream);
                            managerformemployee.label1.Text = result.Rows[0]["ad"] + " " + result.Rows[0]["soyad"];
                            managerformemployee.label2.Text = result.Rows[0]["personel_tip"].ToString();
                            managerformemployee.label3.Text = result.Rows[0]["sube"].ToString();
                            managerformemployee.label44.Text = result.Rows[0]["id"].ToString();
                            managerformemployee.label45.Text = result.Rows[0]["yetki_durum"].ToString();
                            managerformemployee.label46.Text = result.Rows[0]["subeler_id"].ToString();
                            managerformemployee.button4.Visible = false;
                            managerformemployee.button5.Visible = false;
                            managerformemployee.button6.Visible = false;
                            managerformemployee.button7.Visible = false;
                            managerformemployee.button8.Visible = false;
                            managerformemployee.button9.Visible = false;
                            managerformemployee.button10.Visible = false;
                            managerformemployee.button11.Visible = false;
                            managerformemployee.button12.Visible = false;
                            managerformemployee.button13.Visible = false;
                            managerformemployee.button14.Visible = false;
                            managerformemployee.panel29.Visible = false;
                            managerformemployee.label24.Visible = false;
                            managerformemployee.label25.Visible = false;
                            managerformemployee.panel31.Visible = false;
                            managerformemployee.label28.Visible = false;
                            managerformemployee.label29.Visible = false;
                            managerformemployee.panel26.Visible = false;
                            managerformemployee.label19.Visible = false;
                            managerformemployee.label18.Visible = false;
                            managerformemployee.panel37.Visible = false;
                            managerformemployee.label41.Visible = false;
                            managerformemployee.label40.Visible = false;
                            managerformemployee.panel24.Visible = false;
                            managerformemployee.label14.Visible = false;
                            managerformemployee.label15.Visible = false;
                            managerformemployee.panel25.Visible = false;
                            managerformemployee.label16.Visible = false;
                            managerformemployee.label17.Visible = false;
                            managerformemployee.panel22.Visible = false;
                            managerformemployee.label10.Visible = false;
                            managerformemployee.label11.Visible = false;
                            managerformemployee.panel21.Visible = false;
                            managerformemployee.label8.Visible = false;
                            managerformemployee.label9.Visible = false;
                            managerformemployee.ShowDialog();
                        }
                        else
                        {
                            managerformemployee.label1.Text = result.Rows[0]["ad"] + " " + result.Rows[0]["soyad"];
                            managerformemployee.label2.Text = result.Rows[0]["personel_tip"].ToString();
                            managerformemployee.label3.Text = result.Rows[0]["sube"].ToString();
                            managerformemployee.label44.Text = result.Rows[0]["id"].ToString();
                            managerformemployee.label45.Text = result.Rows[0]["yetki_durum"].ToString();
                            managerformemployee.label46.Text = result.Rows[0]["subeler_id"].ToString();
                            managerformemployee.button4.Visible = false;
                            managerformemployee.button5.Visible = false;
                            managerformemployee.button6.Visible = false;
                            managerformemployee.button7.Visible = false;
                            managerformemployee.button8.Visible = false;
                            managerformemployee.button9.Visible = false;
                            managerformemployee.button10.Visible = false;
                            managerformemployee.button11.Visible = false;
                            managerformemployee.button12.Visible = false;
                            managerformemployee.button13.Visible = false;
                            managerformemployee.button14.Visible = false;
                            managerformemployee.ShowDialog();
                        }
                    }
                }
                else
                {
                    DialogResult control= MessageBox.Show("Böyle bir kullanıcı bulunmuyor !", "Hata !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Focus();
                    if (control == DialogResult.OK)
                    {
                        clear();
                    }
                    else
                    {
                        clear();
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
