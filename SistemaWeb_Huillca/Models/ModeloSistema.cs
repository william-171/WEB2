namespace SistemaWeb_Huillca.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModeloSistema : DbContext
    {
        public ModeloSistema()
            : base("name=ModeloSistema")
        {
        }

        public virtual DbSet<Actividad> Actividad { get; set; }
        public virtual DbSet<Asignacion> Asignacion { get; set; }
        public virtual DbSet<Control> Control { get; set; }
        public virtual DbSet<ControlAsignacion> ControlAsignacion { get; set; }
        public virtual DbSet<Criterio> Criterio { get; set; }
        public virtual DbSet<DetalleAsignacion> DetalleAsignacion { get; set; }
        public virtual DbSet<Docente> Docente { get; set; }
        public virtual DbSet<Estudiante> Estudiante { get; set; }
        public virtual DbSet<EvidenciaActividad> EvidenciaActividad { get; set; }
        public virtual DbSet<EvidenciaCriterio> EvidenciaCriterio { get; set; }
        public virtual DbSet<Modelo> Modelo { get; set; }
        public virtual DbSet<Semestre> Semestre { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actividad>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Actividad>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Actividad>()
                .Property(e => e.urlactividad)
                .IsUnicode(false);

            modelBuilder.Entity<Actividad>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Asignacion>()
                .Property(e => e.titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Asignacion>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<Control>()
                .Property(e => e.titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Control>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<ControlAsignacion>()
                .Property(e => e.duracion)
                .IsUnicode(false);

            modelBuilder.Entity<ControlAsignacion>()
                .Property(e => e.sustento)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ControlAsignacion>()
                .Property(e => e.porcentaje)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ControlAsignacion>()
                .Property(e => e.condicion)
                .IsUnicode(false);

            modelBuilder.Entity<ControlAsignacion>()
                .Property(e => e.archivo)
                .IsUnicode(false);

            modelBuilder.Entity<ControlAsignacion>()
                .Property(e => e.observacion)
                .IsUnicode(false);

            modelBuilder.Entity<ControlAsignacion>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<Criterio>()
                .Property(e => e.nombre_spanish)
                .IsUnicode(false);

            modelBuilder.Entity<Criterio>()
                .Property(e => e.nombre_english)
                .IsUnicode(false);

            modelBuilder.Entity<Criterio>()
                .Property(e => e.urlcriterio)
                .IsUnicode(false);

            modelBuilder.Entity<Criterio>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Criterio>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Criterio>()
                .HasMany(e => e.Actividad)
                .WithRequired(e => e.Criterio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Criterio>()
                .HasMany(e => e.ControlAsignacion)
                .WithRequired(e => e.Criterio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Criterio>()
                .HasMany(e => e.EvidenciaActividad)
                .WithRequired(e => e.Criterio)
                .HasForeignKey(e => e.actividad_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Criterio>()
                .HasMany(e => e.EvidenciaCriterio)
                .WithRequired(e => e.Criterio)
                .HasForeignKey(e => e.evidencia_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DetalleAsignacion>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<DetalleAsignacion>()
                .HasMany(e => e.ControlAsignacion)
                .WithRequired(e => e.DetalleAsignacion)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Docente>()
                .Property(e => e.dni)
                .IsUnicode(false);

            modelBuilder.Entity<Docente>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Docente>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Docente>()
                .Property(e => e.sexo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Docente>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Docente>()
                .Property(e => e.celular)
                .IsUnicode(false);

            modelBuilder.Entity<Docente>()
                .Property(e => e.cargo)
                .IsUnicode(false);

            modelBuilder.Entity<Docente>()
                .Property(e => e.condicion)
                .IsUnicode(false);

            modelBuilder.Entity<Docente>()
                .Property(e => e.categoria)
                .IsUnicode(false);

            modelBuilder.Entity<Docente>()
                .Property(e => e.foto)
                .IsUnicode(false);

            modelBuilder.Entity<Docente>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<Docente>()
                .HasMany(e => e.ControlAsignacion)
                .WithRequired(e => e.Docente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Docente>()
                .HasMany(e => e.Usuario)
                .WithRequired(e => e.Docente)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.dni)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.apellido)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.sexo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.direccion)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.celular)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.foto)
                .IsUnicode(false);

            modelBuilder.Entity<Estudiante>()
                .Property(e => e.estado)
                .IsUnicode(false);

            modelBuilder.Entity<EvidenciaActividad>()
                .Property(e => e.archivo)
                .IsUnicode(false);

            modelBuilder.Entity<EvidenciaActividad>()
                .Property(e => e.tamanio)
                .IsUnicode(false);

            modelBuilder.Entity<EvidenciaActividad>()
                .Property(e => e.tipo)
                .IsUnicode(false);

            modelBuilder.Entity<EvidenciaActividad>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<EvidenciaCriterio>()
                .Property(e => e.archivo)
                .IsUnicode(false);

            modelBuilder.Entity<EvidenciaCriterio>()
                .Property(e => e.tamanio)
                .IsUnicode(false);

            modelBuilder.Entity<EvidenciaCriterio>()
                .Property(e => e.tipo)
                .IsUnicode(false);

            modelBuilder.Entity<EvidenciaCriterio>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Modelo>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Modelo>()
                .Property(e => e.descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Modelo>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Modelo>()
                .HasMany(e => e.Criterio)
                .WithRequired(e => e.Modelo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Semestre>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Semestre>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Semestre>()
                .HasMany(e => e.Actividad)
                .WithRequired(e => e.Semestre)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.clave)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.nivel)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.avatar)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.estado)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
