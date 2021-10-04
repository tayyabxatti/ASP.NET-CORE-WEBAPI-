using Microsoft.IdentityModel.Tokens;
using Clv.Models.ApiModels.AuthenticateDto;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Clv.Utilities.Hashing
{
    public static class JWTToken
    {
        public static string GenerateToken(string AssociatedId,string IsCompleted, string RoleName,string Username,string UserId,string ParentID,string SecretKey)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role, RoleName),
                    new Claim(ClaimTypes.Name, Username),
                    new Claim(ClaimTypes.NameIdentifier,UserId),
                    new Claim(ClaimTypes.GroupSid,IsCompleted),
                    new Claim(ClaimTypes.SerialNumber,ParentID),
                    //new Claim(ClaimTypes.DenyOnlySid,IsCompleted)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);

        }
    }
}
