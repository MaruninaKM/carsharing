using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Marunina_a_17_20_TR
{
    public partial class Analiyst : Form
    {
        private string connString;
        private NpgsqlConnection connect;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        private DataTable df = new DataTable();
        public Analiyst()
        {
            InitializeComponent();
            connString = "Host=localhost;Username=Analyst;Password=470019;Database=TR_a_17_20_Marunina_K_M";
            connect = new NpgsqlConnection(connString);

            try
            {
                //Открываем соединение.
                connect.Open();
            }
            catch (Exception ex)
            {
                //Код обработки ошибок
                MessageBox.Show("Cannot connect to Database. Please enter correct details");
            }
            var sql = "SELECT * from car order by id_area;";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, connect);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee frm1 = new Employee();
            frm1.Show();
            this.Hide();
            connect.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (textBox1.Text.Length == 0)
                if (e.KeyChar != 65 && e.KeyChar != 66 && e.KeyChar != 67 && e.KeyChar != 69 && e.KeyChar != 72 && e.KeyChar != 75 && e.KeyChar != 77 && e.KeyChar != 79 && e.KeyChar != 80 && e.KeyChar != 84 && e.KeyChar != 88 && e.KeyChar != 89 && e.KeyChar != 8)
                    e.Handled = true;
            if (textBox1.Text.Length == 1)
                if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                    e.Handled = true;
            if (textBox1.Text.Length == 2)
                if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                    e.Handled = true;
            if (textBox1.Text.Length == 3)
                if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                    e.Handled = true;
            if (textBox1.Text.Length == 4)
                if (e.KeyChar != 65 && e.KeyChar != 66 && e.KeyChar != 67 && e.KeyChar != 69 && e.KeyChar != 72 && e.KeyChar != 75 && e.KeyChar != 77 && e.KeyChar != 79 && e.KeyChar != 80 && e.KeyChar != 84 && e.KeyChar != 88 && e.KeyChar != 89 && e.KeyChar != 8)
                    e.Handled = true;
            if (textBox1.Text.Length == 5)
                if (e.KeyChar != 65 && e.KeyChar != 66 && e.KeyChar != 67 && e.KeyChar != 69 && e.KeyChar != 72 && e.KeyChar != 75 && e.KeyChar != 77 && e.KeyChar != 79 && e.KeyChar != 80 && e.KeyChar != 84 && e.KeyChar != 88 && e.KeyChar != 89 && e.KeyChar != 8)
                    e.Handled = true;
            if (textBox1.Text.Length == 6) button2.Enabled = true;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Analiyst_car frm2 = new Analiyst_car(textBox1.Text);
            frm2.Show();
        }

        
    }
}
