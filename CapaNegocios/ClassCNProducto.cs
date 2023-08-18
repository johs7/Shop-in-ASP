using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocios
{
    public class ClassCNProducto
    {
        private ClassCDProductos objCapaDato = new ClassCDProductos();
        public List<ClassProducto> Listar()
        {
            return objCapaDato.Listar();
        }
        public int Registrar(ClassProducto obj, out string Mensaje)
        {
            Mensaje=string.Empty;
           if(string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje="El Nombre del producto es obligatorio";
            }
           else if(string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje="La Descripción del producto es obligatorio";
            }
            else if (obj.oMarca.IdMarca == 0)
            {
                Mensaje="Debe seleccionar una marca";
            }
            else if (obj.oCategoria.IdCategoria == 0)
            {
                Mensaje="Debe seleccionar una categoria";
            }
           else if(obj.Precio==0){
                Mensaje="El precio del producto es obligatorio";
            }
           else if (obj.Stock == 0)
            {
                Mensaje="El stock del producto es obligatorio";
            }
         
           if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
        }
        public bool Editar(ClassProducto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El Nombre del producto es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La Descripción del producto es obligatorio";
            }
            else if (obj.oMarca.IdMarca == 0)
            {
                Mensaje = "Debe seleccionar una marca";
            }
            else if (obj.oCategoria.IdCategoria == 0)
            {
                Mensaje = "Debe seleccionar una categoria";
            }
            else if (obj.Precio == 0)
            {
                Mensaje = "El precio del producto es obligatorio";
            }
            else if (obj.Stock == 0)
            {
                Mensaje = "El stock del producto es obligatorio";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool GuardarDatosImagen(ClassProducto obj,out string Mensaje)
        {
            return objCapaDato.GuardarDatosImagen(obj, out Mensaje);
        }


        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }
    }
}
