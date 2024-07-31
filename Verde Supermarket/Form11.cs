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
    
    public partial class Form11 : Form
    {
        string pay;
        public Form11()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //Radio button for the apple pay
            if (radioButton1.Checked == true)
            {
                pay = "Apple Pay";
                label11.Text = pay;
                

            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //Radio button for the paypal
            pay = "PayPal";
            label11.Text = pay;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            //Radio button for the cash
            pay = "Cash";
            label11.Text = pay;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //Radio button for the card
            pay = "Card";
            label11.Text = pay;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //button for the pay
            string message = " Payment Completed ✔" +
                "" +
                "\n Thank you for your order";
            MessageBox.Show(message);

        }

        private void label7_Click(object sender, EventArgs e)
        {
            //Lable for the total price
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            //Radio button for the apple pay
            pay = "Apple Pay";
            label11.Text = pay;

        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {

            //Radio button for the PayPal
            pay = "PayPal";
            label11.Text = pay;

        }

        private void radioButton2_CheckedChanged_1(object sender, EventArgs e)
        {
            //Radio button for the Cash
            pay = "Cash";
            label11.Text = pay;

        }

        private void radioButton4_CheckedChanged_1(object sender, EventArgs e)
        {
            //Radio button for the Card
            pay = "Card";
            label11.Text = pay;


        }
    }
}
