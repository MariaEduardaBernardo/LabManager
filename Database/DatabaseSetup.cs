using Microsoft.Data.Sqlite;

namespace LabManager.Database;

class DatabaseSetup
{
    public DatabaseSetup()
    {
        CreateComputerTable();
        CreateLabTable();
    }
    private void CreateComputerTable()
    {
        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = @"
            CREAT TABLE IF NOY EXISTS Computers(
                id int not null primary key,
                ram varchar(100) not null,
                processor varchar(100) not null
            );
        ";

        command.ExecuteNonQuery();
        connection.Close();
    }

    private void CreateLabTable()
    {
    }
}