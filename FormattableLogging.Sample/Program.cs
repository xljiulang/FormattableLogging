using FormattableLogging.Sample.Server;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace FormattableLogging.Sample
{
    public class Program
    {
        static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args);
            builder.ConfigureServices(services =>
            {
                services.AddSingleton<LoggerService>();
                services.AddHostedService<LoggerHostedService>();
            });
            builder.UseSerilog((hosting, logger) =>
            {
                var template = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}]{NewLine}{SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}";
                logger.ReadFrom.Configuration(hosting.Configuration)
                    .Enrich.FromLogContext()
                    .WriteTo.Console(outputTemplate: template);
            });
            builder.Build().Run();
        }
    }
}
