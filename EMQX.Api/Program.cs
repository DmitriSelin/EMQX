using EMQX.Api.Fabrics;
using EMQX.Api.Fabrics.Interfaces;
using EMQX.Api.Services;
using EMQX.Api.Services.Interfaces;
using MQTTnet;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddScoped<MqttFactory>();
    builder.Services.AddScoped<IMqttClientFabric, MqttClientFabric>();
    builder.Services.AddScoped<IEMQXService, EMQXService>();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}