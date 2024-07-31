using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Verde_Supermarket
{
    
    public partial class Form11 : Form
    {
        private Model1 dbContext;
        string pay;
        public string orderNumb { get; set; }
        public string userName { get; private set; }
        public Form11(string userName,string orderNumb)
        {
            InitializeComponent();
            dbContext = new Model1();
            this.orderNumb = orderNumb;
            this.userName = userName;
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
            Form1 form = new Form1();
            form.Show();
            Visible = false;

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

        private void Form11_Load(object sender, EventArgs e)
        {
            float total = 0;

            var toCount = from p in dbContext.carts
                        where p.orderNumber == orderNumb
                        select p;

            foreach ( var q in toCount)
            {  
                total += (float)q.pPrice * (float)q.quantity;
            }

            label7.Text = Convert.ToString(total);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //To the cart form
            Form10 form = new Form10(userName, orderNumb);
            form.Show();
            Visible = false;
        }
    }
}
