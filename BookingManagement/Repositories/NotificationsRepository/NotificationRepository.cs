using BookingManagement.Data;
using BookingManagement.Domain.Notifications;
using BookingManagement.Repositories.BaseRepository;

namespace BookingManagement.Repositories.NotificationsRepository
{
    public class NotificationRepository : BaseRepository<Notification, Guid>, INotificationRepository
    {
        public NotificationRepository(BookManagementDbContext context) : base(context)
        {
        }
    }
}
