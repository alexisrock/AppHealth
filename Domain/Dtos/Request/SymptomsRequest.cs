using Domain.Commonds;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Request
{
    public class SintomasUsuario : IRequest<BaseResponse>
    {
        public List<SymptomsRequest>? Symstoms { get; set; }
    }

    public class SymptomsRequest 
    {
        public int IdUsuario { get; set; }        
        public string? IdSintoma { get; set; }
        public string? Choise { get; set; }
        public string? Source { get; set; }
        public DateTime? observed_at { get; set; }

    }

    public class SintomasIdUsuario : IRequest<BaseResponse>
    {
        public int IdUsuario { get; set; }
    }

}
