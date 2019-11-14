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
        int row_index;
        public Form3()
        {
            InitializeComponent();
        }
        public Form3(String id)
        {
            InitializeComponent();
            button2.Hide();
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
                    String name = datareader1.GetString(1);
                    MessageBox.Show("Welcome user:" + name);
                }
            }
            datareader1.Close();
            dataGridView1.ColumnCount = 9;
            dataGridView1.Columns[0].Name = "User_Id";
            dataGridView1.Columns[1].Name = "User Name";
            dataGridView1.Columns[2].Name = "Email";
            dataGridView1.Columns[3].Name = "Medicine Id";
            dataGridView1.Columns[4].Name = "Medicine Type";
            dataGridView1.Columns[5].Name = "Medicine Name";
            dataGridView1.Columns[6].Name = "Count";
            dataGridView1.Columns[7].Name = "Expiry Month";
            dataGridView1.Columns[8].Name = "Expiry Year";

            string query1 = "SELECT * from users";
            MySqlCommand sqlcommand2 = new MySqlCommand(query1, mySqlConnection);
            //sqlcommand1.Parameters.AddWithValue("@id", user_id);
            //MySqlDataReader datareader2 = sqlcommand2.ExecuteReader();
            MySqlDataAdapter da = new MySqlDataAdapter(sqlcommand2);
            DataSet ds = new DataSet();
            da.Fill(ds);
            //DataTable dt =
            //if(datareader2.HasRows)
            //{
            //while(datareader2.Read())
            //{
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                String id1 = ds.Tables[0].Rows[i]["Id"].ToString();
                String name = ds.Tables[0].Rows[i]["Name"].ToString();
                String email_id = ds.Tables[0].Rows[i]["Email"].ToString();

                string query2 = "SELECT * from medicine_donate where Uid=@id1";
                MySqlCommand sqlcommand3 = new MySqlCommand(query2, mySqlConnection);
                sqlcommand3.Parameters.AddWithValue("@id1", id1);
                //datareader2.Close();
                MySqlDataReader datareader3 = sqlcommand3.ExecuteReader();
                if (datareader3.HasRows)
                {
                    while (datareader3.Read())
                    {
                        dataGridView1.Rows.Add(id1, name, email_id,datareader3.GetString(0),datareader3.GetString(1), datareader3.GetString(2), datareader3.GetString(3), datareader3.GetString(4), datareader3.GetString(5), datareader3.GetString(6));
                    }
                }
                datareader3.Close();
            }  //}
            //}
            //datareader2.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Dispose();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            button2.Show();
            row_index = e.RowIndex;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dataGridView1.Rows[row_index].Cells[3].Value.ToString());
            MySqlConnection mySqlConnection1 = new MySqlConnection("data source = 127.0.0.1;port=3306;username=root;password=; database = medicine;");
            mySqlConnection1.Open();
            //textBox1.Text = id.ToString();
            String q = "Update medicine_donate SET Approved=@Approved where Mid=@mid";
            MySqlCommand sqlcommand4 = new MySqlCommand(q, mySqlConnection1);
            sqlcommand4.Parameters.AddWithValue("@Approved", "Yes");
            sqlcommand4.Parameters.AddWithValue("@mid", id);
            sqlcommand4.ExecuteNonQuery();
            MessageBox.Show("Updated");
        }
    }
}