using ApiAppHealth.Helpers;
using Domain.Dtos.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiAppHealth.Controllers
{
    /// <summary>
    /// Controlador de Sintomas
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SintomasController : ControllerBase
    {
        private readonly ISender _sender;

        /// <summary>
        /// Constructor
        /// </summary>
        public SintomasController(ISender _sender)
        {
            this._sender = _sender;

        }


        /// <summary>
        /// Metodo de obtener cualquier condicionar que pueda tener la persona   
        /// </summary>
        [HttpGet, Route("[action]/{edad}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> GetSintomas(int edad)
        {
            try
            {
                var response = await _sender.Send(new UsuarioEdadSintomasReqeuest()
                {
                    Edad = edad
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





        /// <summary>
        /// Metodo para que el usuario guarde todos sus simtomas 
        /// </summary>
        [HttpPost, Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> CreateSintomas([FromBody]SintomasUsuario request)
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
        /// Metodo para que el usuario guarde todos sus simtomas 
        /// </summary>
        [HttpDelete, Route("[action]/{idUsuario}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> DeleteSintomas(int idUsuario)
        {
            try
            {
                var response = await _sender.Send(new SintomasIdUsuario() {
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
