using Microsoft.Data.SqlClient;
using ModelsLayer;
namespace RepoLayer
{
    public class QuestRetreival {
        SqlConnection connection = new SqlConnection ($"{Secrets.connection_string}");
        public async Task<Quest> FetchQuest(string questGiver, string location) {   
        List<Quest> QuestReference = new List<Quest>();
            try {
                    connection.Open();
                    SqlCommand command = new SqlCommand( $"Select * From InfoQuest WHERE QuestGiver = '{questGiver}' AND QuestOrigin = '{location}'", connection);       
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    if(reader.HasRows) {
                        while(reader.Read()) {
                            string questDetails = (string) reader["QuestDetails"];
                            string questConclusion = (string) reader["QuestConclusion"];
                            int reward = (int) reader["QuestReward"];
                            string identifier = (string) reader["QuestIdentifier"];

                            Quest response = new Quest {
                                Details = questDetails,
                               Conclusion = questConclusion,
                               Reward = reward,
                               Identifer = identifier
                            };  
                            QuestReference.Add(response);
                        }
                    }
            }
            catch(SqlException){
                throw;
            }
            finally{
                connection.Close();
            }
            return QuestReference[0];
        }   
    }
}