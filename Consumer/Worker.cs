using Consumer.Services.RabbitMQ;

namespace Consumer;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly RabbitMqConsumerService _service;

    public Worker(ILogger<Worker> logger,RabbitMqConsumerService service)
    {
        _logger = logger;
        _service = service;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            // _logger.LogInformation("New read at: {time}", DateTimeOffset.Now);
            _service.ConsumeMessage();
            await Task.Delay(1000, stoppingToken);
        }
    }
}
