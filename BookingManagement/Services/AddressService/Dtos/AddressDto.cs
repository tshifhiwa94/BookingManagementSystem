namespace BookingManagement.Services.AddressService.Dtos
{
    public class AddressDto
    {
        /// <summary>
        /// Unique identifier for the address
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Street { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string State { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PostalCode { get; set; }

    }
}
