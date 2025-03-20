namespace Cura.DTOs.Message
{
    public class SendMessageRequest
    {
        public string? RecipientId { get; set; }
        public string Text { get; set; } = string.Empty;
    }
}
