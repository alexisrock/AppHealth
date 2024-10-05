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

    public class ConditionsUsuario : IRequest<BaseResponse>
    {
        public List<ConditionsRequest>? Conditions { get; set; }
    }
    public class ConditionsRequest
    {
        public int IdUsuario { get; set; }       
        public string? IdCondicion { get; set; }
        public string? Nombre { get; set; }
        public string? Categoria { get; set; }
        public string? Severidad { get; set; }

    }
    public class ConditionsIdUsuario : IRequest<BaseResponse>
    {
        public int IdUsuario { get; set; }
    }
}
