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
    
    public partial class Empleado_Salario_Historico
    {
        public int Id_Salario_Historico { get; set; }
        public int Empleado_Id { get; set; }
        public int Salario_Basico_Anterior { get; set; }
        public int Salario_Basico_Nuevo { get; set; }
        public System.DateTime Fecha_Hora { get; set; }
        public int Usuario_Id { get; set; }
    
        public virtual Empleado Empleado { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
