using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;

namespace Jimmy
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }
        WebClient cliente = new WebClient();
        string ruta = null;
        private void btndescargar_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialogo = new SaveFileDialog();
            dialogo.Filter = "Todos los archivos|*.*";
            dialogo.FileName = txturl.Text.Substring(txturl.Text.LastIndexOf("/") + 1);
            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                ruta = dialogo.FileName;
                cliente.DownloadFileAsync(new Uri(txturl.Text), dialogo.FileName);
            }
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            cliente.DownloadProgressChanged += new DownloadProgressChangedEventHandler(cargando);
            cliente.DownloadFileCompleted += new AsyncCompletedEventHandler(descargado);
        }

        private void cargando(object sender, DownloadProgressChangedEventArgs e)
        {
            pbprogreso.Value = e.ProgressPercentage;
            lbprogreso.Text = pbprogreso.Value.ToString() + "%";
        }

        private void descargado(object sender, AsyncCompletedEventArgs e)
        {
            pbprogreso.Value = 0;
            lbprogreso.Text = "0%";
            if (MessageBox.Show("¿Desea abrir el archivo descargado?", "Archivo Descargado", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(ruta);
            }
        }
    }
}
