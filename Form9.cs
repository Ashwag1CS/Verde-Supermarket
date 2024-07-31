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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Verde_Supermarket
{
    public partial class Form9 : Form
    {
        public string ConnectionString = "Data Source=LAPTOP-79V8HE9P;Initial Catalog=supermarket;Integrated Security=True";
        private Model1 dbContext;
        public string userName { get; private set; }
        public string orderNumb { get; set; }
        public Form9(string userName, string orderNumb)
        {
            InitializeComponent();
            dbContext = new Model1();
            this.userName = userName;
            this.orderNumb = orderNumb;
        }

        private void button1_Click(object sender, EventArgs e)
        {  //To the categoris form (Home page)
            Form2 form = new Form2(userName, orderNumb);
            form.Show();
            Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Search button
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select orderNumber,pID,pName,pBrand,pCategory,pPrice,quantity from carts where username='" + userName + "'", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable preOrder = new DataTable();
            adapter.Fill(preOrder);
            dataGridView1.DataSource = preOrder;
            con.Close();
        }
    }
}
