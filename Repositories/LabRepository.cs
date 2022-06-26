using LabManager.Database;
using LabManager.Models;
using Microsoft.Data.Sqlite;

namespace LabManager.Repositories;
class LabRepository
{
    private readonly DatabaseConfig _databaseConfig;

    public LabRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }

    public List<Lab> GetAll()
    {
        var labs = new List<Lab>();

        var connection = new SqliteConnection("Data Source=database.db");       
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Labs";
        var reader = command.ExecuteReader();
        while(reader.Read())
        {
            var id = reader.GetInt32(0);
            var number = reader.GetInt32(1);
            var name = reader.GetString(2);
            var block = reader.GetString(3);
            var lab = new Lab(id, number, name, block);
            labs.Add(lab);
        }
        connection.Close();
        return labs;
    }

    public void Save(Lab lab)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();

        command.CommandText = "INSERT INTO Lab VALUES ($id, $number, $name, $block)";
        command.Parameters.AddWithValue("$id", lab.Id);
        command.Parameters.AddWithValue("$number", lab.Number);
        command.Parameters.AddWithValue("$name", lab.Name);
        command.Parameters.AddWithValue("$block", lab.Block);

        command.ExecuteNonQuery();
        connection.Close();
    }
} 