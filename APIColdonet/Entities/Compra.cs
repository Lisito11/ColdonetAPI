using System;
using System.Collections.Generic;

#nullable disable

namespace APIColdonet.Entities
{
    public partial class Compra:IId
    {
        public Compra()
        {
            DetalleCompras = new HashSet<DetalleCompra>();
        }

        public int Id { get; set; }
        public string NombreCompra { get; set; }
        public DateTime? FechaCompra { get; set; }
        public decimal? TotalCompra { get; set; }
        public int? EstatusCompra { get; set; }
        public decimal? PorPagar { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }
    }
}
