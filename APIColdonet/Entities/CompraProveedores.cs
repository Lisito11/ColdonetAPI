using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.Entities {
    public class CompraProveedores {
        public int ProveedorId { get; set; }
        public int CompraId { get; set; }
        public Proveedor Proveedor { get; set; }
        public Compra Compra { get; set; }
    }
}
