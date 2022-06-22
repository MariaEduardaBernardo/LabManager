using LabManager.Models;
using Microsoft.Data.Sqlite;
using LabManager.Database;
using Dapper;

namespace LabManager.Repositories;

class ComputerRepository
{

    private readonly DatabaseConfig _databaseConfig;
    public ComputerRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }

    public IEnumerable<Computer> GetAll()
    {

        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var computers = connection.Query<Computer>("SELECT * FROM Computers");

        return computers;
    }

    public Computer Save(Computer computer)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        connection.Execute("INSERT INTO Computers VALUES(@Id, @Ram, @Processor)",computer);

        connection.Close();
        return computer;
    }

    public Computer GetById(int id)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();
        
        var Computers = connection.QuerySingle<Computer>("SELECT * FROM Computers WHERE id = @Id", new {Id = id});
        
        return Computers;
    }

    public void Delete(int id)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        connection.Execute ("DELETE FROM Computers WHERE id = @Id", new {Id = id});

;
    }

    public Computer Update(Computer computer)
    {
        var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            UPDATE Computers 
            SET ram=$ram, processor=$processor 
            WHERE (id = $id)
        ";

        command.Parameters.AddWithValue("$id", computer.Id);
        command.Parameters.AddWithValue("$ram", computer.Ram);
        command.Parameters.AddWithValue("$processor", computer.Processor);

        command.ExecuteNonQuery();
        connection.Close();

        return computer;
    }

    public bool ExistsById(int id){
        
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        connection.Open();

        var result = connection.ExecuteScalar<Boolean>("SELECT count(id) FROM Computers WHERE id=@id", new{Id = id});

        var command = connection.CreateCommand();
        command.CommandText = "SELECT count(id) FROM Computers WHERE id=$id";
        command.Parameters.AddWithValue("$id", id);

        return result;
    }

    
    private Computer ReaderToComputer(SqliteDataReader reader)
    {
        var computer = new Computer(
        reader.GetInt32(0), reader.GetString(1), reader.GetString(2)
        );

        return computer;
    }
}