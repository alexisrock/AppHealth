using Domain.Dtos.Request;
using Domain.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface
{
    public interface IInfermedicaIntegration
    {
        public Task<ConditionsResponse> Condiciones(int edad);
        public Task<SintomasResponse> Sintomas(int edad);
        public Task<DiagnosisResponse> Diagnostico(DiagnosisRequest request);
    }
}
