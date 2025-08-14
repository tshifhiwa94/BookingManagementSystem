using BookingManagement.Services.AddressService.Dtos;
using BookingManagement.Services.PersonService.Dtos;

namespace BookingManagement.Services.BranchService.Dtos
{
    public class BranchDto
    {
        public Guid? Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public AddressDto Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public PersonDto Manager { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PhoneNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime EstablishedDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OperatingHours { get; set; }

        /// <summary>
        /// Time zone of the branch location.
        /// </summary>
        public string Country { get; set; }

        /// <summary>
        /// Optional notes or description.
        /// </summary>
        public string Notes { get; set; }
    }
}
