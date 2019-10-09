using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MvcInAction.Filter.Filters;

namespace MvcInAction.Filter.Controllers
{
    [ActionFilter("onController")]
    public class FilterOnDifferentScopeController : ControllerBase
    {
        [HttpGet("/different-scope")]
        [ActionFilter("onAction")]
        public string FilterOnAction()
        {
            return "different-scope";
        }
    }
}