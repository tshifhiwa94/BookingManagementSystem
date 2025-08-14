using BookingManagement.Domain.Branches;
using BookingManagement.Domain.Persons;
using BookingManagement.Domain.RecordEntitys;

namespace BookingManagement.Domain.Departments
{
    public class Department : RecordEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual bool IsActive { get; set; } = true;
        /// <summary>
        /// 
        /// </summary>
        public virtual string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string PhoneNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string OperationHours { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Person HeadOfDepartment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Branch Branch { get; set; }
    }

}
