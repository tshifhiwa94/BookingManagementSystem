using BookingManagement.Domain.Notifications;
using BookingManagement.Repositories.BaseRepositories;

namespace BookingManagement.Repositories.NotificationsRepository
{
    public interface INotificationRepository : IBaseRepository<Notification, Guid>
    {
    }
}
