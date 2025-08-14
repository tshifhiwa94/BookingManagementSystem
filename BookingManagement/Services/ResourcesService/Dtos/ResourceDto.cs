using BookingManagement.Services.BranchService.Dtos;
using BookingManagement.Services.DepartmentsService.Dtos;

namespace BookingManagement.Services.ResourcesService.Dtos
{
    public class ResourceDto
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
        public string TypeDescription { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public long? Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string StatusDescription { get; set; } = string.Empty;
        /// <summary>
        /// 
        /// </summary>
        public bool IsAvailable { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int? Capacity { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long UsageStats { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public BranchDto Branch { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DepartmentDto? Department { get; set; }
    }

}
