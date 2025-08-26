/*using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SalesforceApi.Services
{
    public class SalesforceService
    {
        private readonly string _clientId = "3MVG9QJ.PEcCek9b41JjBs7vJq0Yo2PSA4dKSl80ZFTNY0QM572VNciI0.IZSk1FTOhnilcZPVsq0mSleRFa6";
    private readonly string _clientSecret = "1ED7E538A35CACD400A1C40151E14AB9E51422BFB47B9AD4C343BDA8DC178A44";
    private readonly string _username = "elvisdcosta44-gpnf@force.com";
    private readonly string _password = "Qwerty1234zujNoMkKVDKHkn5vShwNSAFv";
    private readonly string _loginUrl = "https://login.salesforce.com";

        private string _accessToken;
        private string _instanceUrl;

        // Authenticate with Salesforce
        public async Task AuthenticateAsync()
        {
            try
            {
                using var client = new HttpClient();

                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", "password"),
                    new KeyValuePair<string, string>("client_id", _clientId),
                    new KeyValuePair<string, string>("client_secret", _clientSecret),
                    new KeyValuePair<string, string>("username", _username),
                    new KeyValuePair<string, string>("password", _password)
                });

                var response = await client.PostAsync($"{_loginUrl}/services/oauth2/token", content);
                var responseString = await response.Content.ReadAsStringAsync();

                Console.WriteLine("Salesforce Auth Response: " + responseString);

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception($"Salesforce authentication failed: {response.StatusCode} {responseString}");
                }

                var json = JObject.Parse(responseString);

                _accessToken = json["access_token"]?.ToString();
                _instanceUrl = json["instance_url"]?.ToString();

                if (string.IsNullOrEmpty(_accessToken) || string.IsNullOrEmpty(_instanceUrl))
                {
                    throw new Exception("Salesforce authentication did not return access_token or instance_url.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Salesforce authentication exception: " + ex.Message);
                throw;
            }
        }

        // Run SOQL query
        public async Task<JObject> QueryAsync(string soql)
        {
            if (string.IsNullOrEmpty(_accessToken))
            {
                await AuthenticateAsync();
            }

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {_accessToken}");

            var response = await client.GetAsync($"{_instanceUrl}/services/data/v57.0/query?q={Uri.EscapeDataString(soql)}");
            var responseString = await response.Content.ReadAsStringAsync();

            Console.WriteLine("Salesforce Query Response: " + responseString);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"Salesforce query failed: {response.StatusCode} {responseString}");
            }

            return JObject.Parse(responseString);
        }
    }
}

*/
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace SalesforceApi.Services
{
    public class SalesforceService
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private string _instanceUrl;
        private string _accessToken;

        // Username-Password OAuth
        public async Task AuthenticateAsync(string username, string password, string securityToken)
        {
            var clientId = "3MVG9QJ.PEcCek9b41JjBs7vJq0Yo2PSA4dKSl80ZFTNY0QM572VNciI0.IZSk1FTOhnilcZPVsq0mSleRFa6";     
            var clientSecret = "1ED7E538A35CACD400A1C40151E14AB9E51422BFB47B9AD4C343BDA8DC178A44"; 
            var loginUrl = "https://login.salesforce.com/services/Soap/u/57.0";

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string,string>("grant_type","password"),
                new KeyValuePair<string,string>("client_id", clientId),
                new KeyValuePair<string,string>("client_secret", clientSecret),
                new KeyValuePair<string,string>("username", username),
                new KeyValuePair<string,string>("password", password + securityToken)
            });

            var response = await _httpClient.PostAsync(loginUrl, content);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var obj = JObject.Parse(json);

            _accessToken = obj["access_token"].ToString();
            _instanceUrl = obj["instance_url"].ToString();
        }

        public async Task<JArray> QueryAsync(string soql)
        {
            if (_accessToken == null) throw new Exception("Not authenticated");

            var request = new HttpRequestMessage(HttpMethod.Get, $"{_instanceUrl}/services/data/v57.0/query?q={Uri.EscapeDataString(soql)}");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _accessToken);

            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var obj = JObject.Parse(json);
            return (JArray)obj["records"];
        }
    }
}
