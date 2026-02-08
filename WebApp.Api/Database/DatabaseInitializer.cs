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
            try
            {
                var script = File.ReadAllText(file);
                using var connection = new MySqlConnection(connectionString);
                connection.Open();
                using var command = new MySqlCommand(script, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (ex.GetType() == typeof(MySqlException))
                {
                    // Ignore "PROCEDURE already exists" error
                    Console.WriteLine($"Stored procedure in {file} already exists. Skipping.");
                }
                else
                {
                    Console.WriteLine($"Error executing {file}: {ex.Message}");
                }
            }
        }
    }
}
