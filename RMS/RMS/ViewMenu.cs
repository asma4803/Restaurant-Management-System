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
    public partial class ViewMenu : Form
    {
        SqlConnection con;
      
        public ViewMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer c = new Customer();
            c.Show();
        }

        private void ViewMenu_Load(object sender, EventArgs e)
        {
            try
            {
                String conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
                con = new SqlConnection(conString);
                con.Open();

                //SqlDataAdapter sda2 = new SqlDataAdapter("Create OR REPLACE View MenuVU AS select itemName , itemPrice from menu", con);
                //sda2.SelectCommand.ExecuteNonQuery();

                SqlDataAdapter adap = new SqlDataAdapter("select itemName AS ITEMS, itemPrice AS PRICE from Menu", con);
                DataTable dt = new DataTable();
                adap.Fill(dt);
                dataGridView1.DataSource = dt;
                VisiDataView();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void VisiDataView()
        {
            foreach ( DataGridViewRow dr in dataGridView1.Rows)
            {
                if ( dr.Cells[0].Value.ToString() =="")
                {
                    CurrencyManager currencyManager1 = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                    currencyManager1.SuspendBinding();
                    dr.Visible = false;
                }
            }
            dataGridView1.Refresh();
        }
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //if(dataGridView1.Columns[e.ColumnIndex].Name == "itemName")
            //{
            //    if ( String.IsNullOrEmpty(e.FormattedValue.ToString()))
            //    {
                    
            //    }
            //}
        }

        private void dataGridView1_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            dataGridView1.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dataGridView1_AutoSizeRowsModeChanged(object sender, DataGridViewAutoSizeModeEventArgs e)
        {
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }
    }
}
