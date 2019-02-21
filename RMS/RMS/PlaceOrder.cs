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
    public partial class PlaceOrder : Form
    {
        public PlaceOrder()
        {
            InitializeComponent();
            populateComboBox();
            textBox3.MaxLength = 11;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
        void populateComboBox()
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
                    comboBox1.Items.Add(fil1);
                }
            }
            rdr.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
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


                string query1 = "Insert into CustOrder(ran,cust_id) Values(1,'" + custno + "')";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                SqlDataAdapter sda2 = new SqlDataAdapter(cmd1);
                cmd1.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Items Added");
            }
            catch (Exception)
            {
                MessageBox.Show("Some Problem has occured");
            }
        }

        private void PlaceOrder_Load(object sender, EventArgs e)
        {
            String conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string q = "Select deal_name from Deal where deal_date = '" + DateTime.Today + "'";
            SqlCommand cmd = new SqlCommand(q,con);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read()==true)
            {
                textBox4.Text = sdr.GetValue(0).ToString();
            }
            else
            {
                textBox4.Text = "   ---   ";
            }
            con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            String conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            if (textBox1.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("fill the boxes first");
            }
            else
            {
                string query1 = "Insert into customer ( cust_name , phNO) Values ( '" + textBox1.Text + "','" + textBox3.Text + "')";
                SqlCommand cmd1 = new SqlCommand(query1, con);
                SqlDataAdapter sda2 = new SqlDataAdapter(cmd1);
                cmd1.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Customer Added");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            String conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string query2 = "Select max(ord_No) from [CustOrder]";
            SqlCommand cmd = new SqlCommand(query2, con);
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            int ordno = Convert.ToInt32(ds.Tables[0].Rows[(ds.Tables[0].Rows.Count) - 1][0]) ;

            Object itm = comboBox1.SelectedItem;
            if ( Convert.ToInt32(textBox2.Text) <= 0)
            {
                MessageBox.Show("please correct the number");
            }
            else
            {
                string query = "INSERT INTO orderMenu (ord_no,itemNo,noOfItem) VALUES ('" + (int)ordno + "',(select itemNo from Menu where itemName = '" + itm + "'),'" + textBox2.Text + "')";
                cmd = new SqlCommand(query, con);
                int i = cmd.ExecuteNonQuery();
                MessageBox.Show("Item added, Next Please");
            }
            con.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Receptionist r = new Receptionist();
            r.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int amount = 0;
            String conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();

            string query1 = "Select max(cust_id) from [customer]";
            SqlCommand cmd1 = new SqlCommand(query1, con);
            DataSet ds1 = new DataSet();
            SqlDataAdapter sda1 = new SqlDataAdapter(cmd1);
            sda1.Fill(ds1);
            int custno = Convert.ToInt32(ds1.Tables[0].Rows[(ds1.Tables[0].Rows.Count) - 1][0]);

            string query2 = "Select max(ord_No) from [CustOrder]";
            SqlCommand cmd2 = new SqlCommand(query2, con);
            DataSet ds2 = new DataSet();
            SqlDataAdapter sda2 = new SqlDataAdapter(cmd2);
            sda2.Fill(ds2);
            int ordno = Convert.ToInt32(ds2.Tables[0].Rows[(ds2.Tables[0].Rows.Count) - 1][0]) - 1;

            string q = "Select (ord.noOfItem * I.itemPrice) from orderMenu ord, Menu I where ord.itemNo = I.itemNo and ord.ord_No ='" + ordno + "' GROUP BY (ord.noOfItem * I.itemPrice)";
            SqlCommand cmd = new SqlCommand(q, con);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                amount = amount + Convert.ToInt32(dr[0]);
            }
            dr.Close();
            if ((textBox5.Text) =="")
            {
                string q2 = "Insert into invoice (cust_id , ord_no, invo_date,amount) Values( '" + custno + "','" + ordno + "','" + DateTime.Today + "','" + amount + "')";
                SqlDataAdapter sd = new SqlDataAdapter(q2, con);
                sd.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Order has been placed");
            }

            else if ( Convert.ToInt32(textBox5.Text) > 0)
            {
                string str = "Select deal_price from deal where deal_name = '" + textBox4.Text + "' AND deal_date='" + DateTime.Today + "'";
                SqlCommand cmd8 = new SqlCommand(str, con);
                DataSet ds8 = new DataSet();
                SqlDataAdapter sda8 = new SqlDataAdapter(cmd8);
                sda8.Fill(ds8);
                int Price = Convert.ToInt32(ds8.Tables[0].Rows[(ds8.Tables[0].Rows.Count) - 1][0]);
                Price = Price * Convert.ToInt32(textBox5.Text);
                amount = amount + Price;
                string q2 = "Insert into invoice (cust_id , ord_no, invo_date, deal_name ,noOfDeals,amount) Values( '" + custno + "','" + ordno + "','" + DateTime.Today + "','" + textBox4.Text + "','" + textBox5.Text + "','" + amount + "')";
                SqlDataAdapter sd = new SqlDataAdapter(q2, con);
                sd.SelectCommand.ExecuteNonQuery();
                MessageBox.Show("Order has been placed");
            }


            con.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Invoice Generated");
            this.Hide();
            ViewGeneratedInvoice v = new ViewGeneratedInvoice();
            v.Show();

        }
    }

}
