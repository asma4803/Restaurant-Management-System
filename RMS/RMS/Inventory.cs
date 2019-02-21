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
    public partial class Inventory : Form
    {
        public Inventory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            InsertInInven inven = new InsertInInven();
            inven.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ItemUpdateInIven invenUp = new ItemUpdateInIven();
            invenUp.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manager m = new Manager();
            m.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewInventory vi = new ViewInventory();
            vi.Show();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {

        }
    }
}
