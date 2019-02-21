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
    public partial class InsertInInven : Form
    {
        public InsertInInven()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inventory inven = new Inventory();
            inven.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                String conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                //string[] formats = new string[7] { "dd/MM/yyyy", "dd-MM-yyyy", "dd.MM.yyyy", "MM/dd/yyyy", "MM-dd-yyyy", "MM.dd.yyyy", "dd-mm-yy" };
                //try
                //{
                //    DateTime result = DateTime.ParseExact(textBox2.Text, formats, CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal);

                //}
                //catch (Exception)
                //{
                //    MessageBox.Show("Not Proper date format");
                //}

                DateTime dateTime;
                


                if (textBox1.Text == "" || textBox2.Text == "" || dateTimePicker1.Text == "")
                {
                    MessageBox.Show("Fill all text box first");
                }
                else if (Convert.ToInt32( textBox2.Text) <= 0)
                {
                    MessageBox.Show("Quantity should be more 😊");
                }
                else if (DateTime.TryParse(dateTimePicker1.Text, out dateTime) == false)
                {
                    MessageBox.Show("Not valid date");
                }
                else if ( DateTime.Parse(dateTimePicker1.Text) < DateTime.Today)
                {
                    MessageBox.Show("This date has passed, please enter new date");
                }
                else
                {
                    string q = "INSERT INTO INVENTORY (itmName , qty , itm_date) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + DateTime.Parse(dateTimePicker1.Text) + "')";
                    SqlDataAdapter sda = new SqlDataAdapter(q, con);
                    sda.SelectCommand.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Item Inserted in Inventory");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Can't Enter Again in inventory.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void InsertInInven_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Value = DateTime.Today;
        }
    }
}
