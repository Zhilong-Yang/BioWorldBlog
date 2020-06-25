using System.Threading.Tasks;
using BioWorld.Application.Setting.Queries.GetAdvanceSetting;
using BioWorld.Application.Setting.Queries.GetContentSetting;
using BioWorld.Application.Setting.Queries.GetFeedSetting;
using BioWorld.Application.Setting.Queries.GetFriendLinksSetting;
using BioWorld.Application.Setting.Queries.GetGeneralSetting;
using BioWorld.Application.Setting.Queries.GetNotificationSetting;
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
        
    }
}
