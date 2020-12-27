using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.DTOs.DetalleVentas {
    public class DetalleVentaCreacionDTO {
        public int? EstatusDetalleVenta { get; set; }
        public decimal? PrecioProductoDv { get; set; }
        public int? CantidadProductoDv { get; set; }
        public decimal? CostoProductoDv { get; set; }
        public DateTime? FechaDetalleVenta { get; set; }
        public int? IdVenta { get; set; }
        public int? IdProducto { get; set; }
        public int? IdCliente { get; set; }
        public int? IdUsuario { get; set; }
    }
}
