using APIColdonet.DTOs;
using APIColdonet.DTOs.Productos;
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
    [Route("api/productos")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class ProductoController:CustomBaseController {
        public ProductoController(ColdonetDBContext context, IMapper mapper) : base(context, mapper) {
        }

        //Metodo Get
        [HttpGet]
        public async Task<ActionResult<List<ProductoDTO>>> Get([FromQuery] PaginacionDTO paginacionDTO) {
            return await Get<Producto, ProductoDTO>(paginacionDTO);
        }

        //Metodo Get(id)
        [HttpGet("{id:int}", Name = "obtenerProducto")]
        public async Task<ActionResult<ProductoDTO>> Get(int id) {
            return await Get<Producto, ProductoDTO>(id);
        }

        //Metodo Post
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductoCreacionDTO productoCreacionDTO) {
            return await Post<ProductoCreacionDTO, Producto, ProductoDTO>(productoCreacionDTO, "obtenerProducto");
        }

        //Metodo Put
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductoCreacionDTO productoCreacionDTO) {
            return await Put<ProductoCreacionDTO, Producto>(id, productoCreacionDTO);
        }

        //Metodo Patch
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) {
            return await Delete<Producto>(id);
        }
    }
}
