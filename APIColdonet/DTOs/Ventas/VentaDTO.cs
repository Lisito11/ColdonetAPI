using APIColdonet.DTOs.DetalleVentas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.DTOs.Ventas {
    public class VentaDTO: VentaCreacionDTO {
        public int Id { get; set; }
        public virtual ICollection<DetalleVentaDTO> DetalleVenta { get; set; }

    }
}
