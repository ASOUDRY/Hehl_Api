using Microsoft.Data.SqlClient;
using ModelsLayer;

namespace RepoLayer
{
   public class Login
    {
    SqlConnection connection = new SqlConnection ($"{Secrets.connection_string}");
         public async Task<List<User>> LoginUser(User user) {
            await Task.Delay(1000);

        List<User> PassReference = new List<User>();
             try
                {
                    connection.Open();
                       SqlCommand command = new SqlCommand($"SELECT * FROM UserRegistrar WHERE Username = '{user.name}';", connection);       
                   //  SqlCommand command = new SqlCommand($"SELECT * FROM UserRegistrar WHERE Username = '{user.name}' AND Passcode = '{user.password}';", connection);
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
                        name = username,
                        checkHashed = user.checkHashed           
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

      public async Task<string> RetreivePassword(User user) {
        List<string> v = new List<string>();
         await Task.Delay(1000);
            try
                {
                    connection.Open();       
                     SqlCommand command = new SqlCommand($"SELECT Passcode FROM UserRegistrar WHERE Username = '{user.name}';", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows)
                    {
                    while(reader.Read()) 
                        {
                          string password = (string) reader["Passcode"];
                    v.Add(password);
                    }
                    }
                }
                    catch(SqlException){
                    throw;
                }
                    finally{
                   connection.Close();
                }
                return v[0];
      }
}
}