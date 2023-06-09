using Producer.Core.Model;
using Producer.Core.Services.Implementation;
using Producer.Core.Services.Interface.Base;
using Producer.MessageProducer.Models.Services.Request;
using Producer.MessageProducer.Models.Services.Response;
using Producer.MessageProducer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IServicePost<object, RabbitMessageProducerResponse>,RabbitMqMessageProducer>();
builder.Services.AddScoped<IServicePost<Message, MessageProducerResponse>, MessageProducerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
