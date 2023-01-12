
using Microsoft.Data.SqlClient;
using ModelsLayer;

namespace RepoLayer
{
   public class Login
    {
         public async Task<List<User>> LoginUser(User user) {
            await Task.Delay(1000);
           SqlConnection connection = new SqlConnection ($"{Secrets.connection_string}");

List<User> PassReference = new List<User>();
             try
                {
                    connection.Open();       
                     SqlCommand command = new SqlCommand($"SELECT * FROM UserRegistrar WHERE Username = '{user.name}' AND Passcode = '{user.password}';", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows)
                    {
                    while(reader.Read()) 
                        {
                          string username = (string) reader["Username"];
                          string password = (string) reader["Passcode"];
                          string id = (string) reader["ID"];

                    User response = new User {
                        id = Guid.Parse(id),
                        password = password,
                        name = username            
                    };  
                    PassReference.Add(response);
                    }
                    }
                }
                    catch(SqlException){
                    throw;
                }
                    finally{
                   connection.Close();
                }

            return PassReference;
    }
}
}