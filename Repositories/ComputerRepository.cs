using LabManager.Models;
using Microsoft.Data.Sqlite;
using LabManager.Database;

namespace LabManager.Repositories;

class ComputerRepository
{

    private readonly DatabaseConfig _databaseConfig;
    public ComputerRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }
    public List<Computer> GetAll()
    {
        var computers = new List<Computer>();

        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Computers";

        var reader = command.ExecuteReader();
        while(reader.Read())
        {
            var id = reader.GetInt32(0);
            var ram = reader.GetString(1);
            var processor = reader.GetString(2);
            var computer = new Computer(id, ram, processor);
            computers.Add(computer);
        }
        connection.Close();

        return computers;
    }
}  