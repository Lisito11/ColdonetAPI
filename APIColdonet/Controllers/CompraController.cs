using APIColdonet.DTOs;
using APIColdonet.DTOs.Compras;
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
    [Route("api/compras")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class CompraController:CustomBaseController {
        public CompraController(ColdonetDBContext context, IMapper mapper) : base(context, mapper) {
        }

        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<CompraDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO) {
            return await Get<Compra, CompraDTO>(paginacionDTO);
        }

        //Metodo Get(id)
        [HttpGet("{id:int}", Name = "obtenerCompra")]
        public async Task<ActionResult<CompraDTO>> Get(int id) {
            return await Get<Compra, CompraDTO>(id);
        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CompraCreacionDTO compraCreacionDTO) {
            return await Post<CompraCreacionDTO, Compra, CompraDTO>(compraCreacionDTO, "obtenerCompra");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CompraCreacionDTO compraCreacionDTO) {
            return await Put<CompraCreacionDTO, Compra>(id, compraCreacionDTO);
        }

        //Metodo Patch
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) {
            return await Delete<Compra>(id);
        }
    }
}
