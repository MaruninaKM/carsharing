using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marunina_a_17_20_TR
{
    public partial class Menu_start : Form
    {
        public Menu_start()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client_inp frm2 = new Client_inp();
            frm2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Client_reg frm3 = new Client_reg();
            frm3.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Employee frm4 = new Employee();
            frm4.Show();
            this.Hide();
        }
    }
}
