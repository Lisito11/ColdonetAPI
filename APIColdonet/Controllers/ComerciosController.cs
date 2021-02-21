using APIColdonet.DTOs;
using APIColdonet.DTOs.Comercios;
using APIColdonet.Entities;
using APIColdonet.Helpers;
using APIColdonet.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace APIColdonet.Controllers {
    [ApiController]
    [Route("api/comercios")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ComerciosController : CustomBaseController {
        private readonly ColdonetDBContext context;
        private readonly IMapper mapper;
        public ComerciosController(ColdonetDBContext context, IMapper mapper) : base(context, mapper) {
            this.context = context;
            this.mapper = mapper;
        }

        #region CrudBasicos
        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<ComercioDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO) {
            return await Get<Usuario, ComercioDTO>(paginacionDTO);
        }


        //Metodo Get(id)
        [HttpGet("{id:int}/{param=null}", Name = "obtenerComercio")]
        public async Task<ActionResult<ComercioDetallesDTO>> Get(int id, string param) {
            var comerciosQueryable = context.Usuarios.AsQueryable();

            if (string.Equals(param, "null")) {
                var comercio = await comerciosQueryable
                .Include(x => x.Categoria).ThenInclude(x => x.SubCategoria).ThenInclude(x => x.Productos)
                .Include(x => x.Clientes).ThenInclude(x => x.DetalleVenta)
                .Include(x => x.Compras).ThenInclude(x => x.DetalleCompras)
                .Include(x => x.Productos)
                .Include(x => x.DeudaClientes)
                .Include(x => x.Proveedors).ThenInclude(x => x.DetalleCompras)
                .Include(x => x.SubUsuarios)
                .Include(x => x.Venta).ThenInclude(x => x.DetalleVenta)
                .Include(x => x.IdDireccionNavigation)
                .Include(x => x.IdTipoComercioNavigation)
                .FirstOrDefaultAsync(x => x.Id == id);
                
                if (comercio == null) {
                    return NotFound();
                }

                return mapper.Map<ComercioDetallesDTO>(comercio);

            }

            #region Filtros
            if (string.Equals(param, "categorias")) {
                var comercioCategoria = await comerciosQueryable.Include(x => x.Categoria).ThenInclude(x => x.SubCategoria).ThenInclude(x => x.Productos).FirstOrDefaultAsync(x => x.Id == id);

                return mapper.Map<ComercioDetallesDTO>(comercioCategoria);

            }

            if (string.Equals(param, "clientes")) {
                var comercioClientes = await comerciosQueryable.Include(x => x.Clientes).ThenInclude(x => x.DeudaClientes.
                Where(x => x.EstatusDeudaCliente == 0)).FirstOrDefaultAsync(x => x.Id == id);

                return mapper.Map<ComercioDetallesDTO>(comercioClientes);

            }

            if (string.Equals(param, "compras")) {
                var comercioCompras = await comerciosQueryable.Include(x => x.Compras).ThenInclude(x => x.DetalleCompras).FirstOrDefaultAsync(x => x.Id == id);

                return mapper.Map<ComercioDetallesDTO>(comercioCompras);

            }

            if (string.Equals(param, "productos")) {
                var comercioProducto = await comerciosQueryable.Include(x => x.Productos).FirstOrDefaultAsync(x => x.Id == id);

                return mapper.Map<ComercioDetallesDTO>(comercioProducto);

            }
            if (string.Equals(param, "proveedores")) {
                var comercioProveedores = await comerciosQueryable.Include(x => x.Proveedors).ThenInclude(x => x.DetalleCompras).FirstOrDefaultAsync(x => x.Id == id);

                return mapper.Map<ComercioDetallesDTO>(comercioProveedores);

            }
            if (string.Equals(param, "subusuarios")) {
                var comercioSubUsuarios = await comerciosQueryable.Include(x => x.SubUsuarios).FirstOrDefaultAsync(x => x.Id == id);

                return mapper.Map<ComercioDetallesDTO>(comercioSubUsuarios);

            }
            if (string.Equals(param, "ventas")) {
                var comercioVenta = await comerciosQueryable.Include(x => x.Venta).FirstOrDefaultAsync(x => x.Id == id);

                return mapper.Map<ComercioDetallesDTO>(comercioVenta);

            }
            if (string.Equals(param, "ventas")) {
                var comercioVenta = await comerciosQueryable.Include(x => x.Venta).ThenInclude(x => x.DetalleVenta).FirstOrDefaultAsync(x => x.Id == id);

                return mapper.Map<ComercioDetallesDTO>(comercioVenta);

            }
            if (string.Equals(param, "direccion")) {
                var comercioDireccion = await comerciosQueryable.Include(x => x.IdDireccionNavigation).FirstOrDefaultAsync(x => x.Id == id);

                return mapper.Map<ComercioDetallesDTO>(comercioDireccion);

            }
            if (string.Equals(param, "tipocomercio")) {
                var comercioTipoComercio = await comerciosQueryable.Include(x => x.IdTipoComercioNavigation).FirstOrDefaultAsync(x => x.Id == id);

                return mapper.Map<ComercioDetallesDTO>(comercioTipoComercio);

            }
            #endregion


            return NotFound();

        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ComercioCreacionDTO comercioCreacionDTO) {
            return await Post<ComercioCreacionDTO, Usuario, ComercioDTO>(comercioCreacionDTO, "obtenerComercio");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ComercioCreacionDTO comercioCreacionDTO) {
            return await Put<ComercioCreacionDTO, Usuario>(id, comercioCreacionDTO);
        }

        //Metodo Patch
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) {
            return await Delete<Usuario>(id);
        }
        #endregion

        //Pendiente
        #region CrudPorComercio




        #endregion









    }
}
