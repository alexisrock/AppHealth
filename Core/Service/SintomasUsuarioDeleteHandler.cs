using DataAccess.Interface;
using Domain.Commonds;
using Domain.Dtos.Request; 
using Domain.Entities;
using MediatR;
 

namespace Core.Service
{
    public class SintomasUsuarioDeleteHandler : IRequestHandler<SintomasIdUsuario, BaseResponse>
    {

        private readonly IDataAccess<Symptoms> symptomsAccess;

        public SintomasUsuarioDeleteHandler(IDataAccess<Symptoms> _symptomsAccess)
        {
            symptomsAccess = _symptomsAccess;
        }

        public async Task<BaseResponse> Handle(SintomasIdUsuario request, CancellationToken cancellationToken)
        {
            BaseResponse response;
            try
            {

                var sintomasUsers = await symptomsAccess.GetListByParam(x => x.IdUsuario== request.IdUsuario);
                await symptomsAccess.DeleteRange(sintomasUsers.ToArray());
                response = BaseResponseMapper.MapperBaseRespone(200, "Sintomas eliminados con exito");
            }
            catch (Exception ex)
            {
                response = BaseResponseMapper.MapperBaseRespone(500, ex.Message);
            }
            return response;
        }
    }
}
