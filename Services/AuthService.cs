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
using Microsoft.AspNetCore.Components;
using System.Net;

namespace helloworld.Services
{

    public interface IAuthenticaon
    {
        Task<User> Login(string Username, string Password);
        Task Logout();

        Task Initialize();
        Task<User> getUserByToken(string token);
        Task<User> signUp(string username, string password);
    }

    public class AuthService : IAuthenticaon
    {
        private User user;
        private ILocalStorageService localStorage;
        private ILogger<AuthService> logger;
        private HttpClient httpClient;
        private NavigationManager navigationManager;
        public AuthService(HttpClient _httpClient, ILocalStorageService _localStorage, ILogger<AuthService> _logger, NavigationManager _navigationManager)
        {
            this.localStorage = _localStorage;
            this.logger = _logger; //Replace for Console
            this.httpClient = _httpClient;
            this.navigationManager = _navigationManager;

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
                this.user = UserObject;
                //Set token in localStorage
                await this.localStorage.SetItemAsync("token", JObject.Parse(data).GetValue("token").ToString());

                return await Task.FromResult<User>(UserObject);
            }
            else if (responseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("404 Not Found");
            }
            else
            {
                //Throw exception if error
                var message = await responseMessage.Content.ReadAsStringAsync();
                throw new Exception(JObject.Parse(message).GetValue("message").ToString());
            }
        }

        public async Task Logout()
        {
            await this.localStorage.RemoveItemAsync("token");
            this.user = null;
            this.navigationManager.NavigateTo("login");
        }

        public async Task Initialize()
        {
            var token = await this.localStorage.GetItemAsync<string>("token");
            if (token == null)
            {
                this.navigationManager.NavigateTo("login");
            }
            else
            {
                try
                {
                    await this.getUserByToken(token);
                    this.navigationManager.NavigateTo("/", false);
                }
                catch (Exception e)
                {
                    await this.localStorage.RemoveItemAsync("token");
                    this.navigationManager.NavigateTo("login");
                    this.logger.LogInformation(e.Message);
                }
            }
        }

        public async Task<User> getUserByToken(string token)
        {
            //Create body http request
            var body = new Dictionary<string, string>();
            body.Add("token", token);

            var httpcontent = new StringContent(JsonConvert.SerializeObject(body));

            //Customize header
            httpcontent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            this.httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token);
            //Send request
            var responseMessage = await this.httpClient.PostAsync("user/getbytoken", httpcontent);

            this.httpClient.DefaultRequestHeaders.Authorization = null;
            if (responseMessage.IsSuccessStatusCode)
            {
                //Create User Instance
                var data = await responseMessage.Content.ReadAsStringAsync();
                var UserObject = JsonConvert.DeserializeObject<User>(data);
                this.user = UserObject;

                return await Task.FromResult<User>(UserObject);
            }
            else if (responseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("404 Not Found");
            }
            else
            {
                //Throw exception if error
                var message = await responseMessage.Content.ReadAsStringAsync();
                throw new Exception(JObject.Parse(message).GetValue("message").ToString());
            }
        }

        public async Task<User> signUp(string Username, string Password)
        {
            //Create body http request
            var body = new Dictionary<string, string>();
            body.Add("Username", Username);
            body.Add("Password", Password);

            var httpcontent = new StringContent(JsonConvert.SerializeObject(body));

            //Customize header
            httpcontent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //Send request
            var responseMessage = await this.httpClient.PostAsync("user/signup", httpcontent);

            if (responseMessage.IsSuccessStatusCode)
            {
                //Create User Instance
                var data = await responseMessage.Content.ReadAsStringAsync();
                var UserObject = JsonConvert.DeserializeObject<User>(data);

                this.logger.LogInformation(data);
                this.user = UserObject;
                //Set token in localStorage
                await this.localStorage.SetItemAsync("token", JObject.Parse(data).GetValue("token").ToString());

                return await Task.FromResult<User>(UserObject);
            }
            else if (responseMessage.StatusCode == HttpStatusCode.NotFound)
            {
                throw new Exception("404 Not Found");
            }
            else
            {
                //Throw exception if error
                var message = await responseMessage.Content.ReadAsStringAsync();
                throw new Exception(JObject.Parse(message).GetValue("message").ToString());
            }
        }

        public User GetUser()
        {
            return this.user;
        }
    }
}