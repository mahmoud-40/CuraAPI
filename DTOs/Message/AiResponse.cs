using System.Text.Json.Serialization;

namespace Cura.DTOs.Message
{
    public class AiResponse
    {
        [JsonPropertyName("message")] // Use correct property name if different
        public string Response { get; set; } = string.Empty;
    }

}
