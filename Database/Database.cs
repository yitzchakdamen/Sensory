using MySql.Data.MySqlClient;

namespace Sensory
{
    public class DatabaseManagement
    {
        static string DbName = "sensory";
        static string connectionString = $"Server=Localhost;Port=3306;Database={DbName};User=root;Password='';";

        public DatabaseManagement Connect()
        {
            try
            {
                using var conn = new MySqlConnection(connectionString);
                conn.Open();
                conn.Close();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine($"Error connecting to the database: {ex.Message}");
            }

            "Connected to the Gem successfully.".Print(2);
            PrintMenu.Stop();
            return this;
        }

        public MySqlConnection GetConnection()
        {
            var conn = new MySqlConnection(connectionString);
            conn.Open();
            return conn;
        }
    }

}