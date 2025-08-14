namespace BookingManagement.Services.DepartmentsService.Dtos
{
    public class CreateDepartmentDto
    {
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
        public bool IsActive { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string OperationHours { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid HeadOfDepartmentId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid BranchId { get; set; }
    }
}
