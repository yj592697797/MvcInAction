using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MvcInAction.Filter.Filters
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class AuthorizationFilterAttribute : Attribute, IAuthorizationFilter, IOrderedFilter
    {
        private int _order;
        public AuthorizationFilterAttribute(int order = 0)
        {
            _order = order;
        }
        public int Order => _order;

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            Debug.WriteLine($"OnAuthorization order: {this.Order}");
            // context.Result = new JsonResult(new { error = new { code = 500 } });
        }
    }
}
