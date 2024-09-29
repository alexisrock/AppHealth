
using AutoMapper;
using Domain.Dtos.Request;
using Domain.Dtos.Response;
using Domain.Entities;

namespace Core.Profiles
{
    public class UsersProfile: Profile
    {

        public UsersProfile()
        {


            CreateMap<Users, UsuarioAuthenticationRequest>()
                .ReverseMap();
            CreateMap<Users, UserResponse>()
               .ReverseMap();
        }
    }
}
