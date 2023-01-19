namespace ModelsLayer
{
    public class Witch : Player
    {
        public List<string> spellcasting = new List<string>();

        public string superspell {get; set;} = "";

        public string monstertype  {get; set;} = "";
    }
}