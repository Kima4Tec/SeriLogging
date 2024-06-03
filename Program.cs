using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
namespace SeriLogging
{
    internal class Program
    {
            public static async Task Main(string[] args)
            {
                var host = CreateHostBuilder(args).Build();

                // Resolve MyService directly from the host's service provider
                var myService = host.Services.GetRequiredService<MyService>();

                await myService.DoSomething();

                await myService.StartAsync(CancellationToken.None); // Start the service manually

                await host.RunAsync(); // Run the host           
            }

            public static IHostBuilder CreateHostBuilder(string[] args) =>
                Host.CreateDefaultBuilder(args)
                    .ConfigureServices((_, services) =>
                    {
                        // Register MyService
                        services.AddTransient<MyService>();
                        services.AddSerilog();
                        // Register other services if needed
                    }).UseSerilog((context, config) =>
                    {
                        config.WriteTo.Console().AuditTo.File("c://dev//kmlog.txt");
                    });
        }
}
