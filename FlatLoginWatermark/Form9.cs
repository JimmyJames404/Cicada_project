using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Compression;
using System.IO;

namespace Jimmy
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        public static void Compresion(string NombreArchivo)
        {
            FileStream Archivo;
            try
            {
                // Leemos el archivo a comprimir
                Archivo = new FileStream(NombreArchivo, FileMode.Open, FileAccess.Read, FileShare.Read);

                //Definimos el buffer con el tamaño del archivo
                byte[] btBuffer = new byte[Archivo.Length];

                //Almacenamos los bytes del archivo en el buffer
                int intCount = Archivo.Read(btBuffer, 0, btBuffer.Length);
                Archivo.Close();

                //Definimos el nuevo stream que nos va a permitir grabar el zip
                FileStream Salida = new FileStream(NombreArchivo + ".zip", FileMode.Create, FileAccess.Write);

                //Rutina de compresion usando GZipStream
                GZipStream gzsArchivo = new GZipStream(Salida, CompressionMode.Compress, true);

                //Escribimos el resultado
                gzsArchivo.Write(btBuffer, 0, btBuffer.Length);
                gzsArchivo.Close();

                //Cerramos el archivo
                Salida.Flush();
                Salida.Close();

                MessageBox.Show("Compresion realizada correctamente al archivo: " + NombreArchivo + ".zip");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al comprimir: " + ex.Message);

            }
        }





        public static void Descompresion(string NombreArchivo)
        {
            FileStream Archivo;
            try
            {
                //Leemos archivo a descomprimir
                Archivo = new FileStream(NombreArchivo, FileMode.Open, FileAccess.Read, FileShare.Read);
                GZipStream gzsArchivo = new GZipStream(Archivo, CompressionMode.Decompress);

                //Codigo implementado para conocer las dimensiones que va a tener nuestro                                        buffer, acumulativo.
                int offset = 0;
                int intCountBytes = 0;
                byte[] btSmallBuffer = new byte[100];
                while (true)
                {
                    int bytesRead = gzsArchivo.Read(btSmallBuffer, 0, 100);
                    if (bytesRead == 0)
                    {
                        break;
                    }
                    offset += bytesRead;
                    intCountBytes += bytesRead;
                }
                //Creamos el buffer con el tamaño requerido
                byte[] buffer = new byte[intCountBytes];

                //Leemos el contenido del archivo comprimido al buffer
                Archivo = new FileStream(NombreArchivo, FileMode.Open, FileAccess.Read, FileShare.Read);
                gzsArchivo = new GZipStream(Archivo, CompressionMode.Decompress);
                int intCount = gzsArchivo.Read(buffer, 0, intCountBytes);
                gzsArchivo.Close();

                //Escribimos la salida a un nuevo archivo, ya descomprimido
                FileStream Salida = new FileStream(NombreArchivo.Substring(0, NombreArchivo.Length - 4), FileMode.Create, FileAccess.Write);
                Salida.Write(buffer, 0, intCountBytes);
                Salida.Flush();
                Salida.Close();

                MessageBox.Show("Descompresion realizada correctamente al archivo: " + NombreArchivo.Substring(0, NombreArchivo.Length - 4) + ".zip");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al descomprimir: " + ex.Message);

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Compresion(ofd.FileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Descompresion(ofd.FileName);
            }
        }
    }
}

