using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Common
{
    /// <summary>
    /// Restricts an action or controller to only logged in users.
    /// </summary>
    /// <seealso cref="ResultFilterAttribute" />
    public class AuthorizeAttribute : ActionFilterAttribute
    {
        private const string SessionTokenKey = "SessionToken";

        private ServersAddressesModel m_ServersAddresses;

        public AuthorizeAttribute(IOptions<ServersAddressesModel> serverAddressesOptions)
        {
            m_ServersAddresses = serverAddressesOptions.Value;
        }

        public override async Task OnActionExecutionAsync(
            ActionExecutingContext context, 
            ActionExecutionDelegate next)
        {
            base.OnActionExecuting(context);

            if (context.HttpContext.Request.Headers.TryGetValue(
                SessionTokenKey,
                out var headers))
            {
                if (!headers.Any())
                {
                    context.Result = new UnauthorizedResult();
                }

                var token = headers.First();
                using (var client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add(SessionTokenKey, token);
                    var identityServerAddress = m_ServersAddresses.IdentityServerAddress;
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
            else
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
