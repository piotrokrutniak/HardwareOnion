using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.Products.Commands;
using Application.Features.Products.Commands.CreateProduct;
using Application.Features.Products.Commands.DeleteProductById;
using Application.Features.ProductTypes.Commands.DeleteProductTypeById;
using Application.Features.Products.Commands.UpdateProduct;
using Application.Features.Products.Queries.GetAllProducts;
using Application.Features.ProductTypes.Queries.GetAllProductTypes;
using Application.Features.Products.Queries.GetProductById;
using Application.Features.ProductTypes.Commands.CreateProductType;
using Application.Features.ProductTypes.Commands.UpdateProductType;
using Application.Features.ProductTypes.Queries.GetProductTypeById;
using Application.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductTypeController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductTypesParameter filter)
        {
          
            return Ok(await Mediator.Send(new GetAllProductTypesQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber  }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetProductTypeByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        //[Authorize(Roles= "Moderator,SuperAdmin,Admin")]
        [Authorize]
        public async Task<IActionResult> Post(CreateProductTypeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }   

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateProductTypeCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteProductTypeByIdCommand { Id = id }));
        }
    }
}
