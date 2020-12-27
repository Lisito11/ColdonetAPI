using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.DTOs.Ventas {
    public class VentaCreacionDTO {
        public decimal? TotalVenta { get; set; }
        public decimal? CostoVenta { get; set; }
        public DateTime? FechaVenta { get; set; }
        public int EstatusVenta { get; set; }
        public int? IdUsuario { get; set; }
    }
}
