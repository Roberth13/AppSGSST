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
    
    public partial class normas_sucursal
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public normas_sucursal()
        {
            this.medidas_sucursal = new HashSet<medidas_sucursal>();
        }
    
        public int id_normas_sucursal { get; set; }
        public Nullable<int> id_sucursal { get; set; }
        public Nullable<int> id_normas { get; set; }
        public Nullable<int> estatus_norma { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<medidas_sucursal> medidas_sucursal { get; set; }
        public virtual normas normas { get; set; }
        public virtual sucursal sucursal { get; set; }
    }
}
