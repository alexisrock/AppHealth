using Domain.Commonds;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Response
{
    public class AuthenticationResponse: BaseResponse
    {
        public object? Result { get; set; }
    }
}
