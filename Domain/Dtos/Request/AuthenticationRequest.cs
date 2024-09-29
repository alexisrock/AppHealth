using Domain.Commonds;
using Domain.Dtos.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Request
{
    public class AuthenticationRequest
    {

        public string? Correo { get; set; }
        public string? Password { get; set; }

    }

    public class AuthenticationRequestMethod : IRequest<AuthenticationResponse>
    {

        public string? Correo { get; set; }
        public string? Password { get; set; }
        public Method Method { get; set; }

    }
}
