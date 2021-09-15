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
    public partial class intro : Form
    {
        public intro()
        {

            InitializeComponent();
        }

        private void horafecha_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblfecha.Text = DateTime.Now.ToString("dddd, dd  MMMM yyyy");
        }

        private void lblhora_Click(object sender, EventArgs e)
        {

        }
    }
}
