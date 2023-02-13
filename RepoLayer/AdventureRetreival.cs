using Microsoft.Data.SqlClient;
using ModelsLayer;
namespace RepoLayer
{
    public class AdventureRetreival {
        SqlConnection connection = new SqlConnection ($"{Secrets.connection_string}");
        public async Task<Adventure> FetchAdventure(string key) {   
        List<Adventure> AdventureReference = new List<Adventure>();
            try {
                    connection.Open();
                    SqlCommand command = new SqlCommand( $"SELECT LocationName, LocationDescription, NearestLocation, adventure, monster, creatureclass, hitpoints, attack, defense, uniqueability, onArrival, inCombat, afterCombat FROM Locations INNER JOIN AdventureDescriptions ON Locations.LocationName = AdventureDescriptions.LinkedLocation INNER JOIN Monster ON AdventureDescriptions.monster = Monster.monsterName INNER JOIN Encounter on Locations.LocationName = Encounter.location WHERE Locations.LocationName = '{key}';", connection);       
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    if(reader.HasRows) {
                        while(reader.Read()) {
                            string LName = (string) reader["LocationName"];
                            string LDescription= (string) reader["LocationDescription"];
                            string Next = (string) reader["NearestLocation"];
                            string adventure = (string) reader ["adventure"];
                            string monsterName = (string) reader["monster"];
                            string creatureclass= (string) reader["creatureclass"];
                            int hitpoints = (int) reader["hitpoints"];
                            int attack = (int) reader["attack"];
                            int defense = (int) reader["defense"];
                            string uniqueability = (string) reader["uniqueability"];
                            string onArrival = (string) reader["onArrival"];  
                            string inCombat = (string) reader["inCombat"];  
                            string afterCombat = (string) reader["afterCombat"];
                    
                            Adventure response = new Adventure {
                                monsterName = monsterName,
                                creatureclass = creatureclass,
                                hitpoints = hitpoints,
                                attack = attack,
                                defense = defense,
                                uniqueability = uniqueability,
                                LName = LName,
                                LDescription= LDescription,
                                Next = Next,
                                adventure = adventure,
                                onArrival = onArrival,
                                inCombat = inCombat,
                                afterCombat = afterCombat
                            };  
                            AdventureReference.Add(response);
                        }
                    }
            }
            catch(SqlException){
                throw;
            }
            finally{
                connection.Close();
            }
            return AdventureReference[0];
        }   
    }
}