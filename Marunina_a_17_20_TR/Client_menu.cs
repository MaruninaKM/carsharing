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
    public partial class Client_menu : Form
    {
        
        private string connString;
        private NpgsqlConnection connect;
       
        private DataTable dt = new DataTable();
        private DataTable dt1 = new DataTable();


        public Client_menu(string q)
        {
            InitializeComponent();
            connString = "Host=localhost;Username=Client;Password=221523;Database=TR_a_17_20_Marunina_K_M";
            connect = new NpgsqlConnection(connString);
            label7.Text = q;
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

            var sql3 = "select * from  up1_bonus();";
            NpgsqlCommand da3 = new NpgsqlCommand(sql3, connect);
            da3.ExecuteNonQuery();

            var sql2 = "select * from  up2_bonus();";
            NpgsqlCommand da2 = new NpgsqlCommand(sql2, connect);
            da2.ExecuteNonQuery();

            var sql1 = "select * from trip_func(@a);";
            NpgsqlCommand da1 = new NpgsqlCommand(sql1, connect);
            da1.Parameters.Add("@a", NpgsqlTypes.NpgsqlDbType.Bigint);
            da1.Parameters["@a"].Value = Convert.ToInt64(q);
            NpgsqlDataReader npgSqlDataReader1 = da1.ExecuteReader();
            dt1.Load(npgSqlDataReader1);
            dataGridView1.DataSource = dt1;

            var sql = "select * from bonus_func(@a);";
            NpgsqlCommand da = new NpgsqlCommand(sql, connect);
            da.Parameters.Add("@a", NpgsqlTypes.NpgsqlDbType.Bigint);
            da.Parameters["@a"].Value = Convert.ToInt64(q);
            NpgsqlDataReader npgSqlDataReader = da.ExecuteReader();
            dt.Load(npgSqlDataReader);
            dataGridView2.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bron frm1 = new Bron(Convert.ToInt64(label7.Text));
            frm1.Show();
            this.Hide();
            connect.Close();          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Client_inp frm1 = new Client_inp();
            frm1.Show();
            this.Hide();
            connect.Close();
        }
    }
}
