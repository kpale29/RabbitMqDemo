using Producer.Core.Model;
using Producer.Core.Services.Interface.Base;
using Producer.MessageProducer.Models.Services.Request;
using Producer.MessageProducer.Models.Services.Response;

namespace Producer.MessageProducer.Services;

public class MessageProducerService : IServicePost<Message, MessageProducerResponse>
{
    private readonly IServicePost<object, RabbitMessageProducerResponse> _rabbitProducer;
    public MessageProducerService(IServicePost<object, RabbitMessageProducerResponse> rabbitProducer)
    {
        _rabbitProducer = rabbitProducer;
    }

    public async Task<MessageProducerResponse> PostAsync(Message data)
    {
        await _rabbitProducer.PostAsync(data);

        return new(){
            Response = $"Mensaje enviado, cliente: {data.Dni}"
        };
    }
}