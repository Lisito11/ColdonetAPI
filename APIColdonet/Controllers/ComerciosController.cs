using APIColdonet.DTOs;
using APIColdonet.DTOs.Comercios;
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
    [Route("api/comercios")]
    public class ComerciosController : CustomBaseController {
        private readonly ColdonetDBContext context;
        private readonly IMapper mapper;
        private readonly IAlmacenadorArchivos almacenadorArchivos;
        private readonly string contenedor = "comercios";

        public ComerciosController(ColdonetDBContext context, IMapper mapper, IAlmacenadorArchivos almacenadorArchivos) : base(context, mapper) {
            this.context = context;
            this.mapper = mapper;
            this.almacenadorArchivos = almacenadorArchivos;
        }
        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<ComercioDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO) {
            return await Get<Usuario, ComercioDTO>(paginacionDTO);
        }

        //Metodo Get(id)
        [HttpGet("{id:int}", Name = "obtenerComercio")]
        public async Task<ActionResult<ComercioDTO>> Get(int id) {
            return await Get<Usuario, ComercioDTO>(id);
        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ComercioCreacionDTO comercioCreacionDTO) {
            return await Post<ComercioCreacionDTO, Usuario, ComercioDTO>(comercioCreacionDTO,"obtenerComercio");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ComercioCreacionDTO comercioCreacionDTO) {
            return await Put<ComercioCreacionDTO, Usuario>(id, comercioCreacionDTO);
        }

        //Metodo Patch
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) {
            return await Delete<Usuario>(id);
        }




    }
}
