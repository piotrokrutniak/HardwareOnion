using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Features.OrderItems.Commands.DeleteOrderItemById;
using Application.Features.Orders.Commands.CreateOrder;
using Application.Features.Orders.Commands.UpdateOrder;
using Application.Features.Orders.Queries.GetAllOrders;
using Application.Features.Orders.Queries.GetOrderById;
using Application.Features.Orders.Queries.GetUserBasket;
using Application.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class OrderController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllOrdersParameter filter)
        {
          
            return Ok(await Mediator.Send(new GetAllOrdersQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber, OrderBy = filter.OrderBy ?? "Default"  }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetOrderByIdQuery { Id = id }));
        }

        [HttpGet("GetBasket/{email}")]
        public async Task<IActionResult> Get(string email)
        {
            return Ok(await Mediator.Send(new GetUserBasketQuery { UserEmail = email }));
        }



        // POST api/<controller>
        [HttpPost]
        //[Authorize(Roles= "Moderator,SuperAdmin,Admin")]
        //[Authorize]
        public async Task<IActionResult> Post(CreateOrderCommand command)
        {
            return Ok(await Mediator.Send(command));
        }   

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateOrderCommand command)
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
