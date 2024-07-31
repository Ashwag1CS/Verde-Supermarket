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
    public partial class Form2 : Form
    {
        public static Form2 Instance;
        public Form2()
        {
            InitializeComponent();
            Instance = this;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Opens the log in form --> the first form(Log out)
            Form1 form = new Form1();
            form.Show();
            Visible = false;

            string message = " You've been logged out";
            MessageBox.Show(message);
        }

        private void button4_Click(object sender, EventArgs e)
        {  //Opens the dairy form
            Form3 form = new Form3();
            form.Show();
            Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {   //opens the Bakery form
            Form4 form = new Form4();
            form.Show();
            Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {  //Opens the Vegtables form
            Form5 form = new Form5();
            form.Show();
            Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {   //Opens the Fruit form
            Form6 form = new Form6();
            form.Show();
            Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {  //Opens the Meat form
            Form7 form = new Form7();
            form.Show();
            Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {   //Opens the Snack form
            Form8 form = new Form8();
            form.Show();
            Visible = false;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Opens the Current cart form
            Form10 form = new Form10();
            form.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {  //Opens the prevouis orders form
            Form9 form = new Form9();
            form.Show();
            Visible = false;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
