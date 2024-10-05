using DataAccess.Interface;
using Domain.Commonds;
using Domain.Dtos.Request;
using Domain.Entities;
using MediatR;

namespace Core.Service
{
    public class CondicionUsuarioDeleteHandler : IRequestHandler<ConditionsIdUsuario, BaseResponse>
    {
        private readonly IDataAccess<Conditions> conditionsAccess;

        public CondicionUsuarioDeleteHandler(IDataAccess<Conditions> conditionsAccess)
        {
            this.conditionsAccess = conditionsAccess;
        }

        public async Task<BaseResponse> Handle(ConditionsIdUsuario request, CancellationToken cancellationToken)
        {
            BaseResponse response;
            try
            {

                var condicionsUsers = await conditionsAccess.GetListByParam(x => x.IdUsuario == request.IdUsuario);
                await conditionsAccess.DeleteRange(condicionsUsers.ToArray());
                response = BaseResponseMapper.MapperBaseRespone(200, "Condiciones eliminadas con exito");
            }
            catch (Exception ex)
            {
                response = BaseResponseMapper.MapperBaseRespone(500, ex.Message);
            }
            return response;
        }
    }
}
