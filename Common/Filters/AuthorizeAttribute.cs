using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net;

namespace Common
{
    /// <summary>
    /// Restricts an action or controller to only logged in users.
    /// </summary>
    /// <seealso cref="ResultFilterAttribute" />
    public class AuthorizeAttribute : ActionFilterAttribute
    {
        private CommonConfigModel m_Configuration;

        public AuthorizeAttribute(IOptions<CommonConfigModel> serverAddressesOptions)
        {
            m_Configuration = serverAddressesOptions.Value;
        }

        public override async Task OnActionExecutionAsync(
            ActionExecutingContext context, 
            ActionExecutionDelegate next)
        {
            base.OnActionExecuting(context);

            if (context.HttpContext.Request.Cookies.TryGetValue(
                m_Configuration.SessionCookieKey,
                out var token))
            {
                var cookieContainer = new CookieContainer();
                using (var handler = new HttpClientHandler() { CookieContainer = cookieContainer })
                {
                    using (var client = new HttpClient(handler))
                    {
                        cookieContainer.Add(new Cookie(m_Configuration.SessionCookieKey, token));
                        var identityServerAddress = m_Configuration.IdentityServerAddress;
                        var response = await client.GetAsync($"{identityServerAddress}/api/auth");
                        if (response.IsSuccessStatusCode)
                        {
                            var result = await response.Content.ReadAsStringAsync();
                            var userData = JsonConvert.DeserializeObject<UserModel>(result);
                            context.HttpContext.Items[HttpContextKeys.UserData] = userData;
                            context.Result = (await next())?.Result;
                        }
                        else
                        {
                            context.Result = new UnauthorizedResult();
                        }
                    } 
                }
            }
            else
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
