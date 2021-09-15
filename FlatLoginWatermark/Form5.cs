using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using Microsoft.VisualBasic.Devices;

namespace Jimmy 
{
    public partial class Form5 : Form
    {

        Computer mycomputer = new Computer(); // Así accederemos al "FileSystem".
        string tipo = "carpeta";
        public Form5()
        {
            InitializeComponent();
        }
        private async Task pasoAsync()
        {


            await Task.Delay(3000);

        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (tipo == "carpeta") { mycomputer.FileSystem.CopyDirectory(textBox1.Text, textBox2.Text); } // Copiamos la carpeta.
            if (tipo == "archivo") { mycomputer.FileSystem.CopyFile(textBox1.Text, textBox2.Text); } // Copiamos el archivo.
            this.timer1.Start();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (tipo == "carpeta") { mycomputer.FileSystem.MoveDirectory(textBox1.Text, textBox2.Text); } // Movemos la carpeta.
            if (tipo == "archivo") { mycomputer.FileSystem.MoveFile(textBox1.Text, textBox2.Text); } // Movemos el archivo.
            this.timer1.Start();
            this.progressBar1.Increment(-100);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var resultado = fbd1.ShowDialog();
            if (resultado == DialogResult.OK) { textBox2.Text = fbd1.SelectedPath + textBox1.Text.Substring(textBox1.Text.LastIndexOf(@"\")); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var resultado = fbd1.ShowDialog();
            if (resultado == DialogResult.OK) { textBox1.Text = fbd1.SelectedPath; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var resultado = ofd1.ShowDialog();
            if (resultado == DialogResult.OK) { textBox1.Text = ofd1.FileName; }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                tipo = "carpeta"; // El tipo se cambiará a archivo.
                button1.Enabled = true;
                button2.Enabled = false; //Para poder seleccionar un archivo y no una carpeta.
            }
            else // Si el radiobutton de la carpeta no esta seleccionado (significa lo contrario de la condición que antes hemos puesto).
            {
                tipo = "archivo"; // El tipo se cambiará a carpeta.
                button1.Enabled = false;
                button2.Enabled = true; //Para poder seleccionar una carpeta y no un archivo.
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            //aqui talvez
            this.progressBar1.Increment(1);
     

        }
        private async Task Worker_ProgressChangedAsync(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            //label3.Text = progressBar1.Value + " %";
            if (progressBar1.Value == 100)
            {
                await Task.Delay(2000);
                progressBar1.Value = 0;
            }
        
        }
        private void textBox1_DragDrop(object sender, DragEventArgs e)
        {
            // This just allows you to drop a file into the textbox and display it's path.
            string[] files1 = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string file1 in files1)
                textBox1.Text = file1;
        }

        private void textBox1_DragEnter(object sender, DragEventArgs e)
        {
            //Drag and drop effect in windows
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }

        }

        private void textBox2_DragDrop(object sender, DragEventArgs e)
        {
            string[] files2 = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            foreach (string file2 in files2)
                textBox2.Text = file2;
        }

        private void textBox2_DragEnter(object sender, DragEventArgs e)
        {
            //Drag and drop effect in windows
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.All;
            }
        }

        private void button11_DragDrop(object sender, DragEventArgs e)
        {
            //obtenemos arreglo con los archivos
            string[] archivos=(string[])e.Data.GetData(DataFormats.FileDrop, false);
            //string linea = "";

            textBox1.Text = archivos[0];
            textBox2.Text = Application.StartupPath + @"\Perfiles\Jimmy\Laboral" + textBox1.Text.Substring(textBox1.Text.LastIndexOf(@"\")); ;
            mover();


        }

        private void button11_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button10_DragDrop(object sender, DragEventArgs e)
        {
            //obtenemos arreglo con los archivos
            string[] archivos = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            //string linea = "";

            textBox1.Text = archivos[0];
            textBox2.Text = Application.StartupPath + @"\Perfiles\Jimmy\Escolar" + textBox1.Text.Substring(textBox1.Text.LastIndexOf(@"\")); ;
            mover();
        }

        private void button9_DragDrop(object sender, DragEventArgs e)
        {
            //obtenemos arreglo con los archivos
            string[] archivos = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            //string linea = "";

            textBox1.Text = archivos[0];
            textBox2.Text = Application.StartupPath + @"\Perfiles\Jimmy\Familiar" + textBox1.Text.Substring(textBox1.Text.LastIndexOf(@"\")); ;
            mover();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            criptar();
        }

        private void button8_DragDrop(object sender, DragEventArgs e)
        {
            //obtenemos arreglo con los archivos
            string[] archivos = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            //string linea = "";

            textBox1.Text = archivos[0];
            textBox2.Text = Application.StartupPath + @"\Perfiles\Jimmy\Entretenimiento" + textBox1.Text.Substring(textBox1.Text.LastIndexOf(@"\")); ;
            
            //mover();
        }
        private void mover()
        {
            if (tipo == "carpeta") { mycomputer.FileSystem.MoveDirectory(textBox1.Text, textBox2.Text); } // Movemos la carpeta.
            if (tipo == "archivo") { mycomputer.FileSystem.MoveFile(textBox1.Text, textBox2.Text); } // Movemos el archivo.
            this.timer1.Start();
            this.progressBar1.Increment(-100);
        }
        private void button8_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void button10_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void button9_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                //PONE EL ARCHIVO A CONVERTIR EN BYTES
                Byte[] ARCHIVO = File.ReadAllBytes(textBox1.Text);
                long TAMAÑO = ARCHIVO.Length;
                int num;

                //PREPARA LA CLAVE PARA LA ENCRIPTACION
                MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider(); //PREPARA LA CLAVE PARA LA ENCRIPTACION
                Byte[] CLAVE = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(txtClave.Text));
                MD5.Clear();

                //DEFINE EL TIPO DE ENCRIPTADO
                TripleDESCryptoServiceProvider TDC = new TripleDESCryptoServiceProvider();
                TDC.Key = CLAVE;
                TDC.Mode = CipherMode.ECB;

                //CREA E INICIALIZA EL STREAM PARA EL DESTINO
                FileStream DESTINO = new FileStream(textBox2.Text, FileMode.OpenOrCreate, FileAccess.Write);

                //CREA E INICIALIZA EL STREAM PARA LA ENCRIPTACION
                CryptoStream ENCRIPTADO = new CryptoStream(DESTINO, TDC.CreateEncryptor(), CryptoStreamMode.Write);

                //ENCRIPTA
                num = Convert.ToInt32(TAMAÑO);
                ENCRIPTADO.Write(ARCHIVO, 0, num);

                DESTINO.Close(); //CIERRA EL STREAM DESTINO

                MessageBox.Show("HECHO"); //CONFIRMA QUE HA TERMINADO
            }
            catch
            {
                MessageBox.Show("error");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }
        private void criptar()
        {
            try
            {
                //PONE EL ARCHIVO A CONVERTIR EN BYTES
                Byte[] ARCHIVO = File.ReadAllBytes(textBox1.Text);
                long TAMAÑO = ARCHIVO.Length;
                int num;

                //PREPARA LA CLAVE PARA LA ENCRIPTACION
                MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider(); //PREPARA LA CLAVE PARA LA ENCRIPTACION
                Byte[] CLAVE = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(txtClave.Text));
                MD5.Clear();

                //DEFINE EL TIPO DE ENCRIPTADO
                TripleDESCryptoServiceProvider TDC = new TripleDESCryptoServiceProvider();
                TDC.Key = CLAVE;
                TDC.Mode = CipherMode.ECB;

                //CREA E INICIALIZA EL STREAM PARA EL DESTINO
                FileStream DESTINO = new FileStream(textBox2.Text, FileMode.OpenOrCreate, FileAccess.Write);

                //CREA E INICIALIZA EL STREAM PARA LA ENCRIPTACION
                CryptoStream ENCRIPTADO = new CryptoStream(DESTINO, TDC.CreateEncryptor(), CryptoStreamMode.Write);

                //ENCRIPTA
                num = Convert.ToInt32(TAMAÑO);
                ENCRIPTADO.Write(ARCHIVO, 0, num);

                DESTINO.Close(); //CIERRA EL STREAM DESTINO

                MessageBox.Show("HECHO"); //CONFIRMA QUE HA TERMINADO
            }
            catch
            {
                MessageBox.Show("error");
            }
        }
    }
}
