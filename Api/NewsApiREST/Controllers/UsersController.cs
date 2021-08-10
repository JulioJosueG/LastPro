using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewsApiREST.Data;
using Microsoft.EntityFrameworkCore;
using Dapper;
using NewsApiREST.Models;
using Microsoft.AspNetCore.Authorization;

namespace NewsApiREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly  NewsProjectDBContext context;
        private readonly ITokenProvider tokenProvider;


        public UsersController(NewsProjectDBContext context, ITokenProvider tokenProvider)
        {
            this.context = context;
            this.tokenProvider = tokenProvider;
        }


    /*    [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUser(int id)
        {
            var article = await context.Users.FindAsync(id);

            if (article == null)
            {
                return NotFound();
            }

            return article;
        }*/

        [HttpPost("auth")]
        [AllowAnonymous]
        public IActionResult Authenticate([FromForm] string Username, [FromForm] string Password)
        {
            var connection = context.Database.GetDbConnection();
            var result = connection.QuerySingleOrDefault<Users>("UserValide", new { Username, Password }, commandType: System.Data.CommandType.StoredProcedure); 
        
            if(result == null)
            {
                return BadRequest("Invalid Information.");
            }

            int expirationInHour = 24;

            DateTime expiration = DateTime.UtcNow.AddHours(expirationInHour);

            var token = tokenProvider.CreateToken(result, expiration);


            return Ok(new
            {
                token = token,
                expires_in = expirationInHour * 3600    
            }); 
        
        }








    }
}
