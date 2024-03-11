using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EMQX.Api.Models.Responses
{
    public sealed class PageData
    {
        [Required]
        [JsonPropertyName("listSum")]
        public int ListSum { get; init; }

        [Required]
        [JsonPropertyName("totalPages")]
        public int TotalPages { get; init; }

        public PageData(int listSum, int totalPages)
        {
            ListSum = listSum;
            TotalPages = totalPages;
        }
    }
}