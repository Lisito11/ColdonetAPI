using System;
using System.Collections.Generic;

#nullable disable

namespace APIColdonet.Entities
{
    public partial class Producto:IId
    {
        public Producto()
        {
            DetalleCompras = new HashSet<DetalleCompra>();
            DetalleVenta = new HashSet<DetalleVentum>();
        }

        public int Id { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public decimal? PrecioProdcuto { get; set; }
        public decimal? CostoProducto { get; set; }
        public int? CantidadProducto { get; set; }
        public int? EstatusProducto { get; set; }
        public int? Pesado { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdSubCategoria { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Categorium IdCategoriaNavigation { get; set; }
        public virtual SubCategorium IdSubCategoriaNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }
        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }
    }
}
