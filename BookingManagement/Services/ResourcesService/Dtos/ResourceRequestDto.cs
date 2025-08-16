using BookingManagement.Services.PersonService.Dtos;

namespace BookingManagement.Services.ResourcesService.Dtos
{
    public class ResourceRequestDto
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public string? Description { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public DateTime StartDate { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public DateTime? EndDate { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public bool RequiresApproval { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public long Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string StatusDescription { get; set; }

        public string? Purpose { get; set; }
        /// <summary>
        /// /
        /// </summary>

        public string? Notes { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public DateTime? ApprovedDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? ApprovedBy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? RejectionDate { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public string? RejectionReason { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? RejectedBy { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public DateTime? CancellationDate { get; set; }
        /// <summary>
        /// 
        /// </summary>

        public string? CancellationReason { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? CancelledBy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? ReturnedDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? ReturnedBy { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public PersonDto Requester { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ResourceDto Resource { get; set; }
    }

}
