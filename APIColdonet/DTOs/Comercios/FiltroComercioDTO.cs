using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.DTOs.Comercios {
    public class FiltroComercioDTO {
        public int Pagina { get; set; } = 1;
        public int CantidadRegistrosPorPagina { get; set; } = 10;
        public PaginacionDTO Paginacion {
            get { return new PaginacionDTO() { Pagina = Pagina, CantidadRegistrosPorPagina = CantidadRegistrosPorPagina }; }
        }
        public int CategoriaID { get; set; }

      /*  public virtual DireccionDTO IdDireccionNavigation { get; set; }
        public virtual TipoComercioDTO IdTipoComercioNavigation { get; set; }
        public virtual ICollection<CategoriaDTO> Categoria { get; set; }
        public virtual ICollection<ClienteDTO> Clientes { get; set; }
        public virtual ICollection<CompraDTO> Compras { get; set; }
        public virtual ICollection<ProductoDTO> Productos { get; set; }
        public virtual ICollection<ProveedorDTO> Proveedors { get; set; }
        public virtual ICollection<SubUsuarioDTO> SubUsuarios { get; set; }
        public virtual ICollection<VentaDTO> Venta { get; set; }*/
    }
}
