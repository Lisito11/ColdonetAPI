using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.DTOs.DetalleCompras {
    public class DetalleCompraCreacionDTO {
        public decimal? CostoUnidad { get; set; }
        public int CantidadProductoDc { get; set; }
        public int? IdProducto { get; set; }
        public int? IdCompra { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdProveedor { get; set; }

    }
}
