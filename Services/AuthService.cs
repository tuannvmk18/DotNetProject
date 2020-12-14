using Blazored.LocalStorage;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Net.Http;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using helloworld.Models;
using System;
using Newtonsoft.Json.Linq;
namespace helloworld.Services
{

    public interface IAuthenticaon
    {
        Task<User> Login(string Username, string Password);
        Task Logout();
    }

    public class AuthService : IAuthenticaon
    {
        private ILocalStorageService localStorage;
        private ILogger<AuthService> logger;
        private HttpClient httpClient;
        public AuthService(HttpClient _httpClient, ILocalStorageService _localStorage, ILogger<AuthService> _logger)
        {
            this.localStorage = _localStorage;
            this.logger = _logger;
            this.httpClient = _httpClient;
            this.logger.LogInformation("Initialized AuthService");
        }

        public async Task<User> Login(string Username, string Password)
        {
            //Create body http request
            var body = new Dictionary<string, string>();
            body.Add("Username", Username);
            body.Add("Password", Password);
            var httpcontent = new StringContent(JsonConvert.SerializeObject(body));

            //Customize header
            httpcontent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //Send request
            var responseMessage = await this.httpClient.PostAsync("user/authenticate", httpcontent);

            if (responseMessage.IsSuccessStatusCode)
            {
                //Create User Instance
                var data = await responseMessage.Content.ReadAsStringAsync();
                var UserObject = JsonConvert.DeserializeObject<User>(data);

                //Set token in localStorage
                await this.localStorage.SetItemAsync("token", JObject.Parse(data).GetValue("token").ToString());

                return await Task.FromResult<User>(UserObject);
            }
            else
            {
                //Add throw exception if error
                var message = await responseMessage.Content.ReadAsStringAsync();
                throw new Exception(message);
            }
        }

        public async Task Logout()
        {
            await this.localStorage.RemoveItemAsync("token");
        }
    }
}