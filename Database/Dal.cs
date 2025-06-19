using System.Data;
using MySql.Data.MySqlClient;

namespace Sensory
{
    class Dal
    {
        DatabaseManagement _database;
        public Dal()
        {
            _database = new();
            _database.Connect();
        }

        public MySqlDataReader Query(string Query, Dictionary<string, object>? parametersAndValue = null)
        {
            MySqlConnection coon = _database.GetConnection();
            MySqlCommand cmd = coon.CreateCommand();

            cmd.CommandText = Query;

            if (parametersAndValue != null)
            {
                foreach (var item in parametersAndValue)
                {
                    cmd.Parameters.AddWithValue(item.Key, item.Value);
                }
            }
            try
            {
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error executing query: " + Query);
                Console.WriteLine(ex.Message);
                throw;
            }

        }
        public void Insert(User user)
        {
            string queryText = @"
            INSERT INTO users (first_name, user_name, game_stage,score,last_name)
            VALUES (@first_name, @user_name, @game_stage, @score, @last_name);";

            Dictionary<string, object> parametersAndvalue = new() {
                { "@first_name", user.Name },
                { "@user_name", user.UserName },
                { "@game_stage", user.GameStage},
                { "@score", user.Score},
                { "@last_name", user.LastName}};

            MySqlDataReader intelReports = Query(queryText, parametersAndvalue);
            intelReports.Close();
        }

        public bool UsernameCheck(string UserName)
        {
            if (GetUserByUserName(UserName) == null)
                return false;
            return true;
        }

        public User? GetUserByUserName(string UserName)
        {
            string queryText = $"SELECT * FROM users WHERE users.user_name = @UserName;";

            Dictionary<string, object> parametersAndvalue = new() { { "@UserName", UserName } };
            MySqlDataReader Reader = Query(queryText, parametersAndvalue);

            if (Reader.Read())
            {
                return new User.Builder()
                .SetName(Reader.GetString("first_name"))
                .SetLastName(Reader.GetString("last_name"))
                .SetScore(Reader.GetInt32("score"))
                .SetUserName(Reader.GetString("user_name"))
                .SetGameStage(Reader.GetInt32("game_stage"))
                .Build();
            }
            Reader.Close();
            return null;
        }

        public void Update(string UserName, int score , int GameStage)
        {
            string queryText = @"UPDATE users SET users.game_stage = @game_stage, users.score =@score WHERE users.user_name = @user_name;";

            Dictionary<string, object> parametersAndvalue = new() {
                { "@user_name", UserName },
                { "@game_stage", GameStage},
                { "@score", score}};

            MySqlDataReader Reader = Query(queryText, parametersAndvalue);
            Reader.Close();
        }

    }

}
















        // public MySqlDataReader GetAll(string tableName)
        // {
        //     string queryText = $"SELECT * FROM {tableName};";
        //     return Query(queryText);
        // }

        // public List<Person> GetAllPeople()
        // {
        //     List<Person> ListPerson = new();

        //     MySqlDataReader reader = GetAll("people");

        //     while (reader.Read())
        //     {
        //         ListPerson.Add(Create.CreatingInstancePerson(reader));
        //     }
        //     reader.Close();
        //     return ListPerson;
        // }