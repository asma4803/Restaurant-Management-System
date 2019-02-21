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
    public partial class RemoveItemInMenu : Form
    {
        public RemoveItemInMenu()
        {
            InitializeComponent();
            populateComboBox();
        }

        void populateComboBox()
        {
            String conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();

            string Sql = "Select itemName From Menu";
            SqlCommand cmd = new SqlCommand(Sql, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int statusIndex = rdr.GetOrdinal("itemName");
                string fil1 = rdr.IsDBNull(statusIndex) ? null : rdr.GetString(statusIndex);
                if (fil1 != null)
                {
                    comboBox1.Items.Add(fil1);
                }
            }
            rdr.Close();
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu rm = new Menu();
            rm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                String conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Select atleast One item");
                }
                else
                {
                    //string q = "DELETE from Menu where itemName='" + comboBox1.SelectedItem.ToString() + "'";
                    string q = "UPDATE MENU SET itemName = NULL where itemName = '" + comboBox1.SelectedItem.ToString() + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(q, con);
                    sda.SelectCommand.ExecuteNonQuery();

                    string q2 = "UPDATE MENU SET itemPrice = NULL where itemName = '" + comboBox1.SelectedItem.ToString() + "'";
                    SqlDataAdapter sda2 = new SqlDataAdapter(q2, con);
                    sda2.SelectCommand.ExecuteNonQuery();

                    con.Close();
                    MessageBox.Show("Item Removed");
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Some problem has occured");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void RemoveItemInMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
