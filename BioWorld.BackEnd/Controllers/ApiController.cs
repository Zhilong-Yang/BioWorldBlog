﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BioWorld.BackEnd.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class ApiController : ControllerBase
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        protected ILogger<ControllerBase> Logger { get; }

        protected string UserAgent => Request.Headers["User-Agent"];

        protected ApiController(ILogger<ControllerBase> logger)
        {
            if (null != logger) Logger = logger;
        }
    }
}