using Microsoft.Data.SqlClient;
using ModelsLayer;

namespace RepoLayer
{
    public class LocationRetreival
    {
         SqlConnection connection = new SqlConnection ($"{Secrets.connection_string}");
         public async Task<List<Location>> FetchLocation(string key) {
            await Task.Delay(1000);

        List<Location> LocationReference = new List<Location>();
             try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"SELECT LocationName, LocationDescription, AreaName, AreaInfo, NPCName, NPCInfo, NPCType FROM Locations INNER JOIN Area ON Locations.LocationName = Area.AreaLocation INNER JOIN NPC ON Locations.LocationName = NPC.NPCLocation WHERE Locations.LocationName = '{key}';", connection);       
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows)
                    {
                    while(reader.Read()) 
                        {
                          string LName = (string) reader["LocationName"];
                          string LDescription= (string) reader["LocationDescription"];
                          string AName = (string) reader["AreaName"];
                          string AInfo = (string) reader["AreaInfo"];
                          string NPCName = (string) reader["NPCName"];
                          string NPCInfo = (string) reader["NPCInfo"];
                          string NPCType = (string) reader["NPCType"];

                    Location response = new Location {
                       LName = LName,
                       LDescription = LDescription,
                       AName = AName,
                       AInfo = AInfo,
                       NPCName = NPCName,
                       NPCInfo = NPCInfo,
                       NPCType = NPCType

                    };  
                    LocationReference.Add(response);
                    }
                    }
                }
                    catch(SqlException){
                    throw;
                }
                    finally{
                   connection.Close();
                }

            return LocationReference;
    }   
    }
}