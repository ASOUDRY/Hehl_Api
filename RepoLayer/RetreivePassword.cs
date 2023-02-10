using Microsoft.Data.SqlClient;
using ModelsLayer;
namespace RepoLayer {
    public class RetreivePassword
    {
        SqlConnection connection = new SqlConnection ($"{Secrets.connection_string}");
        public async Task<string> Retreive(User user) {
        List<string> v = new List<string>();
            try {
                connection.Open();       
                SqlCommand command = new SqlCommand($"SELECT Passcode FROM UserRegistrar WHERE Username = '{user.username}';", connection);
                SqlDataReader reader = await command.ExecuteReaderAsync();
                if(reader.HasRows) {
                    while(reader.Read()) {
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