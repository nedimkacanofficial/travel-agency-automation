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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Seyahat_Acentesi_Otomasyonu
{
    public partial class RouteForm : Form
    {
        RouteController routecont = new RouteController();
        HelperController helpercont = new HelperController();
        public RouteForm()
        {
            InitializeComponent();
        }

        public void listele()
        {
            if (routecont.list()!=null)
            {
                dataGridView1.DataSource = routecont.list();
                dataGridView1.Columns["id"].Visible = false;
                dataGridView1.Columns["baslangic_durak_id"].Visible = false;
                dataGridView1.Columns["bitis_durak_id"].Visible = false;
                dataGridView1.Columns["subeler_id"].Visible = false;

                dataGridView1.Columns["guzergah_kodu"].DisplayIndex = 0;
                dataGridView1.Columns["sube"].DisplayIndex = 1;
                dataGridView1.Columns["baslangic_durak"].DisplayIndex = 2;
                dataGridView1.Columns["bitis_durak"].DisplayIndex = 3;
                dataGridView1.Columns["olusturma_tarih"].DisplayIndex = 4;

                dataGridView1.Columns["guzergah_kodu"].HeaderText = "GÜZERGAH ADI";
                dataGridView1.Columns["sube"].HeaderText = "GÜZERGAH ŞUBE";
                dataGridView1.Columns["baslangic_durak"].HeaderText = "BAŞLANGIÇ DURAK";
                dataGridView1.Columns["bitis_durak"].HeaderText = "BİTİŞ DURAK";
                dataGridView1.Columns["olusturma_tarih"].HeaderText = "KAYIT TARİH";
            }
            else
            {
                dataGridView1.DataSource = routecont.list();
            }
        }
        public void clear()
        {
            textBox1.Clear();
            comboBox1.SelectedValue = 0;
            comboBox2.SelectedValue = 0;
            comboBox3.SelectedValue = 0;
        }
        private void RouteForm_Load(object sender, EventArgs e)
        {
            listele();
            helpercont.comboFill("id","ad","SehirlerCombobox",comboBox2);
            helpercont.comboFill("id", "ad", "SehirlerCombobox", comboBox3);
            helpercont.comboFill("id", "ad", "SubelerCombobox", comboBox1);
            clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(comboBox1.SelectedValue) == 0)
            {
                MessageBox.Show("Lütfen bir şube seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (Convert.ToInt32(comboBox2.SelectedValue) == 0)
            {
                MessageBox.Show("Lütfen bir başlangıç durağı seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else if (Convert.ToInt32(comboBox3.SelectedValue) == 0)
            {
                MessageBox.Show("Lütfen bir bitiş durağı seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var routemod = new RouteModel();
                routemod.personeler_id = Convert.ToInt32(label7.Text);
                routemod.guzergah_kodu = textBox1.Text;
                routemod.baslangic_durak_id = Convert.ToInt32(comboBox2.SelectedValue);
                routemod.bitis_durak_id = Convert.ToInt32(comboBox3.SelectedValue);
                routemod.subeler_id = Convert.ToInt32(comboBox1.SelectedValue);
                if (ValidationController.validControl(routemod) == true)
                {
                    var routecontrol = routecont.registerControl(routemod);
                    if (routecontrol == false)
                    {
                        var result = routecont.insert(routemod);
                        if (result == true)
                        {
                            MessageBox.Show("Güzergah başarılı bir şekilde kayıt edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            listele();
                            clear();
                        }
                        else
                        {
                            MessageBox.Show("Güzergah kayıt edilirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            listele();
                            clear();
                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var routemod = new RouteModel();
            routemod.id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["id"].Value);
            routemod.guzergah_kodu = dataGridView1.SelectedRows[0].Cells["guzergah_kodu"].Value.ToString();
            DialogResult yesorno = MessageBox.Show(routemod.guzergah_kodu + " güzergahı silinecek !", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (yesorno == DialogResult.Yes)
            {
                var result = routecont.delete(routemod);
                if (result == true)
                {
                    MessageBox.Show("Güzergah başarılı bir şekilde silindi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listele();
                    clear();
                }
                else
                {
                    MessageBox.Show("Güzergah silinirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    listele();
                    clear();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RouteEditForm routeeditfrm = new RouteEditForm();
            helpercont.comboFill("id", "ad", "SehirlerCombobox", routeeditfrm.comboBox2);
            helpercont.comboFill("id", "ad", "SehirlerCombobox", routeeditfrm.comboBox3);
            helpercont.comboFill("id", "ad", "SubelerCombobox", routeeditfrm.comboBox1);
            routeeditfrm.label3.Text = dataGridView1.SelectedRows[0].Cells["id"].Value.ToString();
            routeeditfrm.label4.Text = label7.Text;
            routeeditfrm.textBox1.Text = dataGridView1.SelectedRows[0].Cells["guzergah_kodu"].Value.ToString();
            routeeditfrm.comboBox2.SelectedValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["baslangic_durak_id"].Value.ToString());
            routeeditfrm.comboBox3.SelectedValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["bitis_durak_id"].Value.ToString());
            routeeditfrm.comboBox1.SelectedValue = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["subeler_id"].Value.ToString());
            routeeditfrm.ShowDialog();
        }

        private void RouteForm_Activated(object sender, EventArgs e)
        {
            listele();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var routemod = new RouteModel();
            routemod.guzergah_kodu = textBox2.Text;
            var result = routecont.search(routemod);
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
                    dataGridView1.Columns["id"].Visible = false;
                    dataGridView1.Columns["baslangic_durak_id"].Visible = false;
                    dataGridView1.Columns["bitis_durak_id"].Visible = false;

                    dataGridView1.Columns["guzergah_kodu"].DisplayIndex = 0;
                    dataGridView1.Columns["sube"].DisplayIndex = 1;
                    dataGridView1.Columns["baslangic_durak"].DisplayIndex = 2;
                    dataGridView1.Columns["bitis_durak"].DisplayIndex = 3;
                    dataGridView1.Columns["olusturma_tarih"].DisplayIndex = 4;

                    dataGridView1.Columns["guzergah_kodu"].HeaderText = "GÜZERGAH ADI";
                    dataGridView1.Columns["sube"].HeaderText = "GÜZERGAH ŞUBE";
                    dataGridView1.Columns["baslangic_durak"].HeaderText = "BAŞLANGIÇ DURAK";
                    dataGridView1.Columns["bitis_durak"].HeaderText = "BİTİŞ DURAK";
                    dataGridView1.Columns["olusturma_tarih"].HeaderText = "KAYIT TARİH";
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
                    label4.Text = routemod.guzergah_kodu + " ile kayıt bulunmuyor !";
                }
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            textBox2.Clear();
            label4.Text = "";
        }
    }
}
