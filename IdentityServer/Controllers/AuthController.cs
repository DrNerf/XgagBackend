using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common;
using DAL;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Login([FromBody]LoginRequest request)
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
                u => u.UserName == request.Username);
            if (user == null)
            {
                return Unauthorized();
            }

            if (!CryptoService.VerifyHashedPassword(user.PasswordHash, request.Password))
            {
                return Unauthorized();
            }

            var token = Guid.NewGuid();
            user.ApiSessionToken = token;
            await DbContext.SaveChangesAsync();
            return Ok(AutoMapper.Map<UserModel>(user));
        }

        [HttpGet]
        [Produces(typeof(UserModel))]
        public IActionResult VerifyToken([FromHeader]string SessionToken)
        {
            if (string.IsNullOrEmpty(SessionToken))
            {
                return BadRequest();
            }

            Guid sessionTokenGuid;
            if (!Guid.TryParse(SessionToken, out sessionTokenGuid))
            {
                return BadRequest();
            }
            
            var user = DbContext.AspNetUsers.FirstOrDefault(u => u.ApiSessionToken == sessionTokenGuid);
            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(AutoMapper.Map<UserModel>(user));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                DbContext.Dispose();
            }
        }
    }
}