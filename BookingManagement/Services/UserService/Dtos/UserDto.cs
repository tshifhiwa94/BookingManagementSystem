namespace BookingManagement.Services.UserService.Dtos
{
    public class UserDto
    {
        /// <summary>
        /// 
        /// </summary>
        public string Id { get; set; } = default!;
        /// <summary>
        /// 
        /// </summary>
        public string? UserName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? Email { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool EmailConfirmed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string? PhoneNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool PhoneNumberConfirmed { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool TwoFactorEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTimeOffset? LockoutEnd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool LockoutEnabled { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int AccessFailedCount { get; set; }

    }

}
