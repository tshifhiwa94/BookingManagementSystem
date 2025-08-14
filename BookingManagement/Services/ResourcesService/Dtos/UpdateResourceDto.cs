namespace BookingManagement.Services.ResourcesService.Dtos
{
    public class UpdateResourceDto
    {
        /// <summary>
        /// 
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Type { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Capacity { get; set; }
        /// <summary>
        /// 
        /// </summary>
    }
}
