using Microsoft.AspNetCore.Mvc;
using Producer.Core.Services.Interface.Base;
using Producer.MessageProducer.Models.Services.Request;
using Producer.MessageProducer.Models.Services.Response;

namespace Producer.MessageProducer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MessageProducerController : ControllerBase
{
    private readonly IServicePost<Message, MessageProducerResponse> _service;

    public MessageProducerController(IServicePost<Message, MessageProducerResponse> service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Post(Message request){

        return Ok(await _service.PostAsync(request));
    }
}
