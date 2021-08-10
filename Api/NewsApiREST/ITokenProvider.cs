using Microsoft.IdentityModel.Tokens;
using NewsApiREST.Models;
using System;

namespace NewsApiREST
{
    public interface ITokenProvider
    {
        string CreateToken(Users user, DateTime expirationDate);
        TokenValidationParameters GetValidationParameters();
    }
}