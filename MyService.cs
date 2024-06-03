using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

public class MyService : IHostedService
{
    private readonly ILogger<MyService> _logger; // Declare a logger field

    // Constructor with ILogger<MyService> parameter for dependency injection
    public MyService(ILogger<MyService> logger)
    {
        _logger = logger; // Assign the logger instance provided by DI to the _logger field
    }

    // Method to perform some action
    public Task DoSomething()
    {
        _logger.LogInformation("KM: Doing something and logging it."); // Log an information message
        _logger.LogWarning("Warning!!!! Remember to drink coffee");
        _logger.LogCritical("Critical error. Coffee machine is broken.");
        return Task.CompletedTask;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation($"KM: Process started. Message from StartAsync()");
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation($"Stop");
        return Task.CompletedTask;
    }
}
