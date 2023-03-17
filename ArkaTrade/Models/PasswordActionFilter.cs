using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ArkaTrade.Models
{
    public class PasswordActionFilter : ActionFilterAttribute
    {
        private readonly string _password;

        public PasswordActionFilter(string password)
        {
            _password = password;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Query.ContainsKey("password") || context.HttpContext.Request.Query["password"] != _password)
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
