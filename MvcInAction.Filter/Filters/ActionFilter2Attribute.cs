using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MvcInAction.Filter.Filters
{
    public class ActionFilter2Attribute : Attribute, IActionFilter, IOrderedFilter
    {
        private int _order;
        public ActionFilter2Attribute(string name, int order = 0)
        {
            this.Name = name;
            _order = order;
        }

        public string Name { get; set; }

        public int Order => _order;

        public void OnActionExecuted(ActionExecutedContext context)
        {
            Debug.WriteLine($"OnActionExecuted2:{this.Name} - \torder: {this.Order}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Debug.WriteLine($"OnActionExecuting2:{this.Name} - \torder: {this.Order}");
        }
    }
}
