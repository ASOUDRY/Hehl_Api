using ModelsLayer;
namespace RepoLayer;
public class Test
{
  
    public async Task<Rogue> Return () {

        await Task.Delay(100);
        Rogue Newbie = new Rogue{
        name = "Rallidan",
        items = {"Cutpurse", "Noshame"},
        Rogueskill = "Steal"
    };
        return Newbie;
    }

}
