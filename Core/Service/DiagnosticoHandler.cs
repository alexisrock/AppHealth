using Core.Interface;
using Domain.Commonds;
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
    public class DiagnosticoHandler : IRequestHandler<DiagnosisRequest, DiagnosisResponse>
    {

        private readonly IInfermedicaIntegration infermedicaIntegration;
        public DiagnosticoHandler(IInfermedicaIntegration _infermedicaIntegration)
        {
            infermedicaIntegration = _infermedicaIntegration;
        }
        public async Task<DiagnosisResponse> Handle(DiagnosisRequest request, CancellationToken cancellationToken)
        {

            var Response = new DiagnosisResponse();
            try
            {
                Response = await infermedicaIntegration.Diagnostico(request);
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
