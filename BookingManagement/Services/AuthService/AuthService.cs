using AutoMapper;
using BookingManagement.Domain.Persons;
using BookingManagement.Domain.Users;
using BookingManagement.Repositories.PersonRepository;
using BookingManagement.Repositories.UserRepository;
using BookingManagement.Services.AuthService.Dtos;
using BookingManagement.Services.PersonService.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BookingManagement.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IPersonRepository _personRepo;
        private readonly IUserRepository _userRepo;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public AuthService(IPersonRepository personRepo,
            IUserRepository userRepo,
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            IMapper mapper)
        {
            _personRepo = personRepo;
            _userRepo = userRepo;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _mapper = mapper;
        }


        public async Task<TokenResponseDto> LoginAsync(LoginDto input)
        {
            var user = await _userManager.FindByNameAsync(input.Username);
            if (user == null) return null;

            var result = await _signInManager.CheckPasswordSignInAsync(user, input.Password, false);

            if (!result.Succeeded)
            {
                return null; // Or return a failed login response
            }

            return await CreateTokenResponse(user);
        }



        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PersonDto> RegisterAsync(PersonDto input)
        {


            var existingUser = await _userManager.FindByNameAsync(input.UserName);
            if (existingUser is not null) return null;


            // 1. Create User from input
            var user = _mapper.Map<User>(input);
            var createResult = await _userManager.CreateAsync(user, input.Password);
            if (!createResult.Succeeded)
            {
                // You might want to handle or return errors here
                return null;
            }

            // 2. Assign roles to the user
            var roleNames = input.RoleNames?.Select(r => r.Trim()).Where(r => !string.IsNullOrWhiteSpace(r)).ToList() ?? new List<string>() { "User" };

            foreach (var roleName in roleNames)
            {

                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    var newRole = await _roleManager.CreateAsync(new IdentityRole(roleName));
                    if (!newRole.Succeeded) continue; // or handle errors
                }

                if (!await _userManager.IsInRoleAsync(user, roleName))
                {
                    await _userManager.AddToRoleAsync(user, roleName);
                }
            }

            // 3. Create Person and link User
            var person = _mapper.Map<Person>(input);
            person.User = user; // Link the newly created user

            return _mapper.Map<PersonDto>(await _personRepo.AddAsync(person));
        }

        public async Task<TokenResponseDto> RefreshTokenAsync(RefreshTokenRequestDto requestDto)
        {
            var user = await _userRepo.ValidateRefreshTokenAsync(requestDto.UserId.ToString(), requestDto.RefreshToken);

            if (user is null)
            {
                return null; // Invalid or expired refresh token
            }

            return await CreateTokenResponse(user);
        }


        public Task<bool> ChangePasswordAsync(Guid userId, string currentPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ConfirmEmailAsync(Guid userId, string token)
        {
            throw new NotImplementedException();
        }

        public Task<PersonDto> GetCurrentUserAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<string>> GetUserRolesAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUserAuthenticatedAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUserInAnyRoleAsync(string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsUserInRoleAsync(string roleName)
        {
            throw new NotImplementedException();
        }



        public Task<bool> ResendConfirmationEmailAsync(Guid userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ResetPasswordAsync(Guid userId, string newPassword)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SendPasswordResetEmailAsync(string emailAddress)
        {
            throw new NotImplementedException();
        }

        // Private Methods
        #region
        private async Task<TokenResponseDto> CreateTokenResponse(User? user)
        {
            var accessToken = await CreateToken(user);
            var refreshToken = await GenerateRefreshTokenAsync(user);
            return new TokenResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        private async Task<string> GenerateRefreshTokenAsync(User user)
        {
            var refreshToken = GenerateRefreshToken();
            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7); // Set expiry time for the refresh token

            await _userRepo.UpdateAsync(user);
            return refreshToken;
        }

        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);

            return Convert.ToBase64String(randomNumber);
        }

        private async Task<string> CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim( ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("AppSettings:Token")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("AppSettings : Issuer"),
                audience: _configuration.GetValue<string>("AppSettings : Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }
        #endregion
    }
}
