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
    public partial class Insert_car : Form
    {
        private string connString;
        private NpgsqlConnection connect;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        
        private DataSet ds1 = new DataSet();
        private DataTable dt1 = new DataTable();
        private DataTable df1 = new DataTable();

        private DataSet ds2 = new DataSet();
        private DataTable dt2 = new DataTable();
        private DataTable df2 = new DataTable();
        public Insert_car()
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

        private void button4_Click(object sender, EventArgs e)
        {
            Analiyst frm1 = new Analiyst();
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
            
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        { 
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)        
                e.Handled = true;
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
            if (textBox1.Text.Length == 6 && textBox3.Text.Length != 0 && textBox5.Text.Length != 0) button4.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            var sql1 = "call insert_car(@a,@b,@c,@d,@e,@f);";
            NpgsqlCommand npgSqlCommand = new NpgsqlCommand(sql1, connect);
            npgSqlCommand.Parameters.Add("@a", NpgsqlTypes.NpgsqlDbType.Varchar, 10);
            npgSqlCommand.Parameters["@a"].Value = textBox1.Text;

            npgSqlCommand.Parameters.Add("@b", NpgsqlTypes.NpgsqlDbType.Varchar, 50);
            npgSqlCommand.Parameters["@b"].Value = comboBox1.Text;
            npgSqlCommand.Parameters.Add("@c", NpgsqlTypes.NpgsqlDbType.Varchar, 50);
            npgSqlCommand.Parameters["@c"].Value = comboBox2.Text;

            npgSqlCommand.Parameters.Add("@d", NpgsqlTypes.NpgsqlDbType.Integer);
            npgSqlCommand.Parameters["@d"].Value = Convert.ToInt32(textBox3.Text);
            npgSqlCommand.Parameters.Add("@e", NpgsqlTypes.NpgsqlDbType.Integer);
            npgSqlCommand.Parameters["@e"].Value = 0;
            npgSqlCommand.Parameters.Add("@f", NpgsqlTypes.NpgsqlDbType.Integer);
            npgSqlCommand.Parameters["@f"].Value = Convert.ToInt32(textBox5.Text); 
       
            try
            {
                npgSqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //Код обработки ошибок
                MessageBox.Show("Primary key violation");
            }

            var sql = "SELECT * from car order by id_area;";
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sql, connect);
            ds2.Reset();
            da2.Fill(ds2);
            dt2 = ds2.Tables[0];
            dataGridView1.DataSource = dt2;
        }
    }
}
