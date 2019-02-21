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
using System.Globalization;
using System.Configuration;

namespace RMS
{
    public partial class AddDeal : Form
    {
        public AddDeal()
        {
            InitializeComponent();
            populateCheckedBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Manager m = new Manager();
            //m.Show();
        }
        bool checkList()
        {
            for (int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                if (checkedListBox1.CheckedItems.Contains("ItemWithIndex'"+i+"'") != null)
                {
                    return true;
                }
            }
            return false;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                String conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT deal_name FROM Deal WHERE deal_name = '" + textBox1.Text + "'", con);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read() == true)
                {
                    MessageBox.Show("Deal with this name is already exists, try a different name");
                }
                sdr.Close();
                //con1.Close();
                //SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\ME\Downloads\RMS\RMS\Database1.mdf;Integrated Security=True;Connect Timeout=30");
                //con.Open();
                SqlCommand cmd1 = new SqlCommand("SELECT deal_date FROM Deal WHERE deal_date = '" + dateTimePicker1.Text + "'", con);
                SqlDataReader sdr1 = cmd1.ExecuteReader();
                DateTime dateTime;
                if (textBox1.Text == "" || dateTimePicker1.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Please fill all text boxes");
                }

                

                else if (DateTime.TryParse(dateTimePicker1.Text, out dateTime) == false)
                {
                    MessageBox.Show("Not valid date");
                }

                else if (Convert.ToInt32(textBox3.Text) <= 0)
                {
                    MessageBox.Show("Enter the correct amount");
                }
                else if (DateTime.Parse(dateTimePicker1.Text) < DateTime.Today)
                {
                    MessageBox.Show("Date has passed");
                }
               
                else if (!checkList())
                {
                    MessageBox.Show("Select atleast one item");
                }
                else if (sdr1.Read() == true)
                {
                    MessageBox.Show("There is already a deal on this date");
                }
                else
                {
                    string q = "INSERT INTO Deal (deal_name,deal_date,deal_price) VALUES ('" + textBox1.Text + "','" + DateTime.Parse(dateTimePicker1.Text) + "','" + textBox3.Text + "')";
                    sdr1.Close();
                    SqlDataAdapter sda = new SqlDataAdapter(q, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    foreach (var checkItems in checkedListBox1.CheckedItems)
                    {
                        string query = "INSERT INTO menuDeal (deal_name, itemNo) values ('" + textBox1.Text + "',(select itemNo from Menu where itemName = '" + checkItems.ToString() + "'))";
                        SqlDataAdapter sda2 = new SqlDataAdapter(query, con);
                        sda2.SelectCommand.ExecuteNonQuery();
                    }
                    con.Close();
                    MessageBox.Show("Deal Added");
                }
            }
            catch (Exception eq)
            {
                MessageBox.Show(eq.StackTrace);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddDeal_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet2.Menu' table. You can move, or remove it, as needed.
            //this.menuTableAdapter.Fill(this.database1DataSet2.Menu);
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Value = DateTime.Today;
          
        }
        void populateCheckedBox()
        {
            string Sql = "select itemName from Menu";
            String conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand(Sql, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int statusIndex = rdr.GetOrdinal("itemName");
                string fil1 = rdr.IsDBNull(statusIndex) ? null : rdr.GetString(statusIndex);
                if (fil1 != null)
                {
                    checkedListBox1.Items.Add(fil1);
                }

            }
            rdr.Close();

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
          
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
           
        }

        private void maskedTextBox1_TypeValidationCompleted(object sender, TypeValidationEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Deals m = new Deals();
            m.Show();
        }
    }
}
