//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Hospital.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class INTERNADO
    {
        public int ID { get; set; }
        public Nullable<System.DateTime> INGRESO { get; set; }
        public Nullable<System.DateTime> SALIDA { get; set; }
        public Nullable<int> ID_PACIENTE { get; set; }
        public Nullable<int> ID_HOSPITAL_ESPECIALIDAD { get; set; }
        public Nullable<bool> VISIBLE { get; set; }
    }
}
