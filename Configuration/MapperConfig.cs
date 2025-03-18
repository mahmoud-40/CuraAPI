using AutoMapper;
using Cura.DTOs;
using Cura.Models;

namespace Cura.Configuration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Notification, GetNotificationDTO>();
            CreateMap<SendDTO, Notification>();
        }
    }
}
