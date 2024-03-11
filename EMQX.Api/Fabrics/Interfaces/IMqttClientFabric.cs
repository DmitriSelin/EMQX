using MQTTnet.Client;

namespace EMQX.Api.Fabrics.Interfaces
{
    public interface IMqttClientFabric
    {
        Task<IMqttClient> Create(Func<MqttApplicationMessageReceivedEventArgs, Task> receiveApplicationMessage);
    }
}