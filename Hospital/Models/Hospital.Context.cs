﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HOSPITALEntities : DbContext
    {
        public HOSPITALEntities()
            : base("name=HOSPITALEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CONSULTA> CONSULTA { get; set; }
        public virtual DbSet<DETALLE_RECETA> DETALLE_RECETA { get; set; }
        public virtual DbSet<DOCTOR> DOCTOR { get; set; }
        public virtual DbSet<DOCTOR_ESPECIALIDAD> DOCTOR_ESPECIALIDAD { get; set; }
        public virtual DbSet<ESPECIALIDAD> ESPECIALIDAD { get; set; }
        public virtual DbSet<HOSPITAL> HOSPITAL { get; set; }
        public virtual DbSet<HOSPITAL_DOCTOR> HOSPITAL_DOCTOR { get; set; }
        public virtual DbSet<HOSPITAL_ESPECIALIDAD> HOSPITAL_ESPECIALIDAD { get; set; }
        public virtual DbSet<INTERNADO> INTERNADO { get; set; }
        public virtual DbSet<MEDICAMENTO> MEDICAMENTO { get; set; }
        public virtual DbSet<PACIENTE> PACIENTE { get; set; }
        public virtual DbSet<RECETA> RECETA { get; set; }
        public virtual DbSet<VISITA> VISITA { get; set; }
    }
}
