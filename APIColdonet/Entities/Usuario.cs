using System;
using System.Collections.Generic;

#nullable disable

namespace APIColdonet.Entities
{
    public partial class Usuario: IId
    {
        public Usuario()
        {
            Categoria = new HashSet<Categorium>();
            Clientes = new HashSet<Cliente>();
            Compras = new HashSet<Compra>();
            DetalleCompras = new HashSet<DetalleCompra>();
            DetalleVenta = new HashSet<DetalleVentum>();
            DeudaClientes = new HashSet<DeudaCliente>();
            Productos = new HashSet<Producto>();
            Proveedors = new HashSet<Proveedor>();
            SubCategoria = new HashSet<SubCategorium>();
            SubUsuarios = new HashSet<SubUsuario>();
            Venta = new HashSet<Ventum>();
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Contraseña { get; set; }
        public string Telefono { get; set; }
        public DateTime? FechaIngreso { get; set; }
        public int? Delivery { get; set; }
        public int? EstatusUsuario { get; set; }
        public int? IdTipoComercio { get; set; }
        public int? IdDireccion { get; set; }
        public int? TipoPago { get; set; }

        public virtual Direccion IdDireccionNavigation { get; set; }
        public virtual TipoComercio IdTipoComercioNavigation { get; set; }
        public virtual ICollection<Categorium> Categoria { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Compra> Compras { get; set; }
        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }
        public virtual ICollection<DetalleVentum> DetalleVenta { get; set; }
        public virtual ICollection<DeudaCliente> DeudaClientes { get; set; }
        public virtual ICollection<Producto> Productos { get; set; }
        public virtual ICollection<Proveedor> Proveedors { get; set; }
        public virtual ICollection<SubCategorium> SubCategoria { get; set; }
        public virtual ICollection<SubUsuario> SubUsuarios { get; set; }
        public virtual ICollection<Ventum> Venta { get; set; }
    }
}
