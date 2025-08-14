using BookingManagement.Domain.Persons;
using BookingManagement.Domain.RecordEntitys;
using BookingManagement.Domain.Services.Enums;

namespace BookingManagement.Domain.Services
{
    public class ServiceRequest : RecordEntity<Guid>
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
        public virtual DateTime EndDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual int DurationInMinutes =>
            (StartDate != default && EndDate != default && EndDate > StartDate)
                ? (int)(EndDate - StartDate).TotalMinutes
                : 0;
        /// <summary>
        /// 
        /// </summary>
        public virtual bool RequiresApproval { get; set; } = false;
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListServiceRequestStatus? Status { get; set; } = RefListServiceRequestStatus.Drafted;
        /// <summary>
        /// 
        /// </summary>
        public virtual Person ApprovedBy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Person RejectedBy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? ApprovedDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string RejectionReason { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? RejectionDate { get; set; }
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
        public virtual string CancellationReason { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? FulfillmentStartDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? FulfillmentEndDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Person FulfilledBy { get; set; }
        /// <summary>
        /// total duration in minutes between when a service started and when it was completed.
        /// </summary>
        public virtual int? FulfillmentDurationInMinutes =>
                        (FulfillmentStartDate.HasValue && FulfillmentEndDate.HasValue)
                            ? (int)(FulfillmentEndDate.Value - FulfillmentStartDate.Value).TotalMinutes
                            : null;

        /// <summary>
        /// 
        /// </summary>
        public virtual Person Requester { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Service Service { get; set; }
    }
}
