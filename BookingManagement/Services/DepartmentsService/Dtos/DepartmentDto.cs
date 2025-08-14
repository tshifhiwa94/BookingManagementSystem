using BookingManagement.Services.BranchService.Dtos;
using BookingManagement.Services.PersonService.Dtos;

namespace BookingManagement.Services.DepartmentsService.Dtos
{
    public class DepartmentDto
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
        public PersonDto HeadOfDepartment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public BranchDto Branch { get; set; }
    }
}
