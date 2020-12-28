using APIColdonet.DTOs.Categorias;
using APIColdonet.DTOs.Clientes;
using APIColdonet.DTOs.Comercios;
using APIColdonet.DTOs.Compras;
using APIColdonet.DTOs.DetalleCompras;
using APIColdonet.DTOs.DetalleVentas;
using APIColdonet.DTOs.DeudaCliente;
using APIColdonet.DTOs.Direcciones;
using APIColdonet.DTOs.Productos;
using APIColdonet.DTOs.Proveedores;
using APIColdonet.DTOs.SubCategorias;
using APIColdonet.DTOs.SubUsuarios;
using APIColdonet.DTOs.TipoComercios;
using APIColdonet.DTOs.UsuariosAPI;
using APIColdonet.DTOs.Ventas;
using APIColdonet.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using NetTopologySuite.Geometries;
using System.Collections.Generic;

namespace APIColdonet.Helpers {
    public class AutoMapperProfiles : Profile {
        public AutoMapperProfiles(GeometryFactory geometryFactory) {

            CreateMap<IdentityUser, UsuarioDTO>();

            //Comercio
            CreateMap<Usuario, ComercioDTO>().ReverseMap();
            CreateMap<ComercioCreacionDTO, Usuario>();


            CreateMap<Usuario, ComercioDetallesDTO>().ReverseMap();
              //  .ForMember(x => x.Categorias, options => options.MapFrom(MapperComercios.MapUsuariosCategorias));
               /* .ForMember(x => x.Clientes, options => options.MapFrom(MapUsuariosClientes))
                .ForMember(x => x.Compras, options => options.MapFrom(MapUsuariosCompras))
                .ForMember(x => x.Productos, options => options.MapFrom(MapUsuariosProductos))
                .ForMember(x => x.Proveedors, options => options.MapFrom(MapUsuariosProveedors))
                .ForMember(x => x.SubCategoria, options => options.MapFrom(MapUsuariosSubCategoria))
                .ForMember(x => x.SubUsuarios, options => options.MapFrom(MapUsuariosSubUsuarios))
                .ForMember(x => x.Venta, options => options.MapFrom(MapUsuariosVenta));*/

            //Tipo de comercio
            CreateMap<TipoComercio, TipoComercioDTO>().ReverseMap();
            CreateMap<TipoComercioCreacionDTO, TipoComercio>();

            //Direccion
            CreateMap<Direccion, DireccionDTO>()
                .ForMember(x=> x.Latitud, x=> x.MapFrom(y=> y.Ubicacion.Y))
                .ForMember(x => x.Longitud, x => x.MapFrom(y => y.Ubicacion.X));

            CreateMap<DireccionDTO, Direccion>()
                .ForMember(x => x.Ubicacion, x => x.MapFrom(y => 
                geometryFactory.CreatePoint(new Coordinate(y.Longitud, y.Latitud))));

            CreateMap<DireccionCreacionDTO, Direccion>()
                .ForMember(x => x.Ubicacion, x => x.MapFrom(y =>
               geometryFactory.CreatePoint(new Coordinate(y.Longitud, y.Latitud))));


            //Sub Usuario
            CreateMap<SubUsuario, SubUsuarioDTO>().ReverseMap();
            CreateMap<SubUsuarioCreacionDTO, SubUsuario>();

            //Categoria
            CreateMap<Categorium, CategoriaDTO>().ReverseMap();
            CreateMap<CategoriaCreacionDTO, Categorium>();

            //SubCategoria
            CreateMap<SubCategorium, SubCategoriaDTO>().ReverseMap();
            CreateMap<SubCategoriaCreacionDTO, SubCategorium>();

            //Productos
            CreateMap<Producto, ProductoDTO>().ReverseMap();
            CreateMap<ProductoCreacionDTO, Producto>();

            //Clientes
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<ClienteCreacionDTO, Cliente>();

            //Ventas
            CreateMap<Ventum, VentaDTO>().ReverseMap();
            CreateMap<VentaCreacionDTO, Ventum>();

            //DetalleVentas
            CreateMap<DetalleVentum, DetalleVentaDTO>().ReverseMap();
            CreateMap<DetalleVentaCreacionDTO, DetalleVentum>();

            //DeudaClientes
            CreateMap<DeudaCliente, DeudaClienteDTO>().ReverseMap();
            CreateMap<DeudaClienteCreacionDTO, DeudaCliente>();

            //Proveedores
            CreateMap<Proveedor, ProveedorDTO>().ReverseMap();
            CreateMap<ProveedorCreacionDTO, Proveedor>();






            //Compras
            CreateMap<Compra, CompraDTO>().ReverseMap();
            CreateMap<CompraCreacionDTO, Compra>(); //.ForMember(x => x.CompraProveedores, options => options.MapFrom(MapCompraProveedores));

            //DetalleCompras
            CreateMap<DetalleCompra, DetalleCompraDTO>().ReverseMap();
            CreateMap<DetalleCompraCreacionDTO, DetalleCompra>();

        }
      /*  private List<CompraProveedores> MapCompraProveedores(CompraCreacionDTO compraCreacionDTO, Compra compra) {

            var resultado = new List<CompraProveedores>();

            if (compraCreacionDTO.ProveedoresID == null) { return resultado; }

            foreach (var id in compraCreacionDTO.ProveedoresID) {
                resultado.Add(new CompraProveedores() { ProveedorId = id });
            }

            return resultado;*/
        }
    }

