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
    
    public partial class gestion_laboral
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public gestion_laboral()
        {
            this.trabajador_gestion = new HashSet<trabajador_gestion>();
        }
    
        public int id_ges_lab { get; set; }
        public Nullable<System.DateTime> fecha { get; set; }
        public string descripcion { get; set; }
        public string soporte { get; set; }
        public Nullable<int> id_tipo_gestion { get; set; }
        public Nullable<int> cant_horas { get; set; }
        public string razon_inasistencia { get; set; }
        public string objetivos { get; set; }
        public Nullable<int> id_usuario { get; set; }
    
        public virtual tipo_gestion tipo_gestion { get; set; }
        public virtual usuario usuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<trabajador_gestion> trabajador_gestion { get; set; }
    }
}
