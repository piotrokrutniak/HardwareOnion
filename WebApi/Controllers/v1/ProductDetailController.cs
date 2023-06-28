using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Features.ProductDetails.Commands.DeleteProductDetailById;
using Application.Features.ProductDetails.Queries.GetAllProductDetails;
using Application.Features.ProductDetails.Queries.GetProductDetailById;
using Application.Features.ProductDetails.Commands.CreateProductDetail;
using Application.Features.ProductDetails.Commands.UpdateProductDetail;
using Application.Features.ProductDetails.Queries.GetProductDetailsByProductId;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProductDetailController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProductDetailsParameter filter)
        {
            return Ok(await Mediator.Send(new GetAllProductDetailsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber  }));
        }

        // GET: api/<controller>
        [HttpGet("ByProductId")]
        public async Task<IActionResult> Get([FromQuery] GetAllProductDetailsByProductIdParameter filter)
        {
            return Ok(await Mediator.Send(new GetAllProductDetailsByProductIdQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber, ProductId = filter.ProductId }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetProductDetailsByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        //[Authorize(Roles= "Moderator,SuperAdmin,Admin")]
        [Authorize]
        public async Task<IActionResult> Post(CreateProductDetailCommand command)
        {
            return Ok(await Mediator.Send(command));
        }   

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateProductDetailCommand command)
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
            return Ok(await Mediator.Send(new DeleteProductDetailByIdCommand { Id = id }));
        }
    }
}
