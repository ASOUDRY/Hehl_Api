namespace ModelsLayer {
    public class Adventure
    {
        public string adventure {get; set;} = "";
        public string monsterName {get; set;} = "";
        public string creatureclass {get; set;} = "";
        public int hitpoints {get; set;}
        public int attack {get; set;}
        public int defense {get; set;}
        public string uniqueability {get; set;} = ""; 
        public string LName {get; set;} = "";
        public string LDescription {get; set;} = "";
        public string Next {get; set;} = "";
        public string onArrival {get; set;} = ""; 
        public string inCombat {get; set;} = ""; 
        public string afterCombat {get; set;} = "";
    }
}