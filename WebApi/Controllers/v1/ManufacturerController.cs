using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Application.Features.Manufacturers.Commands.UpdateManufacturer;
using Application.Features.Manufacturers.Commands.CreateManufacturer;
using Application.Features.Manufacturers.Queries.GetManufacturerById;
using Application.Features.Manufacturers.Queries.GetAllManufacturers;
using Application.Features.Manufacturers.Commands.DeleteManufacturerById;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ManufacturerController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllManufacturersParameter filter)
        {
          
            return Ok(await Mediator.Send(new GetAllManufacturersQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber  }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetManufacturerByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        //[Authorize(Roles= "Moderator,SuperAdmin,Admin")]
        [Authorize]
        public async Task<IActionResult> Post(CreateManufacturerCommand command)
        {
            return Ok(await Mediator.Send(command));
        }   

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateManufacturerCommand command)
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
            return Ok(await Mediator.Send(new DeleteManufacturerByIdCommand { Id = id }));
        }
    }
}
