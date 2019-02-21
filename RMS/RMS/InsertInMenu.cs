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
    public partial class InsertInMenu : Form
    {
        public InsertInMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                String conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT itemName FROM Menu WHERE itemName = '"+ textBox1.Text+"'",con);
                SqlDataReader sdr = cmd.ExecuteReader();
               
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Fill all the boxes");
                }
                else if (sdr.Read()==true)
                {
                    MessageBox.Show("This item is already present in menu");
                }
                else if ( Convert.ToInt32(textBox2.Text) <=0)
                {
                    MessageBox.Show("Please ,Enter the correct value");
                }
                else
                {
                    string q = "INSERT INTO Menu (itemName , itemPrice) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "')";
                    sdr.Close();
                    SqlDataAdapter sda = new SqlDataAdapter(q, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Item Inserted");
                }
            }
            catch( Exception)
            {
                MessageBox.Show("Some problem has occur");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu m = new Menu();
            m.Show();
        }

        private void InsertInMenu_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
