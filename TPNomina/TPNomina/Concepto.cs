//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TPNomina
{
    using System;
    using System.Collections.Generic;
    
    public partial class Concepto
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Concepto()
        {
            this.Liquidacion_Mensual_Detalle = new HashSet<Liquidacion_Mensual_Detalle>();
        }
    
        public int Id_Concepto { get; set; }
        public string Descripcion { get; set; }
        public string Tipo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Liquidacion_Mensual_Detalle> Liquidacion_Mensual_Detalle { get; set; }
    }
}
