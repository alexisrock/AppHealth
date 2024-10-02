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
    public class SymptomsProfile : Profile
    {

        public SymptomsProfile()
        {
            CreateMap<Symptoms, SymptomsRequest>()
               .ReverseMap();
        }
    }
}
