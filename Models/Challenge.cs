namespace helloworld.Models {
    public class Challenge {
        public string challengeId{get; set;}
        public string description{get; set;}
        public string title{get; set;}

        public Challenge(string challengeId, string title, string description) {
            this.challengeId = challengeId;
            this.title = title;
            this.description = description;
        }
    }
}