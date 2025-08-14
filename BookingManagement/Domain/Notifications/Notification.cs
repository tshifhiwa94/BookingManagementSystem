using BookingManagement.Domain.Persons;
using BookingManagement.Domain.RecordEntitys;

namespace BookingManagement.Domain.Notifications
{
    public class Notification : RecordEntity<Guid>
    {
        public virtual string Message { get; set; }
        public virtual bool IsRead { get; set; }
        public virtual Person Person { get; set; }
    }
}
