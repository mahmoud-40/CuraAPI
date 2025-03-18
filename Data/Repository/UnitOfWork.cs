using Cura.Data.Interface;
using Cura.Models;

namespace Cura.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public INotificationRepository NotificationRepository { get; }
      
        public UnitOfWork(ApplicationDbContext context, INotificationRepository notificationRepository)
        {
            _context = context;
            NotificationRepository = notificationRepository;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}