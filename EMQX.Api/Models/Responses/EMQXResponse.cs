using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EMQX.Api.Models.Responses
{
    public sealed class EMQXResponse
    {
        [Required]
        [JsonPropertyName("data")]
        public PageData Data { get; init; }

        [Required]
        [JsonPropertyName("cmd")]
        public int Command { get; init; }

        [Required]
        [JsonPropertyName("msgId")]
        public int MessageId { get; init; }

        [Required]
        [JsonPropertyName("rslt")]
        public int Result { get; init; }

        [Required]
        [JsonPropertyName("rsn")]
        public string Response { get; init; }

        public EMQXResponse(PageData data, int command, int messageId, int result, string response = "Success")
        {
            Data = data;
            Command = command;
            MessageId = messageId;
            Result = result;
            Response = response;
        }
    }
}