using Domain.Commonds;
using Domain.Dtos.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Request
{
    public class UsuarioEdadRequest: IRequest<ConditionsResponse>
    { 
        public int Edad { get; set; }
    }


    public class UsuarioEdadSintomasReqeuest: IRequest<SintomasResponse> 
    {
        public int Edad { get; set; }
    }



}
