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
    public partial class DepartmentEditForm : Form
    {
        DepartmentController departmentcont = new DepartmentController();
        public DepartmentEditForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(comboBox1.SelectedValue) == 0)
            {
                MessageBox.Show("Lütfen bir şehir seçiniz !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult yesorno = MessageBox.Show("Şube güncellenmek üzere onaylıyor musunuz ?", "Dikkat !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (yesorno == DialogResult.Yes)
                {
                    var departmentmod = new DepartmentModel();
                    departmentmod.ad = textBox1.Text;
                    departmentmod.sehirler_id = Convert.ToInt32(comboBox1.SelectedValue);
                    departmentmod.id = Convert.ToInt32(label3.Text);
                    if (ValidationController.validControl(departmentmod) == true)
                    {
                        var control = departmentcont.registerControl(departmentmod);
                        if (control == false)
                        {
                            var result = departmentcont.update(departmentmod);
                            if (result == true)
                            {
                                MessageBox.Show("Şube başarılı bir şekilde güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Şube güncellenirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Close();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Şube zaten kayıtlı lütfen başka bir isim ile tekrar güncelleyin !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }
    }
}
