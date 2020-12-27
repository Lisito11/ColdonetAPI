using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.DTOs.SubCategorias {
    public class SubCategoriaCreacionDTO {
        public string CodigoSubCategoria { get; set; }
        public string NombreSubCategoria { get; set; }
        public string DescripcionSubCategoria { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdUsuario { get; set; }
    }
}
