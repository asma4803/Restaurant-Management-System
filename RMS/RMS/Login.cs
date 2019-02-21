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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            textBox2.PasswordChar = '*';
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SelectOne so = new SelectOne();
            so.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String conString = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            SqlConnection con = new SqlConnection(conString);
            con.Open();
            String query = String.Format(@"Select * from [User] where login = '{0}' and password = '{1}'", textBox1.Text, textBox2.Text);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                bool mngr = rdr.GetBoolean(3);
                bool recep = rdr.GetBoolean(4);
                if (mngr)
                {
                    this.Hide();
                    Manager m = new Manager();
                    m.Show();
                }
                
               else if (recep)
                {
                    this.Hide();
                    Receptionist r = new Receptionist();
                    r.Show();
                }
            }
            else
            {
                MessageBox.Show("Wrong username/Password");
            }
            con.Close();
        }
        private void Login_Load(object sender, EventArgs e)
        {

        }
           
    }
}
