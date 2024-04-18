namespace WebDriverProject.Test;

public class LoggerTests : BaseTest
{
    [Test]
    public void Logger()
    {
        logger.Trace("Log Trace");
        logger.Debug("Log Debug");
        logger.Info("Log Info");
        logger.Error("Log Error");
        logger.Fatal("Log Fatal");
    }
}