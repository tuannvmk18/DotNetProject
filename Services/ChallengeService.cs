using System.Net.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace helloworld.Services {
    public class ChallengeService {
        private HttpClient _httpClient;
        private ILogger<ChallengeService> _logger;
        public ChallengeService( HttpClient httpClient, ILogger<ChallengeService> logger) {
            this._httpClient = httpClient;
            this._logger = logger;
        }

        public void runCode(string value) {

        }
    }
}