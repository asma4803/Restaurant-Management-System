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
    public partial class ViewInventory : Form
    {
        public ViewInventory()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inventory v = new Inventory();
            v.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewAllInven v = new ViewAllInven();
            v.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewSelected v = new ViewSelected();
            v.Show();
        }

        private void ViewInventory_Load(object sender, EventArgs e)
        {

        }
    }
}
