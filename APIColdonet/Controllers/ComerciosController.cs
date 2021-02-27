using APIColdonet.DTOs;
using APIColdonet.DTOs.Comercios;
using APIColdonet.DTOs.UsuariosAPI;
using APIColdonet.Entities;
using APIColdonet.Helpers;
using APIColdonet.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace APIColdonet.Controllers {
    [ApiController]
    [Route("api/comercios")]
    public class ComerciosController : CustomBaseController {
        private readonly ColdonetDBContext context;
        private readonly IMapper mapper;
        private readonly IConfiguration _configuration;

        public ComerciosController(ColdonetDBContext context, IMapper mapper, IConfiguration configuration) : base(context, mapper) {
            this.context = context;
            this.mapper = mapper;
            _configuration = configuration;
        }

        #region CrudBasicos
        //Metodo Get
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<List<ComercioDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO) {
            return await Get<Usuario, ComercioDTO>(paginacionDTO);
        }


        //Metodo Get(id)
        [HttpGet("{id:int}/{param=null}", Name = "obtenerComercioById")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
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

            #region Filtros por id
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

        //Metodo Get(email)
        [HttpGet("{email}/{param=null}", Name = "obtenerComercioByEmail")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult<ComercioDetallesDTO>> Get(string email, string param) {
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
                .FirstOrDefaultAsync(x => x.Email == email);

                if (comercio == null) {
                    return NotFound();
                }

                return mapper.Map<ComercioDetallesDTO>(comercio);

            }

            #region Filtros por email
            if (string.Equals(param, "categorias")) {
                var comercioCategoria = await comerciosQueryable.Include(x => x.Categoria).ThenInclude(x => x.SubCategoria).ThenInclude(x => x.Productos).FirstOrDefaultAsync(x => x.Email == email);

                return mapper.Map<ComercioDetallesDTO>(comercioCategoria);

            }

            if (string.Equals(param, "clientes")) {
                var comercioClientes = await comerciosQueryable.Include(x => x.Clientes).ThenInclude(x => x.DeudaClientes.
                Where(x => x.EstatusDeudaCliente == 0)).FirstOrDefaultAsync(x => x.Email == email);

                return mapper.Map<ComercioDetallesDTO>(comercioClientes);

            }

            if (string.Equals(param, "compras")) {
                var comercioCompras = await comerciosQueryable.Include(x => x.Compras).ThenInclude(x => x.DetalleCompras).FirstOrDefaultAsync(x => x.Email == email);

                return mapper.Map<ComercioDetallesDTO>(comercioCompras);

            }

            if (string.Equals(param, "productos")) {
                var comercioProducto = await comerciosQueryable.Include(x => x.Productos).FirstOrDefaultAsync(x => x.Email == email);

                return mapper.Map<ComercioDetallesDTO>(comercioProducto);

            }
            if (string.Equals(param, "proveedores")) {
                var comercioProveedores = await comerciosQueryable.Include(x => x.Proveedors).ThenInclude(x => x.DetalleCompras).FirstOrDefaultAsync(x => x.Email == email);

                return mapper.Map<ComercioDetallesDTO>(comercioProveedores);

            }
            if (string.Equals(param, "subusuarios")) {
                var comercioSubUsuarios = await comerciosQueryable.Include(x => x.SubUsuarios).FirstOrDefaultAsync(x => x.Email == email);

                return mapper.Map<ComercioDetallesDTO>(comercioSubUsuarios);

            }
            if (string.Equals(param, "ventas")) {
                var comercioVenta = await comerciosQueryable.Include(x => x.Venta).FirstOrDefaultAsync(x => x.Email == email);

                return mapper.Map<ComercioDetallesDTO>(comercioVenta);

            }
            if (string.Equals(param, "ventas")) {
                var comercioVenta = await comerciosQueryable.Include(x => x.Venta).ThenInclude(x => x.DetalleVenta).FirstOrDefaultAsync(x => x.Email == email);

                return mapper.Map<ComercioDetallesDTO>(comercioVenta);

            }
            if (string.Equals(param, "direccion")) {
                var comercioDireccion = await comerciosQueryable.Include(x => x.IdDireccionNavigation).FirstOrDefaultAsync(x => x.Email == email);

                return mapper.Map<ComercioDetallesDTO>(comercioDireccion);

            }
            if (string.Equals(param, "tipocomercio")) {
                var comercioTipoComercio = await comerciosQueryable.Include(x => x.IdTipoComercioNavigation).FirstOrDefaultAsync(x => x.Email == email);

                return mapper.Map<ComercioDetallesDTO>(comercioTipoComercio);

            }
            #endregion


            return NotFound();

        }


        //Metodo Put
        [HttpPut("{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Put(int id, [FromBody] ComercioCreacionDTO comercioCreacionDTO) {



            return await Put<ComercioCreacionDTO, Usuario>(id, comercioCreacionDTO);
        }

        //Metodo Patch
        [HttpDelete("{id:int}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<ActionResult> Delete(int id) {
            return await Delete<Usuario>(id);
        }
        #endregion

        //Pendiente
        #region CrudPorComercio




        #endregion

        #region Tokens
        //Construir un token
        private UserToken ConstruirToken(UserInfo userInfo) {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userInfo.Nombre),
                new Claim(ClaimTypes.Email, userInfo.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiracion = DateTime.UtcNow.AddYears(1);
            
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null, 
                audience: null, 
                claims: claims, 
                expires: expiracion, 
                signingCredentials: creds);

            return new UserToken() {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiracion = expiracion
            };

        }
        //Iniciar sesion
        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserInfo usuarioLogin) {
            var usuario =  await context.Usuarios.Where(x => x.Email == usuarioLogin.Email && x.Contraseña == usuarioLogin.Password).FirstOrDefaultAsync();

            if (usuario != null) {
                var userinfo = new UserInfo() { Nombre = usuario.Nombre, Email = usuario.Email, Password = usuario.Contraseña };
                return ConstruirToken(userinfo);
            } else {
                return BadRequest("Login Invalido");
            }
        }
        //Registrar un usuario
        [HttpPost]
        public async Task<ActionResult<UserToken>> Post([FromBody] ComercioCreacionDTO comercioCreacionDTO) {
            try {
                var entidad = mapper.Map<Usuario>(comercioCreacionDTO);
                context.Add(entidad);
                //  var dtoLectura = mapper.Map<ComercioDTO>(entidad);

                var userinfo = new UserInfo() { Email = comercioCreacionDTO.Email, Password = comercioCreacionDTO.Contraseña, Nombre = comercioCreacionDTO.Nombre };

                await context.SaveChangesAsync();
                
                // return new CreatedAtRouteResult("obtenerComercio", new { id = entidad.Id }, dtoLectura);
                return ConstruirToken(userinfo);
            } catch (Exception e) {
                return Content(e.ToString());
            }

            // return await Post<ComercioCreacionDTO, Usuario, ComercioDTO>(comercioCreacionDTO, "obtenerComercio");
        }
        #endregion

    }
}
