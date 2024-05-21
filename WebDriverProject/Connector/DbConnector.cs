using Npgsql;
using WebDriverProject.Utils;

namespace WebDriverProject.Connector;

public class DbConnector
{
    public NpgsqlConnection Connection { get; init; }

    public DbConnector()
    {
        var connectionString = $"Host={Configurator.ReadConfiguration().DbSettings.DB_Server};" +
                               $"Port={Configurator.ReadConfiguration().DbSettings.DB_Port};" +
                               $"Database={Configurator.ReadConfiguration().DbSettings.DB_Name};" +
                               $"User Id={Configurator.ReadConfiguration().DbSettings.DB_Username};" +
                               $"Password = {Configurator.ReadConfiguration().DbSettings.DB_Password};";

        Connection = new NpgsqlConnection(connectionString);
        Connection.Open();
    }

    public void CloseConnection()
    {
        Connection.Close();
    }
}