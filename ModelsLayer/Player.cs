namespace ModelsLayer;
public class Player : User
{
    public string characterName {get; set;} = "";
    public List<string> items = new List<string>();

    public int hitpoints {get; set;}

    public int attack {get; set;}

    public int defense {get; set;}

}
