//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestorSGSST2017.ModeloDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Investigacion_ac_in
    {
        public int id_inv_ac_in { get; set; }
        public string tipo { get; set; }
        public Nullable<System.DateTime> fecha_evento { get; set; }
        public Nullable<System.DateTime> hora_evento { get; set; }
        public string dia_semana { get; set; }
        public Nullable<int> antiguedad { get; set; }
        public string actividad_realizaba { get; set; }
        public string naturaleza_lesion { get; set; }
        public string gravedad_lesion { get; set; }
        public string descripcion_lesion { get; set; }
        public string reposo { get; set; }
        public Nullable<int> dias_reposo { get; set; }
        public Nullable<System.DateTime> fecha_reintegro { get; set; }
        public string adiestramiento { get; set; }
        public string costo_transporte { get; set; }
        public string costo_atencion { get; set; }
        public string costo_tratamiento { get; set; }
        public string costo_indemizacion { get; set; }
        public string costo_reemplazo { get; set; }
        public string costo_reposo { get; set; }
        public string costo_materiales { get; set; }
        public string costo_produccion { get; set; }
        public string porque1 { get; set; }
        public string respuesta1 { get; set; }
        public string porque2 { get; set; }
        public string respuesta2 { get; set; }
        public string porque3 { get; set; }
        public string respuesta3 { get; set; }
        public string porque4 { get; set; }
        public string respuesta4 { get; set; }
        public string porque5 { get; set; }
        public string respuesta5 { get; set; }
        public string que { get; set; }
        public string respuesta_que { get; set; }
        public string porque { get; set; }
        public string respuesta_porque { get; set; }
        public string quien { get; set; }
        public string respuesta_quien { get; set; }
        public string donde { get; set; }
        public string respuesta_donde { get; set; }
        public string cuando { get; set; }
        public string respuesta_cuando { get; set; }
        public string como { get; set; }
        public string respuesta_como { get; set; }
        public string cuanto { get; set; }
        public string respuesta_cuanto { get; set; }
        public string tipo_accidente { get; set; }
        public string tipo_lesion { get; set; }
        public string agente_lesion { get; set; }
        public string parte_cuerpo { get; set; }
        public string nota { get; set; }
        public Nullable<int> id_at_it_el_pa { get; set; }
        public string medida1 { get; set; }
        public string responsable1 { get; set; }
        public Nullable<System.DateTime> fecha_medida1 { get; set; }
        public string medida2 { get; set; }
        public string responsable2 { get; set; }
        public Nullable<System.DateTime> fecha_medida2 { get; set; }
        public string medida3 { get; set; }
        public string responsable3 { get; set; }
        public Nullable<System.DateTime> fecha_medida3 { get; set; }
        public string supervisor { get; set; }
        public string tiempo_cargo { get; set; }
        public string actividad { get; set; }
    
        public virtual Tbl_At_it_el_pa Tbl_At_it_el_pa { get; set; }
    }
}