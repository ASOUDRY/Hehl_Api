namespace ModelsLayer
{
    public class User
    {
   public Guid id {get; set;} = Guid.NewGuid();
    public string name {get; set;} = "";
    public string password {get; set;} = "";

    public int checkHashed {get; set;}
    }
}