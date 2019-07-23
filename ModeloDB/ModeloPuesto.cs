using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorSGSST2017.ModeloDB
{
    class ModeloPuesto
    {
        public static GrupoLiEntities1 contexto = new GrupoLiEntities1();

        public ModeloPuesto() { }

        ///<summary>Agrega informacion a la tabla Puesto de Trabajo</summary>
        ///<return>Devuelve true si la operacion fue exitosa, false si fue fallida.</return>
        ///<param name="_nombre">Nombre del Puesto de Trabajo</param>
        ///<param name="_descripcion">Descripcion del puesto de trabajo</param>
        ///<param name="_id_area">id del area a la cual pertenece el puesto de trabajo</param>
        public static bool Add_PuestoTrabajo(string _nombre, string _descripcion, int _id_area, int _usu_bit, string _pagina)
        {
            bool bError = true;

            Tbl_Puesto_trabajo nuevo = new Tbl_Puesto_trabajo()
            {
                nombre = _nombre,
                descripcion = _descripcion,
                id_area = _id_area
            };

            try
            {
                contexto.Tbl_Puesto_trabajo.Add(nuevo);
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
