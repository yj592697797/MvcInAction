using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcInAction.Filter.Filters
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ExceptionFilterAttribute : Attribute, IExceptionFilter, IOrderedFilter
    {
        private int _order;
        public ExceptionFilterAttribute(int order = 0)
        {
            _order = order;
        }
        public int Order => _order;

        public void OnException(ExceptionContext context)
        {
            Debug.WriteLine($"OnException order: {this.Order}");
            // context.Result = new JsonResult(new { error = new { code = 500 } });
        }
    }
}
