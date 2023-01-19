using Microsoft.Data.SqlClient;
using ModelsLayer;

namespace RepoLayer
{
    public class RogueRetreival
    {
         SqlConnection connection = new SqlConnection ($"{Secrets.connection_string}");
         public async Task<List<Rogue>> getCharacter() {
            await Task.Delay(1000);

        List<Rogue> WitchReference = new List<Rogue>();
             try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"SELECT * FROM UserRegistrar WHERE Username = Witch';", connection);       
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows)
                    {
                    while(reader.Read()) 
                        {
                          string username = (string) reader["Username"];
                          string password = (string) reader["Passcode"];
                          string id = (string) reader["ID"];

                    Rogue response = new Rogue {
                        id = Guid.Parse(id),
                        password = password,
                        name = username,         
                    };  
                    WitchReference.Add(response);
                    }
                    }
                }
                    catch(SqlException){
                    throw;
                }
                    finally{
                   connection.Close();
                }

            return WitchReference;
    }   
    }
}