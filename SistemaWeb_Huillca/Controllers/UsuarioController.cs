using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaWeb_Huillca.Filters;
using SistemaWeb_Huillca.Models;

namespace SistemaWeb_Huillca.Controllers
{
    [Autenticado]
    public class UsuarioController : Controller
    {
        private Usuario objusuario = new Usuario();
        private Docente objdo = new Docente();

        // GET: Usuario
        public ActionResult Index(string criterio)
        {
            if(criterio == null || criterio == "")
            {
                return View(objusuario.Listar());
            }
            else
            {
                return View(objusuario.Buscar(criterio));
            }
            
        }

        public ActionResult Ver(int id)
        {
            return View(objusuario.Obtener(id));
        }

        public ActionResult Buscar(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objusuario.Listar());
            }
            else
            {
                return View(objusuario.Buscar(criterio));
            }

        }

        public ActionResult AgregarEditar(int id = 0)
        {
            ViewBag.Docente = objdo.Listar();
            return View(
                id == 0 ? new Usuario () : objusuario.Obtener(id)
                );
        }

        public ActionResult Guardar(Usuario model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Usuario");

            }
            else
            {
                return View("~/Views/Usuario/AgregarEditar.cshtml", model);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objusuario.usuario_id = id;
            objusuario.Eliminar();
            return Redirect("~/Usuario");
        }
    }
}