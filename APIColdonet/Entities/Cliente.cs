using System;
using System.Collections.Generic;

#nullable disable

namespace APIColdonet.Entities
{
    public partial class Cliente: IId
    {
        public Cliente()
        {
            DetalleVenta = new HashSet<DetalleVentum>();
            DeudaClientes = new HashSet<DeudaCliente>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal? Abono { get; set; }
        public decimal? DeudaTotal { get; set; }
        public int? Estatus { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }
        public virtual ICollection<DeudaCliente> DeudaClientes { get; set; }
    }
}
