using Microsoft.AspNetCore.Identity;

namespace BookingManagement.Domain.Users
{
    public class User : IdentityUser
    {
        /// <summary>

        /// <summary>
        /// 
        /// </summary>
        public virtual string? RefreshToken { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? RefreshTokenExpiryTime { get; set; }
    }
}
