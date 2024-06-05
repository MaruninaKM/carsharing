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
    public partial class Operator : Form
    {
        private string connString;
        private NpgsqlConnection connect;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        private DataTable df = new DataTable();
        
        private DataSet ds1 = new DataSet();
        private DataTable dt1 = new DataTable();
        private DataTable df1 = new DataTable();

        private DataSet ds2 = new DataSet();
        private DataTable dt2 = new DataTable();
        private DataTable df2 = new DataTable();

        public Operator()
        {
            InitializeComponent();

            connString = "Host=localhost;Username=Operator;Password=868575;Database=TR_a_17_20_Marunina_K_M";
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
           
            var sql = "SELECT * from town order by id_area;";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, connect);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;

            var sql1 = "SELECT * FROM kolvo order by id_area;";
            NpgsqlDataAdapter da1 = new NpgsqlDataAdapter(sql1, connect);
            ds1.Reset();
            da1.Fill(ds1);
            dt1 = ds1.Tables[0];
            dataGridView2.DataSource = dt1;

            var sql2 = "SELECT * from car order by id_area;";
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sql2, connect);
            ds2.Reset();
            da2.Fill(ds2);
            dt2 = ds2.Tables[0];
            dataGridView3.DataSource = dt2;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Employee frm1 = new Employee();
            frm1.Show();
            this.Hide();
            connect.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var sql3 = "select * from peregon(@a,@b);";
            NpgsqlCommand npgSqlCommand = new NpgsqlCommand(sql3, connect);
            npgSqlCommand.Parameters.Add("@a", NpgsqlTypes.NpgsqlDbType.Integer); 
            npgSqlCommand.Parameters["@a"].Value = Convert.ToInt32(textBox3.Text);
            npgSqlCommand.Parameters.Add("@b", NpgsqlTypes.NpgsqlDbType.Varchar); 
            npgSqlCommand.Parameters["@b"].Value = textBox1.Text;

            npgSqlCommand.ExecuteNonQuery();
            
            var sql4 = "SELECT * FROM kolvo order by id_area;";
            NpgsqlDataAdapter da1 = new NpgsqlDataAdapter(sql4, connect);
            ds1.Reset();
            da1.Fill(ds1);
            dt1 = ds1.Tables[0];
            dataGridView2.DataSource = dt1;
            
            var sql5 = "SELECT * from car order by id_area;";
            NpgsqlDataAdapter da2 = new NpgsqlDataAdapter(sql5, connect);
            ds2.Reset();
            da2.Fill(ds2);
            dt2 = ds2.Tables[0];
            dataGridView3.DataSource = dt2;                          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
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
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
            if (textBox1.Text.Length == 6) button2.Enabled = true;
        }
    }
}
