namespace helloworld.Models {
    public class Challenge {
        public string challengeId;
        public string description;
        public string title;

        public Challenge(string challengeId, string title, string description) {
            this.challengeId = challengeId;
            this.title = title;
            this.description = description;
        }
    }
}