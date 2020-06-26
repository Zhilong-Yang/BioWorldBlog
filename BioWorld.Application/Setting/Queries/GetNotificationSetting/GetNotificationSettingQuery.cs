using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BioWorld.Application.Common.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BioWorld.Application.Setting.Queries.GetNotificationSetting
{
    public class GetNotificationSettingQuery : IRequest<NotificationSettingsDto>
    {
        public class
            GetNotificationSettingQueryHandler : IRequestHandler<GetNotificationSettingQuery, NotificationSettingsDto>
        {
            private readonly IApplicationDbContext _context;

            public GetNotificationSettingQueryHandler(IApplicationDbContext context)
            {
                if (null != context) _context = context;
            }

            public async Task<NotificationSettingsDto> Handle(GetNotificationSettingQuery request,
                CancellationToken cancellationToken)
            {
                var entity = await _context.NotificationSettings
                    .Select(c => new NotificationSettingsDto
                    {
                        Id = c.Id,
                        AdminEmail = c.AdminEmail,
                        EmailDisplayName = c.EmailDisplayName,
                        EnableEmailSending = c.EnableEmailSending,
                        SendEmailOnCommentReply = c.SendEmailOnCommentReply,
                        SendEmailOnNewComment = c.SendEmailOnNewComment
                    })
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);
                return entity;
            }
        }
    }
}