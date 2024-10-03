using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace RPSLS.Infrastructure.Clients.CodeChallenge
{
    public class CodeChallengeApiClient : ICodeChallengeApiClient
    {
        private const string URL = "https://codechallenge.boohma.com/random";

        private readonly string urlParameters = "";

        public async Task<int> GetRandomNumber()
        {
            HttpClient client = new()
            {
                BaseAddress = new Uri(URL)
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(urlParameters).Result;

            if (response.IsSuccessStatusCode)
            {
                var result = FindAndExtractNumberFromString(response.Content.ReadAsStringAsync().Result);

                client.Dispose();

                return result;
            }

            client.Dispose();

            return 0;
        }


        private static int FindAndExtractNumberFromString(string responseMessageContent)
        {
            var resultString = Regex.Match(responseMessageContent, @"\d+").Value;
            var result = int.Parse(resultString);

            if (result > 5)
            {
                Random random = new();
                return random.Next(1, 5);
            }
            else
            {
                return result;
            }
        }
    }
}
