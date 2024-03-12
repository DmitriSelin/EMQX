using EMQX.Api.Extensions;
using EMQX.Api.Fabrics.Interfaces;
using EMQX.Api.Models;
using EMQX.Api.Models.Responses;
using EMQX.Api.Services.Interfaces;
using MQTTnet;
using MQTTnet.Client;
using System.Text.Json;

namespace EMQX.Api.Services
{
    public class EMQXService : IEMQXService
    {
        private readonly IMqttClientFabric _clientFabric;
        private readonly MqttFactory _factory;
        private const int successResult = 0;

        public EMQXService(IMqttClientFabric clientFabric, MqttFactory factory)
        {
            _clientFabric = clientFabric;
            _factory = factory;
        }

        public async Task<EMQXResponse> ConnectAsync(MessageRequest request)
        {
            using var client = await _clientFabric.Create(OnApplicationMessageReceivedAsync);

            if (client == null)
                throw new ArgumentNullException(nameof(client));

            MqttClientSubscribeOptions options = _factory.GetMqttClientSubOptions();
            await client.SubscribeAsync(options);

            MqttApplicationMessage appMessage = GetAppMessage(request);
            await client.PublishAsync(appMessage);
            await client.DisconnectAsync();

            EMQXResponse response = CreateResponse(request);
            return response;
        }

        private async Task OnApplicationMessageReceivedAsync(MqttApplicationMessageReceivedEventArgs arg)
        {
            Console.WriteLine($"Получено сообщение с кодом: {arg.ReasonCode}");
            string data = arg.ApplicationMessage.ConvertPayloadToString();
            await Task.CompletedTask;
        }

        private static MqttApplicationMessage GetAppMessage(MessageRequest request)
        {
            string payload = JsonSerializer.Serialize(request);
            MqttApplicationMessage appMessage = EMQXExtensions.GetMqttApplicationMessage(payload);
            return appMessage;
        }

        private static EMQXResponse CreateResponse(MessageRequest request)
        {
            var data = new PageData(request.Data.StartNumber, 1);
            var response = new EMQXResponse(data, request.Command, request.MessageId, successResult);
            return response;
        }
    }
}