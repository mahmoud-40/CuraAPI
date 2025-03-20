using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Cura.DTOs.Message;
using Swashbuckle.AspNetCore.Annotations;

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
        public async Task<IActionResult> SendMessage([FromForm] SendMessageRequest request)
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

                
                // make response 


                var response = new {success = true, response = responseContent.Trim()};

                return Ok( new { data = response });
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

        [HttpGet("send2")]
        public async Task<IActionResult> SendMessage2([FromQuery] string recipientId, [FromQuery] string text)
        {
            if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(recipientId))
                return BadRequest(new { message = "Recipient ID and message text cannot be empty" });

            try
            {
                var requestData = new Dictionary<string, string>
                {
                    { "recipientId", recipientId },
                    { "msg", text }
                };

                var formData = new FormUrlEncodedContent(requestData);

                using var aiResponse = await _httpClient.PostAsync("https://1630-197-32-24-246.ngrok-free.app/get", formData);

                aiResponse.EnsureSuccessStatusCode();

                var responseContent = await aiResponse.Content.ReadAsStringAsync();

                return Ok(new { data = new { success = true, response = responseContent.Trim() } });
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