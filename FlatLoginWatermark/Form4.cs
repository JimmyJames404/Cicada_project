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
using static System.Windows.Forms.ListViewItem;

namespace Jimmy
{
    public partial class Form4 : Form
    {
        string tipo = "Solo datos";
        public Form4()
        {
            InitializeComponent();
        }

        private async Task button8_ClickAsync(object sender, EventArgs e)
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
            else if (tipo == "especificado")
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (TextWriter tw = new StreamWriter(new FileStream(sfd.FileName, FileMode.Create), Encoding.UTF8))
                        {
                            foreach (ListViewItem item in listView1.Items)
                            {
                                await tw.WriteLineAsync(" Empresa : " + item.SubItems[0].Text + "\n Nombre : " + item.SubItems[1].Text + "\n Telefono : " + item.SubItems[2].Text + "\n Email : " + item.SubItems[3].Text + "\n\n");
                            }
                            MessageBox.Show("Guardado Correctamente");
                        }
                    }
                }
            }
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            this.listView1.View = View.Details;
            this.listView1.FullRowSelect = true;
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

        private void button5_Click(object sender, EventArgs e)
        {
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
        }

        private void button7_Click(object sender, EventArgs e)
        {

           //listView1.SelectedItems[0].SubItems[0].Text = textBox1.Text;
            listView1.SelectedItems[0].SubItems[1].Text = textBox2.Text;
            listView1.SelectedItems[0].SubItems[2].Text = textBox3.Text;
            listView1.SelectedItems[0].SubItems[3].Text = textBox4.Text;
            textBox1.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem fila in listView1.SelectedItems)
            {
                fila.Remove();

            }
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
        private void button4_Click(object sender, EventArgs e)
        {
            abrir2();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            this.listView1.View = View.Details;
            this.listView1.FullRowSelect = true;

        }

        private void Button8_ClickAsync(object sender, EventArgs e)
        {
            abrir2();
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
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
            else if (tipo == "especificado")
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Text Documents|*.txt", ValidateNames = true })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (TextWriter tw = new StreamWriter(new FileStream(sfd.FileName, FileMode.Create), Encoding.UTF8))
                        {
                            foreach (ListViewItem item in listView1.Items)
                            {
                                await tw.WriteLineAsync(" Empresa : " + item.SubItems[0].Text + "\n Nombre : " + item.SubItems[1].Text + "\n Telefono : " + item.SubItems[2].Text + "\n Email : " + item.SubItems[3].Text + "\n\n");
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
            textBox1.Enabled = false;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog abrir = new OpenFileDialog();
            abrir.Filter = "Documento de texto|*.txt";
            abrir.Title = "Abrir...";
            abrir.FileName = "Sin titulo 1";
            var resultado = abrir.ShowDialog();
            if (resultado == DialogResult.OK)
            {

                string line = "";
                foreach (ListViewItem item in this.listView1.Items)
                {
                    StreamWriter file = new StreamWriter(abrir.FileName ,true);
                    line = "";
                    foreach (ListViewSubItem subitem in item.SubItems)
                    {
                        line += subitem.Text + ", ";
                    }
                    file.WriteLine(line);
                }
               // file.Close();
                //StreamReader leer = new StreamReader(abrir.FileName);
                //richTextBox2.Text = leer.ReadToEnd();
                //leer.Close();
            }
            
            /* using (StreamWriter file = new StreamWriter(abrir.f, true))
             {
                 string line = "";
                 foreach (ListViewItem item in this.listView1.Items)
                 {
                     line = "";
                     foreach (ListViewSubItem subitem in item.SubItems)
                     {
                         line += subitem.Text + ", ";
                     }
                     file.WriteLine(line);
                 }
                 file.Close();
             }*/
            /*var fileLines = File.ReadAllLines(@"C:\Users\Jimmy\Desktop\ji.txt");

    for (int i = 0; i + 4 < fileLines.Length; i += 5)
            {
                listView1.Items.Add(
                    new ListViewItem(new[]
                    {
                fileLines[i],
                fileLines[i + 1],
                fileLines[i + 2],
                fileLines[i + 3],
                fileLines[i + 4]
                    }));
            }

            // Resize the columns
            for (int i = 0; i < listView1.Columns.Count; i++)
            {
              listView1.Columns[i].Width = -2;
            }*/
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
