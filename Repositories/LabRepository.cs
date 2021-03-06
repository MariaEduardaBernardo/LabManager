using LabManager.Database;
using LabManager.Models;
using Microsoft.Data.Sqlite;
using Dapper;

namespace LabManager.Repositories;

class LabRepository
{
    private readonly DatabaseConfig _databaseConfig;

    public LabRepository(DatabaseConfig databaseConfig)
    {
        _databaseConfig = databaseConfig;
    }

    public IEnumerable<Lab> GetAll()
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);

        var labs = connection.Query<Lab>("SELECT * FROM Lab");

        return labs;
    }

    public Lab Save(Lab lab)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);

        connection.Execute("INSERT INTO Lab VALUES(@Id, @Number, @Name, @Block)", lab);

        return lab;
    }

    public Lab GetById(int id)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);
        
        var lab = connection.QuerySingle<Lab>("SELECT * FROM Lab WHERE (id = @Id)", new { Id = id });

        return lab;
    }

    public Lab Update(Lab lab)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);

        connection.Execute("UPDATE Lab SET number = @Number, name = @Name, block = @Block WHERE (id = @Id)", lab);

        return lab;
    }

    public void Delete(int id)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);

        connection.Execute("DELETE FROM Lab WHERE (id = @Id)", new { Id = id });
    }

    public bool ExistsById(int id)
    {
        using var connection = new SqliteConnection(_databaseConfig.ConnectionString);

        var result = connection.ExecuteScalar<bool>("SELECT count(id) FROM Lab WHERE (id = @Id)", new { Id = id });
        return result;
    }

    private Lab ReaderToLab(SqliteDataReader reader)
    {
        var lab = new Lab(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));

        return lab;
    }
}