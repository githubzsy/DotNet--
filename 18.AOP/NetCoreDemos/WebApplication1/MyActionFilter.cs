using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace WebApplication1
{
    public class MyActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine($"{DateTime.Now} on action exceuting");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            Console.WriteLine($"{DateTime.Now} on action exceuted");
        }
    }
}
