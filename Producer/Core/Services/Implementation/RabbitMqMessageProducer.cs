using System.Text;
using Producer.Core.Services.Interface.Base;
using RabbitMQ.Client;
using System.Text.Json;
using Producer.Core.Model;

namespace Producer.Core.Services.Implementation;

public class RabbitMqMessageProducer : IServicePost<object, RabbitMessageProducerResponse>
{
    public async Task<RabbitMessageProducerResponse> PostAsync(object data)
    {
        ConnectionFactory factory = new()
        {
            HostName = "localhost"
        };

        using (var connection = factory.CreateConnection())

        using (var channel = connection.CreateModel())
        {
            byte[] body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(data));
            channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);
            await Task.Run(() =>
            {
             channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);
            });
        }

        return new RabbitMessageProducerResponse()
        {
            Response = true
        };
    }
}