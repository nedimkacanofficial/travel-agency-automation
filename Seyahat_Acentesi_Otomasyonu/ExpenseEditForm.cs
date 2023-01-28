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
    public partial class ExpenseEditForm : Form
    {
        ExpenseController expensecont = new ExpenseController();
        public ExpenseEditForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult yesorno = MessageBox.Show("Masraf güncellenmek üzere onaylıyor musunuz ?", "Dikkat !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (yesorno == DialogResult.Yes)
            {
                if (radioButton1.Checked)
                {
                    if (Convert.ToInt32(comboBox1.SelectedValue) == 0)
                    {
                        MessageBox.Show("Lütfen bir personel seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else if (Convert.ToInt32(comboBox2.SelectedValue) == 0)
                    {
                        MessageBox.Show("Lütfen bir araç seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else if (Convert.ToInt32(comboBox3.SelectedValue) == 0)
                    {
                        MessageBox.Show("Lütfen bir sefer seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else if (Convert.ToInt32(comboBox4.SelectedValue) == 0)
                    {
                        MessageBox.Show("Lütfen bir masraf türü seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else if (string.IsNullOrEmpty(textBox1.Text))
                    {
                        MessageBox.Show("Tutar boş geçilemez !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (textBox1.Text == ",")
                    {
                        MessageBox.Show("Lütfen geçerli bir tutar giriniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        var expensemod = new ExpenseModel();
                        expensemod.personeller_id = Convert.ToInt32(comboBox1.SelectedValue);
                        expensemod.araclar_id = Convert.ToInt32(comboBox2.SelectedValue);
                        expensemod.seferler_id = Convert.ToInt32(comboBox3.SelectedValue);
                        expensemod.masraf_tipleri_id = Convert.ToInt32(comboBox4.SelectedValue);
                        expensemod.tutar = Convert.ToDecimal(textBox1.Text);
                        expensemod.aciklama = textBox3.Text;
                        expensemod.masraf_tarih = DateTime.Now;
                        expensemod.id = Convert.ToInt32(label3.Text);
                        if (ValidationController.validControl(expensemod) == true)
                        {
                            var result = expensecont.carExpenseUpdate(expensemod);
                            if (result == true)
                            {
                                MessageBox.Show("Masraf başarılı bir şekilde güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Masraf güncellenirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
                else if (radioButton2.Checked)
                {
                    if (Convert.ToInt32(comboBox1.SelectedValue) == 0)
                    {
                        MessageBox.Show("Lütfen bir personel seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else if (Convert.ToInt32(comboBox4.SelectedValue) == 0)
                    {
                        MessageBox.Show("Lütfen masraf türü seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else if (string.IsNullOrEmpty(textBox1.Text))
                    {
                        MessageBox.Show("Tutar boş geçilemez !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (textBox1.Text == ",")
                    {
                        MessageBox.Show("Lütfen geçerli bir tutar giriniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    }
                    else
                    {
                        var expensemod = new ExpenseModel();
                        expensemod.personeller_id = Convert.ToInt32(comboBox1.SelectedValue);
                        expensemod.subeler_id = Convert.ToInt32(comboBox2.SelectedValue);
                        expensemod.masraf_tipleri_id = Convert.ToInt32(comboBox4.SelectedValue);
                        expensemod.tutar = Convert.ToDecimal(textBox1.Text);
                        expensemod.aciklama = textBox3.Text;
                        expensemod.masraf_tarih = DateTime.Now;
                        expensemod.id = Convert.ToInt32(label3.Text);
                        if (ValidationController.validControl(expensemod) == true)
                        {
                            var result = expensecont.deparmentExpenseUpdate(expensemod);
                            if (result == true)
                            {
                                MessageBox.Show("Masraf başarılı bir şekilde güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Masraf güncellenirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                    }
                }
            }
        }
    }
}
