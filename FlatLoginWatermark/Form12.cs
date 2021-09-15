using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jimmy
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void horafecha_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblfecha.Text = DateTime.Now.ToString("dddd, dd  MMMM yyyy");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            MessageBox.Show ("Archivos encriptados");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Archivos libres");
        }
    }
}
