using NLog;
using WorkflowManagement.Business.Interfaces;

namespace WorkflowManagement.Business.CustomLogger
{
    public class NLogLogger : ICustomLogger
    {
        public void LogError(string message)
        {
            var logger = LogManager.GetLogger("loggerFile");
            logger.Log(LogLevel.Error, message);
        }
    }
}
