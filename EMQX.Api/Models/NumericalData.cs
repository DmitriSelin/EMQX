using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EMQX.Api.Models
{
    public sealed class NumericalData
    {
        [Required]
        [JsonPropertyName("startNum")]
        public int StartNumber { get; init; }

        [Required]
        [JsonPropertyName("getNum")]
        public int Number { get; init; }

        public NumericalData(int startNumber, int number)
        {
            StartNumber = startNumber;
            Number = number;
        }
    }
}