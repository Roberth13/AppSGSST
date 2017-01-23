using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorSGSST2017.ModeloDB
{
    class ModeloUsuario
    {
        public static GrupoLiEntities contexto = new GrupoLiEntities();

        public ModeloUsuario() { }

        ///<summary>valdia la credenciales del usuario</summary>
        ///<return>Devuelve el Id de sucursal, empresa , rol y de usuario</return>
        public static string ValidarUsuario(string login, string clave)
        {
            Utilidades objUtilidades = new Utilidades();
            clave = objUtilidades.cifrarCadena(Convert.ToString(clave));

            var resultado = "";
            var consulta = from US in contexto.usuario where (US.login == login && US.clave == clave) select new { _id_rol = US.id_rol };

            foreach (var datos in consulta)
            {
                if (datos._id_rol == 1)
                {
                    var consulta1 = from US in contexto.usuario
                                    where (US.login == login && US.clave == clave)
                                    select new
                                    {
                                        _id_usuario = US.id_usuario,
                                        _id_rol = US.id_rol
                                    };

                    foreach (var datos1 in consulta1)
                    {
                        resultado = string.Concat(datos1._id_usuario);
                    }
                }
                else
                {
                    var consulta1 = from US in contexto.usuario
                                    where (US.login == login && US.clave == clave)
                                    select new
                                    {
                                        _id_usuario = US.id_usuario,
                                        _id_empresa = US.trabajador.puesto_trabajo.area.sucursal.id_empresa,
                                        _id_sucursal = US.trabajador.puesto_trabajo.area.id_sucursal,
                                        _id_rol = US.id_rol
                                    };
                    foreach (var datos1 in consulta1) { resultado = ""+datos1._id_usuario; }
                }
            }
            return resultado;
        }
    }

    class Utilidades
    {
        public string cifrarCadena(string mensaje)
        {
            string result = string.Empty;
            byte[] encryted = Encoding.Unicode.GetBytes(mensaje);
            result = Convert.ToBase64String(encryted);
            return result;
        }

        public string descifrarCadena(string mensaje)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(mensaje);
            result = Encoding.Unicode.GetString(decryted);
            return result;
        }

        public static bool isExcel(string extension)
        {
            if (extension.ToUpper() == ".XLS" || extension.ToUpper() == ".XLSX")
                return true;
            return false;
        }

    }
}
