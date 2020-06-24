﻿using System.Threading.Tasks;
using BioWorld.Application.Setting.Queries.GetContentSetting;
using BioWorld.Application.Setting.Queries.GetGeneralSetting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BioWorld.BackEnd.Controllers
{
    public class ConfigureSettingController: ApiController
    {
        public ConfigureSettingController(ILogger<ControllerBase> logger) : base(logger)
        {
        }

        [HttpGet]
        public async Task<ActionResult<GetGeneralSettingsDto>> GetGeneral()
        {
            return Ok(await Mediator.Send(new GetGeneralSettingQuery()));
        }

        [HttpGet]
        public async Task<ActionResult<ContentSettingsDto>> GetContent()
        {
            return Ok(await Mediator.Send(new GetContentSettingQuery()));
        }

        
    }
}