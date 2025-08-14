namespace BookingManagement.Services.AuthService.Dtos
{
    public class RefreshTokenRequestDto
    {
        /// <summary>
        /// The refresh token to be used for generating a new access token.
        /// </summary>
        public required string RefreshToken { get; set; }
        /// <summary>
        /// The username of the user requesting the refresh token.
        /// </summary>
        public Guid UserId { get; set; }
    }
}
