using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.DTOs.Comercios {
    public class ComercioCreacionDTO {
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string Telefono { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int? Delivery { get; set; }
        public int? EstatusUsuario { get; set; }
        public int? IdTipoComercio { get; set; }
        public int? IdDireccion { get; set; }
    }
}
