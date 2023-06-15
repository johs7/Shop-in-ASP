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
                string clave = "johan";
                obj.Clave = CN_Recurso.ConvertirSha256(clave);
                return objCapaDato.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }
            
        }
    }
}
