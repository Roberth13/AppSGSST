using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestorSGSST2017.Clases
{
    class Utilidades1
    {

        public static StreamWriter abrirEscritor()
        {
            StreamWriter escritor = new System.IO.StreamWriter(@"log.txt");
            return escritor;
        }

        public static void cerrarEscritor(StreamWriter escritor)
        {
            escritor.Dispose();
            escritor.Close();
        }

        public static void agregarMensaje(StreamWriter escritor, string msj, RichTextBox txtArea, string tipoMsj)
        {
            int length = txtArea.TextLength;
            txtArea.AppendText(msj + "\r\n");
            txtArea.SelectionStart = length;
            txtArea.SelectionLength = msj.Length;
            if (tipoMsj == "INFO")
                txtArea.SelectionColor = Color.Blue;
            else if (tipoMsj == "ERROR")
                txtArea.SelectionColor = Color.Red;
            else if (tipoMsj == "EXITO")
                txtArea.SelectionColor = Color.Green;
            else if (tipoMsj == "WARN")
                txtArea.SelectionColor = Color.Yellow;
            escritor.WriteLine(msj);
        }

        public static bool isExcel(string _ext) {
            if (_ext.ToUpper() == ".XLS" || _ext.ToUpper() == ".XLSX") {
                return true;
            }
            return false;
        }
    }
}
