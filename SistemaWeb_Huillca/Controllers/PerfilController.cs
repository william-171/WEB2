using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaWeb_Huillca.Models;
using SistemaWeb_Huillca.Filters;

namespace SistemaWeb_Huillca.Controllers
{
    [Autenticado]
    public class PerfilController : Controller
    {
        private Usuario objusu = new Usuario();
        // GET: Perfil
        public ActionResult Index()
        {
            return View(objusu.Obtener(SessionHelper.GetUser()));
        }

        public JsonResult Actualizar(Usuario model, HttpPostedFileBase foto)
        {
            var rm = new ResponseModel();

            ModelState.Remove("usuario_id");
            ModelState.Remove("docente_id");
            ModelState.Remove("nivel");
            ModelState.Remove("estado");

            if (ModelState.IsValid)
            {
                rm = model.Guardarperfil(foto);
            }
            rm.href = Url.Content("/Default/Index");
            return Json(rm);

        }
    }
}