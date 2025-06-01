
using Microsoft.VisualBasic;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace Classifier
{
    public class Classifier
    {
        private static readonly HttpClient client = new();

        public async Task<string> Classify(string text)
        {
            var jsonContent = @"{""contents"": [{""parts"": [{""text"": ""Explain how AI works""}]}]}";
            var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            using HttpResponseMessage response = await client.PostAsync("https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key=AIzaSyDsMgU-PM7whRK1GZnkpY9OH0YkDeHGoiI", httpContent);

            string responseBody = await response.Content.ReadAsStringAsync();
            ApiResponse apiResponse = JsonSerializer.Deserialize<ApiResponse>(responseBody);

            var responseText = apiResponse.Candidates.FirstOrDefault().Content.Parts.FirstOrDefault().Text;

            return responseText;
        }
    }
}
