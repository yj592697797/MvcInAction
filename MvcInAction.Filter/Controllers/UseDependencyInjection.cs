using Microsoft.AspNetCore.Mvc;
using MvcInAction.Filter.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcInAction.Filter.Controllers
{
    public class UseDependencyInjection : ControllerBase
    {
        [HttpGet("/use-type-filter")]
        [TypeFilter(typeof(LoggerFilterAttribute))]
        public string UseTypeFilter()
        {
            return "use-type-filter";
        }

        [HttpGet("/use-encapsulation-type-filter")]
        [EncapsulationTypeFilter]
        public string UseEncapsulationType()
        {
            return "use-encapsulation-type-filter";
        }

        [HttpGet("/use-service-filter")]
        [ServiceFilter(typeof(LoggerFilter2Attribute))]
        public string UseServiceFilter()
        {
            return "use-service-filter";
        }
    }
}
