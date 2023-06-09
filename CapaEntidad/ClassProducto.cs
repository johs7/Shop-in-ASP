using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ClassProducto
    {
        public string IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public ClassMarca oMarca { get; set; }
        public ClassCategoria oCategoria { get; set; }
        public  decimal Precio { get; set; }
        public int Stock { get; set; }
        public string RutaImagen { get; set; }
        public string NombreImagen { get; set; }
        public bool Activo { get; set; }

    }
}
