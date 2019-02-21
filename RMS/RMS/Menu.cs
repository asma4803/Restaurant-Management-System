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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            InsertInMenu im = new InsertInMenu();
            im.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ModifyItemInMenu mm = new ModifyItemInMenu();
            mm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            RemoveItemInMenu rm = new RemoveItemInMenu();
            rm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Manager m = new Manager();
            m.Show();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }
    }
}
