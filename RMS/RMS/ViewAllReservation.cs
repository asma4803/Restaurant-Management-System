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
    public partial class ViewAllReservation : Form
    {
        public ViewAllReservation()
        {
            InitializeComponent();
        }

        private void dataGridView1_AutoSizeRowsModeChanged(object sender, DataGridViewAutoSizeModeEventArgs e)
        {
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            dataGridView1.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;

        }

        private void ViewAllReservation_Load(object sender, EventArgs e)
        {
            String conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string sql2 = "select tableNo, res_date as Date from reservation order by res_date";
            SqlDataAdapter adap = new SqlDataAdapter(sql2, con);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewReservationToRecep v = new ViewReservationToRecep();
            v.Show();
        }
    }
}
