using CostingManagement.Core.Interfaces;
using CostingManagement.Data.DbModels.SecuritySchema;
using CostingManagement.DTO.Security.User;
using CostingManagement.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CostingManagement.Services.Security.Account
{
    public class AccountService : IAccountService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        private readonly IResponseDTO _response;
        private readonly RoleManager<ApplicationRole> _roleManager;

        public AccountService(
          IConfiguration configuration,
          UserManager<ApplicationUser> userManager,
          IPasswordHasher<ApplicationUser> passwordHasher,
          IResponseDTO responseDTO,
          RoleManager<ApplicationRole> roleManager)
        {
            _configuration = configuration;
            _userManager = userManager;
            _passwordHasher = passwordHasher;
            _response = responseDTO;
            _roleManager = roleManager;
        }
        

        public async Task<IResponseDTO> Login(LoginParamsDto loginParams)
        {
            try
            {
                var appUser = await _userManager.FindByEmailAsync(loginParams.Email);

                if (appUser == null)
                {
                    _response.Message = "Email is not found";
                    _response.IsPassed = false;
                    return _response;
                }

                if (appUser.Status == UserStatusEnum.Locked.ToString())
                {
                    _response.Message = "Your Account is locked. Please contact your administration";
                    _response.IsPassed = false;
                    return _response;
                }

                if (appUser.Status == UserStatusEnum.NotActive.ToString())
                {
                    _response.Message = "Your Account is disabled. Please contact your administration";
                    _response.IsPassed = false;
                    return _response;
                }

                if (appUser != null &&
                    _passwordHasher.VerifyHashedPassword(appUser, appUser.PasswordHash, loginParams.Password) !=
                    PasswordVerificationResult.Success)
                {
                    appUser.AccessFailedCount += 1;
                    await _userManager.UpdateAsync(appUser);

                    _response.Message = $"Invalid password";
                    _response.IsPassed = false;
                    return _response;
                }


                // in case user logged in successfully, reset AccessFailedCount
                if (appUser.AccessFailedCount > 0)
                {
                    appUser.AccessFailedCount = 0;
                    await _userManager.UpdateAsync(appUser);
                }

                var token = GenerateJSONWebToken(appUser.Id, appUser.UserName);

                _response.IsPassed = true;
                _response.Message = "You are logged in successfully.";
                _response.Data = token;
            }
            catch (Exception ex)
            {
                _response.IsPassed = false;
                _response.Message = $"Error: {ex.Message} Details: {ex.InnerException?.Message}";
                return _response;
            }

            return _response;
        }
        public string GenerateJSONWebToken(int userId, string userName)
        {
            var signingKey = Convert.FromBase64String(_configuration["Jwt:Key"]);
            var expiryDuration = int.Parse(_configuration["Jwt:ExpiryDuration"]);

            var claims = new List<Claim>
            {
                new Claim("userid", userId.ToString()),
                new Claim(ClaimTypes.NameIdentifier, userName)
            };

            var user = _userManager.FindByIdAsync(userId.ToString()).Result;
            var roles = _userManager.GetRolesAsync(user).Result;
            foreach (var item in roles)
            {
                var roleClaim = new Claim(ClaimTypes.Role, item);
                claims.Add(roleClaim);
            }

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = null,              // Not required as no third-party is involved
                Audience = null,            // Not required as no third-party is involved
                IssuedAt = DateTime.UtcNow,
                NotBefore = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddMinutes(expiryDuration),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(signingKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var token = jwtTokenHandler.WriteToken(jwtToken);
            return token;
        }
    }
}
