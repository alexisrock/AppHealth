using Domain.Commonds;
using Domain.Dtos.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Request;

    public class DiagnosisRequest : IRequest<DiagnosisResponse>
    {
        public string? sex { get; set; }
        public Age? age { get; set; }
        public List<DiagnosisEvidence>? evidence { get; set; }
        public List<DiagnosisConditionRequest>? conditions { get; set; }
    }


    public class Age
    {
        public int value { get; set; }
    }

    public class DiagnosisConditionRequest
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? common_name { get; set; }
        public double probability { get; set; }
    }

    public class DiagnosisEvidence
    {
        public string? id { get; set; }
        public string? choice_id { get; set; }
        public string? source { get; set; }

    }
