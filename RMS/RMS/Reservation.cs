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
    public partial class Reservation : Form
    {
        public Reservation()
        {
            InitializeComponent();
            loadTables();
            getMaxResID();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT res_id FROM Reservation WHERE res_id = '" + textBox3.Text + "'", con);
            SqlDataReader sdr = cmd.ExecuteReader();
            int tblNo = (int)comboBox1.SelectedItem;
            DateTime dateTime;
            if (Convert.ToInt32(textBox1.Text) <= 0)
            {
                MessageBox.Show("Incorrect Number of chairs");
            }
            else if (sdr.Read()==true)
            {
                MessageBox.Show("Please try a different ID :) ");
            }
            else if (DateTime.TryParse(dateTimePicker1.Text, out dateTime) == false)
            {
                MessageBox.Show("Not valid date");
            }

            else if ( DateTime.Parse(dateTimePicker1.Text) < DateTime.Today)
            {
                MessageBox.Show("This date has passed, can't reserved");
            }

            else
            {
                string sql = "INSERT INTO Reservation (tableNo,noOfChairs , res_date, res_id,res_name) VALUES ( '" + tblNo + "','" + textBox1.Text + "','" + DateTime.Parse(dateTimePicker1.Text) + "','" + textBox3.Text + "','" + textBox4.Text + "')";
                sdr.Close();
                SqlDataAdapter sad = new SqlDataAdapter(sql, con);
                sad.SelectCommand.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Reserved Now");
            }
            con.Close();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Receptionist r = new Receptionist();
            //r.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        void getMaxResID() {
            int maxId = 0;
            String conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            String query = "Select MAX(res_id) from Reservation";
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read()) {
                 maxId= rdr.GetInt32(0);
            }
            int curr_id = maxId + 1;
            textBox3.Text = curr_id.ToString();
            textBox3.Enabled = false;
        }

        void loadTables()
        {
            String conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            string sql= "select tableNo from Reservation";
            SqlCommand cmd = new SqlCommand(sql, con);
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(ds);
            bool[] visited = new bool[51];
            for (int i = 1; i <= 50; i++)
                visited[i] = false;
            
            int c = ds.Tables[0].Rows.Count;
            for (int k = 0; k < c;k++)
            {
                visited[(int)ds.Tables[0].Rows[k]["tableNo"]] = true;
            }
            for (int i = 1; i <= 50; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if ((int)ds.Tables[0].Rows[j]["tableNo"] != i && !visited[i])
                    {
                        comboBox1.Items.Add(i);
                        visited[i] = true;
                    }
                }
            }
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Receptionist r = new Receptionist();
            r.Show();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Reservation_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Value = DateTime.Today;
        }
    }
}
