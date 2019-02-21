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
    public partial class ModifyItemInMenu : Form
    {
        public ModifyItemInMenu()
        {
            InitializeComponent();
            pupolateComboBox();

        }
        void pupolateComboBox()
        {
            String conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string comboQuery = "Select ItemName From Menu";
            SqlCommand cmd = new SqlCommand(comboQuery, con);
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
            try
            {
                String conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                if (textBox3.Text == "" || comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Check the boxes again");
                }
                else if(Convert.ToInt32( textBox3.Text) <= 0)
                {
                    MessageBox.Show("NOoO.. Please correct the price.😜");
                }
                else
                {
                    Object itmName = comboBox1.SelectedItem;

                    string q = "UPDATE MENU SET itemPrice = '" + textBox3.Text + "'where itemName ='" + itmName + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(q, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Item Price Updated");
                }
            }
            catch (Exception)
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

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ModifyItemInMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
