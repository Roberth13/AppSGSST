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
    
    public partial class fotos_accidente
    {
        public int id_fotos_acci { get; set; }
        public string ruta { get; set; }
        public int id_acc_lab { get; set; }
    
        public virtual acc_inc_lab acc_inc_lab { get; set; }
    }
}
