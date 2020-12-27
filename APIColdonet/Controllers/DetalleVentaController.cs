using APIColdonet.DTOs;
using APIColdonet.DTOs.DetalleVentas;
using APIColdonet.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.Controllers {
    [ApiController]
    [Route("api/detalleventas")]
    public class DetalleVentaController:CustomBaseController {
        public DetalleVentaController(ColdonetDBContext context, IMapper mapper) : base(context, mapper) {
        }

        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<DetalleVentaDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO) {
            return await Get<DetalleVentum, DetalleVentaDTO>(paginacionDTO);
        }

        //Metodo Get(id)
        [HttpGet("{id:int}", Name = "obtenerDetalleVenta")]
        public async Task<ActionResult<DetalleVentaDTO>> Get(int id) {
            return await Get<DetalleVentum, DetalleVentaDTO>(id);
        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DetalleVentaCreacionDTO ventaCreacionDTO) {
            return await Post<DetalleVentaCreacionDTO, DetalleVentum, DetalleVentaDTO>(ventaCreacionDTO, "obtenerDetalleVenta");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] DetalleVentaCreacionDTO ventaCreacionDTO) {
            return await Put<DetalleVentaCreacionDTO, DetalleVentum>(id, ventaCreacionDTO);
        }

        //Metodo Patch
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) {
            return await Delete<DetalleVentum>(id);
        }
    }
}
