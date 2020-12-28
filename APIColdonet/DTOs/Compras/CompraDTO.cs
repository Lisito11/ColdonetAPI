using APIColdonet.DTOs.DetalleCompras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.DTOs.Compras {
    public class CompraDTO: CompraCreacionDTO {
        public int Id { get; set; }
        public virtual ICollection<DetalleCompraDTO> DetalleCompras { get; set; }

    }
}
