//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _2parcial
{
    using System;
    using System.Collections.Generic;
    
    public partial class Empleado
    {
        public int EmpID { get; set; }
        public string Nombre { get; set; }
        public long Cedula { get; set; }
        public int DepID { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public System.DateTime FechaIngreso { get; set; }
        public bool Estado { get; set; }
    
        public virtual Departamento Departamento { get; set; }
    }
}
