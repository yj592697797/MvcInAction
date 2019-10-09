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
    public class ActionFilterAttribute : Attribute, IActionFilter, IOrderedFilter
    {
        private int _order;
        public ActionFilterAttribute(string name, int order = 0)
        {
            this.Name = name;
            _order = order;
        }

        public string Name { get; set; }

        public int Order => _order;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine($"OnActionExecuted:{this.Name} - \torder: {this.Order}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine($"OnActionExecuting:{this.Name} - \torder: {this.Order}");
            // context.Result = new JsonResult(new { error = new { code = 500 } });
        }
    }
}
