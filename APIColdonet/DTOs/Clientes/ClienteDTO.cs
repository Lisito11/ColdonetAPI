using APIColdonet.DTOs.DetalleVentas;
using APIColdonet.DTOs.DeudaCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.DTOs.Clientes {
    public class ClienteDTO:ClienteCreacionDTO {
        public int Id { get; set; }
        public virtual ICollection<DetalleVentaDTO> DetalleVenta { get; set; }
    }
}
