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
using Microsoft.Office.Interop;
using _Excel = Microsoft.Office.Interop.Excel;
using ExcelDataReader;

namespace Jimmy
{
    public partial class Form2 : Form
    {
        string carpeta = Application.StartupPath + @"\Sucesos";
        string a = "";

        public Form2()
        {
            InitializeComponent();
          
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            config();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            var tipo = "";
            if (comboBox1.SelectedItem != null)
            {
                tipo = comboBox1.SelectedItem.ToString();
            }
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "All files |" + tipo;//*.txt*,*.docx*
            dialog.Multiselect = false;


            if (dialog.ShowDialog() == DialogResult.OK)
            {
                String path = dialog.FileName;
                FileInfo fi = new FileInfo(path);
                // var nombre = fi.Name;//COn extension
                var nombre = Path.GetFileNameWithoutExtension(fi.Name);//Sin extension
                string extension;
                extension = Path.GetExtension(path);
                using (StreamReader reader = new StreamReader(new FileStream(path, FileMode.Open), new UTF8Encoding()))
                {
                    FileInfo file = new FileInfo(dialog.FileName);
                    ListViewItem itm;

                    itm = new ListViewItem(Convert.ToString(nombre));
                    itm.SubItems.Add(extension);
                    itm.SubItems.Add(dialog.FileName);
                    long b = file.Length;
                    var c = "";
                    var peso = "";
                    if (comboBox1.SelectedItem != null)
                    {
                        tipo = comboBox2.SelectedItem.ToString();

                        if (tipo == "Byte") { c = b.ToString(); }//1 Bytes =  Kilobytes
                        if (tipo == "Kilobyte") { c = (b * 0.000977).ToString(); }
                        if (tipo == "Megabyte") { c = (b * 9.5367431640625E-7).ToString(); }
                        if (tipo == "Gigabyte") { c = (b * 9.3132257461548E-10).ToString(); }
                        if (tipo == "Terabyte") { c = (b * 9.3132257461548E-10).ToString(); }
                        if (tipo == "Bits") { c = (b * 16).ToString(); }//1 Bytes =  Kilobytes

                        // if () { }
                    }
                    peso = c;
                    //int peso = file.Length * pesO;
                    itm.SubItems.Add(peso + " " + tipo);
                    // itm.SubItems.Add(file.Length.ToString() + " Byte");

                    a = "El usuario abrio el archivo " + nombre +"con dirreccion "+ dialog.FileName;
                    impresion();
                    listView1.Items.Add(itm);

                }
            }


        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                comboBox2.Visible = true;
            }
            else
            {
                comboBox2.Visible = false;
            }
        }

        private void config()
        {

            listView1.View = View.Details;
            if (checkBox1.Checked == true)
            {
                this.listView1.Columns.Add("Nombre de archivo", 200);
            }
            else { }
            if (checkBox2.Checked == true)
            {
                this.listView1.Columns.Add("Extension", 150);
            }
            if (checkBox3.Checked == true)
            {
                this.listView1.Columns.Add("Ruta", 350);
            }
            if (checkBox4.Checked == true)
            {
                this.listView1.Columns.Add("Peso", 200);
            }


            this.listView1.GridLines = true;
            this.listView1.View = View.Details;
            //this.listView1.FullRowSelect = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (panel1.Visible == true)
            {
                panel1.Visible = false;
            }
            else { panel1.Visible = true; }
        }

        private void pictureBox1_MouseHover(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(78, 76);//68, 66
        }

        private void pictureBox1_DragLeave(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Size = new Size(68, 66);//68, 66
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //listView1.Refresh();
            listView1.Clear();
            config();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }
        private void carga2()
        {
            /*lvTimeSheet.View = View.Details;
            lvTimeSheet.Columns.Add("Matricula");
            lvTimeSheet.Columns.Add("Nombre");
            lvTimeSheet.Columns.Add("Telefono");
            lvTimeSheet.Columns.Add("Email");
            // lvTimeSheet.Columns.Add("Total Pay");

            // Auto-size the columns
            for (int i = 0; i < lvTimeSheet.Columns.Count; i++)
            {
                lvTimeSheet.Columns[i].Width = -2;
            }*/
        }
       
        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void lvTimeSheet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
       
        
        private void button5_Click( object sender, EventArgs e)
        {
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (panel2.Visible == true)
            {
                panel2.Visible = false;
            }
            else { panel2.Visible = true; }
        }
        DataTableCollection tableCollection;
        private void button4_Click_1(object sender, EventArgs e)
        {
           
            using (OpenFileDialog openFileDialog = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtFilename.Text = openFileDialog.FileName;
                    a = "El usuario abrio el archivo de excel" + txtFilename.Text;
                    impresion();
                    using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                        {
                            DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                            {
                                ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                            });
                            tableCollection = result.Tables;
                            cboSheet.Items.Clear();
                            foreach (DataTable table in tableCollection)
                                cboSheet.Items.Add(table.TableName);//agregar hoja
                        }
                    }
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = tableCollection[cboSheet.SelectedItem.ToString()];
            dataGridView1.DataSource = dt;
        }

        private void txtFilename_TextChanged(object sender, EventArgs e)
        {

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

                escribir.WriteLine(""+a);
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
    }    
        
}

