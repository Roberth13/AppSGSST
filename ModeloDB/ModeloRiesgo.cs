using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorSGSST2017.ModeloDB
{
    class ModeloRiesgo
    {
         public static GrupoLiEntities1 contexto = new GrupoLiEntities1();

         public ModeloRiesgo() { }

         ///<summary>Agrega informacion a la tabla Riesgo</summary>
         ///<return>Devuelve true si la operacion fue exitosa, false si fue fallida.</return>
         ///<param name="_id_puesto_trabajo">id del puesto de trabajo asociado al riesgo</param>
         ///<param name="_fecha_eva">fecha de evaluacion del riesgo</param>
         ///<param name="_id_responsable">id del trabajador que hizo la investigacion del riesgo</param>
         ///<param name="_identificacion_riesgo">Descripcion del riesgo</param>
         ///<param name="_probabilidad">probabilidad que ocurra el riesgo</param>
         ///<param name="_severidad">severidad del riesgo</param>
         ///<param name="_valor_riesgo">valor calculado del riesgo</param>
         ///<param name="_id_prioridad">id de la´prioridad asociado al riesgo</param>
         ///<param name="_medidas_fuente">medidas fuente del riesgo</param>
         ///<param name="_medidas_ambiente">medidas ambiente del riesgo</param>
         ///<param name="_medidas_trabajador">medidas trabajador del riesgo</param>
         ///<param name="_estatus-">estatus del riesgo</param>
         ///<param name="_id_factor_riesgo">id del factor de riesgo asociado al riesgo</param>
         ///<param name="_consecuencia">consecuencia del riesgo</param>
         ///<param name="_id_sucursal">id de la sucursal asociado al riesgo</param>
         /*public static bool Add_Riesgos(
             int _id_puesto_trabajo, string _fecha_eva, int _id_responsable, string _identificacion_riesgo,
             string _probabilidad, string _severidad, string _valor_riesgo, int _id_prioridad,
             string _medidas_fuente, string _medidas_ambiente, string _medidas_trabajador, string _estatus,
             int _id_factor_riesgo, string _consecuencia, int _id_sucursal, int _matriz_riesgos, int _usu_bit, string _pagina)
         {
             bool bError = true;
             riesgos nuevo = new riesgos()
             {
                 id_puesto_trabajo = _id_puesto_trabajo,
                 fecha_eva = Convert.ToDateTime(_fecha_eva),
                 id_responsable = _id_responsable,
                 identificacion_riesgo = _identificacion_riesgo,
                 probabilidad = _probabilidad,
                 severidad = _severidad,
                 valor_riesgo = _valor_riesgo,
                 id_prioridad = _id_prioridad,
                 medidas_fuente = _medidas_fuente,
                 medidas_ambiente = _medidas_ambiente,
                 medidas_trabajador = _medidas_trabajador,
                 estatus = _estatus,
                 id_factor_riesgo = _id_factor_riesgo,
                 consecuencia = _consecuencia,
                 id_sucursal = _id_sucursal,
                 matriz_riesgo = _matriz_riesgos,
                 porc_estatus = 0
             };

             try
             {
                 contexto.riesgos.Add(nuevo);
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
         }*/
    }
}
