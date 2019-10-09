using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcInAction.Filter.Filters;

namespace MvcInAction.Filter.Controllers
{
    public class SpecifiedOrderController : ControllerBase
    {
        [HttpGet("/specified-order-on-action-filter")]
        [ActionFilter("", 1), ActionFilter2("", 2), ActionFilter("", 3)]
        public string FilterOnAction()
        {
            return "specified-order-on-action-filter";
        }

        [HttpGet("/specified-order-on-exception-filter")]
        [ExceptionFilter(1), ExceptionFilter(2)]
        public string FilterOnException()
        {
            throw new Exception("test");
        }

        [HttpGet("/specified-order-on-authorization-filter")]
        [AuthorizationFilter(1), AuthorizationFilter(2)]
        public string FilterOnAuthorization()
        {
            return "specified-order-on-authorization-filter";
        }

        [HttpGet("/specified-order-on-different-filter")]
        [ActionFilter("", 1), ActionFilter2("", 2), AuthorizationFilter(3), AuthorizationFilter(4)]
        public string FilterOnDifferent()
        {
            return "specified-order-on-authorization-filter";
        }
    }
}