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
    
    public partial class Tbl_Documento
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Documento()
        {
            this.Tbl_Soporte = new HashSet<Tbl_Soporte>();
        }
    
        public int id_documento { get; set; }
        public Nullable<int> id_tabla { get; set; }
        public string nombre { get; set; }
        public string ruta { get; set; }
        public string tipo { get; set; }
        public Nullable<System.DateTime> fecha_subida { get; set; }
    
        public virtual Tbl_Sucursal Tbl_Sucursal { get; set; }
        public virtual Tbl_Trabajador Tbl_Trabajador { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Soporte> Tbl_Soporte { get; set; }
    }
}