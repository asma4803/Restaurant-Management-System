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
    public partial class Deals : Form
    {
        public Deals()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manager m = new Manager();
            m.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AddDeal ad = new AddDeal();
            ad.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewDealsToManager d = new ViewDealsToManager();
            d.Show();
        }

        private void Deals_Load(object sender, EventArgs e)
        {

        }
    }
}
