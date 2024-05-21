using NLog;
using Npgsql;
using WebDriverProject.Utils;

namespace WebDriverProject.Connector;

public class DbConnector
{
    private Logger _logger = LogManager.GetCurrentClassLogger();
    public NpgsqlConnection Connection { get; init; }

    public DbConnector()
    {
        var connectionString = $"Host={Configurator.ReadConfiguration().DbSettings.Db_Server};" +
                               $"Port={Configurator.ReadConfiguration().DbSettings.Db_Port};" +
                               $"Database={Configurator.ReadConfiguration().DbSettings.Db_Name};" +
                               $"User Id={Configurator.ReadConfiguration().DbSettings.Db_Username};" +
                               $"Password={Configurator.ReadConfiguration().DbSettings.Db_Password};";

        try
        {
            Connection = new NpgsqlConnection(connectionString);
            Connection.Open();
            _logger.Info("Connected to database");
        }
        catch (Exception e)
        {
            _logger.Error(e, "Failed to connect ot database");
            throw;
        }
    }

    public void CloseConnection()
    {
        Connection.Close();
    }
}