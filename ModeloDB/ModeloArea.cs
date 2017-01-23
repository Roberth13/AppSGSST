using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorSGSST2017.ModeloDB
{
    class ModeloArea
    {
        public static GrupoLiEntities contexto = new GrupoLiEntities();

        public ModeloArea() { }

        ///<summary>Agrega informacion a la tabla Area</summary>
        ///<return>Devuelve true si la operacion fue exitosa, false si fue fallida.</return>
        ///<param name="_nombre">Nombre del area</param>
        ///<param name="_id_sucursal">id de la sucursal al cual pertenece el area</param>
        ///<param name="_id_area_padre">id del area padre del area a agregar</param>
        ///<param name="_area_nivel">nivel del area a agregar</param>
        public static bool Add_Area(string _nombre, int _id_sucursal, int _id_area_padre, int _area_nivel,
            int _usu_bit, string _pagina)
        {
            bool bError = true;

            area nuevo = new area()
            {
                nombre = _nombre,
                id_sucursal = _id_sucursal,
                id_area_padre = _id_area_padre,
                nivel = _area_nivel
            };

            try
            {
                contexto.area.Add(nuevo);
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
