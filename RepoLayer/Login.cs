using Microsoft.Data.SqlClient;
using ModelsLayer;
namespace RepoLayer
{
   public class Login {
    SqlConnection connection = new SqlConnection ($"{Secrets.connection_string}");
        public async Task<UserApiResponse> LoginUser(User user) { 
        List<UserApiResponse> PassReference = new List<UserApiResponse>();
            try {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"SELECT * FROM UserRegistrar WHERE Username = '{user.username}';", connection);       
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    if(reader.HasRows) {
                        while(reader.Read()) {
                            string username = (string) reader["Username"];
                            string characterClass = (string) reader["CharacterClass"];
                            string id = (string) reader["ID"];

                            UserApiResponse response = new UserApiResponse {
                                id = Guid.Parse(id),
                                username = username,
                                characterClass = characterClass       
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
            return PassReference[0];
        }
    }
}