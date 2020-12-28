using APIColdonet.DTOs.Comercios;
using APIColdonet.DTOs.Categorias;
using APIColdonet.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.Helpers {
    public class MapperComercios {
        public static List<CategoriaDTO> MapUsuariosCategorias(Usuario comercio, ComercioDetallesDTO comercioDetallesDTO) {
            var resultado = new List<CategoriaDTO>();

            if (comercio.Categoria == null) { return resultado; }

            foreach (var categoriaUsuario in comercio.Categoria) {
                resultado.Add(new CategoriaDTO {
                   NombreCategoria  = categoriaUsuario.NombreCategoria,
                   CodigoCategoria  = categoriaUsuario.CodigoCategoria,
                   DescripcionCategoria  = categoriaUsuario.DescripcionCategoria
                });
            }

            return resultado;
        }

    }
}
