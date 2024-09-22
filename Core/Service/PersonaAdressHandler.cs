using AutoMapper;
using DataAccess.Interface;
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
    public class PersonaAdressHandler: IRequestHandler<PersonaAdressRequest, List<PersonAddressResponse>>
    {
        private readonly IDataAccess<PersonAddress> dataAccess;
        private readonly IMapper mapper;
        public PersonaAdressHandler(IDataAccess<PersonAddress> dataAccess, IMapper mapper)
        {
            this.dataAccess = dataAccess;
            this.mapper = mapper;
                
        }


       public  async Task<List<PersonAddressResponse>> Handle(PersonaAdressRequest request, CancellationToken cancellationToken)
        {
            var listResponse = new List<PersonAddressResponse>();

            try
            {
                var personasAddressList = await dataAccess.GetListByParam(x => x.AddressID == request.AddressID );
                personasAddressList.ForEach(item =>
                {
                    var response = mapper.Map<PersonAddressResponse>(item);
                    listResponse.Add(response);
                });

;            }
            catch (Exception)
            {
                listResponse = null;
            }

            return listResponse;

        }
    }
}
