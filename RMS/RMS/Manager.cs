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
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login ln = new Login();
            ln.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu m = new Menu();
            m.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Deals ad = new Deals();
            ad.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inventory inven = new Inventory();
            inven.Show();
        }

        private void Manager_Load(object sender, EventArgs e)
        {

        }
    }
}
