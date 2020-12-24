using System;
using System.Collections.Generic;

#nullable disable

namespace APIColdonet.Entities
{
    public partial class DetalleVentum:IId
    {
        public DetalleVentum()
        {
            DeudaClientes = new HashSet<DeudaCliente>();
        }

        public int Id { get; set; }
        public int? EstatusDetalleVenta { get; set; }
        public decimal? PrecioProductoDv { get; set; }
        public int? CantidadProductoDv { get; set; }
        public decimal? CostoProductoDv { get; set; }
        public DateTime? FechaDetalleVenta { get; set; }
        public int? IdVenta { get; set; }
        public int? IdProducto { get; set; }
        public int? IdCliente { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual Ventum IdVentaNavigation { get; set; }
        public virtual ICollection<DeudaCliente> DeudaClientes { get; set; }
    }
}
