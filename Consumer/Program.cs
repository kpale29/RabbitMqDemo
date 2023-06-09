using Consumer;
using Consumer.Services.RabbitMQ;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<RabbitMqConsumerService>();
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
