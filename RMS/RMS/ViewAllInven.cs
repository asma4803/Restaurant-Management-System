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
    public partial class ViewAllInven : Form
    {
        public ViewAllInven()
        {
            InitializeComponent();
        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            dataGridView1.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dataGridView1_AutoSizeRowsModeChanged(object sender, DataGridViewAutoSizeModeEventArgs e)
        {
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewInventory v = new ViewInventory();
            v.Show();
        }

        private void ViewAll_Load(object sender, EventArgs e)
        {
            String conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            string sql2 = "select itmName AS Name, itm_date As Date , qty AS Quantity from inventory order by itm_date";
            SqlDataAdapter adap = new SqlDataAdapter(sql2, con);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("No Record avaliable");
                Application.Exit();
            }
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
