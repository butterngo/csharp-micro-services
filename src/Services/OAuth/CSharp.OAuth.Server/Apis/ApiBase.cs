﻿namespace CSharp.OAuth.Server.Apis
{
    using Core.ModelBase;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("api/[controller]")]
    public class ApiBase<TController>: ControllerBase
        where TController: class
    {

        protected readonly ILogger<TController> _logger;

        public ApiBase(ILogger<TController> logger)
        {
            _logger = logger;
        }

        protected virtual ValidationDto CheckValidation<TDto>(TDto model)
        {
            return ProcessedValidation.CheckValidation(model);
        }

        public override OkObjectResult Ok([ActionResultObjectValue] object value)
        {
            return base.Ok(value);
        }
        protected OkObjectResult Success()
        {
            return Ok(new { success = true });
        }
    }
}
