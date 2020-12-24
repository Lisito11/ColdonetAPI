using System;
using System.Collections.Generic;

#nullable disable

namespace APIColdonet.Entities
{
    public partial class Ventum: IId
    {
        public Ventum()
        {
            DetalleVenta = new HashSet<DetalleVentum>();
        }

        public int Id { get; set; }
        public decimal? TotalVenta { get; set; }
        public decimal? CostoVenta { get; set; }
        public DateTime? FechaVenta { get; set; }
        public int EstatusVenta { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }
    }
}
