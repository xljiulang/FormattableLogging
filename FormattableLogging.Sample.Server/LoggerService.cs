using Microsoft.Extensions.Logging;

namespace FormattableLogging.Sample.Server
{
    public class LoggerService
    {
        private readonly ILogger<LoggerService> logger;

        public LoggerService(ILogger<LoggerService> logger)
        {
            this.logger = logger;
        }

        public void Log()
        {
            this.logger.LogInformation($"a = {1}; b = {2}");
        }
    }
}
