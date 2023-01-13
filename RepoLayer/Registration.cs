using Microsoft.Data.SqlClient;
using ModelsLayer;

namespace RepoLayer
{
    public class Registration
    {
         public async Task<User> RegisterUser(User user) {
            
            List<string> verification = new List<string>();
            await Task.Delay(1000);
           SqlConnection connection = new SqlConnection ($"{Secrets.connection_string}");
           try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"SELECT Username FROM UserRegistrar;", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows)
                    {
                    while(reader.Read()) 
                        {
                          string check = (string) reader["Username"];

                          if (check == user.name) {
                      verification.Add(check);
                          }
                    }
                    }
                }
                    catch(SqlException){
                    throw;
                }
                    finally{
                   connection.Close();
                }

        
    
        if (verification.Count == 0) {
            
    try
        {
          
            connection.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO UserRegistrar (Id, Username, Passcode) VALUES (@Id, @Username, @Passcode)", connection);
            cmd.Parameters.AddWithValue("@Id", user.id);
            cmd.Parameters.AddWithValue("@Username", user.name);
            cmd.Parameters.AddWithValue("@Passcode", user.password);
            cmd.ExecuteNonQuery();
        }
        catch(SqlException)
        {
            throw;
        }
        finally
        {
            connection.Close();
        }
  }
  
  
  if (verification.Count == 0) {
    User Snapshot = new User {
        id = user.id,
        name = user.name,
        password = user.password,
    };
    return Snapshot;
  } 
  else {
    User Snapshot = new User {
    id = user.id,
    name = "The Username is not available",
    password = user.password,
  };
   return Snapshot;
  }   
        }       
    }
}