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

namespace Core.Service;

public class PersonAdressCreateHandler : IRequestHandler<PersonAddressCreateRequest, PersonAddressResponse>
{
    private readonly IDataAccess<PersonAddress> dataAccess;
    private readonly IMapper mapper;
    public PersonAdressCreateHandler(IDataAccess<PersonAddress> dataAccess, IMapper mapper)
    {
        this.dataAccess = dataAccess;
        this.mapper = mapper;

    }


    public async Task<PersonAddressResponse> Handle(PersonAddressCreateRequest request, CancellationToken cancellationToken)
    {
        var  response = new PersonAddressResponse();
        try
        {
            var personaAddress = mapper.Map<PersonAddress>(request);
            var personasA = await dataAccess.CrearAsync(personaAddress);
            response = mapper.Map<PersonAddressResponse>(personasA);           
        }
        catch (Exception ex)
        {
            response = null;
        }

        return response;

    }


}
