using Core.Interface;
using DataAccess.Interface;
using Domain.Dtos.Request;
using Domain.Dtos.Response;
using Domain.Entities;
using System.Text.Json;


namespace Core.Integration
{
    public class InfermedicaIntegration : BaseIntegration, IInfermedicaIntegration
    {
        public InfermedicaIntegration(IDataAccess<Settings> settingDA) : base(settingDA)
        {
        }

      
       public  async Task<ConditionsResponse> Condiciones(int edad)
        {
            var conditionResponse = new ConditionsResponse();   
            string url = $"https://api.infermedica.com/v3/conditions?age.value={edad}&age.unit=year&enable_triage_3=false";
            var response = await ExecGetAsync(url);
          
            if (response is not null && response.StatusCode == System.Net.HttpStatusCode.OK )
            {
                conditionResponse.conditions = await JsonSerializer.DeserializeAsync<List<ConditionResponse>>(await response.Content.ReadAsStreamAsync());               
            }
           
            conditionResponse.statusCode = (int) response!.StatusCode;
            return conditionResponse;
        }


        public async Task<SintomasResponse> Sintomas(int edad)
        {
            var sintomasResponse = new SintomasResponse();
            string url = $"https://api.infermedica.com/v3/symptoms?age.value={edad}&age.unit=year&enable_triage_3=false";
            var response = await ExecGetAsync(url);

            if (response is not null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                sintomasResponse.sintomas = await JsonSerializer.DeserializeAsync<List<Sintomas>>(await response.Content.ReadAsStreamAsync());
            }

            sintomasResponse.statusCode = (int)response!.StatusCode;
            return sintomasResponse;
        }


        public async Task<DiagnosisResponse> Diagnostico(DiagnosisRequest request)
        {
            var diagnosticResponse = new DiagnosisResponse();
            string url = "https://api.infermedica.com/v3/diagnosis";

            var response = await ExecPostAsync(url, request);


            if (response is not null && response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                diagnosticResponse = await JsonSerializer.DeserializeAsync<DiagnosisResponse>(await response.Content.ReadAsStreamAsync());
               
            }

            diagnosticResponse!.statusCode = (int)response!.StatusCode;
            return diagnosticResponse;
        }


    }
}
