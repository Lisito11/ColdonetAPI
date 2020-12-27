using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.DTOs.Proveedores {
    public class ProveedorCreacionDTO {
        public string NombreProveedor { get; set; }
        public string TelefonoProveedor { get; set; }
        public int? IdDireccion { get; set; }
        public int? IdUsuario { get; set; }
    }
}
