using MQTTnet;
using MQTTnet.Client;

namespace EMQX.Api.Extensions
{
    public static class EMQXExtensions
    {
        private const string url = "192.168.1.63";
        private const int port = 1883;
        private const string username = "ilocks_pub";
        private const string password = "123456";
        private const string clientId = "b50687a4-5030-47a9-9422-fb2052e5cc71";
        private static string SubTopic => $"/localhost_hotel/{clientId}/dev_sub";
        private static string PubTopic => $"/localhost_hotel/{clientId}/dev_pub";

        public static async Task ConnectToServerAsync(this IMqttClient client, CancellationToken token = default)
        {
            while(!client.IsConnected)
            {
                try
                {
                    var options = client.GetMqttClientOptions();
                    await client.ConnectAsync(options, token);
                }
                catch (Exception)
                {
                    //TODO: Добавить логирование
                }
            }
        }

        public static MqttClientOptions GetMqttClientOptions(this IMqttClient client)
        {
            var mqttOptions = new MqttClientOptionsBuilder()
                .WithTcpServer(url, port)
                .WithCredentials(username, password)
                .WithClientId(clientId)
                .Build();

            return mqttOptions;
        }

        public static MqttClientSubscribeOptions GetMqttClientSubOptions(this MqttFactory factory)
        {
            var subOptions = factory.CreateSubscribeOptionsBuilder()
                .WithTopicFilter(f =>
                {
                    f.WithTopic(SubTopic);
                })
                .Build();

            return subOptions;
        }

        public static MqttApplicationMessage GetMqttApplicationMessage(string payload)
        {
            var applicationMessage = new MqttApplicationMessageBuilder()
                .WithTopic(PubTopic)
                .WithPayload(payload)
                .Build();

            return applicationMessage;
        }
    }
}