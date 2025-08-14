using BookingManagement.Services.DepartmentsService.Dtos;

namespace BookingManagement.Services.ServicesService.Dtos
{
    public class ServiceDto
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
        public string CategoryName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long? DeliveryMethod { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DeliveryMethodName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long? Status { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string StatusDescription { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string StatusName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DepartmentDto Department { get; set; }
    }
}
