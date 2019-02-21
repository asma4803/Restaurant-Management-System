using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace RMS
{
    public partial class ViewReservationToCust : Form
    {
        public ViewReservationToCust()
        {
            InitializeComponent();
        }

        private void ViewReservation_Load(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\it-expert\Desktop\RMS\RMS\Database1.mdf;Integrated Security=True;Connect Timeout=30");
            //con.Open();


            //string sql2 = "select tableNo AS TableNo, noOfChairs AS Chairs, res_date AS Date, res_id AS AssignedID,res_name AS Customer from reservation";
            //SqlDataAdapter adap = new SqlDataAdapter(sql2, con);
            //DataTable dt = new DataTable();
            //adap.Fill(dt);
            //dataGridView1.DataSource = dt;
            //con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer c = new Customer();
            c.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();

            string sql2 = "select res_id AS AssignedID, res_name AS Name,tableNo AS TableNo, noOfChairs AS Chairs, res_date AS Date from reservation where res_id = '" + Convert.ToInt32(textBox1.Text) + "'";
            SqlDataAdapter adap = new SqlDataAdapter(sql2, con);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            if(dt.Rows.Count==0)
            {
                label2.Show();
                dataGridView1.DataSource = null;
            }
            else
            {
                label2.Hide();
                dataGridView1.DataSource = dt;
            }
            
            con.Close();
        }
    }
}
