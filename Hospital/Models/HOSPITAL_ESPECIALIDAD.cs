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
    
    public partial class HOSPITAL_ESPECIALIDAD
    {
        public int ID { get; set; }
        public Nullable<int> CUARTOS { get; set; }
        public Nullable<int> CUARTOS_LIBRES { get; set; }
        public Nullable<int> PISO { get; set; }
        public Nullable<int> ID_HOSPITAL { get; set; }
        public Nullable<int> ID_ESPECIALIDAD { get; set; }
        public Nullable<bool> VISIBLE { get; set; }
    }
}
