using Core.Interface;
using Domain.Dtos.Request;
using Domain.Dtos.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public class SintomasHandler : IRequestHandler<UsuarioEdadSintomasReqeuest, SintomasResponse>
    {
        private readonly IInfermedicaIntegration infermedicaIntegration;
        public SintomasHandler(IInfermedicaIntegration _infermedicaIntegration)
        {
            infermedicaIntegration = _infermedicaIntegration;
        }


        public async Task<SintomasResponse> Handle(UsuarioEdadSintomasReqeuest request, CancellationToken cancellationToken)
        {
            var Response = new SintomasResponse();
            try
            {
                Response = await infermedicaIntegration.Sintomas(request.Edad);                
            }
            catch (Exception ex)
            {
                Response!.statusCode = Response.statusCode;
                Response.message = ex.InnerException!.Message ?? ex.Message;
            }
            return Response;
        }

    }
}
