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
    
    public partial class medidas_sucursal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public medidas_sucursal()
        {
            this.obligacion = new HashSet<obligacion>();
        }
    
        public int id_medidas_sucursal { get; set; }
        public Nullable<int> id_normas_sucursal { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> estatus_medida { get; set; }
        public Nullable<int> aplica { get; set; }
    
        public virtual normas_sucursal normas_sucursal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<obligacion> obligacion { get; set; }
    }
}