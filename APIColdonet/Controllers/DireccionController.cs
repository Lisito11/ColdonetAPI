using APIColdonet.DTOs;
using APIColdonet.DTOs.Direcciones;
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
    [Route("api/direcciones")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class DireccionController:CustomBaseController {
        public DireccionController(ColdonetDBContext context, IMapper mapper) : base(context, mapper) {
        }

        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<DireccionDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO) {
            return await Get<Direccion, DireccionDTO>(paginacionDTO);
        }

        //Metodo Get(id)
        [HttpGet("{id:int}", Name = "obtenerDireccion")]
        public async Task<ActionResult<DireccionDTO>> Get(int id) {
            return await Get<Direccion, DireccionDTO>(id);
        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DireccionCreacionDTO tipocomercioCreacionDTO) {
            return await Post<DireccionCreacionDTO, Direccion, DireccionDTO>(tipocomercioCreacionDTO, "obtenerTipoComercio");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] DireccionCreacionDTO tipocomercioCreacionDTO) {
            return await Put<DireccionCreacionDTO, Direccion>(id, tipocomercioCreacionDTO);
        }

        //Metodo Patch
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) {
            return await Delete<Direccion>(id);
        }

    }
}
