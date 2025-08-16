namespace BookingManagement.Services.ResourcesService.Dtos
{
    public class CreateResourceRequestDto
    {
        public string Title { get; set; }

        public string? Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool? RequiresApproval { get; set; }

        public string? Purpose { get; set; }

        public Guid RequesterId { get; set; }

        public Guid ResourceId { get; set; }
    }

}
