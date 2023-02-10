namespace ModelsLayer {
    public class Player {
        public string username {get; set;} = "";
        public string cClass{get; set;} = "";
        public string characterName {get; set;} = "";
        public string skill {get; set;} = "";
        public int hitpoints {get; set;}
        public int attack {get; set;}
        public int defense {get; set;}
        public  decimal ttlmon {get; set;}
        public  int ttatk {get; set;}
        public  int ttdef {get; set;}
        public  int ttlhit {get; set;}
    }
}