using System;
using System.Collections.Generic;

#nullable disable

namespace APIColdonet.Entities
{
    public partial class Proveedor:IId
    {
        public Proveedor()
        {
            Compras = new HashSet<Compra>();
        }

        public int Id { get; set; }
        public string NombreProveedor { get; set; }
        public string TelefonoProveedor { get; set; }
        public int? IdDireccion { get; set; }
        public int? IdUsuario { get; set; }
     //   public List<CompraProveedores> CompraProveedores { get; set; }

        public virtual Direccion IdDireccionNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
    }
}
