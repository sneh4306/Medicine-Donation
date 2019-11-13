using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace MedicineDonation
{
    public partial class Form3 : Form
    {
        String user_id;
        MySqlConnection mySqlConnection;
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(String id)
        {
            InitializeComponent();
            this.user_id = id;
            mySqlConnection = new MySqlConnection("data source = 127.0.0.1;port=3306;username=root;password=; database = medicine;");
            mySqlConnection.Open();
            string query = "SELECT * from users where Id=@id";
            MySqlCommand sqlcommand1 = new MySqlCommand(query, mySqlConnection);
            sqlcommand1.Parameters.AddWithValue("@id", user_id);
            MySqlDataReader datareader1 = sqlcommand1.ExecuteReader();
            if (datareader1.HasRows)
            {
                while (datareader1.Read())
                {
                    String name = datareader1.GetString(0);
                    MessageBox.Show("Welcome user:" + name);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Dispose();
        }
    }
}