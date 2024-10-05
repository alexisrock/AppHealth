using AutoMapper;
using DataAccess.Interface;
using Domain.Commonds;
using Domain.Dtos.Request;
using Domain.Dtos.Response;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public class CondicionUsuarioCreateHandler : IRequestHandler<ConditionsUsuario, BaseResponse>
    {
        private readonly IDataAccess<Conditions> conditionsAccess;
        private readonly IMapper maper;

        public CondicionUsuarioCreateHandler(IDataAccess<Conditions> conditionsAccess, IMapper maper)
        {
            this.conditionsAccess = conditionsAccess;
            this.maper = maper;
        }

       

        
        public async Task<BaseResponse> Handle(ConditionsUsuario request, CancellationToken cancellationToken)
        {
            BaseResponse response;

            try
            {
                var conditions = MapperConditionsArray(request);
                await conditionsAccess.InsertRange(conditions);
                response = BaseResponseMapper.MapperBaseRespone(200, "Condiciones ingresadas con exito");
            }
            catch (Exception ex)
            {
                response = BaseResponseMapper.MapperBaseRespone(500, ex.Message);
            }

            return response;
        }

        private Conditions[] MapperConditionsArray(ConditionsUsuario request)
        {

            Conditions[] conditions = new Conditions[request.Conditions!.Count];

            int i = 0;

            request.Conditions.ForEach(item =>
            {
                var condition = maper.Map<Conditions>(item);
                conditions[i] = condition;
                i++;
            }); 

            return conditions;
        }


    }
}
