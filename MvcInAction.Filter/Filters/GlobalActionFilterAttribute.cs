using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcInAction.Filter.Filters
{
    public class GlobalActionFilterAttribute : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine("OnActionExecuted: onGlobal");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine("OnActionExecuting: onGlobal");
        }
    }
}
