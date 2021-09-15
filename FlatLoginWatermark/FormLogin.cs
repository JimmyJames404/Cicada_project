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
using System.Threading;
using Micron;
using Data.Models;
using FlatLoginWatermark;

namespace Jimmy
{
    public partial class FormLogin : Form
    {
        
        MicronDbContext micron = new MicronDbContext();
        public static string usuario = "administrador";
        //string psw = "12345";
        int cont = 0;
        bool a;

        string carpeta = Application.StartupPath + @"\Sucesos";

        public FormLogin()
        {
            InitializeComponent();

        }

        #region Drag Form/ Mover Arrastrar Formulario
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wmsg, int wparam, int lparam);
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region Placeholder or WaterMark
        private void txtuser_Enter(object sender, EventArgs e)
        {
            if (txtEmail2.Text == "Usuario")
            {
                txtEmail2.Text = "";
                txtEmail2.ForeColor = Color.LightGray;
            }
        }

        private void txtuser_Leave(object sender, EventArgs e)
        {
            if (txtEmail2.Text == "")
            {
                txtEmail2.Text = "Usuario";
                txtEmail2.ForeColor = Color.Silver;
            }
        }

        private void txtpass_Enter(object sender, EventArgs e)
        {
            if (txtPassword2.Text == "Contraseña")
            {
                txtPassword2.Text = "";
                txtPassword2.ForeColor = Color.LightGray;
                txtPassword2.UseSystemPasswordChar = true;
            }
        }

        private void txtpass_Leave(object sender, EventArgs e)
        {
            if (txtPassword2.Text == "")
            {
                txtPassword2.Text = "Contraseña";
                txtPassword2.ForeColor = Color.Silver;
                txtPassword2.UseSystemPasswordChar = false;
            }
        }

        #endregion 

