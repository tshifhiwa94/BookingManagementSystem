namespace BookingManagement.Services.BranchService.Dtos
{
    public class CreateBranchDto
    {
        public Guid? Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid AddressId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Guid ManagerId { get; set; }
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
