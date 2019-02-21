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
    public partial class ViewSelected : Form
    {
        public ViewSelected()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewInventory v = new ViewInventory();
            v.Show();
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
                string sql2 = "select itmName AS Name, itm_date AS Date , qty AS Quantity from inventory where itm_date between'" + DateTime.Parse(dateTimePicker1.Text) + "' and '" + DateTime.Parse(dateTimePicker2.Text) + "' order by itm_date";
                SqlDataAdapter adap = new SqlDataAdapter(sql2, con);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                if (dt.Rows.Count == 0)
                {
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

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            dataGridView1.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;

        }

        private void dataGridView1_AutoSizeRowsModeChanged(object sender, DataGridViewAutoSizeModeEventArgs e)
        {
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        }

        private void ViewSelected_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.Value = DateTime.Today;
        }
    }
}
