using DataAccess.Interface;
using Domain.Entities;
using System.Text.Json;


namespace Core.Integration
{
    public abstract class BaseIntegration
    {
        private readonly IDataAccess<Settings> settingDA;

        public BaseIntegration(IDataAccess<Settings> settingDA)
        {

            this.settingDA = settingDA;

        }

        internal async Task<HttpClient> Headers()
        {
            var _httpClient = new HttpClient();
            var appId = await settingDA.GetByParam(x => x.Id.Equals("App-Id"));
            var appKey = await settingDA.GetByParam(x => x.Id.Equals("App-Key"));
            var devMode = await settingDA.GetByParam(x => x.Id.Equals("Dev-Mode"));

            _httpClient.DefaultRequestHeaders.Add(appId!.Id, appId!.Value);
            _httpClient.DefaultRequestHeaders.Add(appKey!.Id, appKey!.Value);
            _httpClient.DefaultRequestHeaders.Add(devMode!.Id, devMode!.Value);
            return _httpClient;
        }

        internal async Task<HttpResponseMessage> ExecGetAsync(string url)
        {

            var httpClient = await Headers();
            var response = await httpClient.GetAsync(url);
            return response;


        }

        internal async Task<HttpResponseMessage> ExecPostAsync(string url, object body)
        {
            var httpClient = await Headers();
            var jsonContent = JsonSerializer.Serialize(body);
            var content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync(url, content);
            return response;
        }

    }
}
