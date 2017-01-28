using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorSGSST2017.Clases
{
    class Utilidades_Varias
    {
        public Utilidades_Varias() { 
        
        }

        public static void abrirEscritor(StreamWriter _stream) 
        { 
            _stream = new StreamWriter(@"Log/log.txt");
        }

        public static void cerrarEscritor(StreamWriter _stream)
        {
            _stream.Dispose();
            _stream.Close();
        }

        public static void escribirMensaje(StreamWriter _stream, string mensaje)
        {
            _stream.WriteLine(DateTime.Now + ": " + mensaje);
        }

    }
}
