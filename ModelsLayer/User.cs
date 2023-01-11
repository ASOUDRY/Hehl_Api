namespace ModelsLayer
{
    public class User
    {
    public Guid Id {get; set;} = Guid.NewGuid();
    public string name {get; set;} = "";
    }
}