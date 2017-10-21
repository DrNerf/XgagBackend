using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Common;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;

namespace IdentityServer
{
    /// <summary>
    /// Authentication controller.
    /// </summary>
    /// <seealso cref="Controller" />
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private readonly ICryptoService m_CryptoService;
        private readonly XgagDbContext m_DbContext;
        private readonly IMapper m_AutoMapper;
        private readonly CommonConfigModel m_Configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        /// <param name="cryptoService">The crypto service.</param>
        /// <param name="autoMapper">The automatic mapper.</param>
        public AuthController(
            XgagDbContext dbContext,
            ICryptoService cryptoService,
            IMapper autoMapper,
            IOptions<CommonConfigModel> configuration)
        {
            m_CryptoService = cryptoService;
            m_DbContext = dbContext;
            m_AutoMapper = autoMapper;
            m_Configuration = configuration.Value;
        }

        /// <summary>
        /// Logins the specified request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The user.</returns>
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

            var user = m_DbContext.AspNetUsers.FirstOrDefault(
                u => u.UserName == request.Username);
            if (user == null)
            {
                return Unauthorized();
            }

            if (!m_CryptoService.VerifyHashedPassword(user.PasswordHash, request.Password))
            {
                return Unauthorized();
            }

            var token = Guid.NewGuid();
            user.ApiSessionToken = token;
            await m_DbContext.SaveChangesAsync();
            Response.Cookies.Append(
                m_Configuration.SessionCookieKey,
                token.ToString(),
                new CookieOptions() { HttpOnly = true });
            return Ok(m_AutoMapper.Map<UserModel>(user));
        }

        /// <summary>
        /// Verifies the token.
        /// </summary>
        /// <param name="SessionToken">The session token.</param>
        /// <returns>The user.</returns>
        [HttpGet]
        [Produces(typeof(UserModel))]
        public IActionResult VerifyToken()
        {
            if (!Request.Cookies.TryGetValue(
                m_Configuration.SessionCookieKey,
                out var sessionToken))
            {
                return Unauthorized();
            }

            if (string.IsNullOrEmpty(sessionToken))
            {
                return BadRequest();
            }

            Guid sessionTokenGuid;
            if (!Guid.TryParse(sessionToken, out sessionTokenGuid))
            {
                return BadRequest();
            }
            
            var user = m_DbContext.AspNetUsers.FirstOrDefault(u => u.ApiSessionToken == sessionTokenGuid);
            if (user == null)
            {
                return Unauthorized();
            }

            return Ok(m_AutoMapper.Map<UserModel>(user));
        }

        /// <summary>
        /// Logs out the specified session token.
        /// </summary>
        /// <param name="SessionToken">The session token.</param>
        /// <returns>OK if the operation is successful.</returns>
        [HttpDelete]
        public async Task<IActionResult> Logout()
        {
            if (!Request.Cookies.TryGetValue(
                m_Configuration.SessionCookieKey,
                out var sessionToken))
            {
                return Unauthorized();
            }

            if (string.IsNullOrEmpty(sessionToken))
            {
                return BadRequest();
            }

            Guid sessionTokenGuid;
            if (!Guid.TryParse(sessionToken, out sessionTokenGuid))
            {
                return BadRequest();
            }

            var user = m_DbContext.AspNetUsers.FirstOrDefault(u => u.ApiSessionToken == sessionTokenGuid);
            if (user == null)
            {
                return BadRequest();
            }
            else
            {
                user.ApiSessionToken = default(Guid?);
                await m_DbContext.SaveChangesAsync();
            }

            return Ok();
        }

        /// <summary>
        /// Releases all resources currently used by this <see cref="T:Microsoft.AspNetCore.Mvc.Controller" /> instance.
        /// </summary>
        /// <param name="disposing"><c>true</c> if this method is being invoked by the <see cref="M:Microsoft.AspNetCore.Mvc.Controller.Dispose" /> method,
        /// otherwise <c>false</c>.</param>
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            if (disposing)
            {
                m_DbContext.Dispose();
            }
        }
    }
}