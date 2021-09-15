using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using Data.Models;
using System.Security.Cryptography;

namespace Jimmy
{
    public partial class Form1 : Form
    {
        string carpeta = Application.StartupPath + @"\Sucesos";
        string a ="";
        string b = "";
        public Form1(User user)
        {
            InitializeComponent();

           // lblName.Text = $"Bienvenido {user.Name}";
            //lblEmail.Text = user.Email;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
          
        }

        private void btnrptventa_Click(object sender, EventArgs e)
        {
           
        }

        private void btnrptcompra_Click(object sender, EventArgs e)
        {
           
        }

        private void btnrptpagos_Click(object sender, EventArgs e)
        {
            
        }

        private void btnsalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea cerrar Sesion?", "Seguro...", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                
               // MessageBox.Show("Vuelva pronto!!.", "Hasta luego!", MessageBoxButtons.OK);
                //Environment.Exit(0);
                //this.Close();
                Form FormLogin = new FormLogin();
                this.Hide();
                FormLogin.ShowDialog();
                this.Close();
                //FormLogin.Show();
                

                /* 
                 Form FormLogin = new FormLogin();
                 FormLogin.Show();
                 this.Close();
                 */
                b = "El usuario cerro seccion";
                impresion();
            }
            else
            {
                a = "Cerrar sesion";
                impresion();
            }
        }

        private void MenuVertical_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void horafecha_Tick(object sender, EventArgs e)
        {
            
            lblhora.Text = DateTime.Now.ToString("HH:mm:ss");
            lblfecha.Text = DateTime.Now.ToString("dddd, dd  MMMM yyyy");
            
        }

        private void lblfecha_Click(object sender, EventArgs e)
        {
          
        }
        private void AbrirFormEnPanel(object formhija)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
           
            fh.Show();
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //AQUI II
           a = "Movimientos";
            impresion();
            AbrirFormEnPanel(new Form5());

        }

        private void lblhora_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
         
        }

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
           a = "Propiedades";
            impresion();
            AbrirFormEnPanel(new Form4());
        }

        private void button3_Click(object sender, EventArgs e)
        {//AQUI II
         a = "Copiar y mover";
            impresion();
            AbrirFormEnPanel(new Form2());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Form12());
            // AbrirFormEnPanel(panel1);
            //AbrirFormEnPanel(new intro());
        }
        private void impresion()
        {
           
            DateTime fecha = DateTime.Now;
            string fech = fecha.Day.ToString() + "-" + fecha.Month.ToString() + "-" + fecha.Year.ToString() + ".txt";
            string archivo = @"\" + fech;

            string suceso = (carpeta + archivo);
            StreamWriter escribir = new StreamWriter(suceso, true);

            try
            {
                string horat = DateTime.Now.ToString("hh:mm:ss");
                DateTime fecha1 = DateTime.Now;
                //DateTime fecha = DateTime.Today;
                
                escribir.WriteLine("El usuario ingreso a el apartado de "+ a);
                //escribir.WriteLine("Password ingresada: " + txtPsw.Text);
                escribir.WriteLine("Hora : " + horat);

               

                escribir.WriteLine("\n");

            }
            catch
            {
                MessageBox.Show("Error");
            }
            escribir.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            a = "Modo Office";
            impresion();
            AbrirFormEnPanel(new Form6());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            a = "Modo .rar";
            impresion();
            AbrirFormEnPanel(new Form9());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            a = "Modo .rar";
            impresion();
            AbrirFormEnPanel(new Form8());
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void gradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BarraTitulo2_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblhora_Click_1(object sender, EventArgs e)
        {

        }

        private void lblName_Click(object sender, EventArgs e)
        {

        }

        private void lblEmail_Click(object sender, EventArgs e)
        {

        }

        private void lblfecha_Click_1(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
         
            MessageBox.Show("Archivos encriptados");/*
            try
            {
                //PONE EL ARCHIVO A CONVERTIR EN BYTES
                Byte[] ARCHIVO = File.ReadAllBytes(txtOrigen.Text);
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
                FileStream DESTINO = new FileStream(txtDestino.Text, FileMode.OpenOrCreate, FileAccess.Write);

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
            }*/
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Archivos libres");
            /*
            try
            {
                //PONE EL ARCHIVO A CONVERTIR EN BYTES
                Byte[] ARCHIVO = File.ReadAllBytes(txtOrigen.Text);
                long TAMAÑO = ARCHIVO.Length;

                //PREPARA LA CLAVE PARA LA DESENCRIPTACION
                MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider(); //PREPARA LA CLAVE PARA LA ENCRIPTACION
                Byte[] CLAVE = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(txtClave.Text));
                MD5.Clear();

                //DEFINE EL TIPO DE ENCRIPTADO
                TripleDESCryptoServiceProvider TDC = new TripleDESCryptoServiceProvider();
                TDC.Key = CLAVE;
                TDC.Mode = CipherMode.ECB;

                //CREA E INICIALIZA EL STREAM PARA EL DESTINO
                FileStream DESTINO = new FileStream(txtDestino.Text, FileMode.OpenOrCreate, FileAccess.Write);

                //CREA E INICIALIZA EL STREAM PARA LA DESENCRIPTACION
                CryptoStream ENCRIPTADO = new CryptoStream(DESTINO, TDC.CreateDecryptor(), CryptoStreamMode.Write);

                //ENCRIPTA
                int num;

                num = Convert.ToInt32(TAMAÑO);
                ENCRIPTADO.Write(ARCHIVO, 0, num);

                DESTINO.Close(); //CIERRA EL STREAM DESTINO

                MessageBox.Show("HECHO"); //CONFIRMA QUE HA TERMINADO
            }
            catch
            {
                MessageBox.Show("error");
            }*/
        }

        private void button7_Click(object sender, EventArgs e)
        {
            a = "Modo Office";
            impresion();
            AbrirFormEnPanel(new Form13());
        }
    }
}

//C:\\temp\\test.txt