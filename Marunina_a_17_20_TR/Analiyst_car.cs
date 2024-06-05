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
    public partial class Analiyst_car : Form
    {
        private string connString;
        private NpgsqlConnection connect;

        private DataTable dt = new DataTable();
        private DataTable dt1 = new DataTable();
        private DataTable dt2 = new DataTable();
        private DataTable dt3 = new DataTable();
        private DataTable dt4 = new DataTable();

        public Analiyst_car(string qs)
        {
            InitializeComponent();
            textBox1.Text = qs;
            connString = "Host=localhost;Username=Analyst;Password=470019;Database=TR_a_17_20_Marunina_K_M";
            connect = new NpgsqlConnection(connString);
            try
            { connect.Open(); }
            catch (Exception ex)
            { MessageBox.Show("Cannot connect to Database. Please enter correct details"); }

            var sql1 = "select * from break_func(@a);";
            NpgsqlCommand da = new NpgsqlCommand(sql1, connect);
            da.Parameters.Add("@a", NpgsqlTypes.NpgsqlDbType.Varchar, 6);
            da.Parameters["@a"].Value = qs;
            NpgsqlDataReader npgSqlDataReader = da.ExecuteReader();
            dt.Load(npgSqlDataReader);
            dataGridView1.DataSource = dt;

            var sql2 = "select * from trip_func(@a);";
            NpgsqlCommand da1 = new NpgsqlCommand(sql2, connect);
            da1.Parameters.Add("@a", NpgsqlTypes.NpgsqlDbType.Varchar, 6);
            da1.Parameters["@a"].Value = qs;
            NpgsqlDataReader npgSqlDataReader1 = da1.ExecuteReader();
            dt1.Load(npgSqlDataReader);
            dataGridView2.DataSource = dt1;
        }
        public void textBox1_TextChanged(object sender, EventArgs e)
        {        }

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
            if (textBox1.Text.Length == 6) button1.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Analiyst frm1 = new Analiyst();
            frm1.Show();
            this.Hide();
            connect.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Info_car frm1 = new Info_car();
            frm1.Show();
            this.Hide();
            connect.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var sql4 = "call delite_break(@a);";
            NpgsqlCommand npgSqlCommand = new NpgsqlCommand(sql4, connect);
            npgSqlCommand.Parameters.Add("@a", NpgsqlTypes.NpgsqlDbType.Integer);
            npgSqlCommand.Parameters["@a"].Value = Convert.ToInt32(textBox2.Text);

            npgSqlCommand.ExecuteNonQuery();

            var sql1 = "select * from break_func(@a);";
            NpgsqlCommand da = new NpgsqlCommand(sql1, connect);
            da.Parameters.Add("@a", NpgsqlTypes.NpgsqlDbType.Varchar, 6);
            da.Parameters["@a"].Value = textBox1.Text;
            NpgsqlDataReader npgSqlDataReader = da.ExecuteReader();
            dt2.Load(npgSqlDataReader);
            dataGridView1.DataSource = dt2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var sql1 = "select * from break_func(@a);";
            NpgsqlCommand da = new NpgsqlCommand(sql1, connect);
            da.Parameters.Add("@a", NpgsqlTypes.NpgsqlDbType.Varchar, 6);
            da.Parameters["@a"].Value = textBox1.Text;
            NpgsqlDataReader npgSqlDataReader = da.ExecuteReader();
            dt3.Load(npgSqlDataReader);
            dataGridView1.DataSource = dt3;

            var sql2 = "select * from trip_func(@a);";
            NpgsqlCommand da1 = new NpgsqlCommand(sql2, connect);
            da1.Parameters.Add("@a", NpgsqlTypes.NpgsqlDbType.Varchar, 6);
            da1.Parameters["@a"].Value = textBox1.Text;
            NpgsqlDataReader npgSqlDataReader1 = da1.ExecuteReader();
            dt4.Load(npgSqlDataReader);
            dataGridView2.DataSource = dt4;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var sql3 = "call delite_car(@a);";
            NpgsqlCommand npgSqlCommand = new NpgsqlCommand(sql3, connect);
            npgSqlCommand.Parameters.Add("@a", NpgsqlTypes.NpgsqlDbType.Varchar,10);
            npgSqlCommand.Parameters["@a"].Value = textBox1.Text;

            npgSqlCommand.ExecuteNonQuery();

            Analiyst frm1 = new Analiyst();
            frm1.Show();
            this.Hide();
            connect.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (textBox2.Text.Length != 0) button6.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Insert_car frm2 = new Insert_car();
            frm2.Show();
            this.Hide();
            connect.Close();
        }
    }
}
