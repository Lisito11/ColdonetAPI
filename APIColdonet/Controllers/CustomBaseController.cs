using APIColdonet.DTOs;
using APIColdonet.Entities;
using APIColdonet.Helpers;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace APIColdonet.Controllers {
    public class CustomBaseController: ControllerBase {
        private readonly ColdonetDBContext context;
        private readonly IMapper mapper;

        public CustomBaseController(ColdonetDBContext context, IMapper mapper) {
            this.context = context;
            this.mapper = mapper;
        }

        //Metodo get para listar entidades
        protected async Task<List<TDTO>> Get<TEntidad, TDTO>() where TEntidad : class {


            var entidades = await context.Set<TEntidad>().AsNoTracking().ToListAsync();
            var dtos = mapper.Map<List<TDTO>>(entidades);
            return dtos;
        }

        //Metodo get para listar entidades con paginacion
        protected async Task<List<TDTO>> Get<TEntidad, TDTO>(PaginacionDTO paginacionDTO)
            where TEntidad : class {
            var queryable = context.Set<TEntidad>().AsQueryable();
            return await Get<TEntidad, TDTO>(paginacionDTO, queryable);
        }

        //Metodo auxiliar get para listar entidades con paginacion
        protected async Task<List<TDTO>> Get<TEntidad, TDTO>(PaginacionDTO paginacionDTO,
            IQueryable<TEntidad> queryable)
            where TEntidad : class {
            await HttpContext.InsertarParametrosPaginacion(queryable, paginacionDTO.CantidadRegistrosPorPagina);
            var entidades = await queryable.Paginar(paginacionDTO).ToListAsync();
            return mapper.Map<List<TDTO>>(entidades);
        }

        protected async Task<ActionResult<TDTO>> Get<TEntidad, TDTO>(int id) where TEntidad : class, IId {
            var entidad = await context.Set<TEntidad>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (entidad == null) {
                return NotFound();
            }

            return mapper.Map<TDTO>(entidad);
        }

        protected async Task<ActionResult> Post<TCreacion, TEntidad, TLectura>(TCreacion creacionDTO, string nombreRuta) where TEntidad : class, IId {
            try {
                var entidad = mapper.Map<TEntidad>(creacionDTO);
                context.Add(entidad);
                await context.SaveChangesAsync();
                var dtoLectura = mapper.Map<TLectura>(entidad);

                return new CreatedAtRouteResult(nombreRuta, new { id = entidad.Id }, dtoLectura);
            } catch (Exception e) {
                return Content(e.ToString());
            }


        }

        protected async Task<ActionResult> Put<TCreacion, TEntidad>
            (int id, TCreacion creacionDTO) where TEntidad : class, IId {
            var entidad = mapper.Map<TEntidad>(creacionDTO);
            entidad.Id = id;
            context.Entry(entidad).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        protected async Task<ActionResult> Delete<TEntidad>(int id) where TEntidad : class, IId, new() {
            var existe = await context.Set<TEntidad>().AnyAsync(x => x.Id == id);
            if (!existe) {
                return NotFound();
            }

            context.Remove(new TEntidad() { Id = id });
            await context.SaveChangesAsync();

            return NoContent();
        }

        protected async Task<ActionResult> Patch<TEntidad, TDTO>(int id, JsonPatchDocument<TDTO> patchDocument)
            where TDTO : class
            where TEntidad : class, IId {
            if (patchDocument == null) {
                return BadRequest();
            }

            var entidadDB = await context.Set<TEntidad>().FirstOrDefaultAsync(x => x.Id == id);

            if (entidadDB == null) {
                return NotFound();
            }

            var dto = mapper.Map<TDTO>(entidadDB);

            patchDocument.ApplyTo(dto, (Microsoft.AspNetCore.JsonPatch.Adapters.IObjectAdapter)ModelState);

            var isValid = TryValidateModel(dto);

            if (!isValid) {
                return BadRequest(ModelState);
            }

            mapper.Map(dto, entidadDB);

            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}
