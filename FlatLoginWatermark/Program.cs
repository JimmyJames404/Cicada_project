using Jimmy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Micron;
using System.Security.Cryptography;
using System.Text;

namespace FlatLoginWatermark
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            MicronConfig config = new MicronConfig()
            {
                DatabaseName = "cicada"
                // DatabaseName = "login_cm"
            };

            MicronDbContext.AddConnectionSetup(config);




            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
          //Application.Run(new Form1());
            Application.Run(new loader());
        }

        public static string CalculateMD5Hash (string input)
        {
            //Calcular MD5Hash del input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            //Convertir arreglo de bytes a string de hexadecimal
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
