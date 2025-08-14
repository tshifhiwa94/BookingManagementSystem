namespace BookingManagement.Services.ServicesService.Dtos
{
    public class UpdateServiceDto
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
        public int MaxParticipants { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long? Category { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long? DeliveryMethod { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long? Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid DepartmentId { get; set; }
    }
}
