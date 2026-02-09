using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace WebApp.Api.Database;

public class DatabaseInitializer
{

    public static void ExecuteStoredProcedures(string connectionString, string scriptsFolder)
    {
        foreach (var file in Directory.GetFiles(scriptsFolder, "*.sql"))
        {
            var script = File.ReadAllText(file);
            try
            {
                using var connection = new MySqlConnection(connectionString);
                connection.Open();
                using var command = new MySqlCommand(script, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error executing {file}: {ex.Message}");
            }
        }
    }
}
