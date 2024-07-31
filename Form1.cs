using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Verde_Supermarket
{
    public partial class Form1 : Form
    {
        public static Form1 Instance;
        public TextBox tb1;
        public string ConnectionString = "Data Source=LAPTOP-79V8HE9P;Initial Catalog=supermarket;Integrated Security=True";
        private Model1 dbContext;
        public string userName { get; private set; }
        string orderNumb = "";


        public Form1()
        {
            InitializeComponent();
            Instance = this;
            dbContext = new Model1();



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string Password = textBox2.Text;
            bool isManager = radioButton1.Checked;



            bool Mpass = false; //to check manager password
            bool Cpass = false; //to check customer password

            if (textBox1.Text == "" || textBox2.Text == "") 
            { MessageBox.Show("please enter your information"); }
            else { 
            //radio checked
            if (isManager)
            {
                //search for manager username
                var matchingManagersName = from manager in dbContext.manager
                                           where manager.username == userName
                                           select manager;



                //wrong username
                if (!matchingManagersName.Any())
                {
                    MessageBox.Show("your username does not exist\nplease try again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //user name exist-->check password
                if (matchingManagersName.Any())
                {
                    var matchingManagersPass = from manager in dbContext.manager
                                               where manager.password == Password
                                               select manager;
                    //is password right?
                    //yse
                    if (matchingManagersPass.Any()) { Mpass = true; }
                    //no
                    else { MessageBox.Show("your password is wrong \nplease try again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                }



                //manager username and password are right
                if (Mpass)
                {
                    Form12 openForm12 = new Form12();
                    openForm12.Show();
                    Visible = false;
                }




            }
            else   //CUSTOMER
            {
                //check customer name
                var matchingCustomerName = from c in dbContext.customer
                                           where c.username == userName
                                           select c;
                //name doesnt exist
                if (!matchingCustomerName.Any())
                {

                    SqlConnection con = new SqlConnection(ConnectionString);
                    con.Open();
                    string password = textBox2.Text; string query = "INSERT INTO customer(username, password) VALUES ('" + userName + "', '" + password + "')";
                    SqlCommand command = new SqlCommand(query, con); command.ExecuteNonQuery();
                    con.Close();
                    string message = "you have been registered.";
                    MessageBox.Show(message);

                    //CREAT NEW CUSTOMER
                }



                //name exist --> check password 
                if (matchingCustomerName.Any())
                {
                    var matchingCustomerPass = from c in dbContext.customer
                                               where c.password == Password
                                               select c;
                    //correct password
                    if (matchingCustomerPass.Any()) {
                        Cpass = true;


                        bool isUniqe = false;
                        //have to be uniqe order number
                        while (!isUniqe)
                        {
                            orderNumb = GenerateOrderNumber();
                            var onq = from n in dbContext.carts
                                      where n.orderNumber == orderNumb
                                      select n;
                            var orNum = onq.FirstOrDefault();
                            if (orNum == null)
                            {
                                isUniqe = true;
                            }
                        }
                    }
                    //wrong password
                    else { MessageBox.Show("your password is wrong\nplease try again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }



                }



                // Open customer form
                if (Cpass)
                {
                    Form2 openForm2 = new Form2(userName,orderNumb);
                    openForm2.Show();
                    Visible = false;
                }
            }

        }
        string GenerateOrderNumber()
            {
                Random n = new Random();
                StringBuilder s = new StringBuilder();

                //s start with sa
                s.Append("1");

                //create 10 random numbers and put them in s
                for (int i = 0; i < 9; i++)
                {
                    int digit = n.Next(9);
                    s.Append(digit);
                }

                return s.ToString();
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //Radio button for the maneger
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Text box for username
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //Text box for Password
        }
    }
    }

