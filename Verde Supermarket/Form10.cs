using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Verde_Supermarket
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {  //To the categories form (Home page)
            Form2 form = new Form2();
            form.Show();
            Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {   //To the payment form 
            Form11 form = new Form11();
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
            //Add button
            string message = "The product has been added to your cart.";
            MessageBox.Show(message);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Remove button
            string message = "The product has been removed from your cart.";
            MessageBox.Show(message);
        }
    }
}
