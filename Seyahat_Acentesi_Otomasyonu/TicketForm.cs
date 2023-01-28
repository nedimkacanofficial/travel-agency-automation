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
    public partial class TicketForm : Form
    {
        public TicketForm()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TicketSearchForm ticketsearchfrm = new TicketSearchForm();
            ticketsearchfrm.label6.Text = label1.Text;
            ticketsearchfrm.ShowDialog();
            this.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            TicketTransactionForm tickettransactionfrm = new TicketTransactionForm();
            tickettransactionfrm.label20.Text = label1.Text;
            tickettransactionfrm.label3.Text = label2.Text;
            tickettransactionfrm.label5.Text = label3.Text;
            tickettransactionfrm.ShowDialog();
            this.Close();
        }
    }
}
