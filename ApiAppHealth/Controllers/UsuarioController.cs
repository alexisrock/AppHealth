using ApiAppHealth.Helpers;
using Domain.Dtos.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ApiAppHealth.Controllers
{
    /// <summary>
    /// Controlador de Condicion
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly ISender _sender;

        /// <summary>
        /// Constructor
        /// </summary>
        public UsuarioController(ISender _sender)
        {
            this._sender = _sender;
        }

      
        /// <summary>
        /// Metodo de actualizar informacion del usuario     
        /// </summary>

        [HttpPut, Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> Update([FromBody] UsuarioUpdateRequest user)

        {
            try
            {
                var response = await _sender.Send(new UsuarioAuthenticationRequest()
                {
                    Id = user.Id,
                    Edad = user.Edad,
                    Nombre = user.Nombre,
                    Apellidos = user.Apellidos,
                    Celular = user.Celular,
                    Contrasena = user.Contrasena,
                    Correo = user.Correo,
                    Genero = user.Genero,
                    Method = Domain.Commonds.Method.Update
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
        /// Metodo de seleccionar informacion del usuario por el correo  
        /// </summary>

        [HttpGet, Route("[action]/{email}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> GetUserByEmail( string email)

        {
            try
            {
                var response = await _sender.Send(new AuthenticationRequestMethod()
                {
                   
                    Correo = email,
                    Password = "",
                    Method = Domain.Commonds.Method.SelectByEmail
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
