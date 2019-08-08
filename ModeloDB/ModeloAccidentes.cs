using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorSGSST2017.ModeloDB
{
    class ModeloAccidentes
    {
        public static GrupoLiEntities1 contexto = new GrupoLiEntities1();

        public ModeloAccidentes() { }

        public static bool Add_Accidentes(int id_trabajador, int id_area, int id_puesto, string sitio, string desc_hechos, string condiciones_inseguras,
                                          string actos_inseguros, string factores_inseguros, string factores_personales,
                                          string tipo, DateTime? fecha_muerte, int dias_incapacidad,
                                          int dias_cargados, int dias_perdidos_ausencia, string dias_no_perdidos, int dias_perdido_restringido, string tipo_enfermedad,
                                          DateTime? fecha_acc, DateTime? hora_acc, int _usu_bit, string _pagina)
        {
            bool bError = true;

            Tbl_At_it_el_pa nuevo = new Tbl_At_it_el_pa()
            {
                #region codigo
                id_trabajador = id_trabajador,
                id_area = id_area,
                id_puesto = id_puesto,
                sitio = sitio,
                descripcion = desc_hechos,
                condiciones_inseguras = condiciones_inseguras,
                actos_inseguros = actos_inseguros,
                factores_inseguros = factores_inseguros,
                factores_personales = factores_personales,
                reporte_accidente = "",
                num_consultas = 0,
                frecuencia_consultas = "",
                tipo_evento = tipo,
                fecha_muerte = fecha_muerte,
                dias_incapacidad = dias_incapacidad,
                dias_cargados = dias_cargados,
                dias_perdidos_ausencia = dias_perdidos_ausencia,
                dias_no_perdidos = dias_no_perdidos,
                tipo_enfermedad = tipo_enfermedad,
                fecha_accidente = fecha_acc,
                hora_accidente = hora_acc,
                dias_perdidos_restingido = dias_perdido_restringido,
                #endregion
            };

            try
            {
                contexto.Tbl_At_it_el_pa.Add(nuevo);
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
