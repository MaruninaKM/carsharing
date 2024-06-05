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
    public partial class Bron : Form
    {
        private string connString;
        private NpgsqlConnection connect;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        private DataTable dt2 = new DataTable();
        private DataTable df = new DataTable();
        public Bron(Int64 q)
        {
            InitializeComponent();
            label9.Text = Convert.ToString(q);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connString = "Host=localhost;Username=postgres;Password=tumblergirl;Database=TR_a_17_20_Marunina_K_M";
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
            string str = comboBox1.Text;
            string str2 = comboBox3.Text;
            var sql = "select id_area, id_car from car where id_area = " + str + " and classs = '" + str2 + "';";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, connect);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;

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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client_inp frm1 = new Client_inp();
            frm1.Show();
            this.Hide();
            connect.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Int64 nomcl = Convert.ToInt64(label9.Text);
            int ar1 = Convert.ToInt32(comboBox1.Text);
            int ar2 = Convert.ToInt32(comboBox2.Text);
            string ncar = textBox1.Text;
            DateTime dat = DateTime.UtcNow.Date;

            var sql1 = "select * from peregon(@a,@b);";
            NpgsqlCommand npgSqlCommand1 = new NpgsqlCommand(sql1, connect);
            npgSqlCommand1.Parameters.Add("@a", NpgsqlTypes.NpgsqlDbType.Integer);
            npgSqlCommand1.Parameters["@a"].Value = ar2;
            npgSqlCommand1.Parameters.Add("@b", NpgsqlTypes.NpgsqlDbType.Varchar);
            npgSqlCommand1.Parameters["@b"].Value = ncar;
            npgSqlCommand1.ExecuteNonQuery();

            var sql2 = "call insert_trip(@b1,@c,@d);";
            NpgsqlCommand npgSqlCommand2 = new NpgsqlCommand(sql2, connect);
            npgSqlCommand2.Parameters.Add("@b1", NpgsqlTypes.NpgsqlDbType.Varchar,10);
            npgSqlCommand2.Parameters["@b1"].Value = ncar;
            npgSqlCommand2.Parameters.Add("@c", NpgsqlTypes.NpgsqlDbType.Bigint);
            npgSqlCommand2.Parameters["@c"].Value = nomcl;
            npgSqlCommand2.Parameters.Add("@d", NpgsqlTypes.NpgsqlDbType.Date);
            npgSqlCommand2.Parameters["@d"].Value = dat;
            npgSqlCommand2.ExecuteNonQuery();

            var sql3 = "select * from skalar(@b);";
            NpgsqlCommand npgSqlCommand3 = new NpgsqlCommand(sql3, connect);
            npgSqlCommand3.Parameters.Add("@b", NpgsqlTypes.NpgsqlDbType.Varchar);
            npgSqlCommand3.Parameters["@b"].Value = ncar;
           
            textBox2.Text = npgSqlCommand3.ExecuteScalar().ToString();
        }
    }
}
