using GestionTareas.Api.Models;
using Serilog;
using Microsoft.Data.Sqlite;


namespace GestionTareas.Api.Infrastructure
{
    public class DbContext
    {
        public void CreateDatabase()
        {
            try
            {
                Log.Information("Start method: DbContext-CreateDatabase");

                using (var connection = new SqliteConnection("Data Source=test.db"))
                {
                    connection.Open();

                    var command = connection.CreateCommand();
                    command.CommandText = @"SELECT * FROM user";
                    
                    //command.Parameters.AddWithValue("$id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var name = reader.GetString(0);

                            Console.WriteLine($"Hello, {name}!");
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                Log.Error(ex.ToString());
            }
        }
    }
}
