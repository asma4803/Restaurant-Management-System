using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RMS
{
    public partial class SignInOrSigUp : Form
    {
        public SignInOrSigUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp n = new SignUp();
            n.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login l = new Login();
            l.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            SelectOne s = new SelectOne();
            s.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SignInOrSigUp_Load(object sender, EventArgs e)
        {

        }
    }
}
