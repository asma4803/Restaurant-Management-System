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
    public partial class ViewReservationToRecep : Form
    {
        public ViewReservationToRecep()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Receptionist r = new Receptionist();
            r.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewAllReservation v = new ViewAllReservation(); 
            v.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewSelectedReservation v = new ViewSelectedReservation();
            v.Show();
        }

        private void ViewReservationToRecep_Load(object sender, EventArgs e)
        {

        }
    }
}
