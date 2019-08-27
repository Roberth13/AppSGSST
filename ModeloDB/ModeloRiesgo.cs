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

        public static bool Add_Factor_identificacion(int _id_factor, int _id_identificacion, string medidas, string tiempo, int _usu_bit, string _pagina)
        {
            bool bError = true;
            Tbl_Factor_identificacion nuevo = new Tbl_Factor_identificacion()
            {
                id_factor = _id_factor,
                id_identificacion = _id_identificacion,
                consecuencias = medidas,
                tiempo_exposicion = tiempo
            };
            try
            {
                contexto.Tbl_Factor_identificacion.Add(nuevo);
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

        public static bool Add_Identificacion_puesto(int id_identificacion_peligro, int id_puesto, int _usu_bit, string _pagina)
        {
            bool bError = true;
            Tbl_Identificacion_puesto nuevo = new Tbl_Identificacion_puesto()
            {
                id_identificacion = id_identificacion_peligro,
                id_puesto = id_puesto
            };

            try
            {
                contexto.Tbl_Identificacion_puesto.Add(nuevo);
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

        ///<summary>Agrega informacion a la tabla Tbl_Identificacion_peligro</summary>
        ///<return>Devuelve true si la operacion fue exitosa, false si fue fallida.</return>
        ///<param name="_id_puesto_trabajo">id del puesto de trabajo asociado al riesgo</param>
        ///<param name="_fecha_eva">fecha de evaluacion del riesgo</param>
        ///<param name="_id_responsable">id del trabajador que hizo la investigacion del riesgo</param>
        public static bool Add_Identificacion_peligro(string medidas, string observaciones, int _usu_bit, string _pagina)
        {
            bool bError = true;
            Tbl_Identificacion_peligro nuevo = new Tbl_Identificacion_peligro()
            {
                medidas_control_existentes = medidas,
                observaciones = observaciones,
                fecha_identificacion = DateTime.Now,
                estatus = "Desactualizado",
                matriz_riesgo = 1
            };

            try
            {
                contexto.Tbl_Identificacion_peligro.Add(nuevo);
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
