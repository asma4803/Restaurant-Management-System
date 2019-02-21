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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login ln = new Login();
            ln.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewMenu vm = new ViewMenu();
            vm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewDeals vd = new ViewDeals();
            vd.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewReservationToCust vr = new ViewReservationToCust();
            vr.Show();
        }

        private void Customer_Load(object sender, EventArgs e)
        {

        }
    }
}
