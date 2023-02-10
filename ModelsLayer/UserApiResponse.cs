namespace ModelsLayer {
    public class UserApiResponse {
        public Guid id {get; set;} = Guid.Empty;
        public string username {get; set;} = "";
        public string characterClass {get; set;} = "";
        public bool isAvailable {get; set;} = true;
    }
}