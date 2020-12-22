namespace helloworld.Models {
    public class TestCase {
        string input{get; set;}
        string output{get; set;}
    }

    public class Challenge {
        public string challengeId{get; set;}
        public string description{get; set;}
        public string title{get; set;}

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