using System;
using System.Collections.Generic;

#nullable disable

namespace APIColdonet.Entities
{
    public partial class DetalleCompra: IId
    {
        public int Id { get; set; }
        public decimal? CostoUnidad { get; set; }
        public int CantidadProductoDc { get; set; }
        public int? IdProducto { get; set; }
        public int? IdCompra { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdProveedor { get; set; }

        public virtual Proveedor IdProveedorNavigation { get; set; }

        public virtual Compra IdCompraNavigation { get; set; }
        public virtual Producto IdProductoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
