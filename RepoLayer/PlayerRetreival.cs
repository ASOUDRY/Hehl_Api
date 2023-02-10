using Microsoft.Data.SqlClient;
using ModelsLayer;
namespace RepoLayer {
    public class PlayerRetreival {
        SqlConnection connection = new SqlConnection ($"{Secrets.connection_string}");
        public async Task<ApiPayload> getCharacter(string username, string userClass) {
            string userInput = username;
            string Knight = userClass;
            string lower = Knight.ToLower();
            string knightskill = lower + "skill";
            string knightPlayer = lower + "Player";       
            List<ApiPayload> WitchReference = new List<ApiPayload>();
            try {
                    connection.Open();
                    SqlCommand command = new SqlCommand($"SELECT DISTINCT playerUsername, playerCharacterName, CharacterClass, {knightskill}, attack, defense, hitpoints, SUM(hpBoost) as total_hitpoints, SUM(money) as total_money, SUM(attackBoost) as total_attack, SUM(defenseBoost) as total_defense,STUFF((SELECT ', ' + itemName FROM Inventory WHERE playerUsername = itemOwner FOR XML PATH (''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS item_names, STUFF((SELECT ', ' + itemDescription FROM Inventory WHERE playerUsername = itemOwner FOR XML PATH (''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS item_descriptions,STUFF((SELECT ', ' + CAST(quantity AS VARCHAR(10)) FROM Inventory WHERE playerUsername = itemOwner FOR XML PATH (''), TYPE ).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS quantity, STUFF((SELECT ', ' + CAST(magical AS VARCHAR(10)) FROM Inventory WHERE playerUsername = itemOwner FOR XML PATH (''), TYPE).value('.', 'NVARCHAR(MAX)'), 1, 2, '') AS magical FROM Player INNER JOIN Inventory ON playerUsername = Inventory.itemOwner INNER JOIN UserRegistrar on playerUsername = UserRegistrar.Username INNER JOIN {Knight} on {knightPlayer} = playerCharacterName WHERE playerUsername = '{userInput}' GROUP BY playerUsername, playerCharacterName, UserRegistrar.CharacterClass, {knightskill}, hitpoints, attack, defense;",connection);       
                    SqlDataReader reader = await command.ExecuteReaderAsync();
                    if(reader.HasRows) {
                        while(reader.Read()) {
                            string cName = (string) reader ["playerCharacterName"];
                            string cClass =(string) reader ["CharacterClass"]; 
                            string skill = (string) reader [$"{knightskill}"];
                            int hp = (int) reader ["hitpoints"]; 
                            int atk = (int) reader ["attack"]; 
                            int def = (int) reader ["defense"];
                            decimal ttlmon = (decimal) reader ["total_money"];
                            int ttatk = (int) reader ["total_attack"];
                            int ttdef = (int) reader ["total_defense"];
                            int ttlhit = (int) reader ["total_hitpoints"];
                            string itemN = (string) reader ["item_names"];
                            string itemD = (string) reader ["item_descriptions"];
                            string quantity = (string) reader ["quantity"];
                            string magical = (string) reader ["magical"];
                        
                            ApiPayload response = new ApiPayload {
                                username = username,
                                characterName = cName,
                                skill = skill,
                                cClass = cClass,
                                hitpoints = hp,
                                attack = atk,
                                defense = def,
                                ttlmon = ttlmon,
                                ttatk = ttatk,
                                ttdef = ttdef,
                                ttlhit = ttlhit,
                                itemN = itemN,
                                itemD = itemD,
                                quantity = quantity,
                                magical = magical
                            };  
                            WitchReference.Add(response);
                        }
                    }
            }
            catch(SqlException) {
                throw;
            }
            finally {
                connection.Close();
            }
            return WitchReference[0];
        }   
    }
}