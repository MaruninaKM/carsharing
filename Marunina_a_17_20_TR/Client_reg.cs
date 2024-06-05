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
    public partial class Client_reg : Form
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
        public Client_reg()
        {
            InitializeComponent();
        }
               
        private void button1_Click(object sender, EventArgs e)
        {
            Menu_start frm1 = new Menu_start();
            frm1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connString = "Host=localhost;Username=Client;Password=221523;Database=TR_a_17_20_Marunina_K_M";
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

            int gh = Convert.ToInt32(textBox4.Text);
            int raz = 2022 - gh; 


            var sql1 = "call insert_client(@a,@b,@d,@e);";
            NpgsqlCommand npgSqlCommand = new NpgsqlCommand(sql1, connect);
            npgSqlCommand.Parameters.Add("@a", NpgsqlTypes.NpgsqlDbType.Bigint);
            npgSqlCommand.Parameters["@a"].Value = Convert.ToInt64(textBox2.Text);

            npgSqlCommand.Parameters.Add("@b", NpgsqlTypes.NpgsqlDbType.Varchar);
            npgSqlCommand.Parameters["@b"].Value = textBox3.Text;

            npgSqlCommand.Parameters.Add("@d", NpgsqlTypes.NpgsqlDbType.Integer);
            npgSqlCommand.Parameters["@d"].Value = raz;

            npgSqlCommand.Parameters.Add("@e", NpgsqlTypes.NpgsqlDbType.Date);
            npgSqlCommand.Parameters["@e"].Value = Convert.ToDateTime(textBox1.Text) ;
           
           try
           {
                npgSqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
            //Код обработки ошибок
              MessageBox.Show(ex.Message);
            }

            Client_menu frm2 = new Client_menu(textBox2.Text); 
            frm2.Show();
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
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            e.Handled = !((c >= 'а' && c <= 'я') || (c >= 'А' && c <= 'Я') || c == 'Ё' || c == 'ё' || c == 32 || c == 8);

            if (textBox2.Text.Length == 11) button2.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
