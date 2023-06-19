using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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
        [HttpGet]
     public JsonResult ListarUsuarios()
        {
            List<ClassUsuario> oLista = new List<ClassUsuario>();

            oLista= new ClassCNUsuarios().Listar();

            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GuardarUsuarios(ClassUsuario obj)
        {
            object resultado;
            string mensaje = string.Empty;

            if(obj.IdUsuario == 0)
            {
                resultado = new ClassCNUsuarios().Registrar(obj, out mensaje);
            }
            else
            {
                resultado = new ClassCNUsuarios().Editar(obj, out mensaje);
            }
          return Json(new {resultado=resultado, mensaje=mensaje }, JsonRequestBehavior.AllowGet);
        }
    }
}
