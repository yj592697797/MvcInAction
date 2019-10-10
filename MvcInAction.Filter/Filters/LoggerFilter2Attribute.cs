﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcInAction.Filter.Filters
{
    public class LoggerFilter2Attribute : Attribute, IResultFilter
    {
        private readonly ILogger _logger;
        public LoggerFilter2Attribute(ILoggerFactory factory)
        {
            _logger = factory.CreateLogger<LoggerFilterAttribute>();
        }
        public void OnResultExecuted(ResultExecutedContext context)
        {
            
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.LogDebug("logger filter 2");
        }
    }
}
