
using Microsoft.Data.SqlClient;
using ModelsLayer;

namespace RepoLayer
{
   public class Login
    {
         public async Task<User> LoginUser() {
            await Task.Delay(1000);
           SqlConnection connection = new SqlConnection ($"{Secrets.connection_string}");

        User v2 = new User{
            name = "Yamcha"
        };

            return v2;
    }
}
}