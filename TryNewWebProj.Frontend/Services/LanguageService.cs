using Blazored.SessionStorage;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using TryNewWebProj.Frontend.Data.Models;

namespace TryNewWebProj.Frontend.Services
{
    public class LanguageService
    {
        private readonly HttpClient httpClient;
        private readonly ISessionStorageService sessionStorage;

        public LanguageService(HttpClient httpClient, ISessionStorageService sessionStorage)
        {
            this.httpClient = httpClient;
            this.sessionStorage = sessionStorage;
        }

        public async Task GetToken()
        {
            string responseString = await sessionStorage.GetItemAsync<string>("oidc.user:https://localhost:7203:word-web-app");
            dynamic data = JObject.Parse(responseString);
            string val = data.access_token;
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", val);
        }

        public async Task<LanguageListVm> GetAllLanguages()
        {
            await GetToken();
            Console.WriteLine(await httpClient.GetStringAsync("1.0/Language"));
            return await httpClient.GetFromJsonAsync<LanguageListVm>("1.0/Language");
        }

        public async Task DeleteLanguage(Guid id)
        {
            await GetToken();
            await httpClient.DeleteAsync($"1.0/Language/{id}");
        }

        public async Task CreateLanguage(LanguageVm languageVm)
        {
            await GetToken();
            await httpClient.PostAsJsonAsync("1.0/Language", languageVm);
        }

        public async Task<LanguageVm> GetLanguageById(int id)
        {
            await GetToken();
            return await httpClient.GetFromJsonAsync<LanguageVm>($"1.0/Language/{id}");
        }
    }
}
