using APIColdonet.DTOs;
using APIColdonet.DTOs.SubUsuarios;
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
    [Route("api/subusuarios")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class SubUsuarioController: CustomBaseController {
        public SubUsuarioController(ColdonetDBContext context, IMapper mapper) : base(context, mapper) {
        }

        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<SubUsuarioDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO) {
            return await Get<SubUsuario, SubUsuarioDTO>(paginacionDTO);
        }

        //Metodo Get(id)
        [HttpGet("{id:int}", Name = "obtenerSubUsuario")]
        public async Task<ActionResult<SubUsuarioDTO>> Get(int id) {
            return await Get<SubUsuario, SubUsuarioDTO>(id);
        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SubUsuarioCreacionDTO subusuarioCreacionDTO) {
            return await Post<SubUsuarioCreacionDTO, SubUsuario, SubUsuarioDTO>(subusuarioCreacionDTO, "obtenerSubUsuario");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] SubUsuarioCreacionDTO subusuarioCreacionDTO) {
            return await Put<SubUsuarioCreacionDTO, SubUsuario>(id, subusuarioCreacionDTO);
        }

        //Metodo Patch
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) {
            return await Delete<SubUsuario>(id);
        }


    }
}
