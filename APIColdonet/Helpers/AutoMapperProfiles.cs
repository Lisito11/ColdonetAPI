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
using APIColdonet.DTOs.Ventas;
using APIColdonet.Entities;
using AutoMapper;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.Helpers {
    public class AutoMapperProfiles : Profile {
        public AutoMapperProfiles(GeometryFactory geometryFactory) {


            //Comercio
            CreateMap<Usuario, ComercioDTO>().ReverseMap();
            CreateMap<ComercioCreacionDTO, Usuario>();
             
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
            CreateMap<CompraCreacionDTO, Compra>();

            //DetalleCompras
            CreateMap<DetalleCompra, DetalleCompraDTO>().ReverseMap();
            CreateMap<DetalleCompraCreacionDTO, DetalleCompra>();

        }
    }
}
