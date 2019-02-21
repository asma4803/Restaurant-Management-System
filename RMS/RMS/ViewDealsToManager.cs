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
    public partial class ViewDealsToManager : Form
    {
        public ViewDealsToManager()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            DateTime dateTime;
            if (string.IsNullOrEmpty(dateTimePicker1.Text) || (string.IsNullOrEmpty(dateTimePicker2.Text)))
            {
                MessageBox.Show("Fill all boxes First");
            }

            else if (DateTime.TryParse(dateTimePicker2.Text, out dateTime) == false || DateTime.TryParse(dateTimePicker1.Text, out dateTime) == false)
            {
                MessageBox.Show("invalid Dates");
            }
            else if (DateTime.Parse(dateTimePicker1.Text) > DateTime.Parse(dateTimePicker2.Text))
            {
                MessageBox.Show("Invalid Dates");
            }
            else
            {
                string sql2 = "select distinct deal_date AS Date, deal_name As Name, deal_price as Price  from Deal where deal_date between'" + DateTime.Parse(dateTimePicker1.Text) + "' and '" + DateTime.Parse(dateTimePicker2.Text) + "' order by deal_date";
                SqlDataAdapter adap = new SqlDataAdapter(sql2, con);

                DataTable dt = new DataTable();
                adap.Fill(dt);
                if (dt.Rows.Count == 0)
                {
                    dataGridView1.DataSource = null;
                    label4.Show();
                }
                else
                {
                    label4.Hide();
                    dataGridView1.DataSource = dt;
                }

            }

            con.Close();
        }

        private void ViewDealsToManager_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Deals d = new Deals();
            d.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
