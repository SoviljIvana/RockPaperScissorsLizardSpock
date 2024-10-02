using System.Net.Http.Headers;

namespace RPSLS.Infrastructure.Clients.CodeChallenge
{
    public class CodeChallengeApiClient : ICodeChallengeApiClient
    {
        private const string URL = "https://codechallenge.boohma.com/random";

        private readonly string urlParameters = "";

        public async Task<string> GetRandomNumber()
        {
            HttpClient client = new()
            {
                BaseAddress = new Uri(URL)
            };

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            HttpResponseMessage response = client.GetAsync(urlParameters).Result;

            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                client.Dispose();
                return await response.Content.ReadAsStringAsync();
            }

            client.Dispose();

            return "no response";

        }
    }
}
