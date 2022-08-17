using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TestApp.Filters
{
    public class AuthHeader : AuthorizeAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var id =
                context.HttpContext.Request.Headers.Where(a => a.Key == "Id");

            if (id == null)
            {
                context.Result = new ForbidResult();
            }

            return;
        }
    }
}
