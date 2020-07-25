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
    public class SemestreController : Controller
    {
        private Semestre objsemestre = new Semestre();

        // GET: Semestre
        public ActionResult Index(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objsemestre.Listar());
            }
            else
            {
                return View(objsemestre.Buscar(criterio));
            }
            
        }

        public ActionResult Ver(int id)
        {
            return View(objsemestre.Obtener(id));
        }

        public ActionResult Buscar(string criterio)
        {
            if (criterio == null || criterio == "")
            {
                return View(objsemestre.Listar());
            }
            else
            {
                return View(objsemestre.Buscar(criterio));
            }

        }

        public ActionResult AgregarEditar(int id = 0)
        {
            
            return View(
                id == 0 ? new Semestre() : objsemestre.Obtener(id)
                );
        }

        public ActionResult Guardar(Semestre model)
        {
            if (ModelState.IsValid)
            {
                model.Guardar();
                return Redirect("~/Semestre");

            }
            else
            {
                return View("~/Views/Semestre/AgregarEditar.cshtml", model);
            }
        }

        public ActionResult Eliminar(int id)
        {
            objsemestre.semestre_id = id;
            objsemestre.Eliminar();
            return Redirect("~/Semestre");
        }
    }
}