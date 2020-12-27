using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.DTOs.Clientes {
    public class ClienteCreacionDTO {
        public string Nombre { get; set; }
        public decimal? Abono { get; set; }
        public decimal? DeudaTotal { get; set; }
        public int? Estatus { get; set; }
        public int? IdUsuario { get; set; }
    }
}
