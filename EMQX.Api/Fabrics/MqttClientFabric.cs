using EMQX.Api.Extensions;
using EMQX.Api.Fabrics.Interfaces;
using MQTTnet;
using MQTTnet.Client;

namespace EMQX.Api.Fabrics
{
    public class MqttClientFabric : IMqttClientFabric
    {
        private readonly MqttFactory _factory;

        public MqttClientFabric(MqttFactory factory)
        {
            _factory = factory;
        }

        public async Task<IMqttClient> Create(Func<MqttApplicationMessageReceivedEventArgs, Task> receiveApplicationMessage)
        {
            var client = _factory.CreateMqttClient();
            client.ApplicationMessageReceivedAsync += receiveApplicationMessage;
            await client.ConnectToServerAsync();
            return client;
        }
    }
}