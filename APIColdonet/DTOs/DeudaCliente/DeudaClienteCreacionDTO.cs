using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.DTOs.DeudaCliente {
    public class DeudaClienteCreacionDTO {
        public decimal? ClienteDebe { get; set; }
        public int? EstatusDeudaCliente { get; set; }
        public int? IdCliente { get; set; }
        public int? IdUsuario { get; set; }
        public DateTime? FechaDeuda { get; set; }
        public string ListaDetalleVenta { get; set; }


    }
}
