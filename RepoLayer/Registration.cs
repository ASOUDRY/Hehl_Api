using Microsoft.Data.SqlClient;
using ModelsLayer;
namespace RepoLayer {
    public class Registration {
         public async Task<UserApiResponse> RegisterUser(User user) {     
            List<string> verification = new List<string>();
            SqlConnection connection = new SqlConnection ($"{Secrets.connection_string}");
            try {
                connection.Open();
                SqlCommand command = new SqlCommand($";", connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                    if(reader.HasRows) {
                        while(reader.Read()) {
                            string check = (string) reader["Username"];
                            if (check == user.username) {
                                verification.Add(check);
                            }
                        }
                    }
            }
            catch(SqlException) {
                throw;
            }
            finally{
                connection.Close();
            }
            if (verification.Count == 0) {     
                try {  
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO UserRegistrar (Id, Username, Passcode, Email, CharacterName, CharacterClass) VALUES (@Id, @Username, @Passcode, @Email, @CharacterName, @CharacterClass)", connection);
                    cmd.Parameters.AddWithValue("@Id", user.id);
                    cmd.Parameters.AddWithValue("@Username", user.username);
                    cmd.Parameters.AddWithValue("@Passcode", user.password);
                    cmd.Parameters.AddWithValue("@Email", user.email);
                    cmd.Parameters.AddWithValue("@CharacterName", user.character);
                    cmd.Parameters.AddWithValue("@CharacterClass", user.characterclass);
                    cmd.ExecuteNonQuery();
                }
                catch(SqlException){
                    throw;
                }
                finally{
                        connection.Close();
                }
            }
            if (verification.Count == 0) {
            UserApiResponse Snapshot = new UserApiResponse {
                id = user.id,
                username = user.username,
                characterClass = user.characterclass,
                isAvailable = true
            };
            return Snapshot;
            } 
            else {
                UserApiResponse Snapshot = new UserApiResponse {
                    id = user.id,
                    username = user.username,
                    characterClass = user.characterclass,
                    isAvailable = false
                };
                return Snapshot;
            }    
        }
    }
}