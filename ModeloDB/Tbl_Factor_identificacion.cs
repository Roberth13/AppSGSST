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
    
    public partial class Tbl_Factor_identificacion
    {
        public int id_fac_ide { get; set; }
        public Nullable<int> id_factor { get; set; }
        public Nullable<int> id_identificacion { get; set; }
        public string consecuencias { get; set; }
        public string tiempo_exposicion { get; set; }
    
        public virtual Tbl_Factor_riesgo Tbl_Factor_riesgo { get; set; }
        public virtual Tbl_Identificacion_peligro Tbl_Identificacion_peligro { get; set; }
    }
}