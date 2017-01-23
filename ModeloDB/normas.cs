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
    
    public partial class normas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public normas()
        {
            this.medidas = new HashSet<medidas>();
            this.normas_sucursal = new HashSet<normas_sucursal>();
        }
    
        public int id_normas { get; set; }
        public int id_item { get; set; }
        public string tipo_matriz { get; set; }
        public string tema_especifico { get; set; }
        public string documento { get; set; }
        public string anho { get; set; }
        public string articulo { get; set; }
        public string literal { get; set; }
        public string paragrafo { get; set; }
        public string numeral { get; set; }
        public string concordante { get; set; }
        public string obligaciones { get; set; }
        public string sanciones { get; set; }
        public Nullable<int> porc_cum { get; set; }
        public string pdf { get; set; }
    
        public virtual items_division items_division { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<medidas> medidas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<normas_sucursal> normas_sucursal { get; set; }
    }
}