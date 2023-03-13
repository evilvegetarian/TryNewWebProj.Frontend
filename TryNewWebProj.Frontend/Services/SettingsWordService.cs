using System.Net.Http.Json;
using TryNewWebProj.Frontend.Data.Models;

namespace TryNewWebProj.Frontend.Services
{
    public class SettingsWordService
    {
        private readonly HttpClient httpClient;

        public SettingsWordService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task UpdateAllSettings()
        {
            await httpClient.GetAsync("Setting/UpdateAllSett");
        }

        public async Task CompleteQuizByWordId(Sett sett)
        {
            await httpClient.PutAsJsonAsync<Sett>($"1.0/Setting", sett);
        }

        public async Task<SettingsWordVm> GetSettingsByWordId(Guid wordId)
        {
            return await httpClient.GetFromJsonAsync<SettingsWordVm>($"1.0/Setting/{wordId}");
        }
    }
}
