namespace BookingManagement.Services.ResourcesService.Dtos
{
    public class UpdateResourceRequestDto
    {
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


    }
}
