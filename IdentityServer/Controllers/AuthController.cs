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

        public AuthController(
            XgagDbContext dbContext,
            ICryptoService cryptoService)
        {
            CryptoService = cryptoService;
            DbContext = dbContext;
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

            return Ok(new UserModel());
        }
    }
}