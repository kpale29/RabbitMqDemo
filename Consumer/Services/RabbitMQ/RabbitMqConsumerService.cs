using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer.Services.RabbitMQ;

public class RabbitMqConsumerService{
    public void ConsumeMessage(){
        ConnectionFactory factory = new() { HostName = "localhost" };
        using (var connection = factory.CreateConnection())
        using (var channel = connection.CreateModel())
        {
            channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (model,ea) =>{
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                Console.WriteLine($"✅ Mensaje: {message}");
            };

            channel.BasicConsume(queue: "hello", autoAck:true,consumer:consumer);
        }
    }
}