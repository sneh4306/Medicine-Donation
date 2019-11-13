using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace MedicineDonation
{
    public partial class Form1 : Form
    {
        MySqlConnection mySqlConnection;
        List<int> id_list;
        public Form1()
        {
            InitializeComponent();
            groupBox2.Hide();
            button4.Hide();
            textBox2.PasswordChar = '*';
            textBox6.PasswordChar = '*';
            textBox7.PasswordChar = '*';
           // List<Control> validate = new List<Control>();
            errorProvider1.SetError(textBox3, "Cannot be empty");
            errorProvider2.SetError(textBox4, "Cannot be empty");
            errorProvider3.SetError(textBox5, "Cannot be empty");
            errorProvider4.SetError(textBox6, "Cannot be empty");
            errorProvider5.SetError(textBox7, "Cannot be empty");
            errorProvider6.SetError(textBox1, "Cannot be empty");
            errorProvider7.SetError(textBox2, "Cannot be empty");
            errorProvider8.SetError(textBox8, "Cannot be empty");
            mySqlConnection = new MySqlConnection("data source = 127.0.0.1;port=3306;username=root;password=; database = medicine;");
            mySqlConnection.Open();
            id_list = new List<int>();
        }

        private void ToolTip1_Popup(object sender, PopupEventArgs e)
        {
           // toolTip1.SetToolTip("kjhgf");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            //Register Button4
            groupBox2.Show();
            button4.Show();
            groupBox1.Hide();
            label3.Hide();
            button2.Hide();
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            groupBox1.Show();
            label3.Show();
            button2.Show();
            groupBox2.Hide();
            button4.Hide();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox8.Text = "";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //String name = textBox3.Text;
            //String contact = textBox4.Text;
            //String email_id = textBox5.Text;
            //String pass = textBox6.Text;
            //String cpass = textBox7.Text;

            //while((string.IsNullOrEmpty(textBox3.Text) && string.IsNullOrEmpty(textBox4.Text) && string.IsNullOrEmpty(textBox5.Text) && string.IsNullOrEmpty(textBox6.Text) && string.IsNullOrEmpty(textBox7.Text)))
            //{
            //  errorProvider1.SetError(button3, "Fill Out all the fields");
            // continue;
            //}

            //errorProvider1.Clear();
            //MessageBox.Show("registered Successfully");
            //if(errorProvider2.GetError(textBox6).equals(""))
            //{

            //}
            //bool success = true;
            bool f = isValid();
            if(f)
            {
                //textBox8.Text = f.ToString();
                Random r = new Random();
                int id_gen = r.Next(1, 100);
                while(id_list.Contains(id_gen))
                {
                    id_gen = r.Next(1, 100);
                }
                id_list.Add(id_gen);
                String name = textBox3.Text;
                String contact = textBox4.Text;
                String email_id = textBox5.Text;
                String pass = textBox6.Text;
                var sha = SHA256.Create();
                var bytes = Encoding.UTF8.GetBytes(pass);
                var hash = sha.ComputeHash(bytes);
                String hash1 = Convert.ToBase64String(hash);
                //textBox8.Text = hash1;
                String query = "INSERT INTO users VALUES(@Id,@Name,@Contact,@Email,@Pass)";
                MySqlCommand sqlCommand = new MySqlCommand(query, mySqlConnection);
                sqlCommand.Parameters.AddWithValue("@Id", id_gen);
                sqlCommand.Parameters.AddWithValue("@Name", name);
                sqlCommand.Parameters.AddWithValue("@Contact", contact);
                sqlCommand.Parameters.AddWithValue("@Email", email_id);
                sqlCommand.Parameters.AddWithValue("@Pass", hash1);
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("You are Registered. Your id for future access is: "+id_gen.ToString()+ ".Please note it down for future access");
                
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                groupBox2.Hide();
                button4.Hide();
                groupBox1.Show();
                button2.Show();
                label3.Show();
            }
            else
            {
                MessageBox.Show("Satisfy all conditions","Confirmation");
            }
        }

        public bool isValid()
        {
            if((errorProvider1.GetError(textBox3)!=""))
            {
                return false;

            }
            else if((errorProvider2.GetError(textBox4) != ""))
            {
                return false;
            }
            else if((errorProvider3.GetError(textBox5) != ""))
            {
                return false;
            }
            else if((errorProvider4.GetError(textBox6) != ""))
            {
                return false;
            }
            else if((errorProvider5.GetError(textBox7) != ""))
            {
                return false;
            }
            else
            {
                return true;
            }
            //return true;
            
            
               // return true;
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //bool f = false;
            if(!(Regex.IsMatch(textBox6.Text, @"([A-Z]{1,})([a-z]{1,})([0-9]{1,})([$!*#%?&]{1,})")))
            {
                errorProvider4.SetError(textBox6, "Password not in the proper format");
                
                //return 1;
            }
            else
            {
                //f = true;
                errorProvider4.Clear();
                
                //return 0;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (textBox6.Text != textBox7.Text)
            {
                errorProvider5.SetError(textBox7, "Password does not match");
                //return false;
                

            }
            else
            {
                errorProvider5.Clear();
                //return true;
                
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                errorProvider1.SetError(textBox3, "cannot be empty");
                
            }
            else
            {
                errorProvider1.Clear();
                
            }
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                errorProvider2.SetError(textBox4, "cannot be empty");

            }
            else
            {
                errorProvider2.Clear();
                if (!(Regex.IsMatch(textBox4.Text, @"^\d{10}$")))
                {
                    errorProvider2.SetError(textBox4, "Enter in correct format");

                }
                else
                {
                    errorProvider2.Clear();

                }
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                errorProvider3.SetError(textBox5, "cannot be empty");
                
            }
            else
            {
                errorProvider3.Clear();
                if (!(Regex.IsMatch(textBox5.Text, @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$")))
                {
                    errorProvider3.SetError(textBox5, "Enter in correct format");
                    
                }
                else
                {
                    errorProvider3.Clear();
                    
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            if(islogin())
            {
                MySqlConnection mySqlConnection1 = new MySqlConnection("data source = 127.0.0.1;port=3306;username=root;password=; database = medicine;");
                mySqlConnection1.Open();
                string query = "SELECT * from users where Id=@id";
                MySqlCommand sqlcommand1 = new MySqlCommand(query, mySqlConnection1);
                sqlcommand1.Parameters.AddWithValue("@id", textBox8.Text);
                MySqlDataReader datareader1 = sqlcommand1.ExecuteReader();
                //mySqlConnection1.Open();
                String email,pass;

                if (datareader1.HasRows)
                {
                    while(datareader1.Read())
                    {
                        email = datareader1.GetString(3);
                        pass = datareader1.GetString(4);
                        //textBox9.Text=email;
                        //textBox10.Text=pass;
                       // textBox9.PasswordChar = "";


                        String pass1 = textBox2.Text;
                        var sha1 = SHA256.Create();
                        var bytes1 = Encoding.UTF8.GetBytes(pass1);
                        var hash1 = sha1.ComputeHash(bytes1);
                        String hash2 = Convert.ToBase64String(hash1);
                        //textBox11.Text = hash2;
                        String em = textBox1.Text;
                        if((hash2 == pass) && (email == em))
                        {
                            MessageBox.Show("Login successful");
                            //datareader1.Close();
                            if(email == "admin@gmail.com")
                            {
                                Form3 f3 = new Form3(textBox8.Text);
                                f3.Show();
                                this.Dispose();
                            }
                            else
                            {
                                Form2 f2 = new Form2(textBox8.Text);
                                f2.Show();
                                this.Hide();
                            }

                        }
                        else
                        {
                            MessageBox.Show("Enter proper credentials");
                            //datareader1.Close();
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox8.Text = "";
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Enter correct Id");
                    //datareader1.Close();
                    textBox1.Text = ""; 
                    textBox2.Text = "";
                    textBox8.Text = "";
                }

            }
            else
            {
                MessageBox.Show("Fill all fields");
            }

        }
        private bool islogin()
        {
            if (errorProvider6.GetError(textBox1) != "")
                return false;
            else if (errorProvider7.GetError(textBox2) != "")
                return false;
            else if (errorProvider8.GetError(textBox8) != "")
                return false;
            else
                return true;
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox8.Text))
            {
                errorProvider8.SetError(textBox8, "cannot be empty");

            }
            else
            {
                errorProvider8.Clear();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                errorProvider6.SetError(textBox1, "cannot be empty");

            }
            else
            {
                errorProvider6.Clear();

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                errorProvider7.SetError(textBox2, "cannot be empty");

            }
            else
            {
                errorProvider7.Clear();

            }
        }
    }
}
