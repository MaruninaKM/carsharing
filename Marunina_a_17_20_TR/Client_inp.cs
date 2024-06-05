using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Marunina_a_17_20_TR
{
    public partial class Client_inp : Form
    {
        public Client_inp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu_start frm1 = new Menu_start();
            frm1.Show();
            this.Hide();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox2.Text.Length == 0)
                if (e.KeyChar != 56) e.Handled = true;

            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (textBox2.Text.Length == 11) button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client_menu frm2 = new Client_menu(textBox2.Text);
            frm2.Show();
            this.Hide();
        }
    }
}
