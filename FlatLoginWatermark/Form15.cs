using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace GUI_MODERNISTA
{
    public partial class Form15 : Form
    {
        string tipo = "Solo datos";
        public Form15()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guardar();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            abrir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == true)
            {
                panel1.Visible = false;
            }
            else
                panel1.Visible = true;


        }

        private void button5_Click(object sender, EventArgs e)
        {
            //imprimir();
            /*StreamWriter escribir = new StreamWriter(@"C:\Users\Jimmy\Desktop\prueba1.txt", true);
            try
            {
                escribir.WriteLine("Matricula : " + textBox1.Text);
                escribir.WriteLine("Nombre : " + textBox2.Text);
                escribir.WriteLine("Telefono : " + textBox3.Text);
                escribir.WriteLine("Correo : " + textBox4.Text);
                escribir.WriteLine("\n");
            }
            catch
            {
                MessageBox.Show("Algo anda mal");
            }
            escribir.Close();*/

            ListViewItem itm;

            itm = new ListViewItem(Convert.ToString(textBox1.Text));
            itm.SubItems.Add(textBox2.Text);
            itm.SubItems.Add(textBox3.Text);
            itm.SubItems.Add(Convert.ToString(textBox4.Text));

            listView1.Items.Add(itm);
            //borrando
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

            // guardar2();
        }
       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guardar()
        {
            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "Documento de texto|*.txt";
            guardar.Title = "Guardar RichTextbox";
            guardar.FileName = "Sin titulo 1";
            var resultado = guardar.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                StreamWriter escribir = new StreamWriter(guardar.FileName);
                foreach (object line in richTextBox1.Lines)
                {
                    escribir.WriteLine(line);

                }
                escribir.Close();
            }
        }

        private void abrir()
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Filter = "Documento de texto|*.txt";
            abrir.Title = "Abrir...";
            abrir.FileName = "Sin titulo 1";
            var resultado = abrir.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                StreamReader leer = new StreamReader(abrir.FileName);
                richTextBox1.Text = leer.ReadToEnd();
                leer.Close();
            }

        }

        private void imprimir()
        {
            saveFileDialog1.FileName = "Sin titulo.txt";
            var sf = saveFileDialog1.ShowDialog();
            if (sf == DialogResult.OK)
            {
                using (var Savefile = new StreamWriter(saveFileDialog1.FileName, true))
                {
                    Savefile.WriteLine("Matricula: " + textBox1.Text + "\nNombre : " + textBox2.Text + "\nTelefono : " + textBox3.Text + "\nCorreo : " + textBox4.Text + "\n");

                }
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            //richTextBox2.Text = StreamReader ().ReadToEnd();
            /*StreamReader leer = new StreamReader(@"C:\Users\Jimmy\Desktop\prueba1.txt");
            richTextBox2.Text = leer.ReadToEnd();
            leer.Close();*/
        }
        private void abrir2()
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Filter = "Documento de texto|*.txt";
            abrir.Title = "Abrir...";
            abrir.FileName = "Sin titulo 1";
            var resultado = abrir.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                StreamReader leer = new StreamReader(abrir.FileName);
                richTextBox2.Text = leer.ReadToEnd();
                leer.Close();
            }

        }
        private void button4_Click_1(object sender, EventArgs e)
        {
            abrir2();
        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
                listView1.SelectedItems[0].SubItems[0].Text = textBox1.Text;
                listView1.SelectedItems[0].SubItems[1].Text = textBox2.Text;
                listView1.SelectedItems[0].SubItems[2].Text = textBox3.Text;
                listView1.SelectedItems[0].SubItems[3].Text = textBox4.Text;
            
        }

        private async void button8_ClickAsync(object sender, EventArgs e)
        {
            if (tipo == "Solo datos")
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (TextWriter tw = new StreamWriter(new FileStream(sfd.FileName, FileMode.Create), Encoding.UTF8))
                        {
                            foreach (ListViewItem item in listView1.Items)
                            {
                                await tw.WriteLineAsync(item.SubItems[0].Text + "\t" + item.SubItems[1].Text + "\t" + item.SubItems[2].Text + "\t" + item.SubItems[3].Text);
                            }
                            MessageBox.Show("Guardado Correctamente");
                        }
                    }
                }
            }
            else if(tipo == "especificado")
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (TextWriter tw = new StreamWriter(new FileStream(sfd.FileName, FileMode.Create), Encoding.UTF8))
                        {
                            foreach (ListViewItem item in listView1.Items)
                            {
                                await tw.WriteLineAsync(" Matricula : "+item.SubItems[0].Text + "\n Nombre : " + item.SubItems[1].Text + "\n Telefono : " + item.SubItems[2].Text + "\n Email : " + item.SubItems[3].Text+ "\n\n");
                            }
                            MessageBox.Show("Guardado Correctamente");
                        }
                    }
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem itm;

           

            if (this.listView1.SelectedItems.Count > 0)
            {
                itm = listView1.SelectedItems[0];

                textBox1.Text = Convert.ToString(itm.Text);

                textBox2.Text = itm.SubItems[1].Text;


                textBox3.Text = itm.SubItems[2].Text;

                textBox4.Text = itm.SubItems[3].Text;
            }
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            this.listView1.View = View.Details;
            this.listView1.FullRowSelect = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem fila in listView1.SelectedItems)
            {
                fila.Remove();

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                tipo = "Solo datos"; 
            }
            else // Si el radiobutton de la carpeta no esta seleccionado (significa lo contrario de la condición que antes hemos puesto).
            {
                tipo = "especificado"; // El tipo se cambiará a carpeta.
               
            }
        }
    }
}
