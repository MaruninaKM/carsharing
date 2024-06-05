using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Marunina_a_17_20_TR
{
    public partial class Employee : Form
    {
        public Employee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Menu_start frm1 = new Menu_start();
            frm1.Show();
            this.Hide();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool f = false;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
            { e.Handled = true;
                f = true;
            }
           if ( f == true && textBox1.Text.Length == 6) button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "260291") {
                Director frm1 = new Director();
                frm1.Show();
                this.Hide();
            }
            if (textBox1.Text == "868575")
            {
                Operator frm2 = new Operator();
                frm2.Show();
                this.Hide();
            }
            if (textBox1.Text == "470019")
            {
                Analiyst frm3 = new Analiyst();
                frm3.Show();
                this.Hide();
            }
        }
    }
}
