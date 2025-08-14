using BookingManagement.Domain.Branches;
using BookingManagement.Domain.Departments;
using BookingManagement.Domain.RecordEntitys;
using BookingManagement.Domain.Resources.Enums;

namespace BookingManagement.Domain.Resources
{
    public class Resource : RecordEntity<Guid>
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
        public virtual RefListResourceType Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsAvailable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListResourceStatus Status { get; set; } = RefListResourceStatus.Operational;
        /// <summary>
        /// 
        /// </summary>
        public virtual int? Capacity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual long UsageStats { get; set; } = 0L;
        /// <summary>
        /// 
        /// </summary>
        public virtual Branch Branch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Department? Department { get; set; }

    }
}
