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
    public partial class ExpenseTypeEditForm : Form
    {
        ExpenseTypeController expensetypecont = new ExpenseTypeController();
        public ExpenseTypeEditForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult yesorno = MessageBox.Show("Masraf türü güncellenmek üzere onaylıyor musunuz ?", "Dikkat !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (yesorno == DialogResult.Yes)
            {
                var expensetypemod = new ExpenseTypeModel();
                expensetypemod.ad = textBox1.Text;
                expensetypemod.id = Convert.ToInt32(label3.Text);
                if (ValidationController.validControl(expensetypemod) == true)
                {
                    var control = expensetypecont.registerControl(expensetypemod);
                    if (control == false)
                    {
                        var result = expensetypecont.update(expensetypemod);
                        if (result == true)
                        {
                            MessageBox.Show("Masraf türü başarılı bir şekilde güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Masraf türü güncellenirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Masraf türü zaten kayıtlı lütfen başka bir isim ile tekrar güncelle !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
