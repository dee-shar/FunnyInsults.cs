using System;
using System.Text;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FunnyInsultsApi
{
    public class FunnyInsults
    {
        private readonly HttpClient httpClient;
        private readonly string apiUrl = "https://api.funnylabz.com/insults";
        public FunnyInsults()
        {
            httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("Dart/3.0 (dart:io)");
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<string> GetContents(
            string language = "en",
            int categoryId = 0, 
            int countryId = 0, 
            int onlyValidated = 0, 
            int orderByScore = 0)
        {
            var response = await httpClient.GetAsync($"{apiUrl}/contents/{language}?categoryid={categoryId}&countryid={countryId}&onlyvalidated={onlyValidated}&orderbyscore={orderByScore}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetCategories(string language = "en")
        {
            var response = await httpClient.GetAsync($"{apiUrl}/categories/{language}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetContentScore(int contentId)
        {
            var response = await httpClient.GetAsync($"{apiUrl}/content/score/{contentId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> ReactToContent(int contentId, int reactionId)
        {
            var response = await httpClient.PostAsync($"{apiUrl}/vote/{contentId}/{reactionId}", null);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
