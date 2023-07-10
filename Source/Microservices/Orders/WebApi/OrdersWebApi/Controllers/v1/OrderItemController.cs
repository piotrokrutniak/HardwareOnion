using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.OrderItems.Commands.CreateOrderItem;
using Application.Features.OrderItems.Commands.DeleteOrderItemById;
using Application.Features.OrderItems.Commands.UpdateOrderItem;
using Application.Features.OrderItems.Queries.GetAllOrderItem;
using Application.Features.OrderItems.Queries.GetOrderItemById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class OrderItemController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllOrderItemsParameter filter)
        {

            return Ok(await Mediator.Send(new GetAllOrderItemsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber}));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetOrderItemByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        //[Authorize(Roles= "Moderator,SuperAdmin,Admin")]
        [Authorize]
        public async Task<IActionResult> Post(CreateOrderItemCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateOrderItemCommand command)
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
            return Ok(await Mediator.Send(new DeleteOrderItemByIdCommand { Id = id }));
        }
    }
}
