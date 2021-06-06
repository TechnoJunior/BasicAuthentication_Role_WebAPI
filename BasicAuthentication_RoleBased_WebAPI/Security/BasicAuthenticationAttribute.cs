using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace BasicAuthentication_RoleBased_WebAPI.Security
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "No username or password supplied");
            }
            else
            {
                string authInfo = actionContext.Request.Headers.Authorization.Parameter;
                string decodeAuthInfo = Encoding.UTF8.GetString(Convert.FromBase64String(authInfo));

                string[] AuthInfoArray = decodeAuthInfo.Split(':');
                string userName = AuthInfoArray[0];
                string password = AuthInfoArray[1];

                if (UserValidate.login(userName, password))
                {
                    var userData = UserValidate.userDetails(userName, password);
                    IPrincipal principal = new GenericPrincipal(new GenericIdentity(userName), userData.U_Role.Split(','));
                    Thread.CurrentPrincipal = principal;

                    if (HttpContext.Current.User != null)
                    {
                        HttpContext.Current.User = principal;
                    }
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, "Invalid Credentials");
                }

            }
            base.OnAuthorization(actionContext);
        }
    }
}