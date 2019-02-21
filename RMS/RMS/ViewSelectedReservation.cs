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
    public partial class ViewSelectedReservation : Form
    {
        public ViewSelectedReservation()
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
                string sql2 = "select tableno, res_date as Date from reservation where res_date between'" + DateTime.Parse(dateTimePicker1.Text) + "' and '" + DateTime.Parse(dateTimePicker2.Text) + "' order by res_date";
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewReservationToRecep v = new ViewReservationToRecep();
            v.Show();
        }

        private void ViewSelectedReservation_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Value = DateTime.Today;

            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Value = DateTime.Today;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            int rowIndex = dataGridView1.CurrentCell.RowIndex;
            int tableNo = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[0].Value);
            dataGridView1.Rows.RemoveAt(rowIndex);
            String query = String.Format(@"Delete from reservation where tableNo = '{0}'", tableNo);
            SqlDataAdapter sda = new SqlDataAdapter(query, con);
            sda.SelectCommand.ExecuteNonQuery();
            MessageBox.Show("Resevation cancel");
            con.Close();
         
        }
    }
}
