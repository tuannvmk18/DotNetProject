using System.Net.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;
namespace helloworld.Services {

    public class Output {
        public string output;
        public string statusCode;
        public string memory;
        public string cpuTime;

        public Output(string output, string statusCode, string memory, string cpuTime) {
            this.output = output;
            this.statusCode = statusCode;
            this.memory = memory;
            this.cpuTime = cpuTime;
        }
    }
    public class Program {
        public string message;
        public string error;
        public Output data;

        public Program(string message, string error, Output data) {
            this.message = message;
            this.error = error;
            this.data = data;
        }
    }

    public class ChallengeService {
        private HttpClient _httpClient;
        private ILogger<ChallengeService> _logger;
        public ChallengeService( HttpClient httpClient, ILogger<ChallengeService> logger) {
            this._httpClient = httpClient;
            this._logger = logger;
        }

        public async Task<Program> runCode(string value) {
            var body = new Dictionary<string, string>();
            body.Add("Lang", "nodejs");
            body.Add("Index", "3");
            body.Add("Program", value);

            var httpcontent = new StringContent(JsonConvert.SerializeObject(body));

             //Customize header
            httpcontent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            //Send request
            var responseMessage = await this._httpClient.PostAsync("compiler", httpcontent);
            if(responseMessage.IsSuccessStatusCode) {
                var reponse = await responseMessage.Content.ReadAsStringAsync();
                var message = JObject.Parse(reponse).GetValue("message").ToString();
                var error = JObject.Parse(reponse).GetValue("message").ToString();

                var data = JObject.Parse(reponse).GetValue("data");
                var output = JObject.FromObject(data).GetValue("output").ToString();
                var statusCode = JObject.FromObject(data).GetValue("statusCode").ToString();
                var memory = JObject.FromObject(data).GetValue("memory").ToString();
                var cpuTime = JObject.FromObject(data).GetValue("cpuTime").ToString();

                var program = new Program(message, error, new Output(output, statusCode, memory, cpuTime));
                return await Task.FromResult<Program>(program);
            }
            return await Task.FromResult<Program>(null);

        }
    }
}