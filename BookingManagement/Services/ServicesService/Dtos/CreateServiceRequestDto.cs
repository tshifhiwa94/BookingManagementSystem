namespace BookingManagement.Services.ServicesService.Dtos
{
    public class CreateServiceRequestDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool RequiresApproval { get; set; }

        public Guid RequesterId { get; set; }

        public Guid ServiceId { get; set; }
    }

}
