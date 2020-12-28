using APIColdonet.DTOs.Productos;
using APIColdonet.DTOs.SubCategorias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.DTOs.Categorias {
    public class CategoriaDTO: CategoriaCreacionDTO {
        public int Id { get; set; }
        public virtual ICollection<SubCategoriaDTO> SubCategoria { get; set; }
        public virtual ICollection<ProductoDTO> Productos { get; set; }

    }
}
