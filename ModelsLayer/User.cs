namespace ModelsLayer {
    public class User {
        public Guid id {get; set;} = Guid.NewGuid();
        public string cClass{get; set;} = "";
        public string username {get; set;} = "";
        public string password {get; set;} = "";
        public string email {get; set;} = "";
        public string character {get; set;} = "";
        public string characterclass {get; set;} = "";
        public int checkPasswordHashValue {get; set;}
    }
}