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
    public partial class Info_car : Form
    {
        private string connString;
        private NpgsqlConnection connect;
        private DataSet ds = new DataSet();
        private DataTable dt = new DataTable();
        private DataTable df = new DataTable();

        private DataSet ds1 = new DataSet();
        private DataTable dt1 = new DataTable();
        private DataTable df1 = new DataTable();
        public Info_car()
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

            var sql = "SELECT * from breaking;";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sql, connect);
            ds.Reset();
            da.Fill(ds);
            dt = ds.Tables[0];
            dataGridView1.DataSource = dt;

            var sql1 = "SELECT * from trip;";
            NpgsqlDataAdapter da1 = new NpgsqlDataAdapter(sql1, connect);
            ds1.Reset();
            da1.Fill(ds1);
            dt1 = ds1.Tables[0];
            dataGridView2.DataSource = dt1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Analiyst frm1 = new Analiyst();
            frm1.Show();
            this.Hide();
            connect.Close();
        }
    }
}
