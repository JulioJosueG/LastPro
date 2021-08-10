using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;


using NewsApiREST.Models;
namespace NewsApiREST
{
    public class TokenProvider : ITokenProvider
    {

        private readonly string _issuer;
        private readonly string _audience;
        private readonly string _secretKey;

        private string _algorit { get; }
        private readonly SymmetricSecurityKey _signingKey;

        public TokenProvider(string issuer, string audience, string secretKey)
        {
            _issuer = issuer;
            _audience = audience;
            _secretKey = secretKey;
            _algorit = SecurityAlgorithms.HmacSha256Signature;
            _signingKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(secretKey));
        }

        public string CreateToken(Users user, DateTime expirationDate)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Username));
            claims.Add(new Claim(ClaimTypes.Name, user.Username));

            ClaimsIdentity identity = new ClaimsIdentity(claims);
            SecurityToken securityToken = tokenHandler.CreateJwtSecurityToken(new SecurityTokenDescriptor
            {
                Audience = _audience,
                Issuer = _issuer,
                SigningCredentials = new SigningCredentials(_signingKey, _algorit),
                Expires = expirationDate.ToUniversalTime(),
                Subject = identity,
            });

            return tokenHandler.WriteToken(securityToken);
        }

        public TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters
            {
                IssuerSigningKey = _signingKey,
                ValidAudience = _audience,
                ValidIssuer = _issuer,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.FromSeconds(0)
            };
        }

    }
}
