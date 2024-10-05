using ApiAppHealth.Helpers;
using Domain.Dtos.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAppHealth.Controllers
{
    /// <summary>
    /// Controlador de diagnostico
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DiagnosticoController : ControllerBase
    {


        private readonly ISender _sender;

        /// <summary>
        /// Constructor
        /// </summary>
        public DiagnosticoController(ISender _sender)
        {
            this._sender = _sender;

        }



        /// <summary>
        /// Metodo para que el usuario realize el diagnostico
        [HttpPost, Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> Diagnosticar([FromBody] DiagnosisRequest request)
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

    }
}
