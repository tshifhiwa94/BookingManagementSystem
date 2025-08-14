using BookingManagement.Domain.Departments;
using BookingManagement.Domain.RecordEntitys;
using BookingManagement.Domain.Services.Enums;

namespace BookingManagement.Domain.Services
{
    public class Service : RecordEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual int MaxParticipants { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListServiceCategory? Category { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListDeliveryMethod? DeliveryMethod { get; set; } = RefListDeliveryMethod.OnSite;
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListServiceStatus Status { get; set; } = RefListServiceStatus.Draft;
        /// <summary>
        /// 
        /// </summary>
        public virtual Department Department { get; set; }

    }
}
