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
    public partial class Form2 : Form
    {
        String user_id;
        MySqlConnection mySqlConnection;
        List<int> id_list;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(String id)
        {
            InitializeComponent();
            //comboBox2.Items.
            this.user_id = id;
            richTextBox1.Hide();
            mySqlConnection = new MySqlConnection("data source = 127.0.0.1;port=3306;username=root;password=; database = medicine;");
            mySqlConnection.Open();
            string query = "SELECT * from users where Id=@id";
            MySqlCommand sqlcommand1 = new MySqlCommand(query, mySqlConnection);
            sqlcommand1.Parameters.AddWithValue("@id", user_id);
            MySqlDataReader datareader1 = sqlcommand1.ExecuteReader();
            if(datareader1.HasRows)
            {
                while(datareader1.Read())
                {
                    String name = datareader1.GetString(1);
                    MessageBox.Show("Welcome user:" + name);
                }
            }
            datareader1.Close();
            errorProvider1.SetError(comboBox1, "should not be empty");
            errorProvider2.SetError(textBox1, "should not be empty");
            errorProvider3.SetError(comboBox2, "should not be empty");
            errorProvider4.SetError(comboBox3, "should not be empty");
            id_list = new List<int>();

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int row_index = comboBox1.SelectedIndex;
            if(row_index!=-1)
            {
                errorProvider1.Clear();
                switch (row_index)
                {
                    case 0:
                        break;
                    case 1:
                        radioButton1.Text = "codeine";
                        radioButton2.Text = "hydrocodone";
                        radioButton3.Text = "morphine ";
                        radioButton4.Text = "fentanyl ";
                        break;
                    case 2:
                        radioButton1.Text = "amoxicillin";
                        radioButton2.Text = "doxycycline";
                        radioButton3.Text = "cephalexin";
                        radioButton4.Text = "metronidazole";
                        break;
                    case 3:
                        radioButton1.Text = "Iodophors";
                        radioButton2.Text = "Hexachlorophene";
                        radioButton3.Text = "Boric acid";
                        radioButton4.Text = "Hydrogen peroxide";
                        break;
                }
            }
            
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider2.SetError(textBox1, "should not be empty");
            }
            else if((int.Parse(textBox1.Text)>=7) || (int.Parse(textBox1.Text) < 0))
            {
                errorProvider2.SetError(textBox1, "Count cannot be more than 7");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(isValidate() && isdateValid())
            {
                Random r = new Random();
                int id_gen = r.Next(1, 1000);
                while (id_list.Contains(id_gen))
                {
                    id_gen = r.Next(1, 1000);
                }
                id_list.Add(id_gen);
                String mtype = comboBox1.SelectedItem.ToString();
                int c = int.Parse(textBox1.Text);
                string ex_mon = comboBox2.SelectedItem.ToString();
                string ex_year = comboBox3.SelectedItem.ToString();
                string mname = enable_select();
                MySqlConnection mySqlConnection1 = new MySqlConnection("data source = 127.0.0.1;port=3306;username=root;password=; database = medicine;");
                mySqlConnection1.Open();
                String query = "INSERT INTO medicine_donate VALUES(@Mid,@Mtype,@Mname,@Count,@Expiry_month,@Expiry_year,@Uid,@Approved,@Checked)";
                MySqlCommand sqlCommand = new MySqlCommand(query, mySqlConnection);
                sqlCommand.Parameters.AddWithValue("@Mid", id_gen);
                sqlCommand.Parameters.AddWithValue("@Mtype", mtype);
                sqlCommand.Parameters.AddWithValue("@Mname", mname);
                sqlCommand.Parameters.AddWithValue("@Count", c);
                sqlCommand.Parameters.AddWithValue("@Expiry_month", ex_mon);
                sqlCommand.Parameters.AddWithValue("@Expiry_year", ex_year);
                sqlCommand.Parameters.AddWithValue("@Uid", user_id);
                sqlCommand.Parameters.AddWithValue("@Approved", "No");
                sqlCommand.Parameters.AddWithValue("@Checked", "No");

                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Medicine has been donated");
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                textBox1.Text = "";
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
            }
            else if(!isValidate())
            {
                MessageBox.Show("Fill the data properly");
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                textBox1.Text = "";
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
            }
            else
            {
                MessageBox.Show("Expiry date is not satisfying condition");
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                textBox1.Text = "";
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int row_index = comboBox1.SelectedIndex;
            if (row_index != -1)
            {
                errorProvider3.Clear();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int row_index = comboBox1.SelectedIndex;
            if (row_index != -1)
            {
                errorProvider4.Clear();
            }
        }
        private bool isValidate()
        {
            if (errorProvider1.GetError(comboBox1) != "")
                return false;
            else if (errorProvider2.GetError(textBox1) != "")
                return false;
            else if (errorProvider3.GetError(comboBox2) != "")
                return false;
            else if (errorProvider4.GetError(comboBox3) != "")
                return false;
            else if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked && !radioButton4.Checked)
                return false;
            else
                return true;
        }
        private bool isdateValid()
        {
            int mon = int.Parse(DateTime.Now.Month.ToString());
            int year = int.Parse(DateTime.Now.Year.ToString());
           
            int mon_selected = int.Parse(comboBox2.SelectedItem.ToString());
            int year_selected = int.Parse(comboBox3.SelectedItem.ToString());
            //textBox2.Text = mon_selected.ToString();
            //textBox3.Text = year_selected.ToString();
            if (year_selected - year == 1)
            {
                if (Math.Abs(mon_selected - mon) <= 8)
                {
                    //textBox4.Text = Math.Abs(mon_selected - mon).ToString();
                    return true;
                }
                else
                    return false;
            }
            else if (year_selected == year)
            {
                if (mon_selected <= mon)
                    return false;
                else if (mon_selected - mon < 4)
                    return false;
                else
                    return true;
            }
            else if (year_selected - year >= 2)
                return true;
            else
                return false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Dispose();
        }
        private string enable_select()
        {
            if (radioButton1.Checked)
                return radioButton1.Text;
            else if (radioButton2.Checked)
                return radioButton2.Text;
            else if (radioButton3.Checked)
                return radioButton3.Text;
            else
                return radioButton4.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Show();
            MySqlConnection mySqlConnection5 = new MySqlConnection("data source = 127.0.0.1;port=3306;username=root;password=; database = medicine;");
            mySqlConnection5.Open();
            String query3 = "SELECT * from medicine_donate where Uid=@uid && Approved=@Approved && Checked=@Checked";
            MySqlCommand sqlcommand5 = new MySqlCommand(query3, mySqlConnection5);
            sqlcommand5.Parameters.AddWithValue("@uid", user_id);
            sqlcommand5.Parameters.AddWithValue("@Approved", "Yes");
            sqlcommand5.Parameters.AddWithValue("@Checked", "No");
            //MySqlDataReader dr = sqlcommand5.ExecuteReader();
            MySqlDataAdapter da1 = new MySqlDataAdapter(sqlcommand5);
            DataSet ds = new DataSet();
            da1.Fill(ds);
            richTextBox1.Text = "";

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {

                richTextBox1.Text += ds.Tables[0].Rows[i]["Mname"].ToString()+"\n";
                String q = "Update medicine_donate SET Checked=@Checked where Mid=@mid";
                MySqlCommand sqlcommand4 = new MySqlCommand(q, mySqlConnection5);
                sqlcommand4.Parameters.AddWithValue("@Checked", "Yes");
                sqlcommand4.Parameters.AddWithValue("@mid", ds.Tables[0].Rows[i]["Mid"].ToString());
                sqlcommand4.ExecuteNonQuery();

            }

                
            

        }
    }
}
