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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {  //To the categories form (Home page)
            Form2 form = new Form2();
            form.Show();
            Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //text box for the ID 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //The Add button
            string message = "The product has been added to your cart.";
            MessageBox.Show(message);
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
        }
    }
}
