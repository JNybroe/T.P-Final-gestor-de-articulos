using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Articulo
{
    public class Articulos
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Caracteristica Marca { get; set; }
        public Caracteristica Categoria { get; set; }
        public string UrlImagen { get; set; }
        public decimal Precio { get; set; }
    }
}
