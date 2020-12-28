using APIColdonet.DTOs;
using APIColdonet.DTOs.SubCategorias;
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
    [Route("api/subcategorias")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class SubCategoriaController:CustomBaseController {
        public SubCategoriaController(ColdonetDBContext context, IMapper mapper) : base(context, mapper) {
        }

        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<SubCategoriaDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO) {
            return await Get<SubCategorium, SubCategoriaDTO>(paginacionDTO);
        }

        //Metodo Get(id)
        [HttpGet("{id:int}", Name = "obtenerSubCategoria")]
        public async Task<ActionResult<SubCategoriaDTO>> Get(int id) {
            return await Get<SubCategorium, SubCategoriaDTO>(id);
        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] SubCategoriaCreacionDTO subCategoriaCreacionDTO) {
            return await Post<SubCategoriaCreacionDTO, SubCategorium, SubCategoriaDTO>(subCategoriaCreacionDTO, "obtenerSubCategoria");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] SubCategoriaCreacionDTO categoriaCreacionDTO) {
            return await Put<SubCategoriaCreacionDTO, SubCategorium>(id, categoriaCreacionDTO);
        }

        //Metodo Patch
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) {
            return await Delete<SubCategorium>(id);
        }
    }
}
