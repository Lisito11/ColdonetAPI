using System;
using System.Collections.Generic;

#nullable disable

namespace APIColdonet.Entities
{
    public partial class DeudaCliente:IId
    {
        public int Id { get; set; }
        public decimal? ClienteDebe { get; set; }
        public int? EstatusDeudaCliente { get; set; }
        public int? IdCliente { get; set; }
        public int? IdUsuario { get; set; }
        public DateTime? FechaDeuda { get; set; }
        public string ListaDetalleVenta { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
