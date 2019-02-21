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
    public partial class Receptionist : Form
    {
        public Receptionist()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login ln = new Login();
            ln.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Reservation rs = new Reservation();
            rs.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            PlaceOrder po = new PlaceOrder();
            po.Show();
        }

        private void Receptionist_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewReservationToRecep v = new ViewReservationToRecep();
            v.Show();
        }
    }
}
