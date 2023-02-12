using Microsoft.AspNetCore.Identity;
using RepoLayer;
using ModelsLayer;
namespace BusinessLayer;
public class ConnectingClass
{
        PlayerRetreival player = new PlayerRetreival();
        MonsterRetreival monster = new MonsterRetreival();
        LocationRetreival location = new LocationRetreival();
        Login login = new Login();
        Registration registration = new Registration();
        BusinessLogic b1 = new BusinessLogic();
        RetreivePassword r1 = new RetreivePassword();

        QuestRetreival q1 = new QuestRetreival();

        public async Task<Character> GetCharacter(string user, string password) 
        {
                ApiPayload ret = await player.getCharacter(user, password);
                Character finalProduct = b1.PayloadProcessing(ret);
                return finalProduct;
        }  
        public async Task<List<Monster>> GetMonster(string key) 
        {
                List<Monster> ret = await monster.FetchMonster(key);
                return ret;
        }

          public async Task<Quest> GetQuest(string questGiver, string location) 
        {
                Quest ret = await q1.FetchQuest(questGiver, location);
                return ret;
        }
        public async Task<List<Location>> FetchLocation(string key) 
        {
                List<Location> ret = await location.FetchLocation(key);
                return ret;
        }  
         public async Task<UserApiResponse> LoginUser(User vit) 
        {
            string retreivedHash = await r1.Retreive(vit);  
            PasswordHasher<User> v = new PasswordHasher<User>();
            vit.checkPasswordHashValue = (int)v.VerifyHashedPassword(vit, retreivedHash, vit.password);
            if (vit.checkPasswordHashValue == 1) {
                UserApiResponse ret = await login.LoginUser(vit);
                return ret;
            }
            UserApiResponse bet = new UserApiResponse();
            return bet;
        }
         public async Task<UserApiResponse> RegisterUser(User bit) 
        {
                PasswordHasher<User> v = new PasswordHasher<User>();
                bit.password = v.HashPassword(bit, bit.password);
                UserApiResponse ret = await registration.RegisterUser(bit);
                return ret;
        }
}