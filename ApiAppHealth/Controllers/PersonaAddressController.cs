using Domain.Dtos.Request;
using Domain.Dtos.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;

namespace ApiMediator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaAddressController : ControllerBase
    {
        private readonly ISender _sender;

        public PersonaAddressController(ISender _sender)
        {
            this._sender = _sender;

        }

        [HttpGet, Route("[action]/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> GetById(string id)

        {
            try
            {
                var list = await _sender.Send(new PersonaAdressRequest()
                {
                    AddressID = id
                });

                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }



        [HttpPost, Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> Create([FromBody] PersonAddressCreateRequest personAddressCreateRequest)
        {
            try
            {
                var personaAddrs = await _sender.Send(personAddressCreateRequest);
                if (personaAddrs is not null)
                    return Ok(personaAddrs);
                else return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

    }
}
