using Microsoft.AspNetCore.Http;
using System.Net.Http.Json;

namespace TryNewWebProj.Frontend.Services
{
    public class TranslateService
    {
        private readonly HttpClient httpClient;

        public TranslateService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<List<string>> GetSinonim(string wordvalue)
        {
            var q = await httpClient.GetAsync($"Translate/GetWordSinonim/{wordvalue}");
            if (((int)q.StatusCode) == StatusCodes.Status404NotFound)
            {
                return null;
            }
            return await q.Content.ReadFromJsonAsync<List<string>>();
        }

        public async Task<string> GetTranslate(string wordvalue)
        {
            var q = await httpClient.GetAsync($"GetTranslate/{wordvalue}/en/ru");

            if (((int)q.StatusCode) == StatusCodes.Status404NotFound)
            {
                return null;
            }
            return await q.Content.ReadAsStringAsync();
        }
    }
}
