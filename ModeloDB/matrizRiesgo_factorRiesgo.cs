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
    
    public partial class matrizRiesgo_factorRiesgo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public matrizRiesgo_factorRiesgo()
        {
            this.riesgos_item = new HashSet<riesgos_item>();
        }
    
        public int id_factor_riesgo { get; set; }
        public string descripcion { get; set; }
        public Nullable<int> id_tipo_riesgo { get; set; }
    
        public virtual matrizRiesgo_tipoRiesgo matrizRiesgo_tipoRiesgo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<riesgos_item> riesgos_item { get; set; }
    }
}
