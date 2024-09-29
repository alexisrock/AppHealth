using Domain.Commonds;
using MediatR;


namespace Domain.Dtos.Request
{
    public class UsuarioAuthenticationRequest: IRequest<BaseResponse>
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? Celular { get; set; }
        public string? Correo { get; set; }
        public string? Edad { get; set; }
        public string? Genero { get; set; }
        public string? Contrasena { get; set; } 
        public Method Method { get; set; }

    }



    public class UsuarioRequest
    {
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? Celular { get; set; }
        public string? Correo { get; set; }
        public string? Edad { get; set; }
        public string? Genero { get; set; }
        public string? Contrasena { get; set; }

    }


    public class UsuarioUpdateRequest
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? Celular { get; set; }
        public string? Correo { get; set; }
        public string? Edad { get; set; }
        public string? Genero { get; set; }
        public string? Contrasena { get; set; }

    }
}
