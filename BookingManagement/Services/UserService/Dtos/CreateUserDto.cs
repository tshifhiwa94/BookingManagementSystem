namespace BookingManagement.Services.UserService.Dtos
{
    public class CreateUserDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; } = default!;
        /// <summary>
        /// 
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? Password { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PhoneNumber { get; set; }
    }

}
