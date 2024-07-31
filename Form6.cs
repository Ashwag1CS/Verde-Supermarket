using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Verde_Supermarket
{
    public partial class Form6 : Form
    {
        public string ConnectionString = "Data Source=LAPTOP-79V8HE9P;Initial Catalog=supermarket;Integrated Security=True";
        private Model1 dbContext;
        public string userName { get; private set; }
        public string orderNumb { get; set; }
        public Form6(string userName, string orderNumb)
        {
            InitializeComponent();
            dbContext = new Model1();
            this.userName = userName;
            this.orderNumb = orderNumb;
        }

        private void button1_Click(object sender, EventArgs e)
        {  //To the categories form (Home page)
            Form2 form = new Form2(userName, orderNumb);
            form.Show();
            Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //text box for the ID 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {  //the id from textbox
                string pid = textBox1.Text;
                //convert it to int
                Int64 pidint = Convert.ToInt64(pid);

                //search item in products
                var qp = from item in dbContext.product
                         where item.pID == pidint
                         select item;
                //search item in cart for the same orderder number
                var qc = from item in dbContext.carts
                         where item.pID == pidint && item.orderNumber == orderNumb
                         select item;

                //the product from products
                var productp = qp.FirstOrDefault();
                //the product from cart
                var productc = qc.FirstOrDefault();
                //product doesnt exsit
                if (productp == null)
                {
                    MessageBox.Show("this product does not exist\nplease try again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //Real Product
                else if (productp.quantity > 0)
                {  //product exist with same order naumber
                    if (productc != null)
                    {
                        productc.quantity++;
                        productp.quantity -= 1;
                        string message = "The product has been added to your cart.";
                        MessageBox.Show(message);

                    }
                    //product does not exust
                    else
                    {
                        //creat new item
                        var cartItem = new carts
                        {
                            pID = productp.pID,
                            pName = productp.pName,
                            pPrice = productp.pPrice,
                            quantity = 1,
                            username = userName,
                            orderNumber = orderNumb,
                            pBrand = productp.pBrand,
                            pCategory = productp.pCategory,

                        };
                        productp.quantity -= 1;
                        dbContext.carts.Add(cartItem);
                        string message = "The product has been added to your cart.";
                        MessageBox.Show(message);

                    }
                    dbContext.SaveChanges();
                    ShowProduct();
                }
                else
                {
                    MessageBox.Show("Sorry the product OUT OF STOCK!!!", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException formatexception)
            {
                MessageBox.Show("please enter an integer", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //The search bar
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //search button
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //search button
            string sProduct = textBox2.Text;
            var check = from p in dbContext.product
                        where p.pCategory == "fruits" && p.pName == sProduct
                        select p;
            if (check.Any())
            {
                SqlConnection con = new SqlConnection(ConnectionString);
                con.Open();
                SqlCommand cmd = new SqlCommand("select pID,pName,quantity,pBrand from product where pCategory='fruits'AND pName='" + sProduct + "'", con);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable Search = new DataTable();
                adapter.Fill(Search);
                dataGridView1.DataSource = Search;
                con.Close();
            }
            else { MessageBox.Show("this product not in this section \nplease try another product", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }


        }

        private void Form6_Load(object sender, EventArgs e)
        {
            ShowProduct();

        }

        public void ShowProduct()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select pId,pName,pBrand,pPrice ,quantity from product where pCategory= 'fruits' ", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable fruitsTable = new DataTable();
            adapter.Fill(fruitsTable);

            dataGridView1.DataSource = fruitsTable;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
