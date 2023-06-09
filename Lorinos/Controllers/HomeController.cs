using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaEntidad;
using CapaNegocios;
namespace Lorinos.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Usuarios()
        {
            return View();
        }
     public JsonResult ListarUsuarios()
        {
            List<ClassUsuario> oLista = new List<ClassUsuario>();
            oLista= new ClassCNUsuarios().Listar();
            return Json(oLista, JsonRequestBehavior.AllowGet);
        }
    }
}
