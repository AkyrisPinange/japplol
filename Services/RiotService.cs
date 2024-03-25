using JAppInfos.Models.champion;
using System.Text.Json;

namespace JAppInfos.Services
{
    public class RiotService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RiotService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<Dictionary<string, ChampionList>> GetChampions()
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("ddragon");
                HttpResponseMessage response = await client.GetAsync("champion.json");

                 response.EnsureSuccessStatusCode();

                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement championsJson = JsonDocument.Parse(jsonString).RootElement.GetProperty("data"); 
                if (CheckJsonElement(championsJson))
                {
                   
                    throw new Exception("Failed to parse champions data"); 
                }
                return JsonSerializer.Deserialize<Dictionary<string, ChampionList>>(championsJson);
            }
            catch (HttpRequestException ex)
            {
                throw new HttpRequestException($"Failed to fetch champions: {ex.Message}");
            }
        }

        public async Task<Dictionary<string, Champion>> GetChampionByName(string name) 
        {
            HttpClient client = _httpClientFactory.CreateClient("ddragon");
            HttpResponseMessage response = await client.GetAsync($"champion/{name}.json");

            response.EnsureSuccessStatusCode();

            string jsonString = await response.Content.ReadAsStringAsync();
            JsonElement championjson = JsonDocument.Parse(jsonString).RootElement.GetProperty("data");
            if (CheckJsonElement(championjson)) 
            {
                throw new Exception("Failed to parse champion data");
            }
            return JsonSerializer.Deserialize<Dictionary<string, Champion>>(championjson);
        }

        private bool CheckJsonElement(JsonElement jsonElement) {
            return jsonElement.ValueKind == JsonValueKind.Null 
                || jsonElement.ValueKind == JsonValueKind.Undefined 
                || jsonElement.Equals("");
        }

        public async Task<Dictionary<string, List<Skin>>> GetChamptionSkins()
        {
            Dictionary<string, ChampionList> champions = await GetChampions();
            Dictionary<string, List<Skin>> championSkins = new Dictionary<string, List<Skin>>();


            foreach (var championEntry in champions)
            {
                string championName = championEntry.Key;
               // Champion champion = championEntry.Value;

                // Retrieve skins for the current champion
                List<Skin> skins = await GetChampionSkinsByName(championName);

                // Add champion skins to the dictionary
                championSkins.Add(championName, skins);
            }

            return championSkins;

        }
        private async Task<List<Skin>> GetChampionSkinsByName(string championName)
        {
            Dictionary<string, Champion> champion = await GetChampionByName(championName);
            List<Skin> skins = champion.Values.First().Skins;

            return skins;

        }
    }
}
