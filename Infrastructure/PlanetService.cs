using System;
using DTOs;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text;

namespace Infrastructure
{
    public class PlanetService: IService
    {
        private string _securityUrl = String.Empty;
        private string _planetUrl = String.Empty;
        private string _username = String.Empty;
        private string _password = String.Empty;

        public void SetUrls(string securityURL, string planetURL)
        {
            _securityUrl = securityURL;
            _planetUrl = planetURL;
        }

        public void SetCredentials(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public SecurityResponse GetToken()
        {
            var requestSecurity = new SecurityRequest();
            var responseSecurity = new SecurityResponse();

            requestSecurity.email = _username;
            requestSecurity.passphrase = _password;

            try
            {
                // Get the token for use the Integration API             
                using (HttpClient apiRequest = new HttpClient())
                {
                    apiRequest.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // No specific resource needs to be set
                    Task<HttpResponseMessage> response = apiRequest.PostAsync(_securityUrl, new StringContent(JsonConvert.SerializeObject(requestSecurity), Encoding.UTF8, "application/json"));

                    // If response is Ok, set the authorization transaction
                    if (response.Result.IsSuccessStatusCode)
                    {
                        responseSecurity = JsonConvert.DeserializeObject<SecurityResponse>(response.Result.Content.ReadAsStringAsync().Result);
                    }
                }
            }
            catch (Exception exp)
            {
                //Logger
            }

            return responseSecurity;
        }

        public IEnumerable<Planet> GetData()
        {
            var planetResponse = new List<Planet>();
            try
            {
                var securityToken = GetToken();
                // Get the token for use the Integration API             
                using (HttpClient apiRequest = new HttpClient())
                {
                    apiRequest.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    apiRequest.DefaultRequestHeaders.Add("Authorization", securityToken.dont_tell_anyone_this_token);

                    // No specific resource needs to be set
                    Task<HttpResponseMessage> response = apiRequest.GetAsync(_planetUrl);

                    // If response is Ok, set the authorization transaction
                    if (response.Result.IsSuccessStatusCode)
                    {
                        planetResponse = JsonConvert.DeserializeObject<List<Planet>>(response.Result.Content.ReadAsStringAsync().Result);
                    }
                }
            }
            catch (Exception exp)
            {
                //Logger
            }
            return planetResponse;
        }
    }
}
