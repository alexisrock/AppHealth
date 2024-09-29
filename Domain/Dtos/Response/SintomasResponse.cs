using Domain.Commonds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos.Response
{
    public class SintomasResponse: BaseResponse
    {
        public List<Sintomas>? sintomas { get; set; }
    }


    public class Sintomas
    {     
        public string? id { get; set; }
        public string? name { get; set; }
        public string? common_name { get; set; }
        public string? sex_filter { get; set; }
        public string? category { get; set; }
        public string? seriousness { get; set; }
        public object? extras { get; set; }
        public List<Child>? children { get; set; }
        public object? image_url { get; set; }
        public object? image_source { get; set; }
        public string? parent_id { get; set; }
        public string? parent_relation { get; set; }
    }


    public class Child
    {
        public string? id { get; set; }
        public string? parent_relation { get; set; }
    }
}
