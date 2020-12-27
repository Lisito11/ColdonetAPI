using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.DTOs.Productos {
    public class ProductoCreacionDTO {
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal? PrecioProdcuto { get; set; }
        public decimal? CostoProducto { get; set; }
        public int? CantidadProducto { get; set; }
        public int? EstatusProducto { get; set; }
        public int? Pesado { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdSubCategoria { get; set; }
        public int? IdUsuario { get; set; }
    }
}
