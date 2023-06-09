using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ClassCarrito
    {
        public int IdCarrito { get; set; }
        public ClassCliente oCliente { get; set; }
        public ClassProducto oProducto { get; set; }
        public int Cantidad { get; set; }

    }
}
