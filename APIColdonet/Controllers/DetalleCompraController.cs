using APIColdonet.DTOs;
using APIColdonet.DTOs.DetalleCompras;
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
    [Route("api/detallecompras")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class DetalleCompraController:CustomBaseController {
        public DetalleCompraController(ColdonetDBContext context, IMapper mapper) : base(context, mapper) {
        }

        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<DetalleCompraDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO) {
            return await Get<DetalleCompra, DetalleCompraDTO>(paginacionDTO);
        }

        //Metodo Get(id)
        [HttpGet("{id:int}", Name = "obtenerDetalleCompra")]
        public async Task<ActionResult<DetalleCompraDTO>> Get(int id) {
            return await Get<DetalleCompra, DetalleCompraDTO>(id);
        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DetalleCompraCreacionDTO detalleCompraCreacionDTO) {
            return await Post<DetalleCompraCreacionDTO, DetalleCompra, DetalleCompraDTO>(detalleCompraCreacionDTO, "obtenerDetalleCompra");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] DetalleCompraCreacionDTO detalleCompraCreacionDTO) {
            return await Put<DetalleCompraCreacionDTO, DetalleCompra>(id, detalleCompraCreacionDTO);
        }

        //Metodo Patch
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) {
            return await Delete<DetalleCompra>(id);
        }
    }
}
