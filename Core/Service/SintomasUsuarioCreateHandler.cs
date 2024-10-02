using AutoMapper;
using DataAccess.Interface;
using Domain.Commonds;
using Domain.Dtos.Request;
using Domain.Entities;
using MediatR;

namespace Core.Service
{
    public class SintomasUsuarioCreateHandler : IRequestHandler<SintomasUsuario, BaseResponse>
    {
        private readonly IDataAccess<Symptoms> symptomsAccess;
        private readonly IMapper maper;


        public SintomasUsuarioCreateHandler(IDataAccess<Symptoms> symptomsAcces, IMapper _maper)
        {
            symptomsAccess = symptomsAcces;
            maper = _maper;
        }
        public async Task<BaseResponse> Handle(SintomasUsuario request, CancellationToken cancellationToken)
        {
            BaseResponse response;

            try
            {
                var simtomas = MapperSymptomsArray(request);
                await symptomsAccess.InsertReange(simtomas);
                response = MapperBaseRespone(200, "Sintomas ingresados con exito");
            }
            catch (Exception ex)
            {
                response = MapperBaseRespone(500, ex.Message);
            }

            return response;
        }

        private Symptoms[] MapperSymptomsArray(SintomasUsuario request)
        {

            Symptoms[] sintomas = new Symptoms[request.Symstoms!.Count];

            int i = 0;

            request.Symstoms.ForEach(item =>
            {
                var sintoma = maper.Map<Symptoms>(item);
                sintomas[i] = sintoma;
                i++;
            });

            return sintomas;
        }

        private BaseResponse MapperBaseRespone(int status, string message)
        {
            return new BaseResponse()
            {
                statusCode = status,
                message = message
            };
        }

    }
}
