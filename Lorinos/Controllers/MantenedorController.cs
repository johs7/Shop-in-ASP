using CapaEntidad;
using CapaNegocios;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

    namespace Lorinos.Controllers
{
    public class MantenedorController : Controller
    {
        // GET: Mantenedor
        public ActionResult Categoria()
        {
            return View();
        }
        public ActionResult Marca()
        {
            return View();
        }
        public ActionResult Producto()
        {
            return View();
        }
        #region categoria
        [HttpGet]
        public JsonResult ListarCategorias()
        {
            List<ClassCategoria> oLista = new List<ClassCategoria>();
            oLista = new ClassCNCategoria().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GuardarCategoria(ClassCategoria obj)
        {
            object resultado;
            string mensaje = string.Empty;

            if (obj.IdCategoria == 0)
            {
                resultado = new ClassCNCategoria().Registrar(obj, out mensaje);
            }
            else
            {
                resultado = new ClassCNCategoria().Editar(obj, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EliminarCategoria(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new ClassCNCategoria().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region marca
        [HttpGet]
        public JsonResult ListarMarca()
        {
            List<ClassMarca> oLista = new List<ClassMarca>();
            oLista = new ClassCN_Marca().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GuardarMarca(ClassMarca obj)
        {
            object resultado;
            string mensaje = string.Empty;

            if (obj.IdMarca == 0)
            {
                resultado = new ClassCN_Marca().Registrar(obj, out mensaje);
            }
            else
            {
                resultado = new ClassCN_Marca().Editar(obj, out mensaje);
            }
            return Json(new { resultado = resultado, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EliminarMarca(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new ClassCN_Marca().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region producto
        [HttpGet]
        public JsonResult ListarProducto()
        {
            List<ClassProducto> oLista = new List<ClassProducto>();
            oLista = new ClassCNProducto().Listar();
            return Json(new { data = oLista }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GuardarProducto(string Objeto,HttpPostedFileBase ArchivoImagen)
        {
            object resultado;
            string mensaje = string.Empty;
            bool operacion_exitosa = true;
            bool guardar_imagen_exito = true;

            ClassProducto oProducto= new ClassProducto();
            oProducto = JsonConvert.DeserializeObject<ClassProducto>(Objeto);
            decimal precio;

            if(decimal.TryParse(oProducto.PrecioTexto,NumberStyles.AllowDecimalPoint,new CultureInfo("es-NI"),out precio))
            {
                oProducto.Precio = precio;
            }
            else
            {
                return Json(new { resultado = false, mensaje = "El formato del precio no es valido" }, JsonRequestBehavior.AllowGet);
            }


            if (oProducto.IdProducto == 0)
            {
               int idproductogenerado=  new ClassCNProducto().Registrar(oProducto, out mensaje);
                if (idproductogenerado != 0)
                {
                    oProducto.IdProducto = idproductogenerado;
                }
                else
                {
                    operacion_exitosa = false;
                }
            }
            else
            {
                operacion_exitosa = new ClassCNProducto().Editar(oProducto, out mensaje);
            }
            if (operacion_exitosa)
            {
                if(ArchivoImagen != null)
                {
                    string RutaGuardar = ConfigurationManager.AppSettings["ServidorFotos"];
                    string Extension= Path.GetExtension(ArchivoImagen.FileName);
                    string NombreImagen = string.Concat(oProducto.IdProducto.ToString(), Extension);
                    try
                    {
                        ArchivoImagen.SaveAs(string.Concat(RutaGuardar, NombreImagen));
                    }
                    catch(Exception ex)
                    {
                        string msg= ex.Message;
                        guardar_imagen_exito = false;
                    }
                    if (guardar_imagen_exito)
                    {
                        oProducto.RutaImagen = RutaGuardar;
                        oProducto.NombreImagen = NombreImagen;
                        bool rspta= new ClassCNProducto().GuardarDatosImagen(oProducto, out mensaje);
                    }
                    else
                    {
                        mensaje = "No se pudo guardar la imagen";
                    }
                }
            }
            return Json(new { operacionExitosa = operacion_exitosa,idGenerado=oProducto.IdProducto, mensaje = mensaje }, JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult EliminarProducto(int id)
        {
            bool respuesta = false;
            string mensaje = string.Empty;

            respuesta = new ClassCN_Marca().Eliminar(id, out mensaje);
            return Json(new { resultado = respuesta, mensaje = mensaje }, JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}