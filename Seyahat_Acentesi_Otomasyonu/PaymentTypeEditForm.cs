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
    public partial class PaymentTypeEditForm : Form
    {
        PaymentTypeController paymenttypecont = new PaymentTypeController();
        public PaymentTypeEditForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult yesorno = MessageBox.Show("Ödeme türü güncellenmek üzere onaylıyor musunuz ?", "Dikkat !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (yesorno == DialogResult.Yes)
            {
                var paymenttypemod = new PaymentTypeModel();
                paymenttypemod.ad = textBox1.Text;
                paymenttypemod.id = Convert.ToInt32(label3.Text);
                if (ValidationController.validControl(paymenttypemod) == true)
                {
                    var control = paymenttypecont.registerControl(paymenttypemod);
                    if (control == false)
                    {
                        var result = paymenttypecont.update(paymenttypemod);
                        if (result == true)
                        {
                            MessageBox.Show("Ödeme türü başarılı bir şekilde güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Ödeme türü güncellenirken bir sorun ile karşılaşıldı !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ödeme türü zaten kayıtlı lütfen başka bir isim ile tekrar güncelleyin !", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
    }
}
