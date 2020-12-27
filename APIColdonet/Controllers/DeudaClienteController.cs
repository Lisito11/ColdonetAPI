using APIColdonet.DTOs;
using APIColdonet.DTOs.DeudaCliente;
using APIColdonet.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIColdonet.Controllers {
    [ApiController]
    [Route("api/deudaclientes")]
    public class DeudaClienteController: CustomBaseController {
        public DeudaClienteController(ColdonetDBContext context, IMapper mapper) : base(context, mapper) {
        }

        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<DeudaClienteDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO) {
            return await Get<DeudaCliente, DeudaClienteDTO>(paginacionDTO);
        }

        //Metodo Get(id)
        [HttpGet("{id:int}", Name = "obtenerDeudaCliente")]
        public async Task<ActionResult<DeudaClienteDTO>> Get(int id) {
            return await Get<DeudaCliente, DeudaClienteDTO>(id);
        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DeudaClienteCreacionDTO deudaClienteCreacionDTO) {
            return await Post<DeudaClienteCreacionDTO, DeudaCliente, DeudaClienteDTO>(deudaClienteCreacionDTO, "obtenerDeudaCliente");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] DeudaClienteCreacionDTO deudaClienteCreacionDTO) {
            return await Put<DeudaClienteCreacionDTO, DeudaCliente>(id, deudaClienteCreacionDTO);
        }

        //Metodo Patch
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) {
            return await Delete<DeudaCliente>(id);
        }
    }
}
