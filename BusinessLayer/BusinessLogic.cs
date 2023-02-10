using ModelsLayer;
namespace BusinessLayer
{
    public class BusinessLogic
    {
      public Character PayloadProcessing(ApiPayload payload) {
        Character lorem = new Character{
          username = payload.username,
          cClass = payload.cClass,
          characterName = payload.characterName,
          skill = payload.skill,
          attack = payload.attack,
          defense = payload.defense,
          ttlmon = payload.ttlmon,
          ttatk = payload.ttatk,
          ttdef = payload.ttdef,
          ttlhit = payload.ttlhit,
          hitpoints = payload.hitpoints,
          Inventory = new List<Item>()
        };

        string[] Name = payload.itemN.Split(",");
        string[] Description = payload.itemD.Split(",");
        string[] Quantity = payload.quantity.Split(",");
        string[] Magical = payload.magical.Split(",");

        int count = Name.Count();

        for (int i = 0; i < count; i++) 
              {
                 int result = Int32.Parse(Quantity[i]);
                 int boolNumber = Int32.Parse(Magical[i]);
                 bool stat = false;
                 if (boolNumber == 1) {
                  stat = true;
                 }
              Item item1 = new Item { name = Name[i], description = Description[i], quantity = result, magical = stat };
              lorem.Inventory.Add(item1);
              }
        return lorem;
      }
    }
}