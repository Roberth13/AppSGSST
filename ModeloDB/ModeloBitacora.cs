using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorSGSST2017.ModeloDB
{
    class ModeloBitacora
    {
        public static GrupoLiEntities contexto = new GrupoLiEntities();

        public ModeloBitacora() { }

        public static bool Add_Registro(DateTime fecha_hora, int _id_usuario, int _id_tipo_evento, string _pagina, string _tabla)
        {
            bool bError = true;

            Eventos nuevo = new Eventos()
            {
                fecha_hora = fecha_hora,
                id_usuario = _id_usuario,
                id_tipo_evento = _id_tipo_evento,
                pagina = _pagina,
                tabla = _tabla
            };

            try
            {
                contexto.Eventos.Add(nuevo);
                contexto.SaveChanges();
            }
            catch (Exception e)
            {
                bError = false;
            }
            return bError;
        }
    }
}
