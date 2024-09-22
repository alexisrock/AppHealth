
using AutoMapper;
using Domain.Dtos.Request;
using Domain.Dtos.Response;
using Domain.Entities;

namespace Core.Profiles
{
    public class PersonaAdressProfile: Profile
    {

        public PersonaAdressProfile()
        {
            CreateMap<PersonAddressResponse, PersonAddress>()
             .ReverseMap();

            CreateMap<PersonAddressCreateRequest, PersonAddress>()
            .ReverseMap();
        }
    }
}
