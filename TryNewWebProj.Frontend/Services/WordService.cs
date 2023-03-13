using Blazored.SessionStorage;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using TryNewWebProj.Frontend.Data.Models;

namespace TryNewWebProj.Frontend.Services
{
    public class WordService
    {
        private readonly HttpClient httpClient;
        private readonly ISessionStorageService sessionStorage;

        public WordService(HttpClient httpClient,ISessionStorageService sessionStorage)
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

        public async Task<WordListVm> GetAllWords(Guid langId)
        {
           await GetToken();
            return await httpClient.GetFromJsonAsync<WordListVm>($"1.0/Word/bylanguage/{langId}");
        }

        public async Task DeleteWord(Guid id)
        {
            await GetToken();
            await httpClient.DeleteAsync($"1.0/Word/{id}");
        }

        public async Task CreateWord(WordVm wordVm)
        {
            await GetToken();
            await httpClient.PostAsJsonAsync("1.0/Word", wordVm);
        }

        public async Task<WordVm> GetWordById(Guid id)
        {
            await GetToken();
            return await httpClient.GetFromJsonAsync<WordVm>($"1.0/Word/{id}");
        }
    }
}
