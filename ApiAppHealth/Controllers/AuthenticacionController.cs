using Domain.Dtos.Request;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAppHealth.Controllers
{
    /// <summary>
    /// Controlador de Condicion
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticacionController : ControllerBase
    {

        private readonly ISender _sender;

        /// <summary>
        /// Constructor
        /// </summary>
        public AuthenticacionController(ISender _sender)
        {
            this._sender = _sender;
        }



        /// <summary>
        /// Metodo de crear el usuario     
        /// </summary>

        [HttpPost, Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> Create([FromBody] UsuarioRequest user)
        {
            try
            {
                var response = await _sender.Send(new UsuarioAuthenticationRequest()
                {
                    Edad = user.Edad,
                    Nombre = user.Nombre,
                    Apellidos = user.Apellidos,
                    Celular = user.Celular,
                    Contrasena = user.Contrasena,
                    Correo = user.Correo,
                    Genero = user.Genero,
                    Method = Domain.Commonds.Method.Create
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
        /// Metodo de crear el usuario     
        /// </summary>

        [HttpPost, Route("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> Authentication([FromBody] AuthenticationRequest user)
        {
            try
            {
                var response = await _sender.Send(new AuthenticationRequestMethod()
                {
                    Correo = user.Correo,
                    Password = user.Password,
                    Method = Domain.Commonds.Method.Create
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
