using Domain.Commonds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Response
{
    public class DiagnosisResponse: BaseResponse
    {
        public DiagnosisQuestionResponse? question { get; set; }
        public List<DiagnosisConditionResponse>? conditions { get; set; }
        public DiagnosisExtrasResponse? extras { get; set; }
        public bool has_emergency_evidence { get; set; }
        public bool should_stop { get; set; }
        public string? interview_token { get; set; }
    }


    public class DiagnosisChoiceResponse
    {
        public string? id { get; set; }
        public string? label { get; set; }
    }

    public class DiagnosisConditionResponse
    {
        public string? id { get; set; }
        public string? name { get; set; }
        public string? common_name { get; set; }
        public double probability { get; set; }
    }

    public class DiagnosisExtrasResponse
    {
    }

    public class DiagnosisItemResponse
    {
        public string? ìd { get; set; }
        public string? name { get; set; }
        public List<DiagnosisChoiceResponse>? choices { get; set; }
    }

    public class DiagnosisQuestionResponse
    {
        public string? type { get; set; }
        public string? text { get; set; }
        public List<DiagnosisItemResponse>? items { get; set; }
        public DiagnosisExtrasResponse? extras { get; set; }
    }
}
