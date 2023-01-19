using Microsoft.Data.SqlClient;
using ModelsLayer;

namespace RepoLayer
{
    public class WitchRetreival
    {
         SqlConnection connection = new SqlConnection ($"{Secrets.connection_string}");
         public async Task<List<Witch>> getCharacter() {
            await Task.Delay(1000);

        List<Witch> WitchReference = new List<Witch>();
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

                    Witch response = new Witch {
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