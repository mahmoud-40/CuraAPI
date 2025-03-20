using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Cura.DTOs.Message;

namespace Cura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public MessageController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Text))
                return BadRequest(new { message = "Message cannot be empty" });

            try
            {
                // Send data as FORM (not JSON)
                var formData = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("msg", request.Text)
                });

                using var aiResponse = await _httpClient.PostAsync("https://1630-197-32-24-246.ngrok-free.app/get", formData);

                aiResponse.EnsureSuccessStatusCode();

                var responseContent = await aiResponse.Content.ReadAsStringAsync();

                return Ok(new { success = true, response = responseContent.Trim() });
            }
            catch (HttpRequestException httpEx)
            {
                return StatusCode(502, new { error = "Bad Gateway", details = httpEx.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Internal Server Error", details = ex.Message });
            }
        }
    }
}