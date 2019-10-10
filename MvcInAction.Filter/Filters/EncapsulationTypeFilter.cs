using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcInAction.Filter.Filters
{
    public class EncapsulationTypeFilter : TypeFilterAttribute
    {
        public EncapsulationTypeFilter()
            :base(typeof(LoggerFilter3Attribute))
        {

        }

        private class LoggerFilter3Attribute : IResultFilter
        {
            private readonly ILogger _logger;
            public LoggerFilter3Attribute(ILoggerFactory loggerFactory)
            {
                _logger = loggerFactory.CreateLogger<LoggerFilter3Attribute>();
            }
            public void OnResultExecuted(ResultExecutedContext context)
            {
                
            }

            public void OnResultExecuting(ResultExecutingContext context)
            {
                _logger.LogDebug("logger filter 3");
            }
        }
    }
}
