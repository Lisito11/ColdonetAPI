using APIColdonet.DTOs;
using APIColdonet.DTOs.TipoComercios;
using APIColdonet.Entities;
using APIColdonet.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.Controllers {
    [ApiController]
    [Route("api/tipocomercios")]
    public class TipoComercioController: CustomBaseController {
        public TipoComercioController(ColdonetDBContext context, IMapper mapper) : base(context, mapper) {
        }

        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<TipoComercioDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO) {
            return await Get<TipoComercio, TipoComercioDTO>(paginacionDTO);
        }

        //Metodo Get(id)
        [HttpGet("{id:int}", Name = "obtenerTipoComercio")]
        public async Task<ActionResult<TipoComercio>> Get(int id) {
            return await Get<TipoComercio, TipoComercio>(id);
        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TipoComercioCreacionDTO tipocomercioCreacionDTO) {
            return await Post<TipoComercioCreacionDTO, TipoComercio, TipoComercioDTO>(tipocomercioCreacionDTO, "obtenerTipoComercio");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] TipoComercioCreacionDTO tipocomercioCreacionDTO) {
            return await Put<TipoComercioCreacionDTO, TipoComercio>(id, tipocomercioCreacionDTO);
        }

        //Metodo Patch
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) {
            return await Delete<TipoComercio>(id);
        }



    }
}
