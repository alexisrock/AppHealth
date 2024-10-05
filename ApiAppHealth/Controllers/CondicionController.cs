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


        /// <summary>
        /// Metodo para que el usuario guarde todas sus condiciones medicas
        /// </summary>
        [HttpPost, Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> CreateCondiciones([FromBody] ConditionsUsuario request)
        {
            try
            {
                var response = await _sender.Send(request);

                if (response.statusCode == 200)
                    return Ok(response);

                return BadRequest(response);
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }


        /// <summary>
        /// Metodo para que el usuario elimine todas sus condiciones medicas 
        /// </summary>
        [HttpDelete, Route("[action]/{idUsuario}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> Delete(int idUsuario)
        {
            try
            {
                var response = await _sender.Send(new ConditionsIdUsuario()
                {
                    IdUsuario = idUsuario
                });

                if (response.statusCode == 200)
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
