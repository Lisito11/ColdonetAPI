using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.DTOs.Categorias {
    public class CategoriaCreacionDTO {
        public string CodigoCategoria { get; set; }
        public string NombreCategoria { get; set; }
        public string DescripcionCategoria { get; set; }
        public int? IdUsuario { get; set; }
    }
}
