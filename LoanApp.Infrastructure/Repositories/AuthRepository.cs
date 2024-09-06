using Data;
using Entities;
using LoanApp.Application.DTOs;
using LoanApp.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LoanApp.Infrastructure.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DbLoanContext _Context;
        private readonly IConfiguration _configuration;

        public AuthRepository(DbLoanContext context, IConfiguration configuration)
        {
            _Context = context;
            _configuration = configuration;
        }

        public async Task<ResponseDto> LoginAsync(LoginDto loginDto)
        {
            try
            {
                if (loginDto == null || string.IsNullOrEmpty(loginDto.Username) || string.IsNullOrEmpty(loginDto.Password)) 
                {
                    return new ResponseDto { IsSuccess = false, Message = "Invalid Username or Password." };
                }
                var user = await _Context.TblUserMasters.Where(x=>x.UserMobile == loginDto.Username && x.Password == loginDto.Password).FirstOrDefaultAsync();
                if(user==null)
                {
                    return new ResponseDto { IsSuccess = false, Message = "User not found." };
                }

                var token = GenerateJwtToken(user, user.UserRole);
                return new ResponseDto {
                    IsSuccess = true,
                    Result = token
                };

            }
            catch (Exception ex)
            {
                return new ResponseDto { IsSuccess = false, Message = $"Error Occured: {ex.Message}" };
            }
        }

        private string GenerateJwtToken(TblUserMaster userMaster, TblRoleMaster roleMaster)
        {
            if (userMaster == null && roleMaster == null)
            {
                throw new Exception("User do not exist.");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]);
            var claims = new[]
            {
                 new Claim(JwtRegisteredClaimNames.Sub, userMaster.UserId.ToString()),
                 new Claim(JwtRegisteredClaimNames.Name, userMaster.UserMobile),
                 new Claim(ClaimTypes.Role, roleMaster.RoleName),
                 new Claim(JwtRegisteredClaimNames.Email, userMaster.UserName)
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(100),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
