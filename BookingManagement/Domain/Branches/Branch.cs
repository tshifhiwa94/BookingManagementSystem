using BookingManagement.Domain.Addresses;
using BookingManagement.Domain.Persons;
using BookingManagement.Domain.RecordEntitys;

namespace BookingManagement.Domain.Branches
{
    public class Branch : RecordEntity<Guid>
    {
        /// <summary>
        /// Name of the branch.
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// Physical address of the branch.
        /// </summary>
        public virtual Address? Address { get; set; }

        /// <summary>
        /// Contact phone number.
        /// </summary>
        public virtual string? PhoneNumber { get; set; }

        /// <summary>
        /// Email address for communication.
        /// </summary>
        public virtual string? Email { get; set; }

        /// <summary>
        /// Indicates whether the branch is currently active.
        /// </summary>
        public virtual bool IsActive { get; set; }

        /// <summary>
        /// Date when the branch was established.
        /// </summary>
        public virtual DateTime EstablishedDate { get; set; }

        /// <summary>
        /// Manager assigned to the branch.
        /// </summary>
        public virtual Person? Manager { get; set; }

        /// <summary>
        /// Operating hours of the branch.
        /// </summary>
        public virtual string? OperatingHours { get; set; }

        /// <summary>
        /// Time zone of the branch location.
        /// </summary>
        public virtual string Country { get; set; }

        /// <summary>
        /// Optional notes or description.
        /// </summary>
        public virtual string? Notes { get; set; }
    }

}
