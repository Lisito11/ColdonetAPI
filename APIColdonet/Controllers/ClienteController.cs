using APIColdonet.DTOs;
using APIColdonet.DTOs.Clientes;
using APIColdonet.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.Controllers {
    [ApiController]
    [Route("api/clientes")]
    public class ClienteController:CustomBaseController {
        public ClienteController(ColdonetDBContext context, IMapper mapper) : base(context, mapper) {
        }

        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<ClienteDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO) {
            return await Get<Cliente, ClienteDTO>(paginacionDTO);
        }

        //Metodo Get(id)
        [HttpGet("{id:int}", Name = "obtenerCliente")]
        public async Task<ActionResult<ClienteDTO>> Get(int id) {
            return await Get<Cliente, ClienteDTO>(id);
        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ClienteCreacionDTO clienteCreacionDTO) {
            return await Post<ClienteCreacionDTO, Cliente, ClienteDTO>(clienteCreacionDTO, "obtenerCliente");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ClienteCreacionDTO clienteCreacionDTO) {
            return await Put<ClienteCreacionDTO, Cliente>(id, clienteCreacionDTO);
        }

        //Metodo Patch
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) {
            return await Delete<Cliente>(id);
        }
    }
}
