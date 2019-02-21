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
    public partial class ViewDeals : Form
    {
        public ViewDeals()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Customer c = new Customer();
            //c.Show();
        }

        private void ViewDeals_Load(object sender, EventArgs e)
        {
            try
            {
                String conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
                SqlConnection con = new SqlConnection(conString);
                con.Open();              

                string sql = "Select deal_name AS DealName , deal_price AS Price from Deal where deal_date = '" + DateTime.Today + "'";
                SqlDataAdapter adap = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                adap.Fill(dt);

                string sq2 = "Select m.itemName AS ITEMS from Menu m ,Deal d, menuDeal md where m.itemNo = md.itemNo AND md.deal_name = d.deal_name AND deal_date = '" + DateTime.Today + "'group by m.itemName";
                SqlDataAdapter adap1 = new SqlDataAdapter(sq2, con);
                DataTable dt1 = new DataTable();
                adap1.Fill(dt1);

                if (dt.Rows.Count == 0)
                {
                    this.label1.Show();
                    this.label2.Show();
                    dataGridView1.Hide();
                    dataGridView2.Hide();
                }
                else
                {
                    dataGridView1.DataSource = dt;
                    dataGridView2.DataSource = dt1;
                }
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Some Problem has occured.");
            }
        }

        private void dataGridView2_AutoSizeRowsModeChanged(object sender, DataGridViewAutoSizeModeEventArgs e)
        {
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void dataGridView2_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            dataGridView2.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Customer c = new Customer();
            c.Show();
        }
    }
}
