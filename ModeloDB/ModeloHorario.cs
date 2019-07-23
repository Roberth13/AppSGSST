using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorSGSST2017.ModeloDB
{
    class ModeloHorario
    {
        public static GrupoLiEntities1 contexto = new GrupoLiEntities1();

        public ModeloHorario() { }

        ///<summary>Agrega informacion a la tabla Horario</summary>
        ///<return>Devuelve true si la operacion fue exitosa, false si fue fallida.</return>
        ///<param name="_nombre">Nombre de la empresa</param>
        ///<param name="_fecha_inicio">Codigo de la empresa</param>
        ///<param name="_fecha_fin">Nit de la empresa</param>
        ///<param name="_id_empresa">Email del representante legal de la empresa</param>
        public static bool Add_Horario(string _nombre, string _fecha_inicio, string _fecha_fin, int _id_empresa, int _usu_bit, string _pagina)
        {
            bool bError = true;
            int idEmpresa = Convert.ToInt32(_id_empresa);

            Tbl_Horario nuevo = new Tbl_Horario()
            {
                nombre = _nombre,
                id_empresa = idEmpresa,
                fecha_inicio = _fecha_inicio,
                fecha_fin = _fecha_fin,
                fecha_creacion = DateTime.Today
            };

            try
            {
                contexto.Tbl_Horario.Add(nuevo);
                contexto.SaveChanges();
            }
            catch (Exception e)
            {
                bError = false;
            }
            if (bError)
            {
                ModeloBitacora.Add_Registro(DateTime.Now, _usu_bit, 1, _pagina, Convert.ToString(nuevo.ToString()));
            }
            return bError;
        }
    }
}
