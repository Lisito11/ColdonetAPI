using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.DTOs.DeudaCliente {
    public class DeudaClienteCreacionDTO {
        public decimal? ClienteDebe { get; set; }
        public int? EstatusDeudaCliente { get; set; }
        public int? IdCliente { get; set; }
        public int? IdDetalleVenta { get; set; }
        public string ProductoCliente { get; set; }
        public int? IdUsuario { get; set; }
    }
}
