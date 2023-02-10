namespace ModelsLayer {
    public class Monster : Location
    {
        public string adventure {get; set;} = "";
        public string monsterName {get; set;} = "";
        public string creatureclass {get; set;} = "";
        public int hitpoints {get; set;}
        public int attack {get; set;}
        public int defense {get; set;}
        public string uniqueability {get; set;} = ""; 
    }
}