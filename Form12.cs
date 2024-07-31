using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Verde_Supermarket
{
    public partial class Form12 : Form
    {

        public string ConnectionString = "Data Source=LAPTOP-79V8HE9P;Initial Catalog=supermarket;Integrated Security=True"; 
        private Model1 dbContext;
        int id;
        public Form12()
        {
            InitializeComponent();
            dbContext = new Model1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Add button
                int id = Convert.ToInt32(textBox1.Text);
                int price = Convert.ToInt32(textBox2.Text);
                string pName = textBox4.Text;
                int quan = Convert.ToInt32(textBox5.Text);
                string brand = textBox3.Text;
                string category = comboBox1.Text;
                String state = "In Stock";
                if (quan == 0)
                    state = "Out of Stock";

                var check = from p in dbContext.product
                            where p.pID == id
                            select p;
                if (!check.Any())
                {
                    string query = "INSERT INTO product(pID, pPrice, pName,pBrand,quantity,pCategory,status) VALUES ('" + id + "', '" + price + "', '" + pName + "', '" + brand + "', '" + quan + "', '" + category + "', '" + state + "')";

                    SqlConnection con = new SqlConnection(ConnectionString);
                    con.Open();
                    SqlCommand command = new SqlCommand(query, con);
                    command.ExecuteNonQuery();

                    con.Close();
                    string message = "The product has been added.";
                    MessageBox.Show(message);
                    showProduct();
                }
                else
                {
                    string message = "this ID is already exist!!!!!!!!!!!\nENTER ANOTHER ID.";
                    MessageBox.Show(message);
                }
            }
            catch (FormatException formatexception)
            {
                MessageBox.Show("please enter an integer", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                //Update button
                int upquan = Convert.ToInt32(textBox5.Text);
                int pid = Convert.ToInt32(textBox1.Text);

                if (upquan == 0)
                {
                    SqlConnection Con2 = new SqlConnection(ConnectionString);
                    Con2.Open();
                    string query1 = "UPDATE product SET status='Out of Stock',quantity=" + upquan + "WHERE pID= " + pid;
                    SqlCommand cmd = new SqlCommand(query1, Con2);
                    cmd.ExecuteNonQuery();
                    Con2.Close();
                    string message = "The product has been updated.";
                    MessageBox.Show(message);
                }
                else
                {
                    SqlConnection Con2 = new SqlConnection(ConnectionString);
                    Con2.Open();
                    string query1 = "UPDATE product SET status='In Stock',quantity=" + upquan + "WHERE pID= " + pid;
                    SqlCommand cmd = new SqlCommand(query1, Con2);
                    cmd.ExecuteNonQuery();
                    Con2.Close();
                    string message = "The product has been updated.";
                    MessageBox.Show(message);
                }
                showProduct();
            }
            catch (FormatException formatexception)
            {
                MessageBox.Show("please enter an integer", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {  //The log out button
            Form1 form = new Form1();
            form.Show();
            Visible = false;

            string message = " You've been logged out";
            MessageBox.Show(message);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Text box for ID
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //Text box for Price
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //Text box for Product Name
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //Text box for Brand Name
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //Text box for Quantity
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(textBox1.Text);

                var check = from p in dbContext.product
                            where p.pID == id
                            select p;


                if (check.Any())
                {
                    using (SqlConnection con = new SqlConnection(ConnectionString))
                    {
                        con.Open();
                        using (SqlCommand command = new SqlCommand("DELETE FROM product WHERE pID= " + id, con))
                        {
                            command.ExecuteNonQuery();
                        }
                        con.Close();
                    }
                    string message = "The product has been removed.";
                    MessageBox.Show(message);
                    showProduct();
                }
                else { MessageBox.Show("this product not in the system!! \nplease try again"); }

            }
            catch(FormatException formatexception)
            {
                MessageBox.Show("please enter an integer", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Button for Update the state
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //Radio button (in stock)
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //Radio button (out of stock)
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form12_Load(object sender, EventArgs e)
        {
            showProduct();
        }

        public void showProduct()
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select pId,pName,pBrand,pPrice,pCategory ,quantity,status  from product", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable managerTable = new DataTable();
            adapter.Fill(managerTable);

            dataGridView1.DataSource = managerTable;
            con.Close();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
