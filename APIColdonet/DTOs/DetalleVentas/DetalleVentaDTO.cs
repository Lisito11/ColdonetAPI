using APIColdonet.DTOs.DeudaCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.DTOs.DetalleVentas {
    public class DetalleVentaDTO: DetalleVentaCreacionDTO {
        public int Id { get; set; }
        public virtual ICollection<DeudaClienteDTO> DeudaClientes { get; set; }

    }
}
