using AutoMapper;
using Core.Interface;
using DataAccess.Interface;
using Domain.Dtos.Request;
using Domain.Dtos.Response;
using Domain.Entities;
using MediatR;


namespace Core.Service
{
    public class CondicionHandler : IRequestHandler<UsuarioEdadRequest, ConditionsResponse>
    {
        private readonly IInfermedicaIntegration infermedicaIntegration;
        public CondicionHandler(IInfermedicaIntegration _infermedicaIntegration)
        {
            infermedicaIntegration = _infermedicaIntegration;
        }


        public async Task<ConditionsResponse> Handle(UsuarioEdadRequest request, CancellationToken cancellationToken)
        {
            var Response = new ConditionsResponse();
            try
            {
                Response = await infermedicaIntegration.Condiciones(request.Edad);
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
