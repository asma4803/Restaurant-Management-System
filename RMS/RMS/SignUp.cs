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
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
            textBox3.PasswordChar = '*';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            bool IsManager = false;
            bool IsReceptionist = false;
            if (checkBox1.Checked && checkBox2.Checked)
            {
                MessageBox.Show("Please Select only one box");
            }

            else if (checkBox1.Checked)
            {
                IsManager =true;
            }
            else if (checkBox2.Checked)
            {
                IsReceptionist = true;
            }
            else if (!checkBox1.Checked || !checkBox2.Checked || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Fill All the boxes");
            }
          
                string query = "INSERT INTO [User] (login ,password,IsManager,IsReceptionist) VALUES ('" + textBox2.Text + "', '" + textBox3.Text + "','" + IsManager + "','" + IsReceptionist + "')";
                SqlDataAdapter sd = new SqlDataAdapter(query, con);
                sd.SelectCommand.ExecuteNonQuery();

            MessageBox.Show("Welcome");
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Login l = new Login();
            //l.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignInOrSigUp o = new SignInOrSigUp();
            o.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }
    }
}
