using APIColdonet.DTOs;
using APIColdonet.DTOs.Categorias;
using APIColdonet.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.Controllers {
    [ApiController]
    [Route("api/categorias")]
    public class CategoriaController:CustomBaseController {
        public CategoriaController(ColdonetDBContext context, IMapper mapper) : base(context, mapper) {
        }

        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<CategoriaDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO) {
            return await Get<Categorium, CategoriaDTO>(paginacionDTO);
        }

        //Metodo Get(id)
        [HttpGet("{id:int}", Name = "obtenerCategoria")]
        public async Task<ActionResult<CategoriaDTO>> Get(int id) {
            return await Get<Categorium, CategoriaDTO>(id);
        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoriaCreacionDTO categoriaCreacionDTO) {
            return await Post<CategoriaCreacionDTO, Categorium, CategoriaDTO>(categoriaCreacionDTO, "obtenerCategoria");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] CategoriaCreacionDTO categoriaCreacionDTO) {
            return await Put<CategoriaCreacionDTO, Categorium>(id, categoriaCreacionDTO);
        }

        //Metodo Patch
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) {
            return await Delete<Categorium>(id);
        }
    }
}
