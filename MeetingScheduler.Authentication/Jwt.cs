using MeetingScheduler.Authentication.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace MeetingScheduler.Authentication
{
    public class Jwt : IToken
    {
        public string CreateToken(string username)
        {
            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = AuthenticationConstants.JWT_ISSUER,
                Expires = DateTime.UtcNow.AddMinutes(AuthenticationConstants.JWT_EXPIRY_MIN),
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, username)
                }),
                SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(Convert.FromBase64String(AuthenticationConstants.JWT_KEY)),
                        SecurityAlgorithms.HmacSha256Signature)
            };
            var jwtHandler = new JwtSecurityTokenHandler();
            var token = jwtHandler.CreateToken(descriptor);
            return jwtHandler.WriteToken(token);
        }

        public ClaimsPrincipal VerifyToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwt = tokenHandler.ReadJwtToken(token);
            if (jwt == null)
                return null;
            var validationParam = new TokenValidationParameters()
            {
                RequireExpirationTime = true,
                ValidateIssuer = true,
                ValidateAudience = false,
                IssuerSigningKey = new SymmetricSecurityKey(Convert.FromBase64String(AuthenticationConstants.JWT_KEY))
            };
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, validationParam, out securityToken);
            return principal;
        }
    }
}
