namespace SistemaWeb_Huillca.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Semestre")]
    public partial class Semestre
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Semestre()
        {
            Actividad = new HashSet<Actividad>();
        }

        [Key]
        public int semestre_id { get; set; }

        [Required]
        [StringLength(250)]
        public string nombre { get; set; }

        public int? anio { get; set; }

        [StringLength(1)]
        public string estado { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Actividad> Actividad { get; set; }


        public List<Semestre> Listar()
        {
            var objsemestre = new List<Semestre>();
            try
            {
                using (var db = new ModeloSistema())
                {

                    objsemestre = db.Semestre.ToList();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objsemestre;
        }

        public Semestre Obtener(int id)
        {
            var objsemestre = new Semestre();
            try
            {
                using (var db = new ModeloSistema())
                {
                    objsemestre = db.Semestre.Where(x => x.semestre_id == id)
                        .SingleOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objsemestre;
        }

        public void Guardar()
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    if (this.semestre_id > 0)
                    {
                        db.Entry(this).State = EntityState.Modified;
                    }
                    else
                    {
                        db.Entry(this).State = EntityState.Added;
                    }
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Eliminar()
        {
            try
            {
                using (var db = new ModeloSistema())
                {

                    db.Entry(this).State = EntityState.Deleted;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<Semestre> Buscar(string criterio)
        {
            var objsemestre = new List<Semestre>();
            string estado = "";
            if (criterio == "Activo") estado = "A";
            if (criterio == "Inactivo") estado = "I";
            try
            {
                using (var db = new ModeloSistema())
                {
                    objsemestre = db.Semestre.Where(x => nombre.Contains(criterio) || x.nombre.Contains(criterio)|| x.estado == estado).ToList();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objsemestre;
        }
    }
}
