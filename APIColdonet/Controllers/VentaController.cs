using APIColdonet.DTOs;
using APIColdonet.DTOs.Ventas;
using APIColdonet.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.Controllers {
    [ApiController]
    [Route("api/ventas")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class VentaController:CustomBaseController {
        public VentaController(ColdonetDBContext context, IMapper mapper) : base(context, mapper) {
        }

        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<VentaDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO) {
            return await Get<Ventum, VentaDTO>(paginacionDTO);
        }

        //Metodo Get(id)
        [HttpGet("{id:int}", Name = "obtenerVenta")]
        public async Task<ActionResult<VentaDTO>> Get(int id) {
            return await Get<Ventum, VentaDTO>(id);
        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] VentaCreacionDTO ventaCreacionDTO) {
            return await Post<VentaCreacionDTO, Ventum, VentaDTO>(ventaCreacionDTO, "obtenerVenta");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] VentaCreacionDTO ventaCreacionDTO) {
            return await Put<VentaCreacionDTO, Ventum>(id, ventaCreacionDTO);
        }

        //Metodo Patch
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) {
            return await Delete<Ventum>(id);
        }
    }
}
