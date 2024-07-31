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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Add button
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Update button
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
            //Remove button
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //Text box for State
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
    }
}
