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
    public partial class Form1 : Form
    {
        public static Form1 Instance;
        public TextBox tb1;
        public Form1()
        {
            InitializeComponent();
            Instance = this;


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {  //To the manager form
                Form12 form = new Form12();
                form.Show();
               Visible = false;
            }
            else
            {   //To the customer form
                Form2 form = new Form2();
                form.Show();
                Visible = false;
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

