using BookingManagement.Domain.RecordEntitys;

namespace BookingManagement.Domain.Addresses
{
    public class Address : RecordEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual string Street { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string City { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string State { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string PostalCode { get; set; }
    }

}
