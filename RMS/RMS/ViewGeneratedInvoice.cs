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
    public partial class ViewGeneratedInvoice : Form
    {
        public ViewGeneratedInvoice()
        {
            InitializeComponent();
        }

        private void GeneratedInvoice_Load(object sender, EventArgs e)
        {
            String conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();

            string query2 = "Select max(cust_id) from [customer]";
            SqlCommand cmd = new SqlCommand(query2, con);
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            int custno = Convert.ToInt32(ds.Tables[0].Rows[(ds.Tables[0].Rows.Count) - 1][0]);

            string q2 = "Select max(ord_No) from [CustOrder]";
            SqlCommand cmd1 = new SqlCommand(q2, con);
            DataSet ds1 = new DataSet();
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            sda1.Fill(ds1);
            int ordno = Convert.ToInt32(ds1.Tables[0].Rows[(ds1.Tables[0].Rows.Count) - 1][0]);

            
            string sql2 = "select invo_no InvoiceNO, cust_id AS CustomerID, ord_no AS OrderNO, invo_date AS Date,ISNULL(deal_name,'NULL') As DealName , noOfDeals As NoOfDeals ,amount AS Amount from invoice where cust_id = '"+custno+"'" ;
            SqlDataAdapter adap = new SqlDataAdapter(sql2, con);
            DataTable dt = new DataTable();
            adap.Fill(dt);
            dataGridView1.DataSource = dt;

            ordno = ordno - 1;

            string q = "Select I.itemName As Name, I.itemPrice As Price,O.noOfItem As NumberOfItems from orderMenu O, Menu I where O.itemNo = I.itemNo and O.ord_No ='" + ordno + "' Group by I.itemName , I.itemPrice , O.noOfItem ";
            SqlDataAdapter adap2 = new SqlDataAdapter(q, con);
            DataTable dt1 = new DataTable();
            adap2.Fill(dt1);
            dataGridView2.DataSource = dt1;



            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
           Receptionist g = new Receptionist();
            g.Show();
        }

        private void dataGridView2_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dataGridView1.Columns[e.Column.Index].FillWeight = e.Column.FillWeight;
        }

        private void dataGridView2_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            dataGridView2.Columns[e.Column.Index].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void dataGridView2_AutoSizeRowsModeChanged(object sender, DataGridViewAutoSizeModeEventArgs e)
        {
            dataGridView2.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
