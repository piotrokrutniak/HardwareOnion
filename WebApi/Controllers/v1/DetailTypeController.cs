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
using Application.Features.DetailTypes.Queries.GetAllDetailTypes;
using Application.Features.DetailTypes.Queries.GetDetailTypeById;
using Application.Features.DetailTypes.Commands.CreateDetailType;
using Application.Features.DetailTypes.Commands.UpdateDetailType;
using Application.Features.DetailTypes.Commands.DeleteDetailTypeById;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class DetailTypeController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllDetailTypesParameter filter)
        {
          
            return Ok(await Mediator.Send(new GetAllDetailTypesQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber  }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetDetailTypeByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        //[Authorize(Roles= "Moderator,SuperAdmin,Admin")]
        [Authorize]
        public async Task<IActionResult> Post(CreateDetailTypeCommand command)
        {
            return Ok(await Mediator.Send(command));
        }   

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateDetailTypeCommand command)
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
            return Ok(await Mediator.Send(new DeleteDetailTypeByIdCommand { Id = id }));
        }
    }
}
