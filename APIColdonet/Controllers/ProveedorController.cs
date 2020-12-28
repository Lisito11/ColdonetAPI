using APIColdonet.DTOs;
using APIColdonet.DTOs.Proveedores;
using APIColdonet.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace APIColdonet.Controllers {
    [ApiController]
    [Route("api/proveedores")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class ProveedorController:CustomBaseController {
        public ProveedorController(ColdonetDBContext context, IMapper mapper) : base(context, mapper) {
        }

        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<ProveedorDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO) {
            return await Get<Proveedor, ProveedorDTO>(paginacionDTO);
        }

        //Metodo Get(id)
        [HttpGet("{id:int}", Name = "obtenerProveedor")]
        public async Task<ActionResult<ProveedorDTO>> Get(int id) {
            return await Get<Proveedor, ProveedorDTO>(id);
        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProveedorCreacionDTO proveedorCreacionDTO) {
            return await Post<ProveedorCreacionDTO, Proveedor, ProveedorDTO>(proveedorCreacionDTO, "obtenerProveedor");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProveedorCreacionDTO proveedorCreacionDTO) {
            return await Put<ProveedorCreacionDTO, Proveedor>(id, proveedorCreacionDTO);
        }

        //Metodo Patch
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) {
            return await Delete<Proveedor>(id);
        }
    }
}
