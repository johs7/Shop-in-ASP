using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocios
{
    public class ClassCNUsuarios
    {
        private ClassCDUsuarios objCapaDato = new ClassCDUsuarios();
        public List<ClassUsuario> Listar()
        {
            return objCapaDato.Listar();
        }
        public int Registrar(ClassUsuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
            {
                Mensaje = "El campo Nombres es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                Mensaje = "El campo Apellidos es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El campo Correo es obligatorio";
            }


            if (string.IsNullOrEmpty(Mensaje))
            {
                string clave=CN_Recurso.GenerarClave();

                string asunto="Creación de cuenta";
                string mensaje_correo="<h3>Su cuenta ha sido creada con éxito</h3></br><p> su contraseña es: ¡clave!</p>";
                mensaje_correo=mensaje_correo.Replace("¡clave!",clave);
             

                bool respuesta=CN_Recurso.EnviarCorreo(obj.Correo,asunto,mensaje_correo);

                if (respuesta)
                {
                    obj.Clave = CN_Recurso.ConvertirSha256(clave);
                    return objCapaDato.Registrar(obj, out Mensaje);
                }
                else
                {
                    Mensaje = "No se pudo enviar el correo";
                    return 0;
                }
            }
            else
            {
                return 0;
            }
            
        }
        public bool Editar(ClassUsuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombres) || string.IsNullOrWhiteSpace(obj.Nombres))
            {
                Mensaje = "El campo Nombres es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Apellidos) || string.IsNullOrWhiteSpace(obj.Apellidos))
            {
                Mensaje = "El campo Apellidos es obligatorio";
            }
            else if (string.IsNullOrEmpty(obj.Correo) || string.IsNullOrWhiteSpace(obj.Correo))
            {
                Mensaje = "El campo Correo es obligatorio";
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
        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }
    }
}
