using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcInAction.Filter.Filters;

namespace MvcInAction.Filter.Controllers
{
    public class FilterOnSameScopeController : ControllerBase
    {
        [HttpGet("/same-scope")]
        [AuthorizationFilter, ResourceFilter, ExceptionFilter, ActionFilter(""), ResultFilter]
        public string FilterOnAction()
        {
            return "same-scope";
        }

        [HttpGet("/same-scope-exception")]
        [AuthorizationFilter, ResourceFilter, ExceptionFilter, ActionFilter(""), ResultFilter]
        public string FilterOnException()
        {
            throw new Exception("test");
        }
    }
}