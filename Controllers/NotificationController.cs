using AutoMapper;
using Cura.Data.Interface;
using Cura.DTOs;
using Cura.DTOs.User;
using Cura.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Cura.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Notification")]
    public class NotificationController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public NotificationController(IUnitOfWork unitOfWork, IMapper mapper, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _context = context;
        }

        [HttpGet("{userId}")]
        [SwaggerOperation(Summary = "Get user notifications", Description = "Get all notifications for a user")]
        [SwaggerResponse(StatusCodes.Status200OK, "Returns the notifications", typeof(IEnumerable<GetNotificationDTO>))]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No notifications found for this user")]
        public async Task<IActionResult> GetUserNotifications(string userId, [FromQuery] bool onlyUnread = false)
        {
            var notifications = await _unitOfWork.NotificationRepository.GetUserNotifications(userId, onlyUnread);

            if (notifications == null || !notifications.Any())
            {
                return NotFound(new { Message = "No notifications found" });
            }

            return Ok(notifications);
        }

        [HttpPut("{notificationId}")]
        [SwaggerOperation(Summary = "Mark notification as read", Description = "Mark a notification as read")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Notification marked as read")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Notification not found")]
        public async Task<IActionResult> MarkAsRead(int notificationId)
        {
            var notification = await _unitOfWork.NotificationRepository.GetById(notificationId);
            if (notification == null)
                return NotFound(new { Message = "Notification not found" });

            await _unitOfWork.NotificationRepository.MarkAsRead(notificationId);
            await _unitOfWork.SaveAsync(); 

            return NoContent();
        }

        [HttpDelete("{userId}")]
        [SwaggerOperation(Summary = "Delete user notifications", Description = "Delete all notifications for a user")]
        [SwaggerResponse(StatusCodes.Status204NoContent, "Notifications deleted")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "No notifications found for this user")]
        public async Task<IActionResult> DeleteUserNotifications(string userId)
        {
            var notifications = await _unitOfWork.NotificationRepository.GetUserNotifications(userId);
            if (!notifications.Any())
                return NotFound(new { Message = "No notifications found for this user" });

            await _unitOfWork.NotificationRepository.DeleteUserNotifications(userId);
            await _unitOfWork.SaveAsync(); 

            return NoContent();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Send notification", Description = "Send a notification to a user")]
        [SwaggerResponse(StatusCodes.Status201Created, "Notification sent", typeof(Configuration.Response<string>))]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid input", typeof(Configuration.Response<string>))]
        public async Task<IActionResult> Send([FromBody] SendDTO send)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _unitOfWork.NotificationRepository.Send(send);
            if (!response.Success)
                return BadRequest(response);

            await _unitOfWork.SaveAsync();  

            return CreatedAtAction(nameof(GetUserNotifications), new { userId = send.UserId }, response);
        }

        // CreateUser for testing purposes
        [HttpPost("CreateUser")]
        [SwaggerOperation(Summary = "Create a test user", Description = "Creates a user for testing purposes.")]
        [SwaggerResponse(StatusCodes.Status200OK, "User created successfully")]
        [SwaggerResponse(StatusCodes.Status400BadRequest, "Invalid request data")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
                BirthDate = model.BirthDate
            };

            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();

            return Ok(new { Message = "User created successfully", UserId = user.Id });
        }
    }
}
