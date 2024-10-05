using AutoMapper;
using Domain.Dtos.Request;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Profiles
{
    public class ConditionsProfile : Profile
    {


        public ConditionsProfile() {

            CreateMap<Conditions, ConditionsRequest>()
              .ReverseMap();



        }
    }
}
