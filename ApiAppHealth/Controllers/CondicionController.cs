using ApiAppHealth.Helpers;
using Domain.Dtos.Request; 
using MediatR;
using Microsoft.AspNetCore.Mvc;
 

namespace ApiMediator.Controllers
{
    /// <summary>
    /// Controlador de Condicion
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CondicionController : ControllerBase
    {
        private readonly ISender _sender;

        /// <summary>
        /// Constructor
        /// </summary>
        public CondicionController(ISender _sender)
        {
            this._sender = _sender;

        }


        /// <summary>
        /// Metodo de obtener todos los sintomas      
        /// </summary>


        [HttpGet, Route("[action]/{edad}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> GetCondiciones(int edad)
        {
            try
            {
                var response = await _sender.Send(new UsuarioEdadRequest()
                {
                    Edad = edad
                });


                if(response.statusCode == 200)
                    return Ok(response);

                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }



       

    }
}
