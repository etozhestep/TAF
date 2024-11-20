using NLog;

namespace WebDriverProject.Core;

public class NLogConfig
{
    public void Config()
    {
        var config = new NLog.Config.LoggingConfiguration();


        //targets
        var errorLogFile = new NLog.Targets.FileTarget("errorLogfile")
        {
            FileName = "ErrorLogFile.txt",
            Layout = "${longdate} * ${level} * ${message}",
            KeepFileOpen = false
        }; 
        var infoLogFile = new NLog.Targets.FileTarget("infoLogfile")
        {
            FileName = "InfoLogFile.txt",
            Layout = "${longdate} * ${level} * ${message}",
            KeepFileOpen = false
        };

        var console = new NLog.Targets.ConsoleTarget("logconsole");


        //rules
        config.AddRule(LogLevel.Error, LogLevel.Error, errorLogFile);
        config.AddRule(LogLevel.Trace, LogLevel.Info, infoLogFile);
        config.AddRule(LogLevel.Trace, LogLevel.Fatal, console);

        //Apply config

        LogManager.Configuration = config;

    }
}