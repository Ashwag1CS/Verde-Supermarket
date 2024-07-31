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
    public partial class Form10 : Form
    {
        public string ConnectionString = "Data Source=LAPTOP-79V8HE9P;Initial Catalog=supermarket;Integrated Security=True";
        private Model1 dbContext;
        public string userName { get; private set; }
        public string orderNumb { get; set; }
        public Form10(string userName, string orderNumb)
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

        private void button4_Click(object sender, EventArgs e)
        {   //To the payment form 
            Form11 form = new Form11(userName,orderNumb);
            form.Show();
            Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Text box for the ID
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
                    showProduct();
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox1.Text);
                var check = from c in dbContext.carts
                            where c.pID == id && c.orderNumber == orderNumb
                            select c;

                var quan = from q in dbContext.carts
                           where q.pID == id && q.orderNumber == orderNumb && q.quantity > 1
                           select q.quantity;
                int newQ;

                foreach (var c in quan)
                {
                    newQ = Convert.ToInt32(c);
                }

                if (check.Any())
                {

                    if (quan.Any())
                    {
                        int result;
                        using (SqlConnection con = new SqlConnection(ConnectionString))
                        {
                            string query = "SELECT quantity FROM carts WHERE pID= " + id + "AND orderNumber =" + orderNumb;
                            SqlDataAdapter sda = new SqlDataAdapter(query, con);
                            con.Open();
                            SqlCommand cmd = new SqlCommand(query, con);
                            try
                            {
                                result = Convert.ToInt32(cmd.ExecuteScalar());
                            }
                            catch (NullReferenceException n)
                            {
                                result = 2;
                            }
                        }
                        result--;
                        SqlConnection Con = new SqlConnection(ConnectionString);
                        Con.Open();
                        string query2 = "UPDATE carts SET quantity =" + result + " WHERE pID= " + id + "AND orderNumber =" + orderNumb;
                        SqlCommand cmd2 = new SqlCommand(query2, Con);
                        cmd2.ExecuteNonQuery();
                        Con.Close();



                    }
                    else
                    {
                        using (SqlConnection con = new SqlConnection(ConnectionString))
                        {
                            con.Open();
                            using (SqlCommand command = new SqlCommand("DELETE FROM carts WHERE pID= " + id + "AND orderNumber =" + orderNumb, con))
                            {
                                command.ExecuteNonQuery();
                            }
                            con.Close();
                        }
                    }
                    string message = "The product has been removed from your cart.";
                    MessageBox.Show(message);
                    showProduct();
                }
                else { MessageBox.Show("this product not in the cart!! \nplease try again", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            }
            catch (FormatException formatexception)
            {
                MessageBox.Show("please enter an integer", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form10_Load(object sender, EventArgs e)
        {
            showProduct();
        }
        public void showProduct()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select pID,pName,pBrand,pCategory,pPrice,quantity from carts where orderNumber='" + orderNumb + "'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable Order = new DataTable();
            adapter.Fill(Order);
            dataGridView1.DataSource = Order;
            con.Close();

        }

       
    }
}
