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
    public partial class SelectOne : Form
    {
        public SelectOne()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignInOrSigUp li = new SignInOrSigUp();
            li.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignInOrSigUp li = new SignInOrSigUp();
            li.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer li = new Customer();
            li.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.Show();
        }

        private void SelectOne_Load(object sender, EventArgs e)
        {

        }
    }
}
