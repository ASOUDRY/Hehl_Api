using Microsoft.Data.SqlClient;
using ModelsLayer;

namespace RepoLayer
{
    public class MonsterRetreival
    {
        
         SqlConnection connection = new SqlConnection ($"{Secrets.connection_string}");
         public async Task<List<Monster>> FetchMonster() {
            await Task.Delay(1000);

        List<Monster> MonsterReference = new List<Monster>();
             try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"SELECT * FROM Monster", connection);       
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows)
                    {
                    while(reader.Read()) 
                        {
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
                        uniqueability = uniqueability      
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