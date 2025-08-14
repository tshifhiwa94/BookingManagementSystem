using BookingManagement.Domain.Persons;
using BookingManagement.Domain.RecordEntitys;
using BookingManagement.Domain.Resources.Enums;

namespace BookingManagement.Domain.Resources
{
    public class ResourceRequest : RecordEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime StartDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? EndDate { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public virtual bool RequiresApproval { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public virtual Person ApprovedBy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? ApprovedDate { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public virtual Person RejectedBy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? RejectionDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string? RejectionReason { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? CancellationDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Person CancelledBy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string? CancellationReason { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? ReturnedDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Person ReturnedBy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string? Notes { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public virtual RefListResourceRequestStatus Status { get; set; } = RefListResourceRequestStatus.NotStarted;
        /// <summary>
        /// 
        /// </summary>
        public virtual string? Purpose { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Person Requester { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Resource Resource { get; set; }
    }
}
