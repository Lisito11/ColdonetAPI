using APIColdonet.DTOs.Comercios;
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

            CreateMap<Usuario, ComercioDTO>().ReverseMap();
            CreateMap<ComercioCreacionDTO, Usuario>();

            CreateMap<TipoComercio, TipoComercioDTO>().ReverseMap();
            CreateMap<TipoComercioCreacionDTO, TipoComercio>();

        }
    }
}
