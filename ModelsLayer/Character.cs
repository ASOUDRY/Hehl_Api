namespace ModelsLayer {
    public class Character : Player
    {
        public List<Item> Inventory {get; set;}  = new List<Item>();   
        public string quest {get; set;} = ""; 
    }
}