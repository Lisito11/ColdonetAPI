using APIColdonet.DTOs.Categorias;
using APIColdonet.DTOs.Clientes;
using APIColdonet.DTOs.Compras;
using APIColdonet.DTOs.DetalleCompras;
using APIColdonet.DTOs.DetalleVentas;
using APIColdonet.DTOs.Direcciones;
using APIColdonet.DTOs.Productos;
using APIColdonet.DTOs.Proveedores;
using APIColdonet.DTOs.SubCategorias;
using APIColdonet.DTOs.SubUsuarios;
using APIColdonet.DTOs.TipoComercios;
using APIColdonet.DTOs.Ventas;
using APIColdonet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.DTOs.Comercios {
    public class ComercioDetallesDTO: ComercioDTO {
        public virtual DireccionDTO IdDireccionNavigation { get; set; }
        public virtual TipoComercioDTO IdTipoComercioNavigation { get; set; }
        public virtual ICollection<CategoriaDTO> Categoria { get; set; }
        public virtual ICollection<ClienteDTO> Clientes { get; set; }
        public virtual ICollection<CompraDTO> Compras { get; set; }
        public virtual ICollection<ProductoDTO> Productos { get; set; }
        public virtual ICollection<ProveedorDTO> Proveedors { get; set; }
        public virtual ICollection<SubUsuarioDTO> SubUsuarios { get; set; }
        public virtual ICollection<VentaDTO> Venta { get; set; }
    }
}
