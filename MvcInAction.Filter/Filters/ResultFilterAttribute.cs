using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcInAction.Filter.Filters
{
    public class ResultFilterAttribute : Attribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            Debug.WriteLine("OnResultExecuted");
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            Debug.WriteLine("OnResultExecuting");
            // context.Result = new JsonResult(new { error = new { code = 500 } });
        }
    }
}
