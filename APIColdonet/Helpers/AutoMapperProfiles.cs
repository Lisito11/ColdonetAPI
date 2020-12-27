using APIColdonet.DTOs.Categorias;
using APIColdonet.DTOs.Comercios;
using APIColdonet.DTOs.Direcciones;
using APIColdonet.DTOs.SubCategorias;
using APIColdonet.DTOs.SubUsuarios;
using APIColdonet.DTOs.TipoComercios;
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
        }
    }
}
