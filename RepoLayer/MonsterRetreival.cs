using Microsoft.Data.SqlClient;
using ModelsLayer;
namespace RepoLayer
{
    public class MonsterRetreival {
        SqlConnection connection = new SqlConnection ($"{Secrets.connection_string}");
        public async Task<List<Monster>> FetchMonster(string key) {   
        List<Monster> MonsterReference = new List<Monster>();
            try {
                    connection.Open();
                    SqlCommand command = new SqlCommand( $"SELECT * FROM Locations FULL OUTER JOIN AdventureDescriptions ON Locations.LocationName = AdventureDescriptions.LinkedLocation FULL OUTER JOIN Monster ON AdventureDescriptions.monster = Monster.monsterName WHERE Locations.LocationName = '{key}';", connection);       
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    if(reader.HasRows) {
                        while(reader.Read()) {
                            string LName = (string) reader["LocationName"];
                            string LDescription= (string) reader["LocationDescription"];
                            string Next = (string) reader["NearestLocation"];
                            string adventure = (string) reader ["adventure"];
                            string monsterName = (string) reader["monsterName"];
                            string creatureclass= (string) reader["creatureclass"];
                            int hitpoints = (int) reader["hitpoints"];
                            int attack = (int) reader["attack"];
                            int defense = (int) reader["defense"];
                            string uniqueability = (string) reader["uniqueability"];

                            Monster response = new Monster {
                                monsterName = monsterName,
                                creatureclass = creatureclass,
                                hitpoints = hitpoints,
                                attack = attack,
                                defense = defense,
                                uniqueability = uniqueability,
                                LName = LName,
                                LDescription= LDescription,
                                Next = Next,
                                adventure = adventure
                            };  
                            MonsterReference.Add(response);
                        }
                    }
            }
            catch(SqlException){
                throw;
            }
            finally{
                connection.Close();
            }
            return MonsterReference;
        }   
    }
}