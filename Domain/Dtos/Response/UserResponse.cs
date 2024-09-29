using Domain.Commonds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Response
{
    public class UserResponse: BaseResponse
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public string? Celular { get; set; }
        public string? Correo { get; set; }
        public string? Edad { get; set; }
        public string? Genero { get; set; }
    }
}
