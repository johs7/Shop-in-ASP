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
    }
}
