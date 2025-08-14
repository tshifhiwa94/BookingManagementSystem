namespace BookingManagement.Services.AuthService.Dtos
{
    public class TokenResponseDto
    {
        /// 
        /// </summary>
        public required string AccessToken { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public required string RefreshToken { get; set; }
    }
}