        private void btncerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            timer2.Enabled = true;
            creando_carpeta();

        }

        //90%
        private void btnlogin_Click(object sender, EventArgs e)
        {/*

            if (txtUsuario.Text == "" || txtPsw.Text == "")
            {
                MessageBox.Show("Porfavor introduzca datos");
            }

            if (txtUsuario.Text == usuario && txtPsw.Text == psw)
            {


                MessageBox.Show("Bienvenido");
                a = true;
                impresion();
                Form form1 = new Form1();
                 form1.Show();
                 this.Hide();

            }
            else
            {
                a = false;
                impresion();
                label2.Visible = true;
                txtIntentos.Visible = true;
                cont = cont + 1;
                txtIntentos.Text = "Intento " + cont + " de 3";
                if (cont == 3)
                {
                    MessageBox.Show("¿Seguro que todo bien?");
                    pasoAsync();
                    cont = 0;
                }

                /*if (cont > 4)
                {
                    MessageBox.Show("Numero de intentos superado.....");
                    //Application.ExitThread();
                  
                }*/
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                txtPassword2.UseSystemPasswordChar = false;
            }
            else
            {
                txtPassword2.UseSystemPasswordChar = true;
            }
        }
        private void crear_perfil()
        {
            string carpetax = Application.StartupPath + @"\Perfiles";

            try
            {
                if (Directory.Exists(carpetax))
                {
                    //  MessageBox.Show("Carpeta existe");
                }
                else
                {
                    //  MessageBox.Show("Configurando \n . . . .");
                    Directory.CreateDirectory(carpetax);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            string carpetay = Application.StartupPath + @"\Perfiles\" + txtName.Text;

            try
            {
                if (Directory.Exists(carpetay))
                {
                    //  MessageBox.Show("Carpeta existe");
                }
                else
                {
                    // MessageBox.Show("Configurando \n . . . .");
                    Directory.CreateDirectory(carpetay);
                    // File.Create(crear);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            string[] bodega = new string[] { "Laboral", "Escolar", "Familiar", "Entretenimiento" };
            foreach (string i in bodega)
            {
                Console.Write("{0} ", i);
                string convertido;
                int unicode = 92;
                convertido = Convert.ToChar(unicode).ToString();
                string s = txtName.Text + convertido + i;
                string carpetaz = Application.StartupPath + @"\Perfiles\" + s;
                try
                {
                    if (Directory.Exists(carpetaz))
                    {
                        //  MessageBox.Show("Carpeta existe");
                    }
                    else
                    {
                        // MessageBox.Show("Configurando \n . . . .");
                        Directory.CreateDirectory(carpetaz);
                        // File.Create(crear);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void creando_carpeta()
        {

            string carpeta = Application.StartupPath + @"\Sucesos";
            DateTime fecha = DateTime.Now;
            string fech = fecha.Day.ToString() + "-" + fecha.Month.ToString() + "-" + fecha.Year.ToString() + ".txt";//Usando el objeto DateTime consigo dia-mes-año y lo monto en un string
            string archivo = @"\" + fech;
            string crear = carpeta + archivo;
            // MessageBox.Show("crear =" + crear);
            try
            {
                if (Directory.Exists(carpeta))
                {
                    // MessageBox.Show("Carpeta existe");
                }
                else
                {
                    MessageBox.Show("Configurando \n . . . .");
                    Directory.CreateDirectory(carpeta);
                    File.Create(crear);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private async Task pasoAsync()
        {

            txtEmail2.Enabled = false;
            txtPassword2.Enabled = false;
            btnlogin.Enabled = false;
            await Task.Delay(9000);
            txtEmail2.Enabled = true;
            txtPassword2.Enabled = true;
            btnlogin.Enabled = true;

           
     

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
                DateTime fecha1 = DateTime.Now;
                //DateTime fecha = DateTime.Today;
                escribir.WriteLine("Usuario: " + usuario);
                escribir.WriteLine("Password ingresada: " + txtPassword2.Text);
                escribir.WriteLine("Fecha : " + fecha1);
                if (a == true)
                {
                    escribir.WriteLine("Suceso : Ingreso exitosamente");
                }
                else
                {
                    escribir.WriteLine("Suceso : Ingreso fallido, su usuario/contraseña fue invalida");
                }

                escribir.WriteLine("\n");

            }
            catch
            {
                MessageBox.Show("Error");
            }
            escribir.Close();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Opacity = this.Opacity + .01;
            if (this.Opacity == 1)
            {
                timer2.Stop();

            }
            else { }
            //FormLogin.Opacity = 90;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void lineShape1_Click(object sender, EventArgs e)
        {

        }

        private void altoButton3_Click(object sender, EventArgs e)
        { //Aqui
            User user = micron.GetRecord<User>($"email='{txtEmail2.Text}'AND password = MD5('{txtPassword2.Text}')");
           /* if (user == null)
            {
                MessageBox.Show("Credenciales invalidas.");
                return;
            }*/

            //entrandoa al inicio
            this.Visible = false;
            var home = new Form1(user);
            home.ShowDialog();
            if(home.DialogResult != DialogResult.No) this.Close();
            //this.Visible = true;
        }

        private void txtPsw_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void altoButton2_Click(object sender, EventArgs e)
        {
           
            
        }

        private void altoButton1_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == false)
            {
                panel3.Visible = false;
                panel2.Visible = true;
            }
           
        }

        private void altoButton2_Click_1(object sender, EventArgs e)
        {
            
                panel3.Visible = true;
                panel2.Visible = false;
            
        }

        private void altoButton1_Click_1(object sender, EventArgs e)
        {
            if (panel2.Visible == false)
            {
                panel3.Visible = false;
                panel2.Visible = true;
            }
        }

        private void altoButton3_Click_1(object sender, EventArgs e)
        {
            if(txtConfirm.Text != txtPassword.Text)
            {
                MessageBox.Show("Contraseñas no coinciden");
            }
            else
            { 

                User user = micron.GetRecord<User>($"email='{txtEmail.Text}' AND password = MD5('{txtPassword.Text}')");
                if (user != null)
                {
                    MessageBox.Show("Usuario ya existente");
                    return;
                }

                user = new User()
                {
                    Name = txtName.Text,
                Email = txtEmail.Text,
                Password = Program.CalculateMD5Hash(txtPassword.Text)
                };

                user = micron.Save(user);
                MessageBox.Show("Cuenta creada satisfactoriamente");
                crear_perfil();
                txtEmail.Text = txtName.Text = txtPassword.Text = string.Empty;
                panel3.Visible = false;
                panel2.Visible = true;
                


             }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void gradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
