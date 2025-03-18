using Microsoft.Extensions.Logging;

namespace Cura.Data.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        INotificationRepository NotificationRepository { get; }
        Task<int> SaveAsync();
    }
}
