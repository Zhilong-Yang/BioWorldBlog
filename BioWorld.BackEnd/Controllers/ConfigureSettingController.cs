using System;
using System.Threading.Tasks;
using BioWorld.Application.Setting.Commands.UpdateAdvanceSetting;
using BioWorld.Application.Setting.Commands.UpdateContentSetting;
using BioWorld.Application.Setting.Commands.UpdateFeedSetting;
using BioWorld.Application.Setting.Commands.UpdateFriendLinksSetting;
using BioWorld.Application.Setting.Commands.UpdateGeneralSetting;
using BioWorld.Application.Setting.Commands.UpdateNotificationSetting;
using BioWorld.Application.Setting.Queries.GetAdvanceSetting;
using BioWorld.Application.Setting.Queries.GetContentSetting;
using BioWorld.Application.Setting.Queries.GetFeedSetting;
using BioWorld.Application.Setting.Queries.GetFriendLinksSetting;
using BioWorld.Application.Setting.Queries.GetGeneralSetting;
using BioWorld.Application.Setting.Queries.GetNotificationSetting;
using BioWorld.Application.Setting.Queries.GetWatermarkSetting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BioWorld.BackEnd.Controllers
{
    public class ConfigureSettingController : ApiController
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

        [HttpGet]
        public async Task<ActionResult<AdvanceSettingsDto>> GetAdvanceSetting()
        {
            return Ok(await Mediator.Send(new GetAdvanceSettingQuery()));
        }

        [HttpGet]
        public async Task<ActionResult<FeedSettingsDto>> GetFeedSetting()
        {
            return Ok(await Mediator.Send(new GetFeedSettingQuery()));
        }

        [HttpGet]
        public async Task<ActionResult<FriendLinksSettingsDto>> GetFriendLinksSetting()
        {
            return Ok(await Mediator.Send(new GetFriendLinksSettingQuery()));
        }

        [HttpGet]
        public async Task<ActionResult<NotificationSettingsDto>> GetNotificationSetting()
        {
            return Ok(await Mediator.Send(new GetNotificationSettingQuery()));
        }

        [HttpGet]
        public async Task<ActionResult<WatermarkSettingsDto>> GetWatermarkSetting()
        {
            return Ok(await Mediator.Send(new GetWatermarkSettingQuery()));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAdvanceSettings(Guid id, UpdateAdvanceSettingCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateContentSetting(Guid id, UpdateContentSettingCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFeedSetting(Guid id, UpdateFeedSettingCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateFriendLinksSetting(Guid id, UpdateFriendLinksSettingCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGeneralSettings(Guid id, UpdateGeneralSettingsCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);
            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateNotificationSetting(Guid id, UpdateNotificationSettingCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);
            return NoContent();
        }
    }
}