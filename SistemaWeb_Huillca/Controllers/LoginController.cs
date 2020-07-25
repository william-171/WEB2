using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SistemaWeb_Huillca.Models;
using SistemaWeb_Huillca.Filters;

namespace SistemaWeb_Huillca.Controllers
{
    public class LoginController : Controller
    {
        private Usuario objusu = new Usuario();
        // GET: Login
        [NoLogin]
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Acceder(string usuario,string password)
        {
            var rm = objusu.Acceder(usuario, password);
            if (rm.response)
            {
                rm.href = Url.Content("~/Default");
            }
            return Json(rm);
        }

        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/Login");
        }
    }
}