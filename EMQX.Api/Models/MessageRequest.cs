using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EMQX.Api.Models
{
    public sealed class MessageRequest
    {
        [Required]
        [JsonPropertyName("cmd")]
        public int Command { get; init; }

        [Required]
        [JsonPropertyName("msgId")]
        public int MessageId { get; init; }

        [Required]
        [JsonPropertyName("data")]
        public NumericalData Data { get; init; }

        public MessageRequest(int command, int messageId, NumericalData data)
        {
            Command = command;
            MessageId = messageId;
            Data = data;
        }
    }
}