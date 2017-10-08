using AutoMapper;
using Common;
using DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace IdentityServer
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        public ICryptoService CryptoService { get; }
        public XgagDbContext DbContext { get; }
        public IMapper AutoMapper { get; }

        public AuthController(
            XgagDbContext dbContext,
            ICryptoService cryptoService,
            IMapper autoMapper)
        {
            CryptoService = cryptoService;
            DbContext = dbContext;
            AutoMapper = autoMapper;
        }

        [HttpPost]
        [Produces(typeof(UserModel))]
        public IActionResult Login([FromBody]LoginRequest request)
        {
            if (string.IsNullOrEmpty(request.Username))
            {
                return BadRequest();
            }

            if (string.IsNullOrEmpty(request.Password))
            {
                return BadRequest();
            }

            var user = DbContext.AspNetUsers.FirstOrDefault(
                u => u.UserName.Equals(request.Username, StringComparison.OrdinalIgnoreCase));
            if (user == null)
            {
                return NotFound();
            }

            if (!CryptoService.VerifyHashedPassword(user.PasswordHash, request.Password))
            {
                return Unauthorized();
            }

            return Ok(AutoMapper.Map<UserModel>(user));
        }
    }
}