
using Newtonsoft.Json;
namespace helloworld.Models {
    public class TestCase {
        [JsonProperty("input")]
        public string input{get; set;}
        [JsonProperty("output")]
        public string output{get; set;}
    }

    public class Challenge {
        [JsonProperty("challengeId")]
        public string challengeId{get; set;}
        [JsonProperty("description")]
        public string description{get; set;}
        [JsonProperty("title")]
        public string title{get; set;}
        [JsonProperty("testCases")]
        public TestCase[] testCases{get; set;}

        public Challenge(string challengeId, string title, string description) {
            this.challengeId = challengeId;
            this.title = title;
            this.description = description;
        }

        public Challenge(string challengeId, string title, string description, TestCase[] testCases) {
            this.challengeId = challengeId;
            this.title = title;
            this.description = description;
            this.testCases = testCases;
        }

        public Challenge() {}
    }
}