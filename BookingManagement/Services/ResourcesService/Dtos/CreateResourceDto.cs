namespace BookingManagement.Services.ResourcesService.Dtos
{
    public class CreateResourceDto
    {
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
        public Guid BranchId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid? DepartmentId { get; set; }
    }
}
