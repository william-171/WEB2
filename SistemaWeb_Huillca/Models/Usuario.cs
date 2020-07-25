namespace SistemaWeb_Huillca.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Web;
    using System.IO;
    using System.Data.Entity.Validation;

    [Table("Usuario")]
    public partial class Usuario
    {
        [Key]
        public int usuario_id { get; set; }

        public int docente_id { get; set; }

        [Required]
        [StringLength(30)]
        public string nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string clave { get; set; }

        [Required]
        [StringLength(20)]
        public string nivel { get; set; }

        [StringLength(250)]
        public string avatar { get; set; }

        [Required]
        [StringLength(1)]
        public string estado { get; set; }

        public virtual Docente Docente { get; set; }


        public ResponseModel Acceder(string usuario,string password)
        {
            var rm = new ResponseModel();

            try
            {
                using (var db = new ModeloSistema())
                {
                    password = HashHelper.MD5(password);

                    var query = db.Usuario.Where(x => x.nombre == usuario).Where(x => x.clave == password).SingleOrDefault();
                    if (query != null)
                    {
                        SessionHelper.AddUserToSession(query.usuario_id.ToString());
                        rm.SetResponse(true);

                    }
                    else
                    {
                        rm.SetResponse(false, "usuario incorrecto");
                    }
                }
            }
            catch(Exception) {
                throw;
            }
            return rm;
        }

        //metodo listar
        public List<Usuario> Listar()
        {
            var objusuario = new List<Usuario>();
            try
            {
                using (var db= new ModeloSistema())
                {

                    objusuario = db.Usuario.Include("Docente").ToList();

                }
            }
            catch(Exception ex){
                throw;
            }
            return objusuario;
        }

        public Usuario Obtener(int id)
        {
            var objusuario = new Usuario();
            try
            {
                using (var db = new ModeloSistema())
                {
                    objusuario = db.Usuario.Include("Docente").Where(x => x.usuario_id == id)
                        .SingleOrDefault();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objusuario;
        }

        public void Guardar()
        {
            try
            {
                using (var db = new ModeloSistema())
                {
                    if(this.usuario_id > 0)
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

        public List<Usuario> Buscar(string criterio)
        {
            var objusuario = new List<Usuario>();
            string estado = "";
            if (criterio == "Activo") estado = "A";
            if (criterio == "Inactivo") estado = "I";
            try
            {
                using (var db = new ModeloSistema())
                {
                    objusuario = db.Usuario.Include("Docente").Where(x=> nombre.Contains(criterio) || x.nombre.Contains(criterio) || x.Docente.nombre.Contains(criterio) || x.Docente.apellido.Contains(criterio) || x.nivel.Contains(criterio) || x.estado == estado).ToList();

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return objusuario;
        }

        //metodo de perfil
        public ResponseModel Guardarperfil(HttpPostedFileBase Foto)
        {
            var rm = new ResponseModel();
            try
            {
                using (var db =new ModeloSistema())
                {
                    db.Configuration.ValidateOnSaveEnabled = false;
                    var usu = db.Entry(this);
                    usu.State = EntityState.Modified;

                    if (Foto != null)
                    {
                        string extension = Path.GetExtension(Foto.FileName).ToLower();
                        int size = 1024 * 1024 * 5;

                        var filtroextension = new[] { ".jpg", ".png", ".jpeg" };
                        var extensiones = Path.GetExtension(Foto.FileName);

                        if (filtroextension.Contains(extensiones) && (Foto.ContentLength <= size))
                        {
                            string archivo = Path.GetFileName(Foto.FileName);
                            Foto.SaveAs(HttpContext.Current.Server.MapPath("~/Uploads/" + archivo));
                            this.avatar = archivo;

                        }
                    }
                    else usu.Property(x => x.avatar).IsModified = false;

                    if (this.usuario_id == 0) usu.Property(x => x.usuario_id).IsModified = false;
                    if (this.docente_id == 0) usu.Property(x => x.docente_id).IsModified = false;
                    if (this.nombre == null) usu.Property(x => x.nombre).IsModified = false;
                    if (this.clave == null) usu.Property(x => x.clave).IsModified = false;
                    if (this.nivel == null) usu.Property(x => x.nivel).IsModified = false;
                    if (this.estado == null) usu.Property(x => x.estado).IsModified = false;

                    db.SaveChanges();
                    rm.SetResponse(true);

                }
            }
            catch(DbEntityValidationException e)
            {
                throw;
            }
            catch(Exception){
                throw;
            }
            return rm;
        }

    }
}
